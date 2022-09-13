
namespace Domain.Entities
{
    /// <summary>
    /// Joining entity class for TeamUser and Permission
    /// </summary>
    public class TeamUserPermission
    {
        public string TeamUserId { get; set; }
        public TeamUser TeamUser { get; set; }
        public short PermissionId { get; set; }
        public Permission Permission { get; set; }
    }
}
