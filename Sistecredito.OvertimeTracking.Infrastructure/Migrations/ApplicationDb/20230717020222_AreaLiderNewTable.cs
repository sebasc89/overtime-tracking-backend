using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sistecredito.OvertimeTracking.Infrastructure.Migrations.ApplicationDb
{
    public partial class AreaLiderNewTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LeaderAreas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LeaderId = table.Column<int>(type: "int", nullable: false),
                    AreaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeaderAreas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LeaderAreas_Areas_AreaId",
                        column: x => x.AreaId,
                        principalTable: "Areas",
                        principalColumn: "AreaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LeaderAreas_Employees_LeaderId",
                        column: x => x.LeaderId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LeaderAreas_AreaId",
                table: "LeaderAreas",
                column: "AreaId");

            migrationBuilder.CreateIndex(
                name: "IX_LeaderAreas_LeaderId",
                table: "LeaderAreas",
                column: "LeaderId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LeaderAreas");
        }
    }
}
