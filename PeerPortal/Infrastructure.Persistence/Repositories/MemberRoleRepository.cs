using Domain.Entities;
using Domain.IRepositories;
using Infrastructure.Persistence.Context;

namespace Infrastructure.Persistence.Repositories
{
    public class MemberRoleRepository : GenericRepository<MemberRole>, IMemberRoleRepository
    {
        private readonly ApplicationDbContext _dbContext;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="dbContext"></param>
        public MemberRoleRepository(ApplicationDbContext dbContext):base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
