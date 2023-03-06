using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InsuranceCompany.Core.Migrations
{
    /// <inheritdoc />
    public partial class DatabaseCreation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Child",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    Surname = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    Age = table.Column<short>(type: "smallint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Child__3214EC07A1E18C97", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Client",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gender = table.Column<bool>(type: "bit", nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Client__3214EC075E2227B5", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InsuranceRate",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BasePayment = table.Column<decimal>(type: "money", nullable: true),
                    UnitPayment = table.Column<decimal>(type: "money", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Insuranc__3214EC07497406FD", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InsuranceStatus",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Status = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    Color = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Insuranc__3214EC07B4801EDD", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InsuranceSurvey",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    Description = table.Column<string>(type: "varchar(1024)", unicode: false, maxLength: 1024, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Insuranc__3214EC073B40440C", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Position",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Position__3214EC07F7254960", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "QuestionType",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Text = table.Column<string>(type: "varchar(1024)", unicode: false, maxLength: 1024, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Question__3214EC072C41760D", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RuleRequest",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsChildRequest = table.Column<bool>(type: "bit", nullable: true),
                    IsOldman = table.Column<bool>(type: "bit", nullable: true),
                    IsDisabledPerson = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__RuleRequ__3214EC074FC3163A", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TypeRequest",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    CountPaymentsInYear = table.Column<short>(type: "smallint", nullable: true),
                    CountYears = table.Column<short>(type: "smallint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__TypeRequ__3214EC07B54222AA", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ClientaChildren",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClientId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ChildId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__ClientaC__3214EC07D0A9F915", x => x.Id);
                    table.ForeignKey(
                        name: "FK__ClientaCh__Child__38996AB5",
                        column: x => x.ChildId,
                        principalTable: "Child",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK__ClientaCh__Clien__37A5467C",
                        column: x => x.ClientId,
                        principalTable: "Client",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Agent",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    Surname = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "datetime", nullable: true),
                    DateOfStart = table.Column<DateTime>(type: "datetime", nullable: true),
                    PositionId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Agent__3214EC075B5E885F", x => x.Id);
                    table.ForeignKey(
                        name: "FK__Agent__PositionI__25869641",
                        column: x => x.PositionId,
                        principalTable: "Position",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PositionClient",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClientId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    PositionId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Position__3214EC0715E303CD", x => x.Id);
                    table.ForeignKey(
                        name: "FK__PositionC__Clien__31EC6D26",
                        column: x => x.ClientId,
                        principalTable: "Client",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK__PositionC__Posit__32E0915F",
                        column: x => x.PositionId,
                        principalTable: "Position",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Question",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Text = table.Column<string>(type: "varchar(1024)", unicode: false, maxLength: 1024, nullable: true),
                    IsMandatory = table.Column<bool>(type: "bit", nullable: true),
                    QuestionTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Question__3214EC070BC0CEF7", x => x.Id);
                    table.ForeignKey(
                        name: "FK__Question__Questi__46E78A0C",
                        column: x => x.QuestionTypeId,
                        principalTable: "QuestionType",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "InsuranceTypeSurvey",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    InsuranceSurveyId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    TypeRequestId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Insuranc__3214EC07877F6247", x => x.Id);
                    table.ForeignKey(
                        name: "FK__Insurance__Insur__6C190EBB",
                        column: x => x.InsuranceSurveyId,
                        principalTable: "InsuranceSurvey",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK__Insurance__TypeR__6D0D32F4",
                        column: x => x.TypeRequestId,
                        principalTable: "TypeRequest",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "RuleTypeRequest",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RuleId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    TypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__RuleType__3214EC078EC75B84", x => x.Id);
                    table.ForeignKey(
                        name: "FK__RuleTypeR__RuleI__3F466844",
                        column: x => x.RuleId,
                        principalTable: "RuleRequest",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK__RuleTypeR__TypeI__403A8C7D",
                        column: x => x.TypeId,
                        principalTable: "TypeRequest",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "InsuranceRequest",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DateOfStart = table.Column<DateTime>(type: "datetime", nullable: true),
                    DateOfEnd = table.Column<DateTime>(type: "datetime", nullable: true),
                    AgentId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    InsuranceRateId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    InsuranceStatusId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Insuranc__3214EC070023678D", x => x.Id);
                    table.ForeignKey(
                        name: "FK__Insurance__Agent__2E1BDC42",
                        column: x => x.AgentId,
                        principalTable: "Agent",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK__Insurance__Insur__2F10007B",
                        column: x => x.InsuranceRateId,
                        principalTable: "InsuranceRate",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK__Insurance__Insur__5CD6CB2B",
                        column: x => x.InsuranceStatusId,
                        principalTable: "InsuranceStatus",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Answer",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Answer = table.Column<string>(type: "varchar(1024)", unicode: false, maxLength: 1024, nullable: true),
                    QuestionId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Answer__3214EC075FAE5581", x => x.Id);
                    table.ForeignKey(
                        name: "FK__Answer__Question__49C3F6B7",
                        column: x => x.QuestionId,
                        principalTable: "Question",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "QuestionSurvey",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SurveyId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    QuestionId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Question__3214EC07B61A0500", x => x.Id);
                    table.ForeignKey(
                        name: "FK__QuestionS__Quest__4D94879B",
                        column: x => x.QuestionId,
                        principalTable: "Question",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK__QuestionS__Surve__4CA06362",
                        column: x => x.SurveyId,
                        principalTable: "RuleRequest",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AnswerValue",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Value = table.Column<string>(type: "varchar(1024)", unicode: false, maxLength: 1024, nullable: true),
                    InsuranceRequestId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    QuestionId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__AnswerVa__3214EC0713DBBB4E", x => x.Id);
                    table.ForeignKey(
                        name: "FK__AnswerVal__Insur__5070F446",
                        column: x => x.InsuranceRequestId,
                        principalTable: "InsuranceRequest",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK__AnswerVal__Quest__5165187F",
                        column: x => x.QuestionId,
                        principalTable: "Question",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Agent_PositionId",
                table: "Agent",
                column: "PositionId");

            migrationBuilder.CreateIndex(
                name: "IX_Answer_QuestionId",
                table: "Answer",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_AnswerValue_InsuranceRequestId",
                table: "AnswerValue",
                column: "InsuranceRequestId");

            migrationBuilder.CreateIndex(
                name: "IX_AnswerValue_QuestionId",
                table: "AnswerValue",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_ClientaChildren_ChildId",
                table: "ClientaChildren",
                column: "ChildId");

            migrationBuilder.CreateIndex(
                name: "IX_ClientaChildren_ClientId",
                table: "ClientaChildren",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_InsuranceRequest_AgentId",
                table: "InsuranceRequest",
                column: "AgentId");

            migrationBuilder.CreateIndex(
                name: "IX_InsuranceRequest_InsuranceRateId",
                table: "InsuranceRequest",
                column: "InsuranceRateId");

            migrationBuilder.CreateIndex(
                name: "IX_InsuranceRequest_InsuranceStatusId",
                table: "InsuranceRequest",
                column: "InsuranceStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_InsuranceTypeSurvey_InsuranceSurveyId",
                table: "InsuranceTypeSurvey",
                column: "InsuranceSurveyId");

            migrationBuilder.CreateIndex(
                name: "IX_InsuranceTypeSurvey_TypeRequestId",
                table: "InsuranceTypeSurvey",
                column: "TypeRequestId");

            migrationBuilder.CreateIndex(
                name: "IX_PositionClient_ClientId",
                table: "PositionClient",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_PositionClient_PositionId",
                table: "PositionClient",
                column: "PositionId");

            migrationBuilder.CreateIndex(
                name: "IX_Question_QuestionTypeId",
                table: "Question",
                column: "QuestionTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_QuestionSurvey_QuestionId",
                table: "QuestionSurvey",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_QuestionSurvey_SurveyId",
                table: "QuestionSurvey",
                column: "SurveyId");

            migrationBuilder.CreateIndex(
                name: "IX_RuleTypeRequest_RuleId",
                table: "RuleTypeRequest",
                column: "RuleId");

            migrationBuilder.CreateIndex(
                name: "IX_RuleTypeRequest_TypeId",
                table: "RuleTypeRequest",
                column: "TypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Answer");

            migrationBuilder.DropTable(
                name: "AnswerValue");

            migrationBuilder.DropTable(
                name: "ClientaChildren");

            migrationBuilder.DropTable(
                name: "InsuranceTypeSurvey");

            migrationBuilder.DropTable(
                name: "PositionClient");

            migrationBuilder.DropTable(
                name: "QuestionSurvey");

            migrationBuilder.DropTable(
                name: "RuleTypeRequest");

            migrationBuilder.DropTable(
                name: "InsuranceRequest");

            migrationBuilder.DropTable(
                name: "Child");

            migrationBuilder.DropTable(
                name: "InsuranceSurvey");

            migrationBuilder.DropTable(
                name: "Client");

            migrationBuilder.DropTable(
                name: "Question");

            migrationBuilder.DropTable(
                name: "RuleRequest");

            migrationBuilder.DropTable(
                name: "TypeRequest");

            migrationBuilder.DropTable(
                name: "Agent");

            migrationBuilder.DropTable(
                name: "InsuranceRate");

            migrationBuilder.DropTable(
                name: "InsuranceStatus");

            migrationBuilder.DropTable(
                name: "QuestionType");

            migrationBuilder.DropTable(
                name: "Position");
        }
    }
}
