using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace InsuranceCompany.Core.Migrations
{
    /// <inheritdoc />
    public partial class InsuranceCost : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6dcf7c3f-8c18-4b9f-8e26-4bf1cdb56488");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a120e08d-c764-4fe6-9c92-33adcda9bb2c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cdba5dbf-c7a7-4b1b-987b-6195c0c7721a");

            migrationBuilder.AddColumn<decimal>(
                name: "Cost",
                table: "TypeRequest",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Cost",
                table: "InsuranceRequest",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "Cost",
                table: "TypeRequest");

            migrationBuilder.DropColumn(
                name: "Cost",
                table: "InsuranceRequest");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "6dcf7c3f-8c18-4b9f-8e26-4bf1cdb56488", "def72ce8-a710-4a93-9058-e65582d7dc82", "Agent", "AGENT" },
                    { "a120e08d-c764-4fe6-9c92-33adcda9bb2c", "bb8db009-3858-49c3-bd65-5b7713969464", "Client", "CLIENT" },
                    { "cdba5dbf-c7a7-4b1b-987b-6195c0c7721a", "bb121708-80ab-4955-9d90-9a6f453685d8", "Administrator", "ADMINISTRATOR" }
                });
        }
    }
}
