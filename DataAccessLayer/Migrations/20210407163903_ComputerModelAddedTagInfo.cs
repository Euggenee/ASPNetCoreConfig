using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class ComputerModelAddedTagInfo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TagInfo",
                table: "ComputerModelTags",
                nullable:true); 

            migrationBuilder.Sql(@"
                UPDATE ComputerModelTags
                SET TagInfo = TageName + '_' + TagMeta + '_' + TagExpiration
            ");

            migrationBuilder.DropColumn(
                name: "TagExpiration",
                table: "ComputerModelTags");

            migrationBuilder.DropColumn(
                name: "TagMeta",
                table: "ComputerModelTags");

            migrationBuilder.DropColumn(
                name: "TageName",
                table: "ComputerModelTags");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TagInfo",
                table: "ComputerModelTags",
                newName: "TageName");

            migrationBuilder.AddColumn<string>(
                name: "TagExpiration",
                table: "ComputerModelTags",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TagMeta",
                table: "ComputerModelTags",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
