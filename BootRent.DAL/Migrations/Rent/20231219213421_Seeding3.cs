using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BootRent.DAL.Migrations.Rent
{
    /// <inheritdoc />
    public partial class Seeding3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Packages_Reservations_Id",
                table: "Packages");

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

            migrationBuilder.AddColumn<Guid>(
                name: "PackageId",
                table: "Reservations",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "ReservationId",
                table: "Packages",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.InsertData(
                table: "Boots",
                columns: new[] { "Id", "BootName", "CreatedAt", "IsAvailable", "Manufacturer", "ProductionYear" },
                values: new object[,]
                {
                    { new Guid("549b92b0-0be0-4d70-ab28-3eeb92cba05e"), "BootName1", new DateTime(2022, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Manufacturer1", 2009 },
                    { new Guid("81f28fe4-4b11-4425-af9b-41812f92398d"), "BootName2", new DateTime(2018, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Manufacturer2", 2004 },
                    { new Guid("8ca42489-2d55-4e18-980c-9d20e2cf6dc5"), "BootName1", new DateTime(2015, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), true, "Manufacturer1", 1999 }
                });

            migrationBuilder.InsertData(
                table: "Packages",
                columns: new[] { "Id", "Description", "PackageName", "Price", "ReservationId" },
                values: new object[,]
                {
                    { new Guid("304becc9-220e-4e30-b0fb-a02d77ace21a"), "Perfect for hosting events and parties", "Party Package", 1000.00m, new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("3192fb4f-d0aa-4335-bc81-22f1131af0da"), "Perfect for weddings events and parties", "Wedding Package", 1500.00m, new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("3e3a53f4-02ef-4d97-822a-886ee8f8abf4"), "Celebrate your birthday with style", "Birthday", 800.00m, new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("572c67d2-e7cf-465e-ad96-c5e63cddc6ac"), "Celebrate your birthday with style", "Birthday Package", 800.00m, new Guid("00000000-0000-0000-0000-000000000000") }
                });

            migrationBuilder.InsertData(
                table: "Reservations",
                columns: new[] { "Id", "BootId", "CheckInDate", "CheckOutDate", "PackageId" },
                values: new object[,]
                {
                    { new Guid("1d104082-d1bc-4c38-8152-e98baaebdcd4"), new Guid("81f28fe4-4b11-4425-af9b-41812f92398d"), new DateTime(2023, 12, 20, 0, 34, 21, 395, DateTimeKind.Local).AddTicks(2093), new DateTime(2023, 12, 30, 0, 34, 21, 395, DateTimeKind.Local).AddTicks(2094), new Guid("304becc9-220e-4e30-b0fb-a02d77ace21a") },
                    { new Guid("663a064c-e2dc-45f3-a86e-7ceea14c6bb1"), new Guid("8ca42489-2d55-4e18-980c-9d20e2cf6dc5"), new DateTime(2023, 12, 20, 0, 34, 21, 395, DateTimeKind.Local).AddTicks(2073), new DateTime(2024, 1, 4, 0, 34, 21, 395, DateTimeKind.Local).AddTicks(2084), new Guid("572c67d2-e7cf-465e-ad96-c5e63cddc6ac") },
                    { new Guid("f907b552-0bbf-4f8a-9d7b-dd6756d53e99"), new Guid("549b92b0-0be0-4d70-ab28-3eeb92cba05e"), new DateTime(2023, 12, 20, 0, 34, 21, 395, DateTimeKind.Local).AddTicks(2097), new DateTime(2024, 1, 9, 0, 34, 21, 395, DateTimeKind.Local).AddTicks(2098), new Guid("3e3a53f4-02ef-4d97-822a-886ee8f8abf4") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Packages_ReservationId",
                table: "Packages",
                column: "ReservationId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Packages_Reservations_ReservationId",
                table: "Packages",
                column: "ReservationId",
                principalTable: "Reservations",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Packages_Reservations_ReservationId",
                table: "Packages");

            migrationBuilder.DropIndex(
                name: "IX_Packages_ReservationId",
                table: "Packages");

            migrationBuilder.DeleteData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: new Guid("304becc9-220e-4e30-b0fb-a02d77ace21a"));

            migrationBuilder.DeleteData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: new Guid("3192fb4f-d0aa-4335-bc81-22f1131af0da"));

            migrationBuilder.DeleteData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: new Guid("3e3a53f4-02ef-4d97-822a-886ee8f8abf4"));

            migrationBuilder.DeleteData(
                table: "Packages",
                keyColumn: "Id",
                keyValue: new Guid("572c67d2-e7cf-465e-ad96-c5e63cddc6ac"));

            migrationBuilder.DeleteData(
                table: "Reservations",
                keyColumn: "Id",
                keyValue: new Guid("1d104082-d1bc-4c38-8152-e98baaebdcd4"));

            migrationBuilder.DeleteData(
                table: "Reservations",
                keyColumn: "Id",
                keyValue: new Guid("663a064c-e2dc-45f3-a86e-7ceea14c6bb1"));

            migrationBuilder.DeleteData(
                table: "Reservations",
                keyColumn: "Id",
                keyValue: new Guid("f907b552-0bbf-4f8a-9d7b-dd6756d53e99"));

            migrationBuilder.DeleteData(
                table: "Boots",
                keyColumn: "Id",
                keyValue: new Guid("549b92b0-0be0-4d70-ab28-3eeb92cba05e"));

            migrationBuilder.DeleteData(
                table: "Boots",
                keyColumn: "Id",
                keyValue: new Guid("81f28fe4-4b11-4425-af9b-41812f92398d"));

            migrationBuilder.DeleteData(
                table: "Boots",
                keyColumn: "Id",
                keyValue: new Guid("8ca42489-2d55-4e18-980c-9d20e2cf6dc5"));

            migrationBuilder.DropColumn(
                name: "PackageId",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "ReservationId",
                table: "Packages");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Packages_Reservations_Id",
                table: "Packages",
                column: "Id",
                principalTable: "Reservations",
                principalColumn: "Id");
        }
    }
}
