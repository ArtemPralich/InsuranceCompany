﻿// <auto-generated />
using System;
using InsuranceCompany.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace InsuranceCompany.Core.Migrations
{
    [DbContext(typeof(InsuranceCompanyContext))]
    [Migration("20230329143453_UpdateModelsAddedGuid")]
    partial class UpdateModelsAddedGuid
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("InsuranceCompany.Core.Agent", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("DateOfBirth")
                        .HasColumnType("datetime");

                    b.Property<DateTime?>("DateOfStart")
                        .HasColumnType("datetime");

                    b.Property<string>("Name")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)");

                    b.Property<Guid?>("PositionId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Surname")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id")
                        .HasName("PK__Agent__3214EC075B5E885F");

                    b.HasIndex("PositionId");

                    b.ToTable("Agent", (string)null);
                });

            modelBuilder.Entity("InsuranceCompany.Core.Answer", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("QuestionAnswer")
                        .HasMaxLength(1024)
                        .IsUnicode(false)
                        .HasColumnType("varchar(1024)")
                        .HasColumnName("Answer");

                    b.Property<Guid?>("QuestionId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id")
                        .HasName("PK__Answer__3214EC075FAE5581");

                    b.HasIndex("QuestionId");

                    b.ToTable("Answer", (string)null);
                });

            modelBuilder.Entity("InsuranceCompany.Core.AnswerValue", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("InsuranceRequestId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("QuestionId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Value")
                        .HasMaxLength(1024)
                        .IsUnicode(false)
                        .HasColumnType("varchar(1024)");

                    b.HasKey("Id")
                        .HasName("PK__AnswerVa__3214EC0713DBBB4E");

                    b.HasIndex("InsuranceRequestId");

                    b.HasIndex("QuestionId");

                    b.ToTable("AnswerValue", (string)null);
                });

            modelBuilder.Entity("InsuranceCompany.Core.Child", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<short?>("Age")
                        .HasColumnType("smallint");

                    b.Property<string>("Name")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Surname")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id")
                        .HasName("PK__Child__3214EC07A1E18C97");

                    b.ToTable("Child", (string)null);
                });

            modelBuilder.Entity("InsuranceCompany.Core.Client", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("DateOfBirth")
                        .HasColumnType("datetime");

                    b.Property<bool?>("Gender")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PersonalCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Surname")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id")
                        .HasName("PK__Client__3214EC075E2227B5");

                    b.ToTable("Client", (string)null);
                });

            modelBuilder.Entity("InsuranceCompany.Core.ClientaChild", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ChildId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ClientId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id")
                        .HasName("PK__ClientaC__3214EC07D0A9F915");

                    b.HasIndex("ChildId");

                    b.HasIndex("ClientId");

                    b.ToTable("ClientaChildren");
                });

            modelBuilder.Entity("InsuranceCompany.Core.InsuranceRate", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal?>("BasePayment")
                        .HasColumnType("money");

                    b.Property<decimal?>("UnitPayment")
                        .HasColumnType("money");

                    b.HasKey("Id")
                        .HasName("PK__Insuranc__3214EC07497406FD");

                    b.ToTable("InsuranceRate", (string)null);
                });

            modelBuilder.Entity("InsuranceCompany.Core.InsuranceRequest", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("AgentId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("DateOfEnd")
                        .HasColumnType("datetime");

                    b.Property<DateTime?>("DateOfStart")
                        .HasColumnType("datetime");

                    b.Property<Guid?>("InsuranceRateId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("InsuranceStatusId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id")
                        .HasName("PK__Insuranc__3214EC070023678D");

                    b.HasIndex("AgentId");

                    b.HasIndex("InsuranceRateId");

                    b.HasIndex("InsuranceStatusId");

                    b.ToTable("InsuranceRequest", (string)null);
                });

            modelBuilder.Entity("InsuranceCompany.Core.InsuranceStatus", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Color")
                        .HasMaxLength(10)
                        .IsUnicode(false)
                        .HasColumnType("varchar(10)");

                    b.Property<string>("Status")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id")
                        .HasName("PK__Insuranc__3214EC07B4801EDD");

                    b.ToTable("InsuranceStatus", (string)null);
                });

            modelBuilder.Entity("InsuranceCompany.Core.InsuranceSurvey", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .HasMaxLength(1024)
                        .IsUnicode(false)
                        .HasColumnType("varchar(1024)");

                    b.Property<string>("Title")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id")
                        .HasName("PK__Insuranc__3214EC073B40440C");

                    b.ToTable("InsuranceSurvey", (string)null);
                });

            modelBuilder.Entity("InsuranceCompany.Core.InsuranceTypeSurvey", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("InsuranceSurveyId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("TypeRequestId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id")
                        .HasName("PK__Insuranc__3214EC07877F6247");

                    b.HasIndex("InsuranceSurveyId");

                    b.HasIndex("TypeRequestId");

                    b.ToTable("InsuranceTypeSurvey", (string)null);
                });

            modelBuilder.Entity("InsuranceCompany.Core.Models.InsuredPerson", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ClientId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("InsuranceRequestId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsMainInsuredPerson")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.HasIndex("InsuranceRequestId");

                    b.ToTable("InsuredPersons");
                });

            modelBuilder.Entity("InsuranceCompany.Core.Models.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("InsuranceCompany.Core.Position", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Title")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id")
                        .HasName("PK__Position__3214EC07F7254960");

                    b.ToTable("Position", (string)null);
                });

            modelBuilder.Entity("InsuranceCompany.Core.PositionClient", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ClientId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("PositionId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id")
                        .HasName("PK__Position__3214EC0715E303CD");

                    b.HasIndex("ClientId");

                    b.HasIndex("PositionId");

                    b.ToTable("PositionClient", (string)null);
                });

            modelBuilder.Entity("InsuranceCompany.Core.Question", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool?>("IsMandatory")
                        .HasColumnType("bit");

                    b.Property<Guid?>("QuestionTypeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Text")
                        .HasMaxLength(1024)
                        .IsUnicode(false)
                        .HasColumnType("varchar(1024)");

                    b.HasKey("Id")
                        .HasName("PK__Question__3214EC070BC0CEF7");

                    b.HasIndex("QuestionTypeId");

                    b.ToTable("Question", (string)null);
                });

            modelBuilder.Entity("InsuranceCompany.Core.QuestionSurvey", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("QuestionId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("SurveyId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id")
                        .HasName("PK__Question__3214EC07B61A0500");

                    b.HasIndex("QuestionId");

                    b.HasIndex("SurveyId");

                    b.ToTable("QuestionSurvey", (string)null);
                });

            modelBuilder.Entity("InsuranceCompany.Core.QuestionType", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Text")
                        .HasMaxLength(1024)
                        .IsUnicode(false)
                        .HasColumnType("varchar(1024)");

                    b.HasKey("Id")
                        .HasName("PK__Question__3214EC072C41760D");

                    b.ToTable("QuestionType", (string)null);
                });

            modelBuilder.Entity("InsuranceCompany.Core.RuleRequest", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool?>("IsChildRequest")
                        .HasColumnType("bit");

                    b.Property<bool?>("IsDisabledPerson")
                        .HasColumnType("bit");

                    b.Property<bool?>("IsOldman")
                        .HasColumnType("bit");

                    b.HasKey("Id")
                        .HasName("PK__RuleRequ__3214EC074FC3163A");

                    b.ToTable("RuleRequest", (string)null);
                });

            modelBuilder.Entity("InsuranceCompany.Core.RuleTypeRequest", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("RuleId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("TypeId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id")
                        .HasName("PK__RuleType__3214EC078EC75B84");

                    b.HasIndex("RuleId");

                    b.HasIndex("TypeId");

                    b.ToTable("RuleTypeRequest", (string)null);
                });

            modelBuilder.Entity("InsuranceCompany.Core.TypeRequest", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<short?>("CountPaymentsInYear")
                        .HasColumnType("smallint");

                    b.Property<short?>("CountYears")
                        .HasColumnType("smallint");

                    b.Property<string>("Title")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id")
                        .HasName("PK__TypeRequ__3214EC07B54222AA");

                    b.ToTable("TypeRequest", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "6dcf7c3f-8c18-4b9f-8e26-4bf1cdb56488",
                            ConcurrencyStamp = "def72ce8-a710-4a93-9058-e65582d7dc82",
                            Name = "Agent",
                            NormalizedName = "AGENT"
                        },
                        new
                        {
                            Id = "cdba5dbf-c7a7-4b1b-987b-6195c0c7721a",
                            ConcurrencyStamp = "bb121708-80ab-4955-9d90-9a6f453685d8",
                            Name = "Administrator",
                            NormalizedName = "ADMINISTRATOR"
                        },
                        new
                        {
                            Id = "a120e08d-c764-4fe6-9c92-33adcda9bb2c",
                            ConcurrencyStamp = "bb8db009-3858-49c3-bd65-5b7713969464",
                            Name = "Client",
                            NormalizedName = "CLIENT"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("InsuranceCompany.Core.Agent", b =>
                {
                    b.HasOne("InsuranceCompany.Core.Position", "Position")
                        .WithMany("Agents")
                        .HasForeignKey("PositionId")
                        .HasConstraintName("FK__Agent__PositionI__25869641");

                    b.Navigation("Position");
                });

            modelBuilder.Entity("InsuranceCompany.Core.Answer", b =>
                {
                    b.HasOne("InsuranceCompany.Core.Question", "Question")
                        .WithMany("Answers")
                        .HasForeignKey("QuestionId")
                        .HasConstraintName("FK__Answer__Question__49C3F6B7");

                    b.Navigation("Question");
                });

            modelBuilder.Entity("InsuranceCompany.Core.AnswerValue", b =>
                {
                    b.HasOne("InsuranceCompany.Core.InsuranceRequest", "InsuranceRequest")
                        .WithMany("AnswerValues")
                        .HasForeignKey("InsuranceRequestId")
                        .HasConstraintName("FK__AnswerVal__Insur__5070F446");

                    b.HasOne("InsuranceCompany.Core.Question", "Question")
                        .WithMany("AnswerValues")
                        .HasForeignKey("QuestionId")
                        .HasConstraintName("FK__AnswerVal__Quest__5165187F");

                    b.Navigation("InsuranceRequest");

                    b.Navigation("Question");
                });

            modelBuilder.Entity("InsuranceCompany.Core.ClientaChild", b =>
                {
                    b.HasOne("InsuranceCompany.Core.Child", "Child")
                        .WithMany("ClientaChildren")
                        .HasForeignKey("ChildId")
                        .HasConstraintName("FK__ClientaCh__Child__38996AB5");

                    b.HasOne("InsuranceCompany.Core.Client", "Client")
                        .WithMany("ClientaChildren")
                        .HasForeignKey("ClientId")
                        .HasConstraintName("FK__ClientaCh__Clien__37A5467C");

                    b.Navigation("Child");

                    b.Navigation("Client");
                });

            modelBuilder.Entity("InsuranceCompany.Core.InsuranceRequest", b =>
                {
                    b.HasOne("InsuranceCompany.Core.Agent", "Agent")
                        .WithMany("InsuranceRequests")
                        .HasForeignKey("AgentId")
                        .HasConstraintName("FK__Insurance__Agent__2E1BDC42");

                    b.HasOne("InsuranceCompany.Core.InsuranceRate", "InsuranceRate")
                        .WithMany("InsuranceRequests")
                        .HasForeignKey("InsuranceRateId")
                        .HasConstraintName("FK__Insurance__Insur__2F10007B");

                    b.HasOne("InsuranceCompany.Core.InsuranceStatus", "InsuranceStatus")
                        .WithMany("InsuranceRequests")
                        .HasForeignKey("InsuranceStatusId")
                        .HasConstraintName("FK__Insurance__Insur__5CD6CB2B");

                    b.Navigation("Agent");

                    b.Navigation("InsuranceRate");

                    b.Navigation("InsuranceStatus");
                });

            modelBuilder.Entity("InsuranceCompany.Core.InsuranceTypeSurvey", b =>
                {
                    b.HasOne("InsuranceCompany.Core.InsuranceSurvey", "InsuranceSurvey")
                        .WithMany("InsuranceTypeSurveys")
                        .HasForeignKey("InsuranceSurveyId")
                        .HasConstraintName("FK__Insurance__Insur__6C190EBB");

                    b.HasOne("InsuranceCompany.Core.TypeRequest", "TypeRequest")
                        .WithMany("InsuranceTypeSurveys")
                        .HasForeignKey("TypeRequestId")
                        .HasConstraintName("FK__Insurance__TypeR__6D0D32F4");

                    b.Navigation("InsuranceSurvey");

                    b.Navigation("TypeRequest");
                });

            modelBuilder.Entity("InsuranceCompany.Core.Models.InsuredPerson", b =>
                {
                    b.HasOne("InsuranceCompany.Core.Client", "Client")
                        .WithMany("InsuredPersons")
                        .HasForeignKey("ClientId");

                    b.HasOne("InsuranceCompany.Core.InsuranceRequest", "InsuranceRequest")
                        .WithMany("InsuredPersons")
                        .HasForeignKey("InsuranceRequestId");

                    b.Navigation("Client");

                    b.Navigation("InsuranceRequest");
                });

            modelBuilder.Entity("InsuranceCompany.Core.PositionClient", b =>
                {
                    b.HasOne("InsuranceCompany.Core.Client", "Client")
                        .WithMany("PositionClients")
                        .HasForeignKey("ClientId")
                        .HasConstraintName("FK__PositionC__Clien__31EC6D26");

                    b.HasOne("InsuranceCompany.Core.Position", "Position")
                        .WithMany("PositionClients")
                        .HasForeignKey("PositionId")
                        .HasConstraintName("FK__PositionC__Posit__32E0915F");

                    b.Navigation("Client");

                    b.Navigation("Position");
                });

            modelBuilder.Entity("InsuranceCompany.Core.Question", b =>
                {
                    b.HasOne("InsuranceCompany.Core.QuestionType", "QuestionType")
                        .WithMany("Questions")
                        .HasForeignKey("QuestionTypeId")
                        .HasConstraintName("FK__Question__Questi__46E78A0C");

                    b.Navigation("QuestionType");
                });

            modelBuilder.Entity("InsuranceCompany.Core.QuestionSurvey", b =>
                {
                    b.HasOne("InsuranceCompany.Core.Question", "Question")
                        .WithMany("QuestionSurveys")
                        .HasForeignKey("QuestionId")
                        .HasConstraintName("FK__QuestionS__Quest__4D94879B");

                    b.HasOne("InsuranceCompany.Core.RuleRequest", "Survey")
                        .WithMany("QuestionSurveys")
                        .HasForeignKey("SurveyId")
                        .HasConstraintName("FK__QuestionS__Surve__4CA06362");

                    b.Navigation("Question");

                    b.Navigation("Survey");
                });

            modelBuilder.Entity("InsuranceCompany.Core.RuleTypeRequest", b =>
                {
                    b.HasOne("InsuranceCompany.Core.RuleRequest", "Rule")
                        .WithMany("RuleTypeRequests")
                        .HasForeignKey("RuleId")
                        .HasConstraintName("FK__RuleTypeR__RuleI__3F466844");

                    b.HasOne("InsuranceCompany.Core.TypeRequest", "Type")
                        .WithMany("RuleTypeRequests")
                        .HasForeignKey("TypeId")
                        .HasConstraintName("FK__RuleTypeR__TypeI__403A8C7D");

                    b.Navigation("Rule");

                    b.Navigation("Type");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("InsuranceCompany.Core.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("InsuranceCompany.Core.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("InsuranceCompany.Core.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("InsuranceCompany.Core.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("InsuranceCompany.Core.Agent", b =>
                {
                    b.Navigation("InsuranceRequests");
                });

            modelBuilder.Entity("InsuranceCompany.Core.Child", b =>
                {
                    b.Navigation("ClientaChildren");
                });

            modelBuilder.Entity("InsuranceCompany.Core.Client", b =>
                {
                    b.Navigation("ClientaChildren");

                    b.Navigation("InsuredPersons");

                    b.Navigation("PositionClients");
                });

            modelBuilder.Entity("InsuranceCompany.Core.InsuranceRate", b =>
                {
                    b.Navigation("InsuranceRequests");
                });

            modelBuilder.Entity("InsuranceCompany.Core.InsuranceRequest", b =>
                {
                    b.Navigation("AnswerValues");

                    b.Navigation("InsuredPersons");
                });

            modelBuilder.Entity("InsuranceCompany.Core.InsuranceStatus", b =>
                {
                    b.Navigation("InsuranceRequests");
                });

            modelBuilder.Entity("InsuranceCompany.Core.InsuranceSurvey", b =>
                {
                    b.Navigation("InsuranceTypeSurveys");
                });

            modelBuilder.Entity("InsuranceCompany.Core.Position", b =>
                {
                    b.Navigation("Agents");

                    b.Navigation("PositionClients");
                });

            modelBuilder.Entity("InsuranceCompany.Core.Question", b =>
                {
                    b.Navigation("AnswerValues");

                    b.Navigation("Answers");

                    b.Navigation("QuestionSurveys");
                });

            modelBuilder.Entity("InsuranceCompany.Core.QuestionType", b =>
                {
                    b.Navigation("Questions");
                });

            modelBuilder.Entity("InsuranceCompany.Core.RuleRequest", b =>
                {
                    b.Navigation("QuestionSurveys");

                    b.Navigation("RuleTypeRequests");
                });

            modelBuilder.Entity("InsuranceCompany.Core.TypeRequest", b =>
                {
                    b.Navigation("InsuranceTypeSurveys");

                    b.Navigation("RuleTypeRequests");
                });
#pragma warning restore 612, 618
        }
    }
}
