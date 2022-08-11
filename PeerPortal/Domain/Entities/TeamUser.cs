using Domain.Common;

namespace Domain.Entities
{
    public class TeamUser: BaseEntity, IAuditableBaseEntity
    {
        public string ApplicationUserId { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
        public string TeamId { get; set; }
        public virtual Team Team { get; set; }
        public virtual ICollection<MemberRole> MemberRoles { get; set; }
        public virtual ICollection<Permission> Permissions { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModifiedAt { get; set; }
    }
}
