using Domain.Entities;
using Domain.IRepositories;
using Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories
{
    /// <summary>
    /// Implementation of ITeamRepository
    /// </summary>
    public class TeamRepository : GenericRepository<Team>, ITeamRepository
    {
        private readonly ApplicationDbContext _dbContext;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="dbContext"></param>
        public TeamRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        ///<inheritdoc [cref="ITeamRepository.GetAsync"] [path=""]/>
        public async Task<Team?> GetAsync(IQueryable<Team> query, string id)
        {
            return await query.FirstOrDefaultAsync(x => x.Id.Equals(id));
        }
    }
}
