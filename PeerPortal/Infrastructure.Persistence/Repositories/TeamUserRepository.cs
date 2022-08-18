using Domain.Entities;
using Domain.IRepositories;
using Infrastructure.Persistence.Context;

namespace Infrastructure.Persistence.Repositories
{
    public class TeamUserRepository : GenericRepository<TeamUser>, ITeamUserRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public TeamUserRepository(ApplicationDbContext dbContext):base(dbContext)
        {
            _dbContext=dbContext;
        }
    }
}
