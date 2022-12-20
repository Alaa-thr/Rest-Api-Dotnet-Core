using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace rest_api_dotnet_core.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("007772ce-ba6b-4071-b356-9503d92d166e"));

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("95a96afc-a1c1-4337-b0a7-a44d6a9f959d"));

            migrationBuilder.AlterColumn<string>(
                name: "Text",
                table: "Comments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "CreatedAt", "Text" },
                values: new object[] { new Guid("6d572d81-a649-4fc1-84ec-f43a9cdcbca1"), new DateTime(2022, 11, 17, 14, 1, 42, 754, DateTimeKind.Local).AddTicks(5806), "Le lorem ipsum est, en imprimerie, une suite de mots sans signification utilisée à titre provisoire pour calibrer une mise en page" });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "CreatedAt", "Text" },
                values: new object[] { new Guid("8c562f81-0360-4ddf-8c95-0088d2e4dcef"), new DateTime(2022, 11, 17, 14, 1, 42, 758, DateTimeKind.Local).AddTicks(6210), "Le lorem ipsum est, en imprimerie, une suite de mots sans signification utilisée" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("6d572d81-a649-4fc1-84ec-f43a9cdcbca1"));

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("8c562f81-0360-4ddf-8c95-0088d2e4dcef"));

            migrationBuilder.AlterColumn<string>(
                name: "Text",
                table: "Comments",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "CreatedAt", "Text" },
                values: new object[] { new Guid("95a96afc-a1c1-4337-b0a7-a44d6a9f959d"), new DateTime(2022, 11, 13, 23, 28, 39, 385, DateTimeKind.Local).AddTicks(878), "Le lorem ipsum est, en imprimerie, une suite de mots sans signification utilisée à titre provisoire pour calibrer une mise en page" });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "CreatedAt", "Text" },
                values: new object[] { new Guid("007772ce-ba6b-4071-b356-9503d92d166e"), new DateTime(2022, 11, 13, 23, 28, 39, 388, DateTimeKind.Local).AddTicks(3518), "Le lorem ipsum est, en imprimerie, une suite de mots sans signification utilisée" });
        }
    }
}
