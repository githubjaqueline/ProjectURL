using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectURL.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "dbSetUrl",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    description = table.Column<string>(nullable: true),
                    shortURL = table.Column<string>(nullable: true),
                    longURL = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dbSetUrl", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "dbSetUrl");
        }
    }
}
