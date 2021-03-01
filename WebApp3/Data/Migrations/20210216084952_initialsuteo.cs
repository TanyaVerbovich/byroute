using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApp3.Data.Migrations
{
    public partial class initialsuteo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Route",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    HowManyPlaces = table.Column<int>(nullable: false),
                    place = table.Column<string>(nullable: true),
                    datafrom = table.Column<DateTime>(nullable: false),
                    Price = table.Column<int>(nullable: false),
                    Telephone = table.Column<long>(nullable: false),
                    isFav = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Route", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Route");
        }
    }
}
