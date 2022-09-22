using Application.Shared.Dtos;
using Application.Wrapper;

namespace Application.IServices
{
    /// <summary>
    /// Interface to interact with team
    /// </summary>
    public interface ITeamService : IBaseService
    {
        /// <summary>
        /// This method applies different logic to create a team,assigns team creator Admin role
        /// </summary>
        /// <param name="createTeamDto"></param>
        /// <returns>returns the newly created team</returns>
        public Task<BaseResponse<GetTeamDto>> CreateTeamAsync(CreateTeamDto createTeamDto);

        /// <summary>
        /// This method Gets Team from by team Id.
        /// </summary>
        /// <param name="teamId"></param>
        /// <returns>returns team details of the given team id</returns>
        public Task<BaseResponse<GetTeamDto>> GetTeamAsync(string teamId);

        /// <summary>
        /// This method Gets list of Team of the currenty logged in user
        /// </summary>
        /// <returns>returns list of teams</returns>
        public Task<BaseResponse<List<GetTeamDto>>> GetAllAsync();
    }
}
