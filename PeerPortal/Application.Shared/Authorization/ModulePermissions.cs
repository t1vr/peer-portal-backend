using Domain.Entities;
using System.Reflection;


namespace Application.Shared.Authorization
{
    /// <summary>
    /// Class for defining all the permissions in the system.
    /// </summary>
    public static class ModulePermissions
    {

        /// <summary>
        /// Class for defining all the permissions in the Team section of the system.
        /// </summary>
        public class Team
        {
            public const string View = "View";
            public const string Create = "Create";
            public const string Edit = "Edit";
            public const string Delete = "Delete";
            public const string Invite = "Invite";
        }


        /// <summary>
        /// This method generates permissions based on the class set as a value of T.
        /// </summary>
        /// <typeparam name="T">T refers to the Module permission class,eg:ModulePermissions.Team</typeparam>
        /// <returns>List of permissions</returns>
        public static List<Permission> GeneratePermissionForModule<T>(T module) where T : class
        {
            var generatedPermissions= new List<Permission>();
            foreach (FieldInfo fieldInfo in typeof(T).GetFields(BindingFlags.Public|BindingFlags.Static))
            {
                string permissionName = $"Permissions.{typeof(T).Name}.{fieldInfo.Name}";
                generatedPermissions.Add(new Permission { PermissionName= permissionName });
            }
            return generatedPermissions;
        }
    }
}

