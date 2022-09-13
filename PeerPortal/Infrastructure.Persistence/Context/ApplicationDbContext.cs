using Application.Shared.Session;
using Domain.Common;
using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Context
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, string, IdentityUserClaim<string>,IdentityUserRole<string>, IdentityUserLogin<string>,IdentityRoleClaim<string>, IdentityUserToken<string>
        >
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options,UserSession userSession) : base(options)
        {
            _userSession = userSession;
        }
        private readonly UserSession _userSession;

        public DbSet<Team> Teams { get; set; }
        public DbSet<TeamUser> TeamUsers { get; set; }
        public DbSet<MemberRole> MemberRoles { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<TeamUserPermission> TeamUserPermissions { get; set; }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            return base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Permission>().Property(permission => permission.Id).ValueGeneratedOnAdd();
            builder.Entity<MemberRole>().HasOne(x => x.TeamUser).WithMany(x => x.MemberRoles).HasForeignKey(x => x.TeamUserId);
            builder.Entity<MemberRole>().HasOne(x => x.ApplicationRole).WithMany(x => x.MemberRoles).HasForeignKey(x => x.ApplicationRoleId);

            builder.Entity<TeamUser>().HasOne(x => x.ApplicationUser).WithMany(x => x.TeamUsers).HasForeignKey(x => x.ApplicationUserId);
            builder.Entity<TeamUser>().HasOne(x => x.Team).WithMany(x => x.TeamUsers).HasForeignKey(x => x.TeamId);

            builder.Entity<TeamUserPermission>().HasOne(x => x.TeamUser).WithMany(x => x.TeamUserPermissions);
            builder.Entity<TeamUserPermission>().HasOne(x => x.Permission).WithMany(x => x.TeamUserPermissions);
            builder.Entity<TeamUserPermission>().HasKey(x => new { x.TeamUserId, x.PermissionId });

            base.OnModelCreating(builder);
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            PopulateAuditFields();
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        private void PopulateAuditFields()
        {
            foreach (var entry in ChangeTracker.Entries<IAuditableBaseEntity>().ToList())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedBy = _userSession.Username;
                        entry.Entity.CreatedAt = DateTime.UtcNow;
                        break;
                    case EntityState.Modified:
                        entry.Entity.LastModifiedBy = _userSession.Username;
                        entry.Entity.LastModifiedAt = DateTime.UtcNow;
                        break;
                }
            }
        }


    }
}
