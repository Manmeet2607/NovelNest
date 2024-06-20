using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NovelNest.Migrations
{
    /// <inheritdoc />
    public partial class AddCompanyRecords : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "Id", "City", "Name", "PhoneNumber", "PostalCode", "State", "StreetAddress" },
                values: new object[,]
                {
                    { 1, "cali", "Anna", "8748593759", "1334032", "ram", "Helix" },
                    { 2, "bramp", "Leo", "338653822", "283848", "finxer", "Bienans" },
                    { 3, "whaels", "Shirley", "32837937947", "284828", "colava", "sndbbam" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
