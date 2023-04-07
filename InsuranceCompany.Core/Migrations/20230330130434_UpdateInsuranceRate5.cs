using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace InsuranceCompany.Core.Migrations
{
    /// <inheritdoc />
    public partial class UpdateInsuranceRate5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5090a80f-2878-4473-bb13-4a60678d6351");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "797924f5-571a-4c4f-9071-a24e28f12af4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "beec6c42-9ca6-46d6-9744-5df77b6d0bdf");

            migrationBuilder.DropColumn(
                name: "Coefficient",
                table: "InsuranceRate");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "64f15c0d-7bd4-4a2d-a41c-d0e247ea39b0", "c48da86a-006d-4d63-bff2-4f1a54f73d4f", "Agent", "AGENT" },
                    { "77941c5c-8364-4171-8e70-51118c72b15b", "80140682-a055-49d7-bafa-0897ead37337", "Client", "CLIENT" },
                    { "82c06cdc-b0d6-4959-b055-92454737e2b5", "64cb8e4f-a3b5-467a-b3b1-fb9cb55a8e5c", "Administrator", "ADMINISTRATOR" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "64f15c0d-7bd4-4a2d-a41c-d0e247ea39b0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "77941c5c-8364-4171-8e70-51118c72b15b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "82c06cdc-b0d6-4959-b055-92454737e2b5");

            migrationBuilder.AddColumn<decimal>(
                name: "Coefficient",
                table: "InsuranceRate",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "5090a80f-2878-4473-bb13-4a60678d6351", "eb98d5fc-0f37-4fd6-ae8e-ae72961ea7fe", "Client", "CLIENT" },
                    { "797924f5-571a-4c4f-9071-a24e28f12af4", "b672c89e-88ea-4aac-83b5-bdadc410a3d9", "Administrator", "ADMINISTRATOR" },
                    { "beec6c42-9ca6-46d6-9744-5df77b6d0bdf", "ed9121e4-4d5f-4c37-ab2d-a2c6cc8175d9", "Agent", "AGENT" }
                });
        }
    }
}
