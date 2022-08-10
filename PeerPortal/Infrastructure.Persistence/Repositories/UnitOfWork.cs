using Domain.IRepositories;
using Infrastructure.Persistence.Context;

namespace Infrastructure.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        public IUserRepository Users { get; set; }
        public ITeamRepository Teams { get; set; }
        public IPermissionRepository Permissions { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="context"></param>
        /// <param name="userRepository"></param>
        /// <param name="teams"></param>
        /// <param name="permissions"></param>
        public UnitOfWork(ApplicationDbContext context,IUserRepository userRepository, ITeamRepository teams, IPermissionRepository permissions)
        {
            _context = context;
            Users = userRepository;
            Teams = teams;
            Permissions = permissions;
        }

        public async Task<int> SaveChangeAsync()
        {
            return await _context.SaveChangesAsync();
        }
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
