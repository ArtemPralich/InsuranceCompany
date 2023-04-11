using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace InsuranceCompany.Core.Migrations
{
    /// <inheritdoc />
    public partial class updateQuestionType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                    { "343a739a-b77c-4355-bf0c-91c5c85e1285", "a6de8211-d3da-4ee9-9263-6d17a04ee0d2", "Administrator", "ADMINISTRATOR" },
                    { "3d6e68e9-09f7-4464-93d9-b9fbd75f6671", "23aed36f-70b0-4499-89cb-c749fd2ee533", "Agent", "AGENT" },
                    { "bced3df3-caa1-4366-9f13-e4894b5550cc", "b8256b3a-af59-4bf0-abb1-dfcb62e0ab3b", "Client", "CLIENT" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "343a739a-b77c-4355-bf0c-91c5c85e1285");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3d6e68e9-09f7-4464-93d9-b9fbd75f6671");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bced3df3-caa1-4366-9f13-e4894b5550cc");

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
    }
}
