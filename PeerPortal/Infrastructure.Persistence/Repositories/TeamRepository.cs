using Application.IRepositories;
using Domain.Entities;
using Infrastructure.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Repositories
{
    public class TeamRepository:GenericRepository<Team>,ITeamRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public TeamRepository(ApplicationDbContext dbContext):base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
