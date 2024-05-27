using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EquipmentManagement.Persistence.Migrations
{
    public partial class UpdateDomain : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Equipment_Project_ProjectName",
                table: "Equipment");

            migrationBuilder.DropIndex(
                name: "IX_Equipment_ProjectName",
                table: "Equipment");

            migrationBuilder.DropColumn(
                name: "ProjectName",
                table: "Equipment");

            migrationBuilder.CreateTable(
                name: "EquipmentProject",
                columns: table => new
                {
                    EquipmentsEquipmentId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProjectName = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EquipmentProject", x => new { x.EquipmentsEquipmentId, x.ProjectName });
                    table.ForeignKey(
                        name: "FK_EquipmentProject_Equipment_EquipmentsEquipmentId",
                        column: x => x.EquipmentsEquipmentId,
                        principalTable: "Equipment",
                        principalColumn: "EquipmentId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EquipmentProject_Project_ProjectName",
                        column: x => x.ProjectName,
                        principalTable: "Project",
                        principalColumn: "ProjectName",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EquipmentProject_ProjectName",
                table: "EquipmentProject",
                column: "ProjectName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EquipmentProject");

            migrationBuilder.AddColumn<string>(
                name: "ProjectName",
                table: "Equipment",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Equipment_ProjectName",
                table: "Equipment",
                column: "ProjectName");

            migrationBuilder.AddForeignKey(
                name: "FK_Equipment_Project_ProjectName",
                table: "Equipment",
                column: "ProjectName",
                principalTable: "Project",
                principalColumn: "ProjectName");
        }
    }
}
