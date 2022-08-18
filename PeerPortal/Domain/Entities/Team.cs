using Domain.Common;

namespace Domain.Entities
{
    public class Team : BaseEntity,IAuditableBaseEntity
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public virtual ICollection<TeamUser> TeamUsers { get; set; }

        public string CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public string? LastModifiedBy { get; set; }
        public DateTime? LastModifiedAt { get; set; }
    }
}
