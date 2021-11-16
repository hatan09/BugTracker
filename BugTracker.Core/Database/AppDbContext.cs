

using BugTracker.Core.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace BugTracker.Core.Database
{
    public class AppDbContext : IdentityDbContext<User, Role, string, IdentityUserClaim<string>, UserRole, IdentityUserLogin<string>, IdentityRoleClaim<string>, IdentityUserToken<string>>
    {
        // public AppDbContext() { }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public virtual DbSet<Company> Companies { get; set; } = null!;
        public virtual DbSet<App> Apps { get; set; } = null!;
        public virtual DbSet<Report> Reports { get; set; } = null!;
        public virtual DbSet<Bug> Bugs { get; set; } = null!;
        public virtual DbSet<Skill> Skills { get; set; } = null!;
        public virtual DbSet<Language> Languages { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Admin>().ToTable("Admins");
            modelBuilder.Entity<Staff>().ToTable("Staffs");
            modelBuilder.Entity<Customer>().ToTable("Customers");

            modelBuilder.Entity<UserRole>(entity =>
            {
                entity.HasOne(ur => ur.Role)
                    .WithMany(r => r!.UserRoles)
                    .HasForeignKey(ur => ur.RoleId)
                    .IsRequired()
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(ur => ur.User)
                    .WithMany(u => u!.UserRoles)
                    .HasForeignKey(ur => ur.UserId)
                    .IsRequired()
                    .OnDelete(DeleteBehavior.Cascade);
            });


            modelBuilder.Entity<StaffApp>(entity =>
            {
                entity.HasOne(sa => sa.Dev)
                    .WithMany(stf => stf.StaffApps)
                    .HasForeignKey(sa => sa.DevId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(sa => sa.App)
                    .WithMany(app => app.StaffApps)
                    .HasForeignKey(sa => sa.AppId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasKey(sa => new { sa.AppId, sa.DevId });
            });

            modelBuilder.Entity<Company>(entity =>
            {
                entity.HasIndex(cpn => cpn.Guid)
                    .IsUnique();

                entity.Property(cpn => cpn.Guid).HasDefaultValueSql("NEWID()");
            });

            modelBuilder.Entity<App>(entity =>
            {
                entity.HasOne(app => app.Company)
                    .WithMany(cpn => cpn.Apps)
                    .HasForeignKey(app => app.CompanyId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Report>(entity =>
            {
                entity.HasOne(rp => rp.App)
                    .WithMany(app => app.Reports)
                    .HasForeignKey(rp => rp.AppId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(rp => rp.Customer)
                    .WithMany(cus => cus.Reports)
                    .HasForeignKey(rp => rp.CustomerId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Bug>(entity =>
            {
                entity.HasOne(bug => bug.App)
                    .WithMany(app => app.Bugs)
                    .HasForeignKey(rp => rp.AppId)
                    .OnDelete(DeleteBehavior.Cascade);
            });


        }
    }
}
