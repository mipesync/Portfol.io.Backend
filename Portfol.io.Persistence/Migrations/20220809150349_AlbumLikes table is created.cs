using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Portfol.io.Persistence.Migrations
{
    public partial class AlbumLikestableiscreated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsLiked",
                table: "Albums");

            migrationBuilder.DropColumn(
                name: "Likes",
                table: "Albums");

            migrationBuilder.AlterColumn<DateOnly>(
                name: "DateOfBirth",
                table: "Users",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AddColumn<string>(
                name: "VerifyCode",
                table: "Users",
                type: "character varying(6)",
                maxLength: 6,
                nullable: true);

            migrationBuilder.CreateTable(
                name: "AlbumLikes",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    AlbumId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlbumLikes", x => new { x.UserId, x.AlbumId });
                    table.ForeignKey(
                        name: "FK_AlbumLikes_Albums_AlbumId",
                        column: x => x.AlbumId,
                        principalTable: "Albums",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AlbumLikes_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AlbumLikes_AlbumId",
                table: "AlbumLikes",
                column: "AlbumId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AlbumLikes");

            migrationBuilder.DropColumn(
                name: "VerifyCode",
                table: "Users");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateOfBirth",
                table: "Users",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateOnly),
                oldType: "date");

            migrationBuilder.AddColumn<bool>(
                name: "IsLiked",
                table: "Albums",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "Likes",
                table: "Albums",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
