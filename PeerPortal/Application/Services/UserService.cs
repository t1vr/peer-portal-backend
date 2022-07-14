using Application.IServices;
using Application.Request_Model;
using Application.ResponseModel;
using Application.Wrapper;
using Domain.Entities;
using Domain.IRepositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Configuration;
using Serilog;
using System.Text;


namespace Application.Services
{
    public class UserService:IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IConfiguration _configuration;
        private readonly IEmailService _emailService;

        public UserService(IUnitOfWork unitOfWork, UserManager<ApplicationUser> userManager,IConfiguration configuration,IEmailService emailService)
        {
            _unitOfWork = unitOfWork;
            _userManager = userManager;
            _emailService = emailService;
            _configuration = configuration;
        }


        public async Task<BaseResponse<UserRegistrationResponseModel>> RegisterUserAsync(RegisterRequest request)
        {
            var userResponse = new UserRegistrationResponseModel(request.FirstName, request.LastName, request.UserName, request.Email);
            var userWithSameUserName = await _userManager.FindByNameAsync(request.UserName);
            if(userWithSameUserName is not null)
            {
                Log.Information($"Username {request.UserName} is already taken.");
                return new BaseResponse<UserRegistrationResponseModel>(false, userResponse, $"Username {request.UserName} is already taken.");
            }
            var userWithSameEmail = await _userManager.FindByEmailAsync(request.Email);

            var user = new ApplicationUser
            {
                Email = request.Email,
                FirstName = request.FirstName,
                LastName = request.LastName,
                UserName = request.UserName
            };

            if (userWithSameEmail is null)
            {
                var result = await _userManager.CreateAsync(user, request.Password);
                if (result.Succeeded)
                {
                    var verificationUri = await SendVerificationEmail(user);
                    return new BaseResponse<UserRegistrationResponseModel>(true, userResponse, $"Successfully created user.");
                }

            }
            return new BaseResponse<UserRegistrationResponseModel>(false, userResponse, $"Something went wrong.");

        }

        private async Task<string> SendVerificationEmail(ApplicationUser user)
        {
            string origin = _configuration.GetSection("AppUrl").Get<string>();
            var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
            var route = "api/account/confirm-email/";
            var _enpointUri = new Uri(string.Concat($"{origin}/", route));
            var verificationUri = QueryHelpers.AddQueryString(_enpointUri.ToString(), "userId", user.Id);
            verificationUri = QueryHelpers.AddQueryString(verificationUri, "code", code);
            //Email Service Call Here
            await  _emailService.SendAsync("clair.dietrich93@ethereal.email", user.Email, "Verify email", $"<p>Please confirm your email by clicking here!</p>");
            return verificationUri;

        }
    }
}
