using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InsuranceCompany.Core.Migrations
{
    /// <inheritdoc />
    public partial class updateAgent : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "441fcfea-e79f-49b8-af3a-467f2a16f1fc",
                column: "ConcurrencyStamp",
                value: "c96a1404-334a-4b01-b50f-75826a1c33e0");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7cae6025-c9d0-40bd-b780-372485e90ce0",
                column: "ConcurrencyStamp",
                value: "46298224-fcfd-4325-86a2-86dfde17b0e9");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "aa30174a-40e9-40cc-a660-f123ff11fa04",
                column: "ConcurrencyStamp",
                value: "33a31b13-919a-4ceb-b7de-0272e0b62fbc");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "441fcfea-e79f-49b8-af3a-467f2a16f1fc",
                column: "ConcurrencyStamp",
                value: "47abab2c-b35a-4e83-bbd9-5aeeed21448e");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7cae6025-c9d0-40bd-b780-372485e90ce0",
                column: "ConcurrencyStamp",
                value: "6782282e-cf17-4496-8881-4b31aa2496f0");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "aa30174a-40e9-40cc-a660-f123ff11fa04",
                column: "ConcurrencyStamp",
                value: "741c23a5-9b5f-4130-80b8-40dac1994075");
        }
    }
}
