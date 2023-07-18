using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sistecredito.OvertimeTracking.Infrastructure.Migrations.ApplicationDb
{
    public partial class AreaLiderNewPropierties : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "EndDate",
                table: "LeaderAreas",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "LeaderAreas",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "StartDate",
                table: "LeaderAreas",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EndDate",
                table: "LeaderAreas");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "LeaderAreas");

            migrationBuilder.DropColumn(
                name: "StartDate",
                table: "LeaderAreas");
        }
    }
}
