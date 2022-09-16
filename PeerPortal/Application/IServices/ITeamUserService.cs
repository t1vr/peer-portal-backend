using Application.Shared.Dtos;
using Application.Wrapper;

namespace Application.IServices
{
    /// <summary>
    /// TeamUser service interface
    /// </summary>
    public interface ITeamUserService : IBaseService
    {
        /// <summary>
        /// This method adds a user in a team
        /// </summary>
        /// <param name="addTeamUserDto"></param>
        /// <returns>Team</returns>
        Task<BaseResponse<GetTeamDto>> AddUserInTeamAsync(AddTeamUserDto addTeamUserDto);
    }
}
