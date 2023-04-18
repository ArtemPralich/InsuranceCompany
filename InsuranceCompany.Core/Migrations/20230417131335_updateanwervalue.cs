using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace InsuranceCompany.Core.Migrations
{
    /// <inheritdoc />
    public partial class updateanwervalue : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "297a11ad-cf46-4dc5-9bb9-e4af9eeef182");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bf846a24-d43a-4ca0-adab-59c3bb9a7f5e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cd51b1aa-d268-4349-926c-7c0e6e428e9d");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "99d94e09-4f4c-4dea-842a-63c4965bdec3", "d66033ec-5064-483b-b678-de9d7d46443f", "Client", "CLIENT" },
                    { "e47c5cd1-d4a5-46b8-bd9f-4d08c48645d6", "bee71ef5-13e5-4cd8-8bf6-5b22a040a1ea", "Agent", "AGENT" },
                    { "f0b607b9-1998-4eff-afb9-639dced0bc51", "8e09cc95-83e8-4500-b6f7-8baf2b97fb39", "Administrator", "ADMINISTRATOR" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "99d94e09-4f4c-4dea-842a-63c4965bdec3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e47c5cd1-d4a5-46b8-bd9f-4d08c48645d6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f0b607b9-1998-4eff-afb9-639dced0bc51");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "297a11ad-cf46-4dc5-9bb9-e4af9eeef182", "340a19b6-8bc6-4e5a-b149-6c274373ac26", "Agent", "AGENT" },
                    { "bf846a24-d43a-4ca0-adab-59c3bb9a7f5e", "3c8c6987-fcbb-456f-8da0-bb47bc048e8c", "Administrator", "ADMINISTRATOR" },
                    { "cd51b1aa-d268-4349-926c-7c0e6e428e9d", "c5a9a9dd-1fb7-49fa-b3fa-26ee1b0c7055", "Client", "CLIENT" }
                });
        }
    }
}
