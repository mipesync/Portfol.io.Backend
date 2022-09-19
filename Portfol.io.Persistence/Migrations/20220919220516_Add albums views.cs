using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Portfol.io.Persistence.Migrations
{
    public partial class Addalbumsviews : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Views",
                table: "Albums",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Views",
                table: "Albums");
        }
    }
}
