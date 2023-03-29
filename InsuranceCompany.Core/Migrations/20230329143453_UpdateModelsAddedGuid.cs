using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace InsuranceCompany.Core.Migrations
{
    /// <inheritdoc />
    public partial class UpdateModelsAddedGuid : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "36689391-9f9b-4bff-bf66-0d191a928693");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9baaa896-0b3a-489e-b898-2cf0c0133249");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dcea560b-9a6a-46a2-b1cf-37d56d508341");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "36689391-9f9b-4bff-bf66-0d191a928693", "492f8e1a-0ad4-4239-a68e-a7578dba98cf", "Agent", "AGENT" },
                    { "9baaa896-0b3a-489e-b898-2cf0c0133249", "205a28f5-66bd-4fdc-98fe-e3547fe6fe04", "Client", "CLIENT" },
                    { "dcea560b-9a6a-46a2-b1cf-37d56d508341", "708da0e9-2b1a-4573-be56-839c5b981b6d", "Administrator", "ADMINISTRATOR" }
                });
        }
    }
}
