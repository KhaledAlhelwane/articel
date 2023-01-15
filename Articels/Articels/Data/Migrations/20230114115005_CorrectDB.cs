using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Articels.Data.Migrations
{
    public partial class CorrectDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Articels_Comments_Commentid",
                table: "Articels");

            migrationBuilder.DropForeignKey(
                name: "FK_Articels_Openines_openinesid",
                table: "Articels");

            migrationBuilder.DropIndex(
                name: "IX_Articels_Commentid",
                table: "Articels");

            migrationBuilder.DropIndex(
                name: "IX_Articels_openinesid",
                table: "Articels");

            migrationBuilder.DropColumn(
                name: "Commentid",
                table: "Articels");

            migrationBuilder.DropColumn(
                name: "openinesid",
                table: "Articels");

            migrationBuilder.AddColumn<int>(
                name: "Articelssid",
                table: "Openines",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Articelssid",
                table: "Comments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Openines_Articelssid",
                table: "Openines",
                column: "Articelssid");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_Articelssid",
                table: "Comments",
                column: "Articelssid");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Articels_Articelssid",
                table: "Comments",
                column: "Articelssid",
                principalTable: "Articels",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Openines_Articels_Articelssid",
                table: "Openines",
                column: "Articelssid",
                principalTable: "Articels",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Articels_Articelssid",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Openines_Articels_Articelssid",
                table: "Openines");

            migrationBuilder.DropIndex(
                name: "IX_Openines_Articelssid",
                table: "Openines");

            migrationBuilder.DropIndex(
                name: "IX_Comments_Articelssid",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "Articelssid",
                table: "Openines");

            migrationBuilder.DropColumn(
                name: "Articelssid",
                table: "Comments");

            migrationBuilder.AddColumn<int>(
                name: "Commentid",
                table: "Articels",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "openinesid",
                table: "Articels",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Articels_Commentid",
                table: "Articels",
                column: "Commentid");

            migrationBuilder.CreateIndex(
                name: "IX_Articels_openinesid",
                table: "Articels",
                column: "openinesid");

            migrationBuilder.AddForeignKey(
                name: "FK_Articels_Comments_Commentid",
                table: "Articels",
                column: "Commentid",
                principalTable: "Comments",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Articels_Openines_openinesid",
                table: "Articels",
                column: "openinesid",
                principalTable: "Openines",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
