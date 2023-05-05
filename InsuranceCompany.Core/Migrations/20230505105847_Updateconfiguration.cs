using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace InsuranceCompany.Core.Migrations
{
    /// <inheritdoc />
    public partial class Updateconfiguration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "9582781d-96fd-494e-9ab5-8d3d2c6827b1", "a641ebdc-d6ff-4884-8963-f6559f063199", "Client", "CLIENT" },
                    { "96f46656-9606-48a1-a8ca-5f815eb26983", "aafd12dc-e43c-48b5-9fb2-32d587a516c5", "Agent", "AGENT" },
                    { "f3cc7c4d-354a-43d1-8a8a-aebf9964cf30", "20201f73-caf7-4fff-bd3b-13d8791d7616", "Administrator", "ADMINISTRATOR" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9582781d-96fd-494e-9ab5-8d3d2c6827b1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "96f46656-9606-48a1-a8ca-5f815eb26983");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f3cc7c4d-354a-43d1-8a8a-aebf9964cf30");
        }
    }
}
