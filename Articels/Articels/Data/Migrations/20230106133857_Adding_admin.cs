using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Migrations;
using System.Collections.Generic;
using System.Security;

#nullable disable

namespace Articels.Data.Migrations
{
    public partial class Adding_admin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [Bio], [Birth], [FirstName], [ProfilePicture], [SecoundName]) VALUES (N'e3d837e6-8c30-4299-a817-fa793c71a405', N'khaledhelwane2@gmail.com', N'KHALEDHELWANE2@GMAIL.COM', N'khaledhelwane2@gmail.com', N'KHALEDHELWANE2@GMAIL.COM', 0, N'AQAAAAEAACcQAAAAECjpYzPWhgZh3uN4WUp7zdg1I6kkXPMLTee2TmnlxjYVeNzR6v/jm0j6q8zbpxMYww==', N'6IITWNNXFYSRX4SJ3S6MDPAMNMLLIRFR', N'e675cb83-b4be-4fdc-8b79-384a5ad229f4', NULL, 0, 0, NULL, 1, 0, NULL, N'2023-01-11 00:00:00', N'khaled', null, N'khaledhelwane@gmail.com')");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("Delete From [dbo].[AspNetUsers] where id='e3d837e6-8c30-4299-a817-fa793c71a405'");
        
        }
    }
}
