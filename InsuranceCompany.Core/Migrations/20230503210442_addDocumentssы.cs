using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace InsuranceCompany.Core.Migrations
{
    /// <inheritdoc />
    public partial class addDocumentssы : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.CreateTable(
                name: "Document",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Path = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InsuranceRequestId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    TemplateId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Document__3214EC070045678D", x => x.Id);
                    table.ForeignKey(
                        name: "FK__Insurance__Document__2F10007B",
                        column: x => x.InsuranceRequestId,
                        principalTable: "InsuranceRequest",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK__Template__Document__5CD6CB2B",
                        column: x => x.TemplateId,
                        principalTable: "Template",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Document_InsuranceRequestId",
                table: "Document",
                column: "InsuranceRequestId");

            migrationBuilder.CreateIndex(
                name: "IX_Document_TemplateId",
                table: "Document",
                column: "TemplateId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Document");

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
    }
}
