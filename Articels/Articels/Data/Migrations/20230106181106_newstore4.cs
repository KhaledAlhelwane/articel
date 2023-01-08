using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Articels.Data.Migrations
{
    public partial class newstore4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Articels_Articelsid",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_Articelsid",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Articelsid",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "Articels",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Articels_ApplicationUserId",
                table: "Articels",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Articels_AspNetUsers_ApplicationUserId",
                table: "Articels",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Articels_AspNetUsers_ApplicationUserId",
                table: "Articels");

            migrationBuilder.DropIndex(
                name: "IX_Articels_ApplicationUserId",
                table: "Articels");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Articels");

            migrationBuilder.AddColumn<int>(
                name: "Articelsid",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

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
    }
}
