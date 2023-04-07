using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace InsuranceCompany.Core.Migrations
{
    /// <inheritdoc />
    public partial class FixedSmallMistake : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InsuredPersons_TypeRequest_TypeRequestId",
                table: "InsuredPersons");

            migrationBuilder.DropIndex(
                name: "IX_InsuredPersons_TypeRequestId",
                table: "InsuredPersons");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "86e199ce-4427-48f9-99e6-329755496837");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8ec44015-5251-4b74-8a82-d474332ad30d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fec48949-9bd5-4ba0-b13f-7aa4d38fc2f2");

            migrationBuilder.DropColumn(
                name: "TypeRequestId",
                table: "InsuredPersons");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "187f3688-968b-4816-aef6-a0c1e4f1cf49", "ae92ecb4-7a24-47b1-92e4-5a27e37cd8a2", "Agent", "AGENT" },
                    { "234ea561-21ae-4651-a657-d9f6468cd76c", "3bcce020-7abe-4119-a033-f8b893587e06", "Client", "CLIENT" },
                    { "9abd6afd-d26b-4ab2-b4e0-ca7ba35add41", "ace78b1b-0adb-4e9a-9e40-902b95d8af48", "Administrator", "ADMINISTRATOR" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "187f3688-968b-4816-aef6-a0c1e4f1cf49");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "234ea561-21ae-4651-a657-d9f6468cd76c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9abd6afd-d26b-4ab2-b4e0-ca7ba35add41");

            migrationBuilder.AddColumn<Guid>(
                name: "TypeRequestId",
                table: "InsuredPersons",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "86e199ce-4427-48f9-99e6-329755496837", "6167d3f6-ec3a-41ae-9716-c51436758c96", "Agent", "AGENT" },
                    { "8ec44015-5251-4b74-8a82-d474332ad30d", "a42770c6-d6d9-4049-ab08-d6a0482497c5", "Client", "CLIENT" },
                    { "fec48949-9bd5-4ba0-b13f-7aa4d38fc2f2", "f2b803d5-32ad-452d-9cd0-e77012b411fc", "Administrator", "ADMINISTRATOR" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_InsuredPersons_TypeRequestId",
                table: "InsuredPersons",
                column: "TypeRequestId");

            migrationBuilder.AddForeignKey(
                name: "FK_InsuredPersons_TypeRequest_TypeRequestId",
                table: "InsuredPersons",
                column: "TypeRequestId",
                principalTable: "TypeRequest",
                principalColumn: "Id");
        }
    }
}
