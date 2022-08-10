using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Team : BaseEntity,IAuditableBaseEntity
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public ICollection<TeamUser> TeamUsers { get; set; }

        public string CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModifiedAt { get; set; }

        public static implicit operator Team(Team v)
        {
            throw new NotImplementedException();
        }
    }
}
