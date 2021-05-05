using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApp3.Data.Migrations
{
    public partial class newMigr : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "Route",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Community",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserName",
                table: "Route");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Community");
        }
    }
}
