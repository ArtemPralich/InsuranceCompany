using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace InsuranceCompany.Core.Migrations
{
    /// <inheritdoc />
    public partial class UpdateSurveys1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1bec3edd-9143-409b-a1e4-a060f1fce344");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ded6cc8d-37e8-47e5-9784-7e5ee4dc4f22");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "eddd40f8-900a-4816-88b8-6d2f6af1574a");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "92625d13-362f-4f83-bcc6-46731c184008", "da55274a-29b8-4203-9c31-c035a4271fc0", "Administrator", "ADMINISTRATOR" },
                    { "9dd15bc6-0b3c-4215-9fc6-a65b1b352160", "e746c2b2-aa75-45b6-a5b8-732b0845c96c", "Agent", "AGENT" },
                    { "bd01b34f-eff8-4761-a9d6-e8bd5d138b31", "ffe62eb4-a766-4599-9a41-4820b0fa3d41", "Client", "CLIENT" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "92625d13-362f-4f83-bcc6-46731c184008");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9dd15bc6-0b3c-4215-9fc6-a65b1b352160");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bd01b34f-eff8-4761-a9d6-e8bd5d138b31");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1bec3edd-9143-409b-a1e4-a060f1fce344", "624293aa-1a8c-4cd3-b8fe-e9a87040a20d", "Administrator", "ADMINISTRATOR" },
                    { "ded6cc8d-37e8-47e5-9784-7e5ee4dc4f22", "11e927bf-aa17-4769-94d2-32f939c9eb8f", "Client", "CLIENT" },
                    { "eddd40f8-900a-4816-88b8-6d2f6af1574a", "cea804ca-072f-4d88-9fa4-50642c9cddaa", "Agent", "AGENT" }
                });
        }
    }
}
