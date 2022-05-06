using Application.IServices;
using Application.Request;
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
        public async Task<IActionResult> Register([FromBody] RegisterRequest registerRequest)
        {
            return await _userService.RegisterUserAsync(registerRequest);
        }
    }
}
