using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace InsuranceCompany.Core.Migrations
{
    /// <inheritdoc />
    public partial class UpdateInsuranceSurvey1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6e06f1cf-29a8-4d7e-ab36-f12e007116e0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7256ba30-656f-4ea3-9f9e-6027fb39ef0e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9ea2a451-7a24-4917-8fe8-62008360e18c");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "554fabd3-9316-436d-bc21-78021e18fb2b", "c3a4b195-99c0-41b5-9e59-ba42bd997b6b", "Agent", "AGENT" },
                    { "d45432cf-6d8e-40d6-82ca-cdf9f2d33c20", "5182df21-b5d6-4974-bd38-a2e423c0fc66", "Client", "CLIENT" },
                    { "f92c278a-ed31-48e0-97a5-0b76ecea083d", "1b37cebe-a19b-40db-a832-e72e93a26d32", "Administrator", "ADMINISTRATOR" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "554fabd3-9316-436d-bc21-78021e18fb2b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d45432cf-6d8e-40d6-82ca-cdf9f2d33c20");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f92c278a-ed31-48e0-97a5-0b76ecea083d");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "6e06f1cf-29a8-4d7e-ab36-f12e007116e0", "c49f1013-8e88-4501-adf2-bd846a1a6df1", "Agent", "AGENT" },
                    { "7256ba30-656f-4ea3-9f9e-6027fb39ef0e", "4066b0f8-06e7-4c98-bbb5-97cb6685ad76", "Administrator", "ADMINISTRATOR" },
                    { "9ea2a451-7a24-4917-8fe8-62008360e18c", "a2530838-be98-40e3-bef9-13e74f01ec3c", "Client", "CLIENT" }
                });
        }
    }
}
