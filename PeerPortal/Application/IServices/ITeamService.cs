using Application.Request_Model;
using Application.ResponseModel;
using Application.Shared.Dtos;
using Application.Wrapper;
using Domain.Common;
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
        /// <param name="createTeamDto"></param>
        /// <returns>returns the newly created team</returns>
        public Task<BaseResponse<GetTeamDto>> CreateTeamAsync(CreateTeamDto createTeamDto);
    }
}
