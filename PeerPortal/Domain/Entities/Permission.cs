using Domain.Common;


namespace Domain.Entities
{
    public class Permission:BaseEntity<string>
    {
        public string PermissionName { get; set; }
        public ICollection<TeamUser> TeamUsers { get; set; }
    }
}
