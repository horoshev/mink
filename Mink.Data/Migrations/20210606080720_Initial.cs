using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Mink.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Uris",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    OriginUri = table.Column<string>(type: "TEXT", nullable: false),
                    MinifiedUriKey = table.Column<string>(type: "TEXT", nullable: false),
                    QrImageUri = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Uris", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Uris");
        }
    }
}
