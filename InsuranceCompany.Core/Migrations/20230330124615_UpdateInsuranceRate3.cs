using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace InsuranceCompany.Core.Migrations
{
    /// <inheritdoc />
    public partial class UpdateInsuranceRate3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                name: "BasePayment",
                table: "InsuranceRate");

            migrationBuilder.DropColumn(
                name: "Cost",
                table: "InsuranceRate");

            migrationBuilder.DropColumn(
                name: "UnitPayment",
                table: "InsuranceRate");

            migrationBuilder.AddColumn<decimal>(
                name: "BasePayment",
                table: "InsuranceRequest",
                type: "money",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "UnitPayment",
                table: "InsuranceRequest",
                type: "money",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "25c8331e-c5cc-4133-a808-d2c4e2dcf97d", "6e2f33a7-0107-4a22-ad91-749a93894a4b", "Administrator", "ADMINISTRATOR" },
                    { "6eb87755-9da9-4ec0-b66d-2f0e16adf32a", "39e3e71d-aa4b-49d3-b448-a7f32ca517e8", "Client", "CLIENT" },
                    { "c3eac066-06b8-4512-af85-6036bd40f3bd", "7fab7d13-a37c-42b6-9839-81e6065e3985", "Agent", "AGENT" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "25c8331e-c5cc-4133-a808-d2c4e2dcf97d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6eb87755-9da9-4ec0-b66d-2f0e16adf32a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c3eac066-06b8-4512-af85-6036bd40f3bd");

            migrationBuilder.DropColumn(
                name: "BasePayment",
                table: "InsuranceRequest");

            migrationBuilder.DropColumn(
                name: "UnitPayment",
                table: "InsuranceRequest");

            migrationBuilder.AddColumn<decimal>(
                name: "BasePayment",
                table: "InsuranceRate",
                type: "money",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Cost",
                table: "InsuranceRate",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "UnitPayment",
                table: "InsuranceRate",
                type: "money",
                nullable: true);

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
    }
}
