
namespace Domain.IRepositories
{
    /// <summary>
    /// Interface to implement Unit of work pattern
    /// </summary>
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository Users { get; set; }
        ITeamRepository Teams { get; set; }
        IPermissionRepository Permissions { get; set; }
        Task<int> SaveChangeAsync();
    }
}
