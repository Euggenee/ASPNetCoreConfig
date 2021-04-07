using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class ComputerModelTagNew : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ComputerModelTags",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TageName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TagMeta = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TagExpiration = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ComputerModelId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComputerModelTags", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ComputerModelTags_ComputerModels_ComputerModelId",
                        column: x => x.ComputerModelId,
                        principalTable: "ComputerModels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ComputerModelTags_ComputerModelId",
                table: "ComputerModelTags",
                column: "ComputerModelId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ComputerModelTags");
        }
    }
}
