using Application.Shared.Authorization;
using Domain.IRepositories;



namespace Infrastructure.Persistence.Seeds
{
    public static class DefaultPermissions
    {
        public static async Task SeedAsync(IPermissionRepository permissionRepository)
        {
            var permissions = ModulePermissions.GeneratePermissionForModule<ModulePermissions.Team>(new ModulePermissions.Team());
            await permissionRepository.CreatePermission(permissions);
        }
    }
}
