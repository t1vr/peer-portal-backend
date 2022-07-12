

namespace Domain.Entities
{
    public class MemberRole
    {
        public string TeamUserId { get; set; }
        public TeamUser TeamUser { get; set; }
        public string ApplicationRoleId { get; set; }
        public ApplicationRole ApplicationRole { get; set; }
    }
}
