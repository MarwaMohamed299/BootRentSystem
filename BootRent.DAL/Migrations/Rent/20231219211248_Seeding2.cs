using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BootRent.DAL.Migrations.Rent
{
    /// <inheritdoc />
    public partial class Seeding2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Boots",
                columns: new[] { "Id", "BootName", "CreatedAt", "IsAvailable", "Manufacturer", "ProductionYear" },
                values: new object[,]
                {
                    { new Guid("19350dbc-3b7d-4279-81d5-d0de467d793f"), "BootName1", new DateTime(2015, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Manufacturer1", 1999 },
                    { new Guid("69a32e79-2dd8-4ffd-af6a-4aa870e7f62d"), "BootName1", new DateTime(2022, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Manufacturer1", 2009 },
                    { new Guid("a4727a9f-5218-45f6-ac11-3652862807e4"), "BootName2", new DateTime(2018, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Manufacturer2", 2004 }
                });

            migrationBuilder.InsertData(
                table: "Packages",
                columns: new[] { "Id", "Description", "PackageName", "Price" },
                values: new object[,]
                {
                    { new Guid("02ca7042-6dbd-46f8-ba44-3ec67876b056"), "Celebrate your birthday with style", "Birthday", 800.00m },
                    { new Guid("26f3bcb3-7d33-4027-a13d-669063071b34"), "Celebrate your birthday with style", "Birthday Package", 800.00m },
                    { new Guid("ca14a971-3c20-4020-9e0a-aa3cbd131b2f"), "Perfect for weddings events and parties", "Wedding Package", 1500.00m },
                    { new Guid("d709e572-be55-41fb-927f-9d962b6dd93a"), "Perfect for hosting events and parties", "Party Package", 1000.00m }
                });

            migrationBuilder.InsertData(
                table: "Reservations",
                columns: new[] { "Id", "BootId", "CheckInDate", "CheckOutDate" },
                values: new object[,]
                {
                    { new Guid("0519e3ac-4f8f-4d5d-91ad-6df05b296759"), new Guid("69a32e79-2dd8-4ffd-af6a-4aa870e7f62d"), new DateTime(2023, 12, 20, 0, 12, 48, 323, DateTimeKind.Local).AddTicks(1384), new DateTime(2024, 1, 9, 0, 12, 48, 323, DateTimeKind.Local).AddTicks(1385) },
                    { new Guid("3c7198a7-dbad-4b85-b631-34fda816fd56"), new Guid("19350dbc-3b7d-4279-81d5-d0de467d793f"), new DateTime(2023, 12, 20, 0, 12, 48, 323, DateTimeKind.Local).AddTicks(1353), new DateTime(2024, 1, 4, 0, 12, 48, 323, DateTimeKind.Local).AddTicks(1366) },
                    { new Guid("9b2775a8-1598-4696-adbe-025c6077acdf"), new Guid("a4727a9f-5218-45f6-ac11-3652862807e4"), new DateTime(2023, 12, 20, 0, 12, 48, 323, DateTimeKind.Local).AddTicks(1380), new DateTime(2023, 12, 30, 0, 12, 48, 323, DateTimeKind.Local).AddTicks(1381) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: new Guid("02ca7042-6dbd-46f8-ba44-3ec67876b056"));

            migrationBuilder.DeleteData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: new Guid("26f3bcb3-7d33-4027-a13d-669063071b34"));

            migrationBuilder.DeleteData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: new Guid("ca14a971-3c20-4020-9e0a-aa3cbd131b2f"));

            migrationBuilder.DeleteData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: new Guid("d709e572-be55-41fb-927f-9d962b6dd93a"));

            migrationBuilder.DeleteData(
                table: "Reservations",
                keyColumn: "Id",
                keyValue: new Guid("0519e3ac-4f8f-4d5d-91ad-6df05b296759"));

            migrationBuilder.DeleteData(
                table: "Reservations",
                keyColumn: "Id",
                keyValue: new Guid("3c7198a7-dbad-4b85-b631-34fda816fd56"));

            migrationBuilder.DeleteData(
                table: "Reservations",
                keyColumn: "Id",
                keyValue: new Guid("9b2775a8-1598-4696-adbe-025c6077acdf"));

            migrationBuilder.DeleteData(
                table: "Boots",
                keyColumn: "Id",
                keyValue: new Guid("19350dbc-3b7d-4279-81d5-d0de467d793f"));

            migrationBuilder.DeleteData(
                table: "Boots",
                keyColumn: "Id",
                keyValue: new Guid("69a32e79-2dd8-4ffd-af6a-4aa870e7f62d"));

            migrationBuilder.DeleteData(
                table: "Boots",
                keyColumn: "Id",
                keyValue: new Guid("a4727a9f-5218-45f6-ac11-3652862807e4"));
        }
    }
}
