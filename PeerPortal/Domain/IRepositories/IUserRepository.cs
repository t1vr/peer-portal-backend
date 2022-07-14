using Domain.Entities;


namespace Domain.IRepositories
{
    public interface IUserRepository : IGenericRepository<ApplicationUser>
    {
        public Task<ApplicationUser> GetUserByUserNameAsync(string username);
    }
}
