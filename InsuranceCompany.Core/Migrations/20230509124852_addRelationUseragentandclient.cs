using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace InsuranceCompany.Core.Migrations
{
    /// <inheritdoc />
    public partial class addRelationUseragentandclient : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "94b43fba-5ea8-4f97-98a6-c6a8357b6d75");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a0c36768-8ce1-4c64-ab84-376b543e078b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fa2a729b-2a03-4b53-aba8-802b4af4f648");

            migrationBuilder.AddColumn<Guid>(
                name: "AgentId",
                table: "AspNetUsers",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ClientId",
                table: "AspNetUsers",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "441fcfea-e79f-49b8-af3a-467f2a16f1fc", "9399a8f6-ca85-4172-8a04-d153f75764bc", "Agent", "AGENT" },
                    { "7cae6025-c9d0-40bd-b780-372485e90ce0", "99b1d1f1-0d07-472d-8078-804720612a25", "Client", "CLIENT" },
                    { "aa30174a-40e9-40cc-a660-f123ff11fa04", "f3cdea15-5694-4f03-8e5c-561394b48bbc", "Administrator", "ADMINISTRATOR" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_AgentId",
                table: "AspNetUsers",
                column: "AgentId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_ClientId",
                table: "AspNetUsers",
                column: "ClientId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Agent_AgentId",
                table: "AspNetUsers",
                column: "AgentId",
                principalTable: "Agent",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Client_ClientId",
                table: "AspNetUsers",
                column: "ClientId",
                principalTable: "Client",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Agent_AgentId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Client_ClientId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_AgentId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_ClientId",
                table: "AspNetUsers");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "441fcfea-e79f-49b8-af3a-467f2a16f1fc");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7cae6025-c9d0-40bd-b780-372485e90ce0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "aa30174a-40e9-40cc-a660-f123ff11fa04");

            migrationBuilder.DropColumn(
                name: "AgentId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ClientId",
                table: "AspNetUsers");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "94b43fba-5ea8-4f97-98a6-c6a8357b6d75", "a6bb7686-6de9-4ec7-b651-6997c862f4be", "Agent", "AGENT" },
                    { "a0c36768-8ce1-4c64-ab84-376b543e078b", "4dfac839-de7b-4d44-acef-8a06e1574842", "Client", "CLIENT" },
                    { "fa2a729b-2a03-4b53-aba8-802b4af4f648", "b0d38392-28a7-42ed-b744-db4f455baca5", "Administrator", "ADMINISTRATOR" }
                });
        }
    }
}
