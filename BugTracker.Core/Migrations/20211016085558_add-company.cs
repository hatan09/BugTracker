using Microsoft.EntityFrameworkCore.Migrations;

namespace BugTracker.Core.Migrations
{
    public partial class addcompany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppDev");

            migrationBuilder.DropTable(
                name: "Devs");

            migrationBuilder.AddColumn<string>(
                name: "AdminId",
                table: "Companies",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Guid",
                table: "Companies",
                type: "nvarchar(450)",
                nullable: true,
                defaultValueSql: "NEWID()");

            migrationBuilder.CreateTable(
                name: "Admins",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admins", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Admins_AspNetUsers_Id",
                        column: x => x.Id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Staffs",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CompanyId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Staffs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Staffs_AspNetUsers_Id",
                        column: x => x.Id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Staffs_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StaffApp",
                columns: table => new
                {
                    DevId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AppId = table.Column<int>(type: "int", nullable: false),
                    IsLeader = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StaffApp", x => new { x.AppId, x.DevId });
                    table.ForeignKey(
                        name: "FK_StaffApp_Apps_AppId",
                        column: x => x.AppId,
                        principalTable: "Apps",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StaffApp_Staffs_DevId",
                        column: x => x.DevId,
                        principalTable: "Staffs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Companies_AdminId",
                table: "Companies",
                column: "AdminId",
                unique: true,
                filter: "[AdminId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Companies_Guid",
                table: "Companies",
                column: "Guid",
                unique: true,
                filter: "[Guid] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_StaffApp_DevId",
                table: "StaffApp",
                column: "DevId");

            migrationBuilder.CreateIndex(
                name: "IX_Staffs_CompanyId",
                table: "Staffs",
                column: "CompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Companies_Admins_AdminId",
                table: "Companies",
                column: "AdminId",
                principalTable: "Admins",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Companies_Admins_AdminId",
                table: "Companies");

            migrationBuilder.DropTable(
                name: "Admins");

            migrationBuilder.DropTable(
                name: "StaffApp");

            migrationBuilder.DropTable(
                name: "Staffs");

            migrationBuilder.DropIndex(
                name: "IX_Companies_AdminId",
                table: "Companies");

            migrationBuilder.DropIndex(
                name: "IX_Companies_Guid",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "AdminId",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "Guid",
                table: "Companies");

            migrationBuilder.CreateTable(
                name: "Devs",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CompanyId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Devs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Devs_AspNetUsers_Id",
                        column: x => x.Id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Devs_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AppDev",
                columns: table => new
                {
                    AppId = table.Column<int>(type: "int", nullable: false),
                    DevId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IsLeader = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppDev", x => new { x.AppId, x.DevId });
                    table.ForeignKey(
                        name: "FK_AppDev_Apps_AppId",
                        column: x => x.AppId,
                        principalTable: "Apps",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AppDev_Devs_DevId",
                        column: x => x.DevId,
                        principalTable: "Devs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AppDev_DevId",
                table: "AppDev",
                column: "DevId");

            migrationBuilder.CreateIndex(
                name: "IX_Devs_CompanyId",
                table: "Devs",
                column: "CompanyId");
        }
    }
}
