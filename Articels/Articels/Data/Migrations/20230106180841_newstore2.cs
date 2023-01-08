using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Articels.Data.Migrations
{
    public partial class newstore2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Articelsid",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Articels",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ArticelBody = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageOfArticel = table.Column<byte[]>(type: "varbinary(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Articels", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_Articelsid",
                table: "AspNetUsers",
                column: "Articelsid");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Articels_Articelsid",
                table: "AspNetUsers",
                column: "Articelsid",
                principalTable: "Articels",
                principalColumn: "id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Articels_Articelsid",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Articels");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_Articelsid",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Articelsid",
                table: "AspNetUsers");
        }
    }
}
