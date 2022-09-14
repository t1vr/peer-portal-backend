using Application.IServices;
using Application.Shared.Dtos;
using Application.Wrapper;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers.v1
{
    [Route("api/[controller]")]
    /*   [Authorize]*/
    [ApiController]
    public class TeamUserController : BaseApiController
    {
        private readonly ITeamUserService _teamUserService;
        public TeamUserController(ITeamUserService teamUserService)
        {
            _teamUserService = teamUserService;
        }

        [HttpPost("invite")]
        public async Task<BaseResponse<AddTeamUserDto>> Add(AddTeamUserDto addTeamUserDto)
        {
            return await _teamUserService.AddUserInTeamAsync(addTeamUserDto);
        }
    }
}
