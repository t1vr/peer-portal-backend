using Domain.Entities;

namespace Domain.IRepositories
{
    /// <summary>
    /// Interface to access Team table in database
    /// </summary>
    public interface ITeamRepository : IGenericRepository<Team>
    {
    }
}
