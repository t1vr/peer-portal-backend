using Application.Shared.Dtos;
using Application.Wrapper;

namespace Application.IServices
{
    /// <summary>
    /// TeamUser service interface
    /// </summary>
    public interface ITeamUserService : IBaseService
    {
        Task<BaseResponse<AddTeamUserDto>> AddUserInTeamAsync(AddTeamUserDto addTeamUserDto);
    }
}
