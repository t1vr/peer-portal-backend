using Microsoft.AspNetCore.Identity;


namespace Domain.Entities
{
    public class ApplicationRole:IdentityRole
    {
        public ICollection<MemberRole> MemberRoles { get; set; }
    }
}
