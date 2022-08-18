using Domain.Common;

namespace Domain.Entities
{
    /// <summary>
    /// Joining entity class Many to many between ApplicationUser and ApplicationRole
    /// </summary>
    public class MemberRole : BaseEntity
    {
        public string TeamUserId { get; set; }
        public virtual TeamUser TeamUser { get; set; }
        public string ApplicationRoleId { get; set; }
        public virtual ApplicationRole ApplicationRole { get; set; }
    }
}
