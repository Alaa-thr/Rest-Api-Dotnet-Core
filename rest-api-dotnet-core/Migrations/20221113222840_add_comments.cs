using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace rest_api_dotnet_core.Migrations
{
    public partial class add_comments : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "CreatedAt", "Text" },
                values: new object[] { new Guid("95a96afc-a1c1-4337-b0a7-a44d6a9f959d"), new DateTime(2022, 11, 13, 23, 28, 39, 385, DateTimeKind.Local).AddTicks(878), "Le lorem ipsum est, en imprimerie, une suite de mots sans signification utilisée à titre provisoire pour calibrer une mise en page" });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "CreatedAt", "Text" },
                values: new object[] { new Guid("007772ce-ba6b-4071-b356-9503d92d166e"), new DateTime(2022, 11, 13, 23, 28, 39, 388, DateTimeKind.Local).AddTicks(3518), "Le lorem ipsum est, en imprimerie, une suite de mots sans signification utilisée" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comments");
        }
    }
}
