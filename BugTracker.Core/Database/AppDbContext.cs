

using BugTracker.Core.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BugTracker.Core.Database
{
    public class AppDbContext : IdentityDbContext<User, Role, string, IdentityUserClaim<string>, UserRole, IdentityUserLogin<string>, IdentityRoleClaim<string>, IdentityUserToken<string>>
    {
       // public AppDbContext() { }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public virtual DbSet<Company> Companies { get; set; } = null!;
        public virtual DbSet<App> Apps { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Staff>().ToTable("Devs");
            modelBuilder.Entity<Customer>().ToTable("Customers");

            modelBuilder.Entity<UserRole>(entity =>
            {
                entity.HasOne(ur => ur.Role).WithMany(r => r!.UserRoles).HasForeignKey(ur => ur.RoleId).IsRequired().OnDelete(DeleteBehavior.Cascade);
                entity.HasOne(ur => ur.User).WithMany(u => u!.UserRoles).HasForeignKey(ur => ur.UserId).IsRequired().OnDelete(DeleteBehavior.Cascade);
            });


            modelBuilder.Entity<StaffApp>(entity => {
                entity.HasOne<Staff>(ad => ad.Dev).WithMany(dv => dv.StaffApps).HasForeignKey(ad => ad.DevId);
                entity.HasOne<App>(ad => ad.App).WithMany(ap => ap.StaffApps).HasForeignKey(ad => ad.AppId);
                entity.HasKey(ad => new { ad.AppId, ad.DevId });
            });
        }
    }  
}
