﻿// <auto-generated />
using System;
using BugTracker.Core.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BugTracker.Core.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20211116034331_edit-guid")]
    partial class editguid
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.10")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BugStaff", b =>
                {
                    b.Property<int>("BugsId")
                        .HasColumnType("int");

                    b.Property<string>("StaffsId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("BugsId", "StaffsId");

                    b.HasIndex("StaffsId");

                    b.ToTable("BugStaff");
                });

            modelBuilder.Entity("BugTracker.Core.Entities.App", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CompanyId")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("LogoURL")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.ToTable("Apps");
                });

            modelBuilder.Entity("BugTracker.Core.Entities.Bug", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AppId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Serverity")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AppId");

                    b.ToTable("Bugs");
                });

            modelBuilder.Entity("BugTracker.Core.Entities.Company", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AdminId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Guid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("LogoURL")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ShortName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AdminId")
                        .IsUnique()
                        .HasFilter("[AdminId] IS NOT NULL");

                    b.HasIndex("Guid")
                        .IsUnique()
                        .HasFilter("[Guid] IS NOT NULL");

                    b.ToTable("Companies");
                });

            modelBuilder.Entity("BugTracker.Core.Entities.Language", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Languages");
                });

            modelBuilder.Entity("BugTracker.Core.Entities.Report", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AppId")
                        .HasColumnType("int");

                    b.Property<string>("CustomerId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AppId");

                    b.HasIndex("CustomerId");

                    b.ToTable("Reports");
                });

            modelBuilder.Entity("BugTracker.Core.Entities.Role", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("BugTracker.Core.Entities.Skill", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Skills");
                });

            modelBuilder.Entity("BugTracker.Core.Entities.StaffApp", b =>
                {
                    b.Property<int>("AppId")
                        .HasColumnType("int");

                    b.Property<string>("DevId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("IsLeader")
                        .HasColumnType("bit");

                    b.HasKey("AppId", "DevId");

                    b.HasIndex("DevId");

                    b.ToTable("StaffApp");
                });

            modelBuilder.Entity("BugTracker.Core.Entities.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<DateTime>("Birthdate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FullName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("Gender")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("BugTracker.Core.Entities.UserRole", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("LanguageStaff", b =>
                {
                    b.Property<int>("LanguagesId")
                        .HasColumnType("int");

                    b.Property<string>("StaffsId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LanguagesId", "StaffsId");

                    b.HasIndex("StaffsId");

                    b.ToTable("LanguageStaff");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("SkillStaff", b =>
                {
                    b.Property<int>("SkillsId")
                        .HasColumnType("int");

                    b.Property<string>("StaffsId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("SkillsId", "StaffsId");

                    b.HasIndex("StaffsId");

                    b.ToTable("SkillStaff");
                });

            modelBuilder.Entity("BugTracker.Core.Entities.Admin", b =>
                {
                    b.HasBaseType("BugTracker.Core.Entities.User");

                    b.ToTable("Admins");
                });

            modelBuilder.Entity("BugTracker.Core.Entities.Customer", b =>
                {
                    b.HasBaseType("BugTracker.Core.Entities.User");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("BugTracker.Core.Entities.Staff", b =>
                {
                    b.HasBaseType("BugTracker.Core.Entities.User");

                    b.Property<int?>("CompanyId")
                        .HasColumnType("int");

                    b.HasIndex("CompanyId");

                    b.ToTable("Staffs");
                });

            modelBuilder.Entity("BugStaff", b =>
                {
                    b.HasOne("BugTracker.Core.Entities.Bug", null)
                        .WithMany()
                        .HasForeignKey("BugsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BugTracker.Core.Entities.Staff", null)
                        .WithMany()
                        .HasForeignKey("StaffsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BugTracker.Core.Entities.App", b =>
                {
                    b.HasOne("BugTracker.Core.Entities.Company", "Company")
                        .WithMany("Apps")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("Company");
                });

            modelBuilder.Entity("BugTracker.Core.Entities.Bug", b =>
                {
                    b.HasOne("BugTracker.Core.Entities.App", "App")
                        .WithMany("Bugs")
                        .HasForeignKey("AppId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("App");
                });

            modelBuilder.Entity("BugTracker.Core.Entities.Company", b =>
                {
                    b.HasOne("BugTracker.Core.Entities.Admin", "Admin")
                        .WithOne("Company")
                        .HasForeignKey("BugTracker.Core.Entities.Company", "AdminId");

                    b.Navigation("Admin");
                });

            modelBuilder.Entity("BugTracker.Core.Entities.Report", b =>
                {
                    b.HasOne("BugTracker.Core.Entities.App", "App")
                        .WithMany("Reports")
                        .HasForeignKey("AppId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BugTracker.Core.Entities.Customer", "Customer")
                        .WithMany("Reports")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("App");

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("BugTracker.Core.Entities.StaffApp", b =>
                {
                    b.HasOne("BugTracker.Core.Entities.App", "App")
                        .WithMany("StaffApps")
                        .HasForeignKey("AppId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BugTracker.Core.Entities.Staff", "Dev")
                        .WithMany("StaffApps")
                        .HasForeignKey("DevId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("App");

                    b.Navigation("Dev");
                });

            modelBuilder.Entity("BugTracker.Core.Entities.UserRole", b =>
                {
                    b.HasOne("BugTracker.Core.Entities.Role", "Role")
                        .WithMany("UserRoles")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BugTracker.Core.Entities.User", "User")
                        .WithMany("UserRoles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");

                    b.Navigation("User");
                });

            modelBuilder.Entity("LanguageStaff", b =>
                {
                    b.HasOne("BugTracker.Core.Entities.Language", null)
                        .WithMany()
                        .HasForeignKey("LanguagesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BugTracker.Core.Entities.Staff", null)
                        .WithMany()
                        .HasForeignKey("StaffsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("BugTracker.Core.Entities.Role", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("BugTracker.Core.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("BugTracker.Core.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("BugTracker.Core.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SkillStaff", b =>
                {
                    b.HasOne("BugTracker.Core.Entities.Skill", null)
                        .WithMany()
                        .HasForeignKey("SkillsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BugTracker.Core.Entities.Staff", null)
                        .WithMany()
                        .HasForeignKey("StaffsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BugTracker.Core.Entities.Admin", b =>
                {
                    b.HasOne("BugTracker.Core.Entities.User", null)
                        .WithOne()
                        .HasForeignKey("BugTracker.Core.Entities.Admin", "Id")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BugTracker.Core.Entities.Customer", b =>
                {
                    b.HasOne("BugTracker.Core.Entities.User", null)
                        .WithOne()
                        .HasForeignKey("BugTracker.Core.Entities.Customer", "Id")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BugTracker.Core.Entities.Staff", b =>
                {
                    b.HasOne("BugTracker.Core.Entities.Company", null)
                        .WithMany("Staffs")
                        .HasForeignKey("CompanyId");

                    b.HasOne("BugTracker.Core.Entities.User", null)
                        .WithOne()
                        .HasForeignKey("BugTracker.Core.Entities.Staff", "Id")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BugTracker.Core.Entities.App", b =>
                {
                    b.Navigation("Bugs");

                    b.Navigation("Reports");

                    b.Navigation("StaffApps");
                });

            modelBuilder.Entity("BugTracker.Core.Entities.Company", b =>
                {
                    b.Navigation("Apps");

                    b.Navigation("Staffs");
                });

            modelBuilder.Entity("BugTracker.Core.Entities.Role", b =>
                {
                    b.Navigation("UserRoles");
                });

            modelBuilder.Entity("BugTracker.Core.Entities.User", b =>
                {
                    b.Navigation("UserRoles");
                });

            modelBuilder.Entity("BugTracker.Core.Entities.Admin", b =>
                {
                    b.Navigation("Company");
                });

            modelBuilder.Entity("BugTracker.Core.Entities.Customer", b =>
                {
                    b.Navigation("Reports");
                });

            modelBuilder.Entity("BugTracker.Core.Entities.Staff", b =>
                {
                    b.Navigation("StaffApps");
                });
#pragma warning restore 612, 618
        }
    }
}
