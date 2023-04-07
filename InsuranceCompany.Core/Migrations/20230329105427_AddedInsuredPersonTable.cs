using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace InsuranceCompany.Core.Migrations
{
    /// <inheritdoc />
    public partial class AddedInsuredPersonTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "InsuredPerson",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsMainInsuredPerson = table.Column<bool>(type: "bit", nullable: false),
                    ClientId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    TypeRequestId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    InsuranceRequestId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InsuredPerson", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InsuredPerson_Client_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Client",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_InsuredPerson_InsuranceRequest_InsuranceRequestId",
                        column: x => x.InsuranceRequestId,
                        principalTable: "InsuranceRequest",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_InsuredPerson_TypeRequest_TypeRequestId",
                        column: x => x.TypeRequestId,
                        principalTable: "TypeRequest",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "07bdd71a-8ff2-403c-899a-c6f857cd2ccb", "ee038af0-3f10-4430-a38a-45743cd1ad18", "Agent", "AGENT" },
                    { "2035c693-2873-4df2-825c-4cface6c9923", "080df0b6-7c45-4beb-9379-6863be1e9f5c", "Client", "CLIENT" },
                    { "7fa321e9-486f-4ea6-b447-d45e840c6ad8", "ccce0d80-1084-4e74-bd91-9b18db4c60fa", "Administrator", "ADMINISTRATOR" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_InsuredPerson_ClientId",
                table: "InsuredPerson",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_InsuredPerson_InsuranceRequestId",
                table: "InsuredPerson",
                column: "InsuranceRequestId");

            migrationBuilder.CreateIndex(
                name: "IX_InsuredPerson_TypeRequestId",
                table: "InsuredPerson",
                column: "TypeRequestId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InsuredPerson");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "07bdd71a-8ff2-403c-899a-c6f857cd2ccb");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2035c693-2873-4df2-825c-4cface6c9923");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7fa321e9-486f-4ea6-b447-d45e840c6ad8");

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
    }
}
