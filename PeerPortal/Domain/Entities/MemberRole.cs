
namespace Domain.Entities
{
    /// <summary>
    /// Joining entity class Many to many between ApplicationUser and ApplicationRole
    /// </summary>
    public class MemberRole
    {
        public string TeamUserId { get; set; }
        public TeamUser TeamUser { get; set; }
        public string ApplicationRoleId { get; set; }
        public ApplicationRole ApplicationRole { get; set; }
    }
}
