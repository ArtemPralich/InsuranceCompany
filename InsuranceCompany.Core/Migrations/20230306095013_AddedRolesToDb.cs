using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace InsuranceCompany.Core.Migrations
{
    /// <inheritdoc />
    public partial class AddedRolesToDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "21f4b85a-2c18-4088-8101-f8ec6faeb8e4", "6eac07e4-9bd7-4c14-8320-35c8635140d5", "Administrator", "ADMINISTRATOR" },
                    { "855ebd85-a883-4d7a-bce0-f8c81327f180", "c67add17-69b8-41ff-ae07-dbc1f2a46569", "Agent", "AGENT" },
                    { "f7837fbd-7e0d-46e5-aa8e-21435cc4d702", "b961a22f-b8d3-4fd9-b96e-621755209c2b", "Client", "CLIENT" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "21f4b85a-2c18-4088-8101-f8ec6faeb8e4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "855ebd85-a883-4d7a-bce0-f8c81327f180");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f7837fbd-7e0d-46e5-aa8e-21435cc4d702");
        }
    }
}
