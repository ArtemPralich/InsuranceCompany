using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace InsuranceCompany.Core.Migrations
{
    /// <inheritdoc />
    public partial class addedInsurancestatusconfiguration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "401c8922-0e44-48c8-8d9a-ca91029ffe25");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "80fceda2-807c-49dd-8862-afeb38331360");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8568126d-89c6-41fc-a92c-d2ee37f4e218");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "aea84485-1f29-4706-b4cc-abd19e2fc8e8", "33ab5614-98ea-4c30-b490-77b8fa225224", "Client", "CLIENT" },
                    { "c6aa8b3d-a36b-476b-98e5-e97882d3cc1e", "38fc6279-885b-476a-8e80-630ee78ad75e", "Administrator", "ADMINISTRATOR" },
                    { "e960e09d-f4ff-4229-b37d-10c5c87e864b", "6322bd33-9c4f-4ff4-8be6-0ef2bbc61f07", "Agent", "AGENT" }
                });

            migrationBuilder.InsertData(
                table: "InsuranceStatus",
                columns: new[] { "Id", "Color", "Status" },
                values: new object[,]
                {
                    { new Guid("8cd43f71-1d6a-4a45-8974-6a4d9f6749ed"), "#a0fa5e", "Подписано" },
                    { new Guid("988a1903-d7b0-442b-809e-4fafbe76b941"), "#ffeed0", "Создано" },
                    { new Guid("b74a9704-ff2c-4992-80b5-f22905091835"), "#d0f5ff", "Заполнено" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "aea84485-1f29-4706-b4cc-abd19e2fc8e8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c6aa8b3d-a36b-476b-98e5-e97882d3cc1e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e960e09d-f4ff-4229-b37d-10c5c87e864b");

            migrationBuilder.DeleteData(
                table: "InsuranceStatus",
                keyColumn: "Id",
                keyValue: new Guid("8cd43f71-1d6a-4a45-8974-6a4d9f6749ed"));

            migrationBuilder.DeleteData(
                table: "InsuranceStatus",
                keyColumn: "Id",
                keyValue: new Guid("988a1903-d7b0-442b-809e-4fafbe76b941"));

            migrationBuilder.DeleteData(
                table: "InsuranceStatus",
                keyColumn: "Id",
                keyValue: new Guid("b74a9704-ff2c-4992-80b5-f22905091835"));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "401c8922-0e44-48c8-8d9a-ca91029ffe25", "eccc8510-908f-4391-9699-eda4aa11e607", "Client", "CLIENT" },
                    { "80fceda2-807c-49dd-8862-afeb38331360", "6f7d3d8e-82de-44ea-9d36-1a6862bf190b", "Administrator", "ADMINISTRATOR" },
                    { "8568126d-89c6-41fc-a92c-d2ee37f4e218", "e1f0488c-1294-4561-bb69-0d647f43535f", "Agent", "AGENT" }
                });
        }
    }
}
