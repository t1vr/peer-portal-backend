using Domain.Entities;
using Domain.IRepositories;
using Infrastructure.Persistence.Context;


namespace Infrastructure.Persistence.Repositories
{
    public class TeamRepository:GenericRepository<Team>,ITeamRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public TeamRepository(ApplicationDbContext dbContext):base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
