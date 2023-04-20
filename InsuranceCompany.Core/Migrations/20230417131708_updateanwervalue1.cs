using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace InsuranceCompany.Core.Migrations
{
    /// <inheritdoc />
    public partial class updateanwervalue1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<Guid>(
                name: "InsuranceSurveyId",
                table: "AnswerValue",
                type: "uniqueidentifier",
                nullable: true);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "InsuranceSurveyId",
                table: "AnswerValue");

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
    }
}
