using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace InsuranceCompany.Core.Migrations
{
    /// <inheritdoc />
    public partial class updateRRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "94b43fba-5ea8-4f97-98a6-c6a8357b6d75", "a6bb7686-6de9-4ec7-b651-6997c862f4be", "Agent", "AGENT" },
                    { "a0c36768-8ce1-4c64-ab84-376b543e078b", "4dfac839-de7b-4d44-acef-8a06e1574842", "Client", "CLIENT" },
                    { "fa2a729b-2a03-4b53-aba8-802b4af4f648", "b0d38392-28a7-42ed-b744-db4f455baca5", "Administrator", "ADMINISTRATOR" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "94b43fba-5ea8-4f97-98a6-c6a8357b6d75");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a0c36768-8ce1-4c64-ab84-376b543e078b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fa2a729b-2a03-4b53-aba8-802b4af4f648");

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
    }
}
