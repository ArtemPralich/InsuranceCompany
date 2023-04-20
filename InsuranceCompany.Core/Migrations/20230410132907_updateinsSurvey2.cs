using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace InsuranceCompany.Core.Migrations
{
    /// <inheritdoc />
    public partial class updateinsSurvey2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_QuestionSurvey_InsuranceSurvey_InsuranceSurveyId",
                table: "QuestionSurvey");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "19c32ba4-e2ba-4e10-bc6c-4a68c383d64c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "85f2c4a4-4a6a-460e-829d-617edd453283");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cd4b3525-bf24-4fd2-a957-49e837014a08");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "297a11ad-cf46-4dc5-9bb9-e4af9eeef182", "340a19b6-8bc6-4e5a-b149-6c274373ac26", "Agent", "AGENT" },
                    { "bf846a24-d43a-4ca0-adab-59c3bb9a7f5e", "3c8c6987-fcbb-456f-8da0-bb47bc048e8c", "Administrator", "ADMINISTRATOR" },
                    { "cd51b1aa-d268-4349-926c-7c0e6e428e9d", "c5a9a9dd-1fb7-49fa-b3fa-26ee1b0c7055", "Client", "CLIENT" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK__QuestionSurvey__InsuranceSurvey__6C190EBB",
                table: "QuestionSurvey",
                column: "InsuranceSurveyId",
                principalTable: "InsuranceSurvey",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK__QuestionSurvey__InsuranceSurvey__6C190EBB",
                table: "QuestionSurvey");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "297a11ad-cf46-4dc5-9bb9-e4af9eeef182");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bf846a24-d43a-4ca0-adab-59c3bb9a7f5e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cd51b1aa-d268-4349-926c-7c0e6e428e9d");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "19c32ba4-e2ba-4e10-bc6c-4a68c383d64c", "c55f0b44-80c5-47d1-b9c0-4fbb0bf48ce2", "Client", "CLIENT" },
                    { "85f2c4a4-4a6a-460e-829d-617edd453283", "0f1fcf70-3f60-4d39-9449-ab4cf02d259b", "Administrator", "ADMINISTRATOR" },
                    { "cd4b3525-bf24-4fd2-a957-49e837014a08", "9d97d6e2-3005-470d-9e85-aa63b7c2ae4b", "Agent", "AGENT" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_QuestionSurvey_InsuranceSurvey_InsuranceSurveyId",
                table: "QuestionSurvey",
                column: "InsuranceSurveyId",
                principalTable: "InsuranceSurvey",
                principalColumn: "Id");
        }
    }
}
