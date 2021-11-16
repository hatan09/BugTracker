using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BugTracker.Core.Migrations
{
    public partial class editguidtype : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Companies_Guid",
                table: "Companies");

            migrationBuilder.AlterColumn<Guid>(
                name: "Guid",
                table: "Companies",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Companies_Guid",
                table: "Companies",
                column: "Guid",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Companies_Guid",
                table: "Companies");

            migrationBuilder.AlterColumn<string>(
                name: "Guid",
                table: "Companies",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.CreateIndex(
                name: "IX_Companies_Guid",
                table: "Companies",
                column: "Guid",
                unique: true,
                filter: "[Guid] IS NOT NULL");
        }
    }
}
