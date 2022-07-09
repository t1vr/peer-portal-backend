using Application.IRepositories;
using Application.IServices;
using Application.Request_Model;
using Application.Wrapper;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class TeamService : ITeamService
    {
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly IUserRepository _userRepository;
        public TeamService(IHttpContextAccessor httpContextAccessor,IUserRepository userRepository)
        {
            _contextAccessor = httpContextAccessor;
            _userRepository = userRepository;
        }
        public async Task<BaseResponse<Team>> CreateTeamAsync(TeamRequest teamRequest)
        {
            var usernameFromToken = _contextAccessor?.HttpContext?.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if(usernameFromToken is null)
            {
                return new BaseResponse<Team>(400, "Null token claims");
            }
            if(usernameFromToken is not null)
            {
                var user = await _userRepository.GetUserByUserNameAsync(usernameFromToken);
            }
            return new BaseResponse<Team>(400, "Null token claims");
        }

    }
}
