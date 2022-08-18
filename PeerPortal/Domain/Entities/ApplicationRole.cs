using Microsoft.AspNetCore.Identity;

namespace Domain.Entities
{
    public class ApplicationRole:IdentityRole
    {
        public ApplicationRole() : base(){ }
        public ApplicationRole(string roleName) : base(roleName){ }
        public virtual ICollection<MemberRole> MemberRoles { get; set; }
    }
}
