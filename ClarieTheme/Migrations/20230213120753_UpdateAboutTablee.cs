using Microsoft.EntityFrameworkCore.Migrations;

namespace ClarieTheme.Migrations
{
    public partial class UpdateAboutTablee : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Teams",
                maxLength: 800,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "Teams");
        }
    }
}
