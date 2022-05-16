using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class TeamUser:AuditableBaseEntity
    {
        
        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }

        public string TeamId { get; set; }
        public Team Team { get; set; }
    }
}
