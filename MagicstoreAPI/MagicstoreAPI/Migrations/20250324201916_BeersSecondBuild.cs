using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MagicstoreAPI.Migrations
{
    /// <inheritdoc />
    public partial class BeersSecondBuild : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "cervezas",
                columns: new[] { "id", "estilo", "nombre", "pais" },
                values: new object[,]
                {
                    { 1, "IPA", "IPA Classic", "USA" },
                    { 2, "Ale", "Golden Ale", "UK" },
                    { 3, "Stout", "Stout Premium", "Ireland" },
                    { 4, "Lager", "Amber Lager", "Germany" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "cervezas",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "cervezas",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "cervezas",
                keyColumn: "id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "cervezas",
                keyColumn: "id",
                keyValue: 4);
        }
    }
}
