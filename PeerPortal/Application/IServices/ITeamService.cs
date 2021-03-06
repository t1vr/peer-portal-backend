using Application.Request_Model;
using Application.Wrapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.IServices
{
    public interface ITeamService
    {
        public Task<BaseResponse<Team>> CreateTeamAsync(TeamRequest teamRequest);
    }
}
