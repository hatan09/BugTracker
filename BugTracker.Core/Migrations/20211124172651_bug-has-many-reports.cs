using Microsoft.EntityFrameworkCore.Migrations;

namespace BugTracker.Core.Migrations
{
    public partial class bughasmanyreports : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BugId",
                table: "Reports",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Reports_BugId",
                table: "Reports",
                column: "BugId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reports_Bugs_BugId",
                table: "Reports",
                column: "BugId",
                principalTable: "Bugs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reports_Bugs_BugId",
                table: "Reports");

            migrationBuilder.DropIndex(
                name: "IX_Reports_BugId",
                table: "Reports");

            migrationBuilder.DropColumn(
                name: "BugId",
                table: "Reports");
        }
    }
}
