

namespace Domain.IRepositories
{
    public interface IUnitOfWork : IDisposable
    {
        Task<int> SaveChangeAsync();
    }
}
