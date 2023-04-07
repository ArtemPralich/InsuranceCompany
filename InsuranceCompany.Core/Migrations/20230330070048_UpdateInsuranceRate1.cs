using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace InsuranceCompany.Core.Migrations
{
    /// <inheritdoc />
    public partial class UpdateInsuranceRate1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0d2dd666-f721-4b1b-aec1-25dbc5732bbe");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9a9137e4-fc2c-41de-a6af-0c7c8e7006b8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c5663649-aa4a-4a57-83c6-4eebe9d7fe45");

            migrationBuilder.AddColumn<decimal>(
                name: "Cost",
                table: "InsuranceRate",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<short>(
                name: "CountPaymentsInYear",
                table: "InsuranceRate",
                type: "smallint",
                nullable: true);

            migrationBuilder.AddColumn<short>(
                name: "CountYears",
                table: "InsuranceRate",
                type: "smallint",
                nullable: true);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "Cost",
                table: "InsuranceRate");

            migrationBuilder.DropColumn(
                name: "CountPaymentsInYear",
                table: "InsuranceRate");

            migrationBuilder.DropColumn(
                name: "CountYears",
                table: "InsuranceRate");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0d2dd666-f721-4b1b-aec1-25dbc5732bbe", "6dc1d53d-d6a1-4dee-b218-85dc0523288e", "Administrator", "ADMINISTRATOR" },
                    { "9a9137e4-fc2c-41de-a6af-0c7c8e7006b8", "e95c7bb3-5a04-48c1-834e-33a45e3db062", "Client", "CLIENT" },
                    { "c5663649-aa4a-4a57-83c6-4eebe9d7fe45", "b725f788-4710-49e6-bb17-538b6c9262a6", "Agent", "AGENT" }
                });
        }
    }
}
