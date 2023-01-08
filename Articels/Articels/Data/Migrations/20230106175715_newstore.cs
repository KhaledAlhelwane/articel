using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Articels.Data.Migrations
{
    public partial class newstore : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("Insert INTO [dbo].[AspNetUserRoles](UserId,RoleId) SELECT 'e3d837e6-8c30-4299-a817-fa793c71a405',Id FROM [dbo].[AspNetRoles] ");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FORM [dbo].[AspNetUserRoles] WHERE UserId='e3d837e6-8c30-4299-a817-fa793c71a405'");

        }
    }
}
