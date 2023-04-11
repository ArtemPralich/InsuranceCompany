using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace InsuranceCompany.Core.Migrations
{
    /// <inheritdoc />
    public partial class updateinsSurvey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                    { "19c32ba4-e2ba-4e10-bc6c-4a68c383d64c", "c55f0b44-80c5-47d1-b9c0-4fbb0bf48ce2", "Client", "CLIENT" },
                    { "85f2c4a4-4a6a-460e-829d-617edd453283", "0f1fcf70-3f60-4d39-9449-ab4cf02d259b", "Administrator", "ADMINISTRATOR" },
                    { "cd4b3525-bf24-4fd2-a957-49e837014a08", "9d97d6e2-3005-470d-9e85-aa63b7c2ae4b", "Agent", "AGENT" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "19c32ba4-e2ba-4e10-bc6c-4a68c383d64c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "85f2c4a4-4a6a-460e-829d-617edd453283");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cd4b3525-bf24-4fd2-a957-49e837014a08");

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
    }
}
