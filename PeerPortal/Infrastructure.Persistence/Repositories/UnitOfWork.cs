using Application.IRepositories;
using Infrastructure.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        public IUserRepository Users { get; private set; }
        public ITeamRepository Teams { get; private set; }

        public UnitOfWork(ApplicationDbContext context,IUserRepository userRepository, ITeamRepository teams)
        {
            _context = context;
            Users = userRepository;
            Teams = teams;
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
