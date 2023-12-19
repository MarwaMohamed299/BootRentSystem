using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BootRent.DAL.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bb89e605-60e3-45e5-95b7-d3d28c7edb4d");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e5f93310-79b8-4f93-b376-847ec31f6e93");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f6225d74-504a-49cf-87ac-05ca3e32d0dd");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "City", "ConcurrencyStamp", "DisplayName", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "Otp", "OtpAge", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "State", "Street", "TwoFactorEnabled", "UserName", "UserType", "ZipCode" },
                values: new object[,]
                {
                    { "0e5c3dba-ce72-405c-8bdb-4dfc0f82f4e0", 0, "Egypt", "3b9ed32b-2ca1-4988-bcc3-432f6d73f16a", "SaraZaki", null, false, "Sara", "Zaki", false, null, null, null, null, null, null, null, false, "844511eb-e876-48ca-ba1c-37fe59e0e8ec", "Alex", "ALGomhorya", false, null, 2, "276" },
                    { "9a26fa92-4521-46c5-be3f-b1e91165260b", 0, "Egypt", "65237d61-7aba-4512-ae80-39b9ac5e94e7", "MohamedSamy", null, false, "Mohamed", "Samy", false, null, null, null, null, null, null, null, false, "910d16c2-70db-4171-8300-a489bf4e5cbd", "NorthCoast", "ALGomhorya", false, null, 1, "135" },
                    { "cb81a3e2-4c4e-4898-90fa-77afccab08dd", 0, "Egypt", "85db1a7e-83da-4ea4-9450-d0cd08d43504", "MarwaMohamed", null, false, "Marwa", "Mohamed", false, null, null, null, null, null, null, null, false, "24d9baa7-ba98-4526-9051-b9b0f87a3c64", "Cairo", "ALGomhorya", false, null, 0, "4521" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0e5c3dba-ce72-405c-8bdb-4dfc0f82f4e0");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9a26fa92-4521-46c5-be3f-b1e91165260b");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cb81a3e2-4c4e-4898-90fa-77afccab08dd");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "City", "ConcurrencyStamp", "DisplayName", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "Otp", "OtpAge", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "State", "Street", "TwoFactorEnabled", "UserName", "UserType", "ZipCode" },
                values: new object[,]
                {
                    { "bb89e605-60e3-45e5-95b7-d3d28c7edb4d", 0, "Egypt", "1a063baa-19a6-428d-8c13-757237741651", "MohamedSamy", null, false, "Mohamed", "Samy", false, null, null, null, null, null, null, null, false, "b0e4838e-cbd0-411e-85ea-c683a22f4d18", "NorthCoast", "ALGomhorya", false, null, 1, "135" },
                    { "e5f93310-79b8-4f93-b376-847ec31f6e93", 0, "Egypt", "31bbaccd-1597-40ea-88f6-49153349546e", "MarwaMohamed", null, false, "Marwa", "Mohamed", false, null, null, null, null, null, null, null, false, "c73b57ad-e938-4f14-99ec-b9d66f5ab925", "Cairo", "ALGomhorya", false, null, 0, "4521" },
                    { "f6225d74-504a-49cf-87ac-05ca3e32d0dd", 0, "Egypt", "40c24674-1d32-4ad5-bc06-10102ed3594b", "SaraZaki", null, false, "Sara", "Zaki", false, null, null, null, null, null, null, null, false, "c2bbe8a3-5d30-4389-a8da-f88bafbb6516", "Alex", "ALGomhorya", false, null, 2, "276" }
                });
        }
    }
}
