using Application.IServices;
using Application.Shared.Dtos;
using Application.Shared.Enum;
using Application.Shared.Session;
using Application.Wrapper;
using AutoMapper;
using Domain.Entities;
using Domain.IRepositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace Application.Services
{
    /// <summary>
    /// Team Service class
    /// </summary>
    public class TeamService : BaseService, ITeamService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly UserSession _session;
        private readonly IMapper _mapper;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="unitOfWork"></param>
        /// <param name="roleManager"></param>
        /// <param name="session"></param>
        /// <param name="mapper"></param>
        public TeamService(IUnitOfWork unitOfWork,
            RoleManager<ApplicationRole> roleManager,
            UserSession session,
            IMapper mapper) : base(session)
        {
            _unitOfWork = unitOfWork;
            _roleManager = roleManager;
            _session = session;
            _mapper = mapper;
        }

        ///<inheritdoc [cref="ITeamService.CreateTeamAsync"] [path=""]/>
        public async Task<BaseResponse<GetTeamDto>> CreateTeamAsync(CreateTeamDto teamRequest)
        {
            var teamUser = new TeamUser
            {
                Id = Guid.NewGuid().ToString(),
                ApplicationUserId = GetCurrentUserId(),
            };
            var team = _mapper.Map<Team>(teamRequest);
            team.Id = Guid.NewGuid().ToString();
            team.TeamUsers = new List<TeamUser>() { teamUser };

            try
            {
                await _unitOfWork.Teams.AddAsync(team);
                var role = await _roleManager.FindByNameAsync(Roles.Admin.ToString());
                var memberRole = new MemberRole
                {
                    Id = Guid.NewGuid().ToString(),
                    TeamUserId = teamUser.Id,
                    ApplicationRoleId = role.Id,
                };
                await _unitOfWork.MemberRoles.AddAsync(memberRole);
                await _unitOfWork.SaveChangeAsync();
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return new BaseResponse<GetTeamDto>("Team creation failed");
            }

            var query = _unitOfWork.Teams.GetQueryable().Include(team => team.TeamUsers).ThenInclude(x => x.ApplicationUser);
            team = await _unitOfWork.Teams.GetAsync(query, team.Id);

            var teamResponseDto = _mapper.Map<GetTeamDto>(team);
            return new BaseResponse<GetTeamDto>(true, teamResponseDto, "Successfully created team");
        }


        ///<inheritdoc [cref="ITeamService.GetTeamAsync"] [path=""]/>
        public async Task<BaseResponse<GetTeamDto>> GetTeamAsync(string teamId)
        {
            if (teamId is null)
            {
                return new BaseResponse<GetTeamDto>("Id cannot be null");
            }
            var query = _unitOfWork.Teams.GetQueryable().Include(team => team.TeamUsers).ThenInclude(x => x.ApplicationUser);
            var team = await _unitOfWork.Teams.GetAsync(query, teamId);
            var getTeamDto = _mapper.Map<GetTeamDto>(team);
            return new BaseResponse<GetTeamDto>(true, getTeamDto, "Successfully retrieved team");
        }

        ///<inheritdoc [cref="ITeamService.GetAllAsync"] [path=""]/>
        public async Task<BaseResponse<List<GetTeamDto>>> GetAllAsync()
        {
            var currentUserId = GetCurrentUserId();
            var query = _unitOfWork.Teams.GetQueryable().Include(x => x.TeamUsers).ThenInclude(x=>x.ApplicationUser);
            var teams = await _unitOfWork.Teams.GetAllAsync(query,currentUserId);
            var getTeamDtoList = _mapper.Map<List<GetTeamDto>>(teams);
            return new BaseResponse<List<GetTeamDto>>(true, getTeamDtoList, "Successfully Retrieved");
        }
    }
}
