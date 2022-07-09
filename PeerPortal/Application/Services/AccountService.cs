using Application.IServices;
using Application.Request_Model;
using Application.ResponseModel;
using Application.Settings;
using Application.Wrapper;
using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Serilog;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class AccountService : IAccountService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        private readonly IEmailService _emailService;
        private readonly IConfiguration _configuration;
        private readonly MailSettings _mailSettings;
        private readonly JWTSettings _jwtSettings;

        public AccountService(UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            IEmailService emailService,
            IConfiguration configuration,
            IOptions<MailSettings> mailSettings,
            IOptions<JWTSettings> jwtSettings)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _emailService = emailService;
            _configuration = configuration;
            _mailSettings = mailSettings.Value;
            _jwtSettings = jwtSettings.Value;
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
            await _emailService.SendAsync(_mailSettings.EmailFrom, user.Email, "Verify email", $"<p>Please confirm your email by clicking here!</p></br>{verificationUri}");
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

        public async Task<BaseResponse<UserResponseModel>> AuthenticateAsync(AuthenticationRequest request)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);
            if (user is null)
            {
                return new BaseResponse<UserResponseModel>($"No Accounts Registered with {request.Email}.");
            }
            var result = await _signInManager.PasswordSignInAsync(user.UserName, request.Password, false, lockoutOnFailure: false);
            if (!result.Succeeded)
            {
                return new BaseResponse<UserResponseModel>($"Invalid Credentials for '{request.Email}'.");
            }
            if (!user.EmailConfirmed)
            {
                return new BaseResponse<UserResponseModel>($"Account Not Confirmed for '{request.Email}'.");

            }
            JwtSecurityToken jwtSecurityToken = await GenerateJWToken(user);
            UserResponseModel response = new UserResponseModel();
            response.Id = user.Id;
            response.JWToken = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
            response.Email = user.Email;
            response.UserName = user.UserName;
            var rolesList = await _userManager.GetRolesAsync(user).ConfigureAwait(false);
            response.IsVerified = user.EmailConfirmed;
            return new BaseResponse<UserResponseModel>(true,response, $"Authenticated {user.UserName}");
        }
        private async Task<JwtSecurityToken> GenerateJWToken(ApplicationUser user)
        {
            var userClaims = await _userManager.GetClaimsAsync(user);
            var roles = await _userManager.GetRolesAsync(user);

            var roleClaims = new List<Claim>();

            for (int i = 0; i < roles.Count; i++)
            {
                roleClaims.Add(new Claim("roles", roles[i]));
            }


            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim("uid", user.Id)
            }
            .Union(userClaims)
            .Union(roleClaims);

            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Key));
            var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

            var jwtSecurityToken = new JwtSecurityToken(
                issuer: _jwtSettings.Issuer,
                audience: _jwtSettings.Audience,
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(_jwtSettings.DurationInMinutes),
                signingCredentials: signingCredentials);
            return jwtSecurityToken;
        }
    }
}
