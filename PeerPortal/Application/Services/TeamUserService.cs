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

        public async Task<BaseResponse<AddTeamUserDto>> AddUserInTeamAsync(AddTeamUserDto addTeamUserDto)
        {
            var userExists = await _uow.Users.GetQueryable().AnyAsync(x => x.Id == addTeamUserDto.ApplicationUserId);
            if (!userExists)
            {
                return new BaseResponse<AddTeamUserDto>("User doesn't exist.");
            }
            var team = await _uow.Teams.GetQueryable().Include(x => x.TeamUsers).FirstOrDefaultAsync(x => x.Id == addTeamUserDto.TeamId);
            var isDuplicateTeamUser = team?.TeamUsers.Any(x => x.ApplicationUserId == addTeamUserDto.ApplicationUserId) ?? false;

            if (isDuplicateTeamUser)
            {
                return new BaseResponse<AddTeamUserDto>("No Team Exist with team Id.");
            }

            var teamUser = new TeamUser
            {
                Id = Guid.NewGuid().ToString(),
                ApplicationUserId = addTeamUserDto.ApplicationUserId,
                TeamId = addTeamUserDto.TeamId,
            };

            var teamUserPermissionList=new List<TeamUserPermission>();
            foreach (var permissonId in addTeamUserDto.Permissions)
            {
                teamUserPermissionList.Add(new TeamUserPermission { TeamUserId = teamUser.Id, PermissionId = permissonId });
            }

            var getTeamDto = new GetTeamDto();
            try
            {
                await _uow.TeamUsers.AddAsync(teamUser);
                await _uow.TeamUserPermissions.AddRangeAsync(teamUserPermissionList);
                await _uow.SaveChangeAsync();
 //               var team = await _teamService.GetTeamAsync(teamUser.Id);
 //               getTeamDto = _mapper.Map<GetTeamDto>(team);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return new BaseResponse<AddTeamUserDto>("Something went wrong.");
            }
            return new BaseResponse<AddTeamUserDto>("User added successfully.");
        }
    }
}
