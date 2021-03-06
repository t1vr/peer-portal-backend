using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ResponseModel
{
    public class TeamResponse:IAuditableBaseEntity
    {
        public Guid Id { get; set; }
        public string title { get; set; }
        public string? Description { get; set; }
        public int MemberCount { get; set; }

        public string CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModifiedAt { get; set; }
    }
}
