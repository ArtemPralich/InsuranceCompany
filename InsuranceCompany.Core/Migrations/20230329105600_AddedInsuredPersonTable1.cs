using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace InsuranceCompany.Core.Migrations
{
    /// <inheritdoc />
    public partial class AddedInsuredPersonTable1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InsuredPerson_Client_ClientId",
                table: "InsuredPerson");

            migrationBuilder.DropForeignKey(
                name: "FK_InsuredPerson_InsuranceRequest_InsuranceRequestId",
                table: "InsuredPerson");

            migrationBuilder.DropForeignKey(
                name: "FK_InsuredPerson_TypeRequest_TypeRequestId",
                table: "InsuredPerson");

            migrationBuilder.DropPrimaryKey(
                name: "PK_InsuredPerson",
                table: "InsuredPerson");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "07bdd71a-8ff2-403c-899a-c6f857cd2ccb");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2035c693-2873-4df2-825c-4cface6c9923");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7fa321e9-486f-4ea6-b447-d45e840c6ad8");

            migrationBuilder.RenameTable(
                name: "InsuredPerson",
                newName: "InsuredPersons");

            migrationBuilder.RenameIndex(
                name: "IX_InsuredPerson_TypeRequestId",
                table: "InsuredPersons",
                newName: "IX_InsuredPersons_TypeRequestId");

            migrationBuilder.RenameIndex(
                name: "IX_InsuredPerson_InsuranceRequestId",
                table: "InsuredPersons",
                newName: "IX_InsuredPersons_InsuranceRequestId");

            migrationBuilder.RenameIndex(
                name: "IX_InsuredPerson_ClientId",
                table: "InsuredPersons",
                newName: "IX_InsuredPersons_ClientId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_InsuredPersons",
                table: "InsuredPersons",
                column: "Id");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "86e199ce-4427-48f9-99e6-329755496837", "6167d3f6-ec3a-41ae-9716-c51436758c96", "Agent", "AGENT" },
                    { "8ec44015-5251-4b74-8a82-d474332ad30d", "a42770c6-d6d9-4049-ab08-d6a0482497c5", "Client", "CLIENT" },
                    { "fec48949-9bd5-4ba0-b13f-7aa4d38fc2f2", "f2b803d5-32ad-452d-9cd0-e77012b411fc", "Administrator", "ADMINISTRATOR" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_InsuredPersons_Client_ClientId",
                table: "InsuredPersons",
                column: "ClientId",
                principalTable: "Client",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_InsuredPersons_InsuranceRequest_InsuranceRequestId",
                table: "InsuredPersons",
                column: "InsuranceRequestId",
                principalTable: "InsuranceRequest",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_InsuredPersons_TypeRequest_TypeRequestId",
                table: "InsuredPersons",
                column: "TypeRequestId",
                principalTable: "TypeRequest",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InsuredPersons_Client_ClientId",
                table: "InsuredPersons");

            migrationBuilder.DropForeignKey(
                name: "FK_InsuredPersons_InsuranceRequest_InsuranceRequestId",
                table: "InsuredPersons");

            migrationBuilder.DropForeignKey(
                name: "FK_InsuredPersons_TypeRequest_TypeRequestId",
                table: "InsuredPersons");

            migrationBuilder.DropPrimaryKey(
                name: "PK_InsuredPersons",
                table: "InsuredPersons");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "86e199ce-4427-48f9-99e6-329755496837");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8ec44015-5251-4b74-8a82-d474332ad30d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fec48949-9bd5-4ba0-b13f-7aa4d38fc2f2");

            migrationBuilder.RenameTable(
                name: "InsuredPersons",
                newName: "InsuredPerson");

            migrationBuilder.RenameIndex(
                name: "IX_InsuredPersons_TypeRequestId",
                table: "InsuredPerson",
                newName: "IX_InsuredPerson_TypeRequestId");

            migrationBuilder.RenameIndex(
                name: "IX_InsuredPersons_InsuranceRequestId",
                table: "InsuredPerson",
                newName: "IX_InsuredPerson_InsuranceRequestId");

            migrationBuilder.RenameIndex(
                name: "IX_InsuredPersons_ClientId",
                table: "InsuredPerson",
                newName: "IX_InsuredPerson_ClientId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_InsuredPerson",
                table: "InsuredPerson",
                column: "Id");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "07bdd71a-8ff2-403c-899a-c6f857cd2ccb", "ee038af0-3f10-4430-a38a-45743cd1ad18", "Agent", "AGENT" },
                    { "2035c693-2873-4df2-825c-4cface6c9923", "080df0b6-7c45-4beb-9379-6863be1e9f5c", "Client", "CLIENT" },
                    { "7fa321e9-486f-4ea6-b447-d45e840c6ad8", "ccce0d80-1084-4e74-bd91-9b18db4c60fa", "Administrator", "ADMINISTRATOR" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_InsuredPerson_Client_ClientId",
                table: "InsuredPerson",
                column: "ClientId",
                principalTable: "Client",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_InsuredPerson_InsuranceRequest_InsuranceRequestId",
                table: "InsuredPerson",
                column: "InsuranceRequestId",
                principalTable: "InsuranceRequest",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_InsuredPerson_TypeRequest_TypeRequestId",
                table: "InsuredPerson",
                column: "TypeRequestId",
                principalTable: "TypeRequest",
                principalColumn: "Id");
        }
    }
}
