using Microsoft.EntityFrameworkCore.Migrations;

namespace BugTracker.Core.Migrations
{
    public partial class staffid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StaffApp_Staffs_DevId",
                table: "StaffApp");

            migrationBuilder.RenameColumn(
                name: "DevId",
                table: "StaffApp",
                newName: "StaffId");

            migrationBuilder.RenameIndex(
                name: "IX_StaffApp_DevId",
                table: "StaffApp",
                newName: "IX_StaffApp_StaffId");

            migrationBuilder.AddForeignKey(
                name: "FK_StaffApp_Staffs_StaffId",
                table: "StaffApp",
                column: "StaffId",
                principalTable: "Staffs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StaffApp_Staffs_StaffId",
                table: "StaffApp");

            migrationBuilder.RenameColumn(
                name: "StaffId",
                table: "StaffApp",
                newName: "DevId");

            migrationBuilder.RenameIndex(
                name: "IX_StaffApp_StaffId",
                table: "StaffApp",
                newName: "IX_StaffApp_DevId");

            migrationBuilder.AddForeignKey(
                name: "FK_StaffApp_Staffs_DevId",
                table: "StaffApp",
                column: "DevId",
                principalTable: "Staffs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
