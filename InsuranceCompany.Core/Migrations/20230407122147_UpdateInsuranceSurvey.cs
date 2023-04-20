using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace InsuranceCompany.Core.Migrations
{
    /// <inheritdoc />
    public partial class UpdateInsuranceSurvey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3d0ee109-9a45-4fcc-aed1-68130bf33bfb");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d0278561-249b-48ec-8118-c7b7b1414e3c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f771835a-c9a5-4085-951f-0b5f52ebbae0");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                    { "3d0ee109-9a45-4fcc-aed1-68130bf33bfb", "4f61e3b5-c179-4591-b972-fd15c149209b", "Client", "CLIENT" },
                    { "d0278561-249b-48ec-8118-c7b7b1414e3c", "e4f84992-15de-4f24-93c1-83efecc4c1fb", "Agent", "AGENT" },
                    { "f771835a-c9a5-4085-951f-0b5f52ebbae0", "04798abc-b1a9-4cf7-9352-18e9716d0b9a", "Administrator", "ADMINISTRATOR" }
                });
        }
    }
}
