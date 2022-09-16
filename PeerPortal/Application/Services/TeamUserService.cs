using Application.IServices;
using Application.Shared.Dtos;
using Application.Shared.Session;
using Application.Wrapper;
using AutoMapper;
using Domain.Entities;
using Domain.IRepositories;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace Application.Services
{
    /// <summary>
    /// Implementation class of the ITeamUserService interface.
    /// </summary>
    public class TeamUserService : BaseService, ITeamUserService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        private readonly ITeamService _teamService;

        public TeamUserService(IUnitOfWork uow, UserSession userSession, ITeamService teamService, IMapper mapper) : base(userSession)
        {
            _uow = uow;
            _mapper = mapper;
            _teamService = teamService;
        }

        ///<inheritdoc [cref="ITeamUserService.AddUserInTeamAsync"] [path=""]/>
        public async Task<BaseResponse<GetTeamDto>> AddUserInTeamAsync(AddTeamUserDto addTeamUserDto)
        {
            var userExists = await _uow.Users.GetQueryable().AnyAsync(x => x.Id == addTeamUserDto.ApplicationUserId);
            if (!userExists)
            {
                return new BaseResponse<GetTeamDto>("User doesn't exist.");
            }
            var team = await _uow.Teams.GetQueryable().Include(x => x.TeamUsers).FirstOrDefaultAsync(x => x.Id == addTeamUserDto.TeamId);
            var isDuplicateTeamUser = team?.TeamUsers.Any(x => x.ApplicationUserId == addTeamUserDto.ApplicationUserId) ?? false;

            if (isDuplicateTeamUser)
            {
                return new BaseResponse<GetTeamDto>("No Team Exist with team Id.");
            }

            var teamUser = _mapper.Map<TeamUser>(addTeamUserDto);
            teamUser.Id=Guid.NewGuid().ToString();
            var teamUserPermissionList =new List<TeamUserPermission>();

            foreach (var permissonId in addTeamUserDto.Permissions)
            {
                teamUserPermissionList.Add(new TeamUserPermission { TeamUserId = teamUser.Id, PermissionId = permissonId });
            }
            teamUser.TeamUserPermissions = teamUserPermissionList;

            try
            {
                await _uow.TeamUsers.AddAsync(teamUser);
                await _uow.TeamUserPermissions.AddRangeAsync(teamUserPermissionList);
                await _uow.SaveChangeAsync();
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return new BaseResponse<GetTeamDto>("Something went wrong.");
            }

            var teamAfterAddingNewUserTask = await _teamService.GetTeamAsync(addTeamUserDto.TeamId);
            var getTeamDto = _mapper.Map<GetTeamDto>(teamAfterAddingNewUserTask.Data);

            return new BaseResponse<GetTeamDto>(true,getTeamDto,"User added successfully.");
        }
    }
}
