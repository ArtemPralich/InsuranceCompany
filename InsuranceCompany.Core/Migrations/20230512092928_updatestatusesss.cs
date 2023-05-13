using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InsuranceCompany.Core.Migrations
{
    /// <inheritdoc />
    public partial class updatestatusesss : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "IsDisabledDocuments",
                table: "InsuranceStatus",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IsDisabledForms",
                table: "InsuranceStatus",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "441fcfea-e79f-49b8-af3a-467f2a16f1fc",
                column: "ConcurrencyStamp",
                value: "5f4fca18-df68-4ac7-afda-401510e9ca48");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7cae6025-c9d0-40bd-b780-372485e90ce0",
                column: "ConcurrencyStamp",
                value: "801d0966-66f9-4af0-83ef-3ef6892d4f71");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "aa30174a-40e9-40cc-a660-f123ff11fa04",
                column: "ConcurrencyStamp",
                value: "88f405ef-8b4b-48d5-a621-293515cea40e");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDisabledDocuments",
                table: "InsuranceStatus");

            migrationBuilder.DropColumn(
                name: "IsDisabledForms",
                table: "InsuranceStatus");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "441fcfea-e79f-49b8-af3a-467f2a16f1fc",
                column: "ConcurrencyStamp",
                value: "d3c9cca6-40d4-4e8a-b029-6b5f834c6488");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7cae6025-c9d0-40bd-b780-372485e90ce0",
                column: "ConcurrencyStamp",
                value: "4f1c47d5-7d05-44a8-ba2b-5907679f9006");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "aa30174a-40e9-40cc-a660-f123ff11fa04",
                column: "ConcurrencyStamp",
                value: "277d7b10-cd66-44cf-a79a-c3b7a6fa6dd4");
        }
    }
}
