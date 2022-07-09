using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ResponseModel
{
    public class TeamResponse:AuditableBaseEntity
    {
        public Guid Id { get; set; }
        public string title { get; set; }
        public string? Description { get; set; }
        public int MemberCount { get; set; }
    }
}
