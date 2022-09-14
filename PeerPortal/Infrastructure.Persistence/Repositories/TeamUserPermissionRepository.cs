using Domain.Entities;
using Domain.IRepositories;
using Infrastructure.Persistence.Context;

namespace Infrastructure.Persistence.Repositories
{
    /// <summary>
    /// Repository class for TeamUserPermission entity
    /// </summary>
    public class TeamUserPermissionRepository : GenericRepository<TeamUserPermission>, ITeamUserPermissionRepository
    {
        public TeamUserPermissionRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
