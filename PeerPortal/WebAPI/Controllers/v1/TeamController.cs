using Application.IServices;
using Application.Request_Model;
using Application.ResponseModel;
using Application.Shared.Dtos;
using Application.Wrapper;
using Domain.Common;
using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace WebAPI.Controllers.v1
{
    [Route("api/[controller]")]
    /*   [Authorize]*/
    [ApiController]
    public class TeamController : BaseApiController
    {
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly ITeamService _teamService;
        public TeamController(IHttpContextAccessor httpContextAccessor, ITeamService teamService)
        {
            _contextAccessor = httpContextAccessor;
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
    }
}
