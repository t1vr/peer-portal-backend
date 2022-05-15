using Application.IServices;
using Application.Request_Model;
using Application.ResponseModel;
using Application.Wrapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers.v1
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : BaseApiController
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpPost]
        public async Task<BaseResponse<UserRegistrationResponseModel>> Register([FromBody] RegisterRequest registerRequest)
        {
            return await _userService.RegisterUserAsync(registerRequest);
        }
    }
}
