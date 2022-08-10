using Application.Request_Model;
using Application.Wrapper;
using Domain.Entities;

namespace Application.IServices
{
    /// <summary>
    /// Interface to interact with team
    /// </summary>
    public interface ITeamService
    {
        /// <summary>
        /// This method applies different logic to create a team,assigns team creator Admin role
        /// </summary>
        /// <param name="teamRequest"></param>
        /// <returns>returns the newly created team</returns>
        public Task<BaseResponse<Team>> CreateTeamAsync(CreateTeamRequest teamRequest);
    }
}
