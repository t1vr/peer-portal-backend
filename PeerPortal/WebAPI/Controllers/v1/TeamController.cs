using Application.IServices;
using Application.Shared.Dtos;
using Application.Wrapper;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers.v1
{
    [Route("api/[controller]")]
    /*   [Authorize]*/
    [ApiController]
    public class TeamController : BaseApiController
    {
        private readonly ITeamService _teamService;
        public TeamController(IHttpContextAccessor httpContextAccessor, ITeamService teamService)
        {
            _teamService = teamService;
        }

        /// <summary>
        /// This Api creates a team 
        /// </summary>
        /// <param name="teamRequest"></param>
        /// <returns>Returns Team Details</returns>
        [HttpPost("create")]
        public async Task<BaseResponse<GetTeamDto>> CreateAsync(CreateTeamDto createTeamDto)
        {
            return await _teamService.CreateTeamAsync(createTeamDto);
        }

        /// <summary>
        /// This Api gets team details given a team id
        /// </summary>
        /// <param name="teamId"></param>
        /// <returns>Returns Team Details</returns>
        [HttpGet("get/{teamId}")]
        public async Task<BaseResponse<GetTeamDto>> GetAsync([FromRoute] string teamId)
        {
            return await _teamService.GetTeamAsync(teamId);
        }

        /// <summary>
        /// This Api retrieves list of teams for the currently logged in user
        /// </summary>
        /// <returns>Returns list of teams.</returns>
        [HttpGet("get")]
        public async Task<BaseResponse<List<GetTeamDto>>> GetAllAsync()
        {
            return await _teamService.GetAllAsync();
        }
    }
}
