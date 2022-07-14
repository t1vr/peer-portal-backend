

namespace Application.Shared.Authorization
{
    /// <summary>
    /// Class for defining all the permissions in the system.
    /// </summary>
    public static class Permissions
    {
        /// <summary>
        /// Class for defining all the permissions in the Team section of the system.
        /// </summary>
        public static class Teams
        {
            public const string View = "Permissions.Teams.View";
            public const string Create = "Permissions.Teams.Create";
            public const string Edit = "Permissions.Teams.Edit";
            public const string Delete = "Permissions.Teams.Delete";
            public const string Invite = "Permissions.Teams.Invite";
        }
    }
}
