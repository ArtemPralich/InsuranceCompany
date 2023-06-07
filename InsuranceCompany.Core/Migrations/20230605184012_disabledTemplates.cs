using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InsuranceCompany.Core.Migrations
{
    /// <inheritdoc />
    public partial class disabledTemplates : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDisabled",
                table: "Template",
                type: "bit",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "441fcfea-e79f-49b8-af3a-467f2a16f1fc",
                column: "ConcurrencyStamp",
                value: "cc5e3e59-af29-44e4-8aec-6212aa0089ee");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7cae6025-c9d0-40bd-b780-372485e90ce0",
                column: "ConcurrencyStamp",
                value: "eb607f94-f05e-443d-91bf-b18c025fc18c");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "aa30174a-40e9-40cc-a660-f123ff11fa04",
                column: "ConcurrencyStamp",
                value: "af240161-03cd-4836-85f9-3e59f0952002");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDisabled",
                table: "Template");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "441fcfea-e79f-49b8-af3a-467f2a16f1fc",
                column: "ConcurrencyStamp",
                value: "a4c0dc48-b36c-4704-b4c9-d6b1117333f7");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7cae6025-c9d0-40bd-b780-372485e90ce0",
                column: "ConcurrencyStamp",
                value: "ab051a91-e276-48fa-b640-517e7bc109f4");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "aa30174a-40e9-40cc-a660-f123ff11fa04",
                column: "ConcurrencyStamp",
                value: "bd55f7c9-d936-4f5a-9f7e-86ae9c150611");
        }
    }
}
