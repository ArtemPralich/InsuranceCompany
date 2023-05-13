using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InsuranceCompany.Core.Migrations
{
    /// <inheritdoc />
    public partial class updateInsurancerequestAgainAgain : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Benefits",
                table: "InsuranceRequest",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "441fcfea-e79f-49b8-af3a-467f2a16f1fc",
                column: "ConcurrencyStamp",
                value: "a25463fe-46a0-4856-a339-2a3170ea3f14");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7cae6025-c9d0-40bd-b780-372485e90ce0",
                column: "ConcurrencyStamp",
                value: "a8d52017-9bf9-47b3-a06a-a9ef9aec8090");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "aa30174a-40e9-40cc-a660-f123ff11fa04",
                column: "ConcurrencyStamp",
                value: "70a022d9-49a4-4e4d-974d-f90b3e15c459");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Benefits",
                table: "InsuranceRequest");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "441fcfea-e79f-49b8-af3a-467f2a16f1fc",
                column: "ConcurrencyStamp",
                value: "68bbe59f-9fd3-4d9a-9585-2d68a3f393cb");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7cae6025-c9d0-40bd-b780-372485e90ce0",
                column: "ConcurrencyStamp",
                value: "1a4a246b-3b6b-4aff-b4e8-d94569aed9c1");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "aa30174a-40e9-40cc-a660-f123ff11fa04",
                column: "ConcurrencyStamp",
                value: "687ac00a-6d6f-4d74-84b5-e8893022ced5");
        }
    }
}
