using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Bimbrownik_API.Migrations.ApplicationAuthDb
{
    /// <inheritdoc />
    public partial class SeedAllData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "61999953-7b32-40ee-a4d1-0d3950381e70");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ebda820d-b993-40e3-b9cd-982db300eb48");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "c1a1f400-1d2b-4f5a-8b66-aaaaaaaaaaaa", null, "Admin", "ADMIN" },
                    { "d2b2f511-2e3c-5g6b-9c77-bbbbbbbbbbbb", null, "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "e3c3f622-3f4d-7h8c-0d88-cccccccccccc", 0, "973f48d8-ecda-4ba6-9aea-58b47ea32d63", "admin@localhost", true, false, null, "ADMIN@LOCALHOST", "ADMIN", "AQAAAAIAAYagAAAAEPtpG44P6Unds0nYI+DXHYetjN4uY/rwVoVFaKIXjk/VhHjUbzLB6qWweJOkG4S5Qg==", null, false, "335e5d2c-e9d4-4bbe-a933-3bcdcaf1d4b1", false, "admin" },
                    { "f4d4g733-4h5e-9i0d-1e99-dddddddddddd", 0, "da70e97e-8ecf-47ce-b813-7bc3c7ce3f4d", "user@localhost", true, false, null, "USER@LOCALHOST", "USER", "AQAAAAIAAYagAAAAEGR3upgnZWqvLDCay1GnUnZ9RA83BmCyfzkcwSkruR6yfSkiSzx8ZAkt3cCIiePIkA==", null, false, "a4c758df-c7b1-4390-b524-0b0c533e46fb", false, "user" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "c1a1f400-1d2b-4f5a-8b66-aaaaaaaaaaaa", "e3c3f622-3f4d-7h8c-0d88-cccccccccccc" },
                    { "d2b2f511-2e3c-5g6b-9c77-bbbbbbbbbbbb", "f4d4g733-4h5e-9i0d-1e99-dddddddddddd" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "c1a1f400-1d2b-4f5a-8b66-aaaaaaaaaaaa", "e3c3f622-3f4d-7h8c-0d88-cccccccccccc" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "d2b2f511-2e3c-5g6b-9c77-bbbbbbbbbbbb", "f4d4g733-4h5e-9i0d-1e99-dddddddddddd" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c1a1f400-1d2b-4f5a-8b66-aaaaaaaaaaaa");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d2b2f511-2e3c-5g6b-9c77-bbbbbbbbbbbb");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e3c3f622-3f4d-7h8c-0d88-cccccccccccc");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f4d4g733-4h5e-9i0d-1e99-dddddddddddd");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "61999953-7b32-40ee-a4d1-0d3950381e70", "61999953-7b32-40ee-a4d1-0d3950381e70", "User", "USER" },
                    { "ebda820d-b993-40e3-b9cd-982db300eb48", "ebda820d-b993-40e3-b9cd-982db300eb48", "Admin", "ADMIN" }
                });
        }
    }
}
