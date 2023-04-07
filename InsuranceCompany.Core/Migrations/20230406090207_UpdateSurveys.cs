using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace InsuranceCompany.Core.Migrations
{
    /// <inheritdoc />
    public partial class UpdateSurveys : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK__Insurance__TypeR__6D0D32F4",
                table: "InsuranceTypeSurvey");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "64f15c0d-7bd4-4a2d-a41c-d0e247ea39b0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "77941c5c-8364-4171-8e70-51118c72b15b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "82c06cdc-b0d6-4959-b055-92454737e2b5");

            migrationBuilder.AddColumn<Guid>(
                name: "InsuranceRateId",
                table: "InsuranceTypeSurvey",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1bec3edd-9143-409b-a1e4-a060f1fce344", "624293aa-1a8c-4cd3-b8fe-e9a87040a20d", "Administrator", "ADMINISTRATOR" },
                    { "ded6cc8d-37e8-47e5-9784-7e5ee4dc4f22", "11e927bf-aa17-4769-94d2-32f939c9eb8f", "Client", "CLIENT" },
                    { "eddd40f8-900a-4816-88b8-6d2f6af1574a", "cea804ca-072f-4d88-9fa4-50642c9cddaa", "Agent", "AGENT" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_InsuranceTypeSurvey_InsuranceRateId",
                table: "InsuranceTypeSurvey",
                column: "InsuranceRateId");

            migrationBuilder.AddForeignKey(
                name: "FK_InsuranceTypeSurvey_TypeRequest_TypeRequestId",
                table: "InsuranceTypeSurvey",
                column: "TypeRequestId",
                principalTable: "TypeRequest",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__Insurance__TypeR__6D0D32F4",
                table: "InsuranceTypeSurvey",
                column: "InsuranceRateId",
                principalTable: "InsuranceRate",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InsuranceTypeSurvey_TypeRequest_TypeRequestId",
                table: "InsuranceTypeSurvey");

            migrationBuilder.DropForeignKey(
                name: "FK__Insurance__TypeR__6D0D32F4",
                table: "InsuranceTypeSurvey");

            migrationBuilder.DropIndex(
                name: "IX_InsuranceTypeSurvey_InsuranceRateId",
                table: "InsuranceTypeSurvey");

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

            migrationBuilder.DropColumn(
                name: "InsuranceRateId",
                table: "InsuranceTypeSurvey");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "64f15c0d-7bd4-4a2d-a41c-d0e247ea39b0", "c48da86a-006d-4d63-bff2-4f1a54f73d4f", "Agent", "AGENT" },
                    { "77941c5c-8364-4171-8e70-51118c72b15b", "80140682-a055-49d7-bafa-0897ead37337", "Client", "CLIENT" },
                    { "82c06cdc-b0d6-4959-b055-92454737e2b5", "64cb8e4f-a3b5-467a-b3b1-fb9cb55a8e5c", "Administrator", "ADMINISTRATOR" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK__Insurance__TypeR__6D0D32F4",
                table: "InsuranceTypeSurvey",
                column: "TypeRequestId",
                principalTable: "TypeRequest",
                principalColumn: "Id");
        }
    }
}
