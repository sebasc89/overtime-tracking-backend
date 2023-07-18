using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sistecredito.OvertimeTracking.Infrastructure.Migrations.ApplicationDb
{
    public partial class AreaLiderRelationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LeaderId",
                table: "Employees",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Employees_LeaderId",
                table: "Employees",
                column: "LeaderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Employees_LeaderId",
                table: "Employees",
                column: "LeaderId",
                principalTable: "Employees",
                principalColumn: "EmployeeId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Employees_LeaderId",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_LeaderId",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "LeaderId",
                table: "Employees");
        }
    }
}
