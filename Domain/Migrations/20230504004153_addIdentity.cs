using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Domain.Migrations
{
    public partial class addIdentity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "ad376a8f", "067e8013-5673-421d-a316-472934757ea3", "Admin", "Admin" },
                    { "bd586a8f", "17c53e81-59b2-438b-920c-c8dbd668be41", "Editor", "Editor" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "a18be9c0", 0, "efe032ff-633c-40f8-9cce-0a4e90020b68", "admin@gmail.com", false, false, null, "admin@gmail.com", "admin", "AQAAAAEAACcQAAAAELrEgu/uuCwhJU2zvEsGTJRmP4YpgbMYnkI7sELqI9jGGL6PxzrW4qcF/qGGe7GrlQ==", null, false, "", false, "admin" },
                    { "a50ze710", 0, "6adf8a19-0862-41db-96a1-d9e84794308f", "Administrator@gmail.com", false, false, null, "Administrator@gmail.com", "Administrator", "AQAAAAEAACcQAAAAEEkHwGkH5ieBYAFYKdoq2YaOhvp1QyZnM+FF1T9slWe2Cvfrg3A07wVMJHuidjWpgA==", null, false, "", false, "Administrator" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "ad376a8f", "a18be9c0" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "bd586a8f", "a50ze710" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "ad376a8f", "a18be9c0" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "bd586a8f", "a50ze710" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ad376a8f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bd586a8f");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a18be9c0");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a50ze710");
        }
    }
}
