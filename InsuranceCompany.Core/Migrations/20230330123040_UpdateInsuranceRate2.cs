using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace InsuranceCompany.Core.Migrations
{
    /// <inheritdoc />
    public partial class UpdateInsuranceRate2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0855dcb0-1a5b-4221-90e1-cc467db58a6c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "20cd0793-5166-4db1-8d43-d67b4bec8d70");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e82e90dd-1de2-4aa2-bb84-feec68c21e0b");

            migrationBuilder.AddColumn<bool>(
                name: "IsFamily",
                table: "InsuranceRate",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsOldman",
                table: "InsuranceRate",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsPersonal",
                table: "InsuranceRate",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "InsuranceRate",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "446d0998-f14b-42a1-a15b-db81f64320f4", "e562230d-ba82-4a8b-86b3-b24196514c6c", "Client", "CLIENT" },
                    { "7b078f0c-ac68-4dbb-838b-a408ebadb8d4", "be4db473-9f3b-45f3-8922-0612f87b16fb", "Administrator", "ADMINISTRATOR" },
                    { "d622b811-48e8-46ab-b539-234fc67a797d", "e51d7a73-2cbc-4e77-8765-e8b19c16dfa9", "Agent", "AGENT" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "446d0998-f14b-42a1-a15b-db81f64320f4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7b078f0c-ac68-4dbb-838b-a408ebadb8d4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d622b811-48e8-46ab-b539-234fc67a797d");

            migrationBuilder.DropColumn(
                name: "IsFamily",
                table: "InsuranceRate");

            migrationBuilder.DropColumn(
                name: "IsOldman",
                table: "InsuranceRate");

            migrationBuilder.DropColumn(
                name: "IsPersonal",
                table: "InsuranceRate");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "InsuranceRate");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0855dcb0-1a5b-4221-90e1-cc467db58a6c", "eae1e340-13f4-45c2-879d-91074da258d7", "Client", "CLIENT" },
                    { "20cd0793-5166-4db1-8d43-d67b4bec8d70", "46daf703-0264-4e6d-9221-c3a6a6c67ea1", "Agent", "AGENT" },
                    { "e82e90dd-1de2-4aa2-bb84-feec68c21e0b", "60a5cc53-38c5-4e68-b66c-aa6933ada3e9", "Administrator", "ADMINISTRATOR" }
                });
        }
    }
}
