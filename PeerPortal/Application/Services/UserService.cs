using Application.IRepositories;
using Application.IServices;
using Application.Request;
using Application.Wrapper;
using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class UserService:IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<ApplicationUser> _userManager;
        public UserService(IUnitOfWork unitOfWork, UserManager<ApplicationUser> userManager)
        {
            _unitOfWork = unitOfWork;
            _userManager = userManager;
        }

        public async Task<BaseResponse<string>> RegisterUserAsync(RegisterRequest request)
        {
            var userWithSameUserName = await _userManager.FindByNameAsync(request.UserName);
            if(userWithSameUserName is not null)
            {
                Log.Information($"Username {request.UserName} is already taken.");
                return new BaseResponse<string>($"Username {request.UserName} is already taken.");
            }
            var user = new ApplicationUser
            {
                Email = request.Email,
                FirstName = request.FirstName,
                LastName = request.LastName,
                UserName = request.UserName
            };
            var userWithSameEmail = await _userManager.FindByEmailAsync(request.Email);
            if(userWithSameEmail is null)
            {
                var result = await _userManager.CreateAsync(user, request.Password);
                if (result.Succeeded)
                {
                    var verificationUri = await SendVerificationEmail(user, origin);
                }
            }
        }

        private async Task<string> SendVerificationEmail(ApplicationUser user, string origin)
        {
            var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
            var route = "api/account/confirm-email/";
            var _enpointUri = new Uri(string.Concat($"{origin}/", route));
            var verificationUri = QueryHelpers.AddQueryString(_enpointUri.ToString(), "userId", user.Id);
            verificationUri = QueryHelpers.AddQueryString(verificationUri, "code", code);
            //Email Service Call Here
            return verificationUri;
        }
    }
}
