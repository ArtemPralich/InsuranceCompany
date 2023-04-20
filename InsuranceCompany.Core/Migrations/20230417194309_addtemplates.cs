using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace InsuranceCompany.Core.Migrations
{
    /// <inheritdoc />
    public partial class addtemplates : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "932d2f10-65a3-4a78-af75-439538e7b529");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a81ba068-c219-41c5-a972-d64b02a5e8db");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bc4e890a-4f38-4ef1-811d-9e97e1272438");

            migrationBuilder.CreateTable(
                name: "Template",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Template__3214EC0715E303CD", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "401c8922-0e44-48c8-8d9a-ca91029ffe25", "eccc8510-908f-4391-9699-eda4aa11e607", "Client", "CLIENT" },
                    { "80fceda2-807c-49dd-8862-afeb38331360", "6f7d3d8e-82de-44ea-9d36-1a6862bf190b", "Administrator", "ADMINISTRATOR" },
                    { "8568126d-89c6-41fc-a92c-d2ee37f4e218", "e1f0488c-1294-4561-bb69-0d647f43535f", "Agent", "AGENT" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Template");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "401c8922-0e44-48c8-8d9a-ca91029ffe25");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "80fceda2-807c-49dd-8862-afeb38331360");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8568126d-89c6-41fc-a92c-d2ee37f4e218");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "932d2f10-65a3-4a78-af75-439538e7b529", "7409b612-c066-4ea2-8cac-2b8a73d01469", "Agent", "AGENT" },
                    { "a81ba068-c219-41c5-a972-d64b02a5e8db", "fa0e7647-ffcb-443c-b875-442ed69d4c09", "Administrator", "ADMINISTRATOR" },
                    { "bc4e890a-4f38-4ef1-811d-9e97e1272438", "c12ce802-da20-4300-b6ab-505800254a6f", "Client", "CLIENT" }
                });
        }
    }
}
