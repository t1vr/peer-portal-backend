using Domain.Entities;
using Domain.IRepositories;
using Infrastructure.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Repositories
{
    /// <summary>
    /// Repository class for Permission entity
    /// </summary>

    public class PermissionRepository : IPermissionRepository
    {
        private readonly ApplicationDbContext _context;
        public PermissionRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// This method saves list of permissions in database
        /// </summary>
        /// <param name="permissions">List of permissions to be saved in the database</param>
        /// <returns>Counts of newly created records</returns>
        public Task<int> CreatePermission(IList<Permission> permissions)
        {
            _context.Permissions.AddRangeAsync(permissions);
            return _context.SaveChangesAsync();
        }
    }
}
