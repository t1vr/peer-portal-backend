using Microsoft.AspNetCore.Authorization;

namespace WebAPI.Authorization
{
    /// <summary>
    /// Custom requirement class for permission management
    /// </summary>
    public class PermissionRequirement : IAuthorizationRequirement
    {
        public string Permission { get; private set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="permission">Name of the permission</param>
        public PermissionRequirement(string permission)
        {
            Permission = permission;
        }
    }
}
