using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace InsuranceCompany.Core.Migrations
{
    /// <inheritdoc />
    public partial class UpdateQuestionSurvey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK__QuestionS__Surve__4CA06362",
                table: "QuestionSurvey");

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

            migrationBuilder.RenameColumn(
                name: "SurveyId",
                table: "QuestionSurvey",
                newName: "RuleRequestId");

            migrationBuilder.RenameIndex(
                name: "IX_QuestionSurvey_SurveyId",
                table: "QuestionSurvey",
                newName: "IX_QuestionSurvey_RuleRequestId");

            migrationBuilder.AddColumn<Guid>(
                name: "InsuranceSurveyId",
                table: "QuestionSurvey",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3d0ee109-9a45-4fcc-aed1-68130bf33bfb", "4f61e3b5-c179-4591-b972-fd15c149209b", "Client", "CLIENT" },
                    { "d0278561-249b-48ec-8118-c7b7b1414e3c", "e4f84992-15de-4f24-93c1-83efecc4c1fb", "Agent", "AGENT" },
                    { "f771835a-c9a5-4085-951f-0b5f52ebbae0", "04798abc-b1a9-4cf7-9352-18e9716d0b9a", "Administrator", "ADMINISTRATOR" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_QuestionSurvey_InsuranceSurveyId",
                table: "QuestionSurvey",
                column: "InsuranceSurveyId");

            migrationBuilder.AddForeignKey(
                name: "FK_QuestionSurvey_InsuranceSurvey_InsuranceSurveyId",
                table: "QuestionSurvey",
                column: "InsuranceSurveyId",
                principalTable: "InsuranceSurvey",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_QuestionSurvey_RuleRequest_RuleRequestId",
                table: "QuestionSurvey",
                column: "RuleRequestId",
                principalTable: "RuleRequest",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_QuestionSurvey_InsuranceSurvey_InsuranceSurveyId",
                table: "QuestionSurvey");

            migrationBuilder.DropForeignKey(
                name: "FK_QuestionSurvey_RuleRequest_RuleRequestId",
                table: "QuestionSurvey");

            migrationBuilder.DropIndex(
                name: "IX_QuestionSurvey_InsuranceSurveyId",
                table: "QuestionSurvey");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3d0ee109-9a45-4fcc-aed1-68130bf33bfb");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d0278561-249b-48ec-8118-c7b7b1414e3c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f771835a-c9a5-4085-951f-0b5f52ebbae0");

            migrationBuilder.DropColumn(
                name: "InsuranceSurveyId",
                table: "QuestionSurvey");

            migrationBuilder.RenameColumn(
                name: "RuleRequestId",
                table: "QuestionSurvey",
                newName: "SurveyId");

            migrationBuilder.RenameIndex(
                name: "IX_QuestionSurvey_RuleRequestId",
                table: "QuestionSurvey",
                newName: "IX_QuestionSurvey_SurveyId");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "92625d13-362f-4f83-bcc6-46731c184008", "da55274a-29b8-4203-9c31-c035a4271fc0", "Administrator", "ADMINISTRATOR" },
                    { "9dd15bc6-0b3c-4215-9fc6-a65b1b352160", "e746c2b2-aa75-45b6-a5b8-732b0845c96c", "Agent", "AGENT" },
                    { "bd01b34f-eff8-4761-a9d6-e8bd5d138b31", "ffe62eb4-a766-4599-9a41-4820b0fa3d41", "Client", "CLIENT" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK__QuestionS__Surve__4CA06362",
                table: "QuestionSurvey",
                column: "SurveyId",
                principalTable: "RuleRequest",
                principalColumn: "Id");
        }
    }
}
