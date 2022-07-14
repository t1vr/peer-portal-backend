using Domain.Entities;
using Domain.IRepositories;
using Infrastructure.Persistence.Context;


namespace Infrastructure.Persistence.Repositories
{
    public class AccountRepository: GenericRepository<ApplicationUser>,IAccountRepository
    {
        private readonly ApplicationDbContext _context;
        public AccountRepository(ApplicationDbContext context):base(context)
        {
            _context = context;
        }
    }
}
