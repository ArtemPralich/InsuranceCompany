using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InsuranceCompany.Core.Migrations
{
    /// <inheritdoc />
    public partial class updatestatusessss : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "IsDisabledForms",
                table: "InsuranceStatus",
                type: "bit",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsDisabledDocuments",
                table: "InsuranceStatus",
                type: "bit",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "441fcfea-e79f-49b8-af3a-467f2a16f1fc",
                column: "ConcurrencyStamp",
                value: "0b023b8e-afd5-4d72-94cf-12917ac7366a");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7cae6025-c9d0-40bd-b780-372485e90ce0",
                column: "ConcurrencyStamp",
                value: "b454c07c-0f8d-4914-a597-0494315d907d");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "aa30174a-40e9-40cc-a660-f123ff11fa04",
                column: "ConcurrencyStamp",
                value: "5a3fdd21-01a4-4541-9ae8-b59e117e00aa");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "IsDisabledForms",
                table: "InsuranceStatus",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "IsDisabledDocuments",
                table: "InsuranceStatus",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

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
    }
}
