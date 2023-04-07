using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace InsuranceCompany.Core.Migrations
{
    /// <inheritdoc />
    public partial class UpdateClientModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<string>(
                name: "PersonalCode",
                table: "Client",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "36689391-9f9b-4bff-bf66-0d191a928693", "492f8e1a-0ad4-4239-a68e-a7578dba98cf", "Agent", "AGENT" },
                    { "9baaa896-0b3a-489e-b898-2cf0c0133249", "205a28f5-66bd-4fdc-98fe-e3547fe6fe04", "Client", "CLIENT" },
                    { "dcea560b-9a6a-46a2-b1cf-37d56d508341", "708da0e9-2b1a-4573-be56-839c5b981b6d", "Administrator", "ADMINISTRATOR" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "36689391-9f9b-4bff-bf66-0d191a928693");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9baaa896-0b3a-489e-b898-2cf0c0133249");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dcea560b-9a6a-46a2-b1cf-37d56d508341");

            migrationBuilder.DropColumn(
                name: "PersonalCode",
                table: "Client");

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
    }
}
