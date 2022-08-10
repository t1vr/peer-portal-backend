using Microsoft.AspNetCore.Identity;

namespace Domain.Entities
{
    public class ApplicationRole:IdentityRole
    {
        public ApplicationRole() : base(){ }
        public ApplicationRole(string roleName) : base(roleName){ }
        public ICollection<MemberRole> MemberRoles { get; set; }
    }
}
