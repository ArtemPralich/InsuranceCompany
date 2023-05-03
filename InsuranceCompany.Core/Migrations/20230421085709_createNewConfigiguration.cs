using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace InsuranceCompany.Core.Migrations
{
    /// <inheritdoc />
    public partial class createNewConfigiguration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "30b342cb-d36f-4d33-84e2-98f5d8696397", "f0c317b4-7e74-4b7d-812a-c4c80745789d", "Administrator", "ADMINISTRATOR" },
                    { "60332123-c836-4544-bbb8-5d7907a653da", "d2866650-97aa-4134-b501-dcdee971edbb", "Client", "CLIENT" },
                    { "93692f6e-a2a9-4377-b54c-8eaf73cb62b0", "99e5e22f-06d4-4d0b-88ca-56c6a60aba75", "Agent", "AGENT" }
                });

            migrationBuilder.InsertData(
                table: "InsuranceRate",
                columns: new[] { "Id", "BaseCoefficient", "CountPaymentsInYear", "CountYears", "IsFamily", "IsOldman", "IsPersonal", "Title" },
                values: new object[,]
                {
                    { new Guid("5a0d244c-9a62-4b9d-eb10-08db30f1069b"), 30m, (short)4, (short)5, false, true, false, "Пенсионный страховой запрос с ежесезонной оплатой" },
                    { new Guid("71718911-3be9-4921-eb0f-08db30f1069a"), 30m, (short)12, (short)5, false, true, false, "Пенсионный страховой запрос с ежемесечной оплатой" },
                    { new Guid("dafe171c-3f15-4d88-eb11-08db30f1069a"), 30m, (short)1, (short)5, false, true, false, "Пенсионный страховой запрос с оплатой раз в год" }
                });

            migrationBuilder.InsertData(
                table: "InsuranceSurvey",
                columns: new[] { "Id", "Description", "Title" },
                values: new object[] { new Guid("f61ccc36-5ede-4769-3083-08db39c03b5b"), "О состоянии здоровья", "Состояние здоровья" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "30b342cb-d36f-4d33-84e2-98f5d8696397");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "60332123-c836-4544-bbb8-5d7907a653da");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "93692f6e-a2a9-4377-b54c-8eaf73cb62b0");

            migrationBuilder.DeleteData(
                table: "InsuranceRate",
                keyColumn: "Id",
                keyValue: new Guid("5a0d244c-9a62-4b9d-eb10-08db30f1069b"));

            migrationBuilder.DeleteData(
                table: "InsuranceRate",
                keyColumn: "Id",
                keyValue: new Guid("71718911-3be9-4921-eb0f-08db30f1069a"));

            migrationBuilder.DeleteData(
                table: "InsuranceRate",
                keyColumn: "Id",
                keyValue: new Guid("dafe171c-3f15-4d88-eb11-08db30f1069a"));

            migrationBuilder.DeleteData(
                table: "InsuranceSurvey",
                keyColumn: "Id",
                keyValue: new Guid("f61ccc36-5ede-4769-3083-08db39c03b5b"));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "aea84485-1f29-4706-b4cc-abd19e2fc8e8", "33ab5614-98ea-4c30-b490-77b8fa225224", "Client", "CLIENT" },
                    { "c6aa8b3d-a36b-476b-98e5-e97882d3cc1e", "38fc6279-885b-476a-8e80-630ee78ad75e", "Administrator", "ADMINISTRATOR" },
                    { "e960e09d-f4ff-4229-b37d-10c5c87e864b", "6322bd33-9c4f-4ff4-8be6-0ef2bbc61f07", "Agent", "AGENT" }
                });
        }
    }
}
