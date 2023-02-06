using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GDi.WinterAcademy.Demo.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedInitialData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Actors",
                columns: new[] { "Id", "DateOfBirth", "Name", "Nationality" },
                values: new object[,]
                {
                    { 1L, new DateTime(1947, 7, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Arnold Schwarzenegger", "Austrian-American" },
                    { 2L, new DateTime(1978, 6, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Zoe Salanda", "American" }
                });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "Duration", "MainCharacterId", "ReleaseDate", "Title" },
                values: new object[,]
                {
                    { 1L, 107, 1L, new DateTime(1984, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Terminator" },
                    { 2L, 107, 1L, new DateTime(1987, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Predator" },
                    { 3L, 192, 2L, new DateTime(2022, 12, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Avatar: The Way of Water" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: 2L);
        }
    }
}
