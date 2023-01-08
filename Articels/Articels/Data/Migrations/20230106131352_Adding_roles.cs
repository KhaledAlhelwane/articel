using Microsoft.CodeAnalysis.VisualBasic.Syntax;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Articels.Data.Migrations
{
    public partial class Adding_roles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                
                table: "AspNetRoles",
                columns: new[] { "Id","Name","NormalizedName","ConcurrencyStamp" },
                values:new object[] { "01422951-91c9-4289-8482-353f79dd1e2f", "Admin","Admin", "eaca4899-d2aa-4b79-aaa4-7b8a1e7953d4" }
                

                );
            migrationBuilder.InsertData(

            table: "AspNetRoles",
            columns: new[] { "Id","Name","NormalizedName","ConcurrencyStamp" },
            values: new object[] { "f97a4590-9ccf-47a7-989f-c85083768023", "User", "User", "f6639307-2e28-4879-be67-c7dc3c826955" }


            );

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM [dbo].[AspNetRoles]");
        }
    }
}
