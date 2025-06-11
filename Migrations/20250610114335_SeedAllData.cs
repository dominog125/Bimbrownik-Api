using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Bimbrownik_API.Migrations
{
    /// <inheritdoc />
    public partial class SeedAllData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AlcoholCategories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("a1111111-1111-1111-1111-111111111111"), "Beer" },
                    { new Guid("b2222222-2222-2222-2222-222222222222"), "Wine" },
                    { new Guid("c3333333-3333-3333-3333-333333333333"), "Whisky" },
                    { new Guid("d4444444-4444-4444-4444-444444444444"), "Vodka" }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "AuthorId", "AuthorUserId", "Name", "PostId" },
                values: new object[,]
                {
                    { new Guid("07777777-7777-7777-7777-777777777777"), "f4d4g733-4h5e-9i0d-1e99-dddddddddddd", null, "Świetny wpis, dzięki!", new Guid("e5555555-5555-5555-5555-555555555555") },
                    { new Guid("08888888-8888-8888-8888-888888888888"), "f4d4g733-4h5e-9i0d-1e99-dddddddddddd", null, "Ciekawy temat, chętnie spróbuję.", new Guid("e5555555-5555-5555-5555-555555555555") },
                    { new Guid("09999999-9999-9999-9999-999999999999"), "f4d4g733-4h5e-9i0d-1e99-dddddddddddd", null, "Super rekomendacje.", new Guid("f6666666-6666-6666-6666-666666666666") }
                });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "AlcoholCategoryId", "AuthorId", "Description", "Name", "Title" },
                values: new object[,]
                {
                    { new Guid("e5555555-5555-5555-5555-555555555555"), new Guid("a1111111-1111-1111-1111-111111111111"), "f4d4g733-4h5e-9i0d-1e99-dddddddddddd", "Krótki przegląd piw z lokalnych browarów.", "Top 5 Craft Beers", "Moje ulubione piwa rzemieślnicze" },
                    { new Guid("f6666666-6666-6666-6666-666666666666"), new Guid("b2222222-2222-2222-2222-222222222222"), "e3c3f622-3f4d-7h8c-0d88-cccccccccccc", "Kilka propozycji win na urodziny i rocznice.", "Wina na specjalne okazje", "Polecane wina" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AlcoholCategories",
                keyColumn: "Id",
                keyValue: new Guid("c3333333-3333-3333-3333-333333333333"));

            migrationBuilder.DeleteData(
                table: "AlcoholCategories",
                keyColumn: "Id",
                keyValue: new Guid("d4444444-4444-4444-4444-444444444444"));

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("07777777-7777-7777-7777-777777777777"));

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("08888888-8888-8888-8888-888888888888"));

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: new Guid("09999999-9999-9999-9999-999999999999"));

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: new Guid("e5555555-5555-5555-5555-555555555555"));

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: new Guid("f6666666-6666-6666-6666-666666666666"));

            migrationBuilder.DeleteData(
                table: "AlcoholCategories",
                keyColumn: "Id",
                keyValue: new Guid("a1111111-1111-1111-1111-111111111111"));

            migrationBuilder.DeleteData(
                table: "AlcoholCategories",
                keyColumn: "Id",
                keyValue: new Guid("b2222222-2222-2222-2222-222222222222"));
        }
    }
}
