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
        public ITeamUserRepository TeamUsers { get; set; }
        public IMemberRoleRepository MemberRoles { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="context"></param>
        /// <param name="user"></param>
        /// <param name="teams"></param>
        /// <param name="permissions"></param>
        /// <param name="teamUsers"></param>
        /// <param name="memberRoles"></param>
        public UnitOfWork(ApplicationDbContext context,
            IUserRepository users, 
            ITeamRepository teams, 
            IPermissionRepository permissions,
            ITeamUserRepository teamUsers,
            IMemberRoleRepository memberRoles)
        {
            _context = context;
            Users = users;
            Teams = teams;
            Permissions = permissions;
            TeamUsers = teamUsers;
            MemberRoles = memberRoles;
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
