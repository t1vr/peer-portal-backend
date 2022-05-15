using Application.IServices;
using Application.Request_Model;
using Application.ResponseModel;
using Application.Wrapper;
using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Configuration;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class AccountService : IAccountService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IEmailService _emailService;
        private readonly IConfiguration _configuration;
        public AccountService(UserManager<ApplicationUser> userManager,
            IEmailService emailService,
            IConfiguration configuration)
        {
            _userManager = userManager;
            this._emailService = emailService;
            _configuration = configuration;
        }



        public async Task<BaseResponse<UserRegistrationResponseModel>> RegisterUserAsync(RegisterRequest request)
        {
            var userResponse = new UserRegistrationResponseModel(request.FirstName, request.LastName, request.UserName, request.Email);
            var userWithSameUserName = await _userManager.FindByNameAsync(request.UserName);
            if (userWithSameUserName is not null)
            {
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
                    return new BaseResponse<UserRegistrationResponseModel>(true, userResponse, $"Successfully created user.{verificationUri}");
                }

            }
            return new BaseResponse<UserRegistrationResponseModel>(false, userResponse, $"Something went wrong.");

        }

        private async Task<string> SendVerificationEmail(ApplicationUser user)
        {
            string origin = _configuration.GetSection("AppUrl").Get<string>();
            var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            token = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(token));
            var route = "api/account/verify-email/";
            var _enpointUri = new Uri(string.Concat($"{origin}/", route));
            var verificationUri = QueryHelpers.AddQueryString(_enpointUri.ToString(), "userId", user.Id);
            verificationUri = QueryHelpers.AddQueryString(verificationUri, "token", token);
            //Email Service Call Here
            await _emailService.SendAsync("clair.dietrich93@ethereal.email", user.Email, "Verify email", $"<p>Please confirm your email by clicking here!</p></br>{verificationUri}");
            return verificationUri;

        }


        public async Task<BaseResponse<string>> ConfirmEmailAsync(string userId, string token)
        {
            token = Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(token));
            try
            {
                var user = await _userManager.FindByIdAsync(userId);
                var result = await _userManager.ConfirmEmailAsync(user, token);
                if (result.Succeeded)
                {
                    return new BaseResponse<string>(true, null, $"Account Confirmed for {user.Email}");
                }
                else
                {
                    return new BaseResponse<string>($"An error occured while confirming {user.Email}.");
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return new BaseResponse<string>($"An error occured while confirming user email.");
            }
        }

    }
}
