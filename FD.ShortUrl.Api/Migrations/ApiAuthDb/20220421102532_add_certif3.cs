using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FD.ShortUrl.Api.Migrations.ApiAuthDb
{
    public partial class add_certif3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MyTitle",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MyTitle",
                table: "AspNetUsers");
        }
    }
}
