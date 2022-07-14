using Domain.Entities;
using Domain.IRepositories;
using Infrastructure.Persistence.Context;
using Microsoft.AspNetCore.Identity;



namespace Infrastructure.Persistence.Repositories
{
    public class UserRepository: GenericRepository<ApplicationUser>,IUserRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        public UserRepository(ApplicationDbContext _context, UserManager<ApplicationUser> userManager) :base(_context)
        {
            _userManager = userManager;
        }

        public async Task<ApplicationUser> GetUserByUserNameAsync(string username)
        {
            return await _userManager.FindByNameAsync(username);
        }
    }
}
