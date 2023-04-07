using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace InsuranceCompany.Core.Migrations
{
    /// <inheritdoc />
    public partial class UpdateInsuranceRate4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<decimal>(
                name: "Coefficient",
                table: "InsuranceRequest",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "BaseCoefficient",
                table: "InsuranceRate",
                type: "decimal(18,2)",
                nullable: true);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                table: "InsuranceRequest");

            migrationBuilder.DropColumn(
                name: "BaseCoefficient",
                table: "InsuranceRate");

            migrationBuilder.DropColumn(
                name: "Coefficient",
                table: "InsuranceRate");

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
    }
}
