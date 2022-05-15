using Application.IServices;
using Application.Request_Model;
using Application.ResponseModel;
using Application.Wrapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace WebAPI.Controllers.v1
{

    [Route("api/[controller]")]
    [ApiController]
    public class AccountController:BaseApiController
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<BaseResponse<UserRegistrationResponseModel>> Register([FromBody] RegisterRequest registerRequest)
        {
            return await _accountService.RegisterUserAsync(registerRequest);
        }

        [AllowAnonymous]
        [HttpPost("verify-email")]
        public async Task<BaseResponse<string>> VerifyEmail([FromQuery] string userId,[FromQuery] string token)
        {
            Log.Information($"userId={userId} token={token} requested to verify Email");
            return await _accountService.ConfirmEmailAsync(userId, token);
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public async Task<BaseResponse<UserResponseModel>> AuthenticateAsync(AuthenticationRequest request)
        {
            return await _accountService.AuthenticateAsync(request);
        }
    }
}
