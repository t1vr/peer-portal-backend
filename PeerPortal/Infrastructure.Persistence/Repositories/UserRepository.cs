using Application.IRepositories;
using Domain.Entities;
using Infrastructure.Persistence.Context;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Repositories
{
    public class UserRepository: GenericRepository<ApplicationUser>,IUserRepository
    {
        private readonly ApplicationDbContext _context;
        public UserRepository(ApplicationDbContext _context):base(_context)
        {

        }

    }
}
