using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.IRepositories
{
    public interface IPermissionRepository
    {
        public Task<int> CreatePermission(IList<Permission> permissions);
    }
}
