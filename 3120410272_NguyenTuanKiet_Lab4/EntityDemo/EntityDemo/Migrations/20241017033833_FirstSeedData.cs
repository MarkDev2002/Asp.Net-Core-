using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EntityDemo.Migrations
{
    /// <inheritdoc />
    public partial class FirstSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "IsActive", "Name" },
                values: new object[,]
                {
                    { 1, true, "Fiction" },
                    { 2, true, "Non-Fiction" },
                    { 3, true, "Science Fiction" },
                    { 4, true, "Biography" }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Author", "Available", "Code", "Cost", "CreatedOn", "Description", "GenreId", "IsActive", "Publisher", "Title" },
                values: new object[,]
                {
                    { 1, "F. Scott Fitzgerald", 10, "B001", 10.99m, new DateTime(2024, 10, 17, 10, 38, 32, 742, DateTimeKind.Local).AddTicks(2479), "A novel about the American dream.", 1, true, "Scribner", "The Great Gatsby" },
                    { 2, "Michelle Obama", 5, "B002", 12.99m, new DateTime(2024, 10, 17, 10, 38, 32, 742, DateTimeKind.Local).AddTicks(2497), "A memoir by the former First Lady of the United States.", 4, true, "Crown Publishing Group", "Becoming" }
                });

            migrationBuilder.InsertData(
                table: "BookImages",
                columns: new[] { "Id", "BookId", "Name" },
                values: new object[,]
                {
                    { 1, 1, "great_gatsby.jpg" },
                    { 2, 2, "becoming.jpg" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "BookImages",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "BookImages",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
