using InsuranceCompany.Core.Configuration;
using InsuranceCompany.Core.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace InsuranceCompany.Core;

public partial class InsuranceCompanyContext : IdentityDbContext<User>
{
    public InsuranceCompanyContext()
    {
    }

    public InsuranceCompanyContext(DbContextOptions<InsuranceCompanyContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Agent> Agents { get; set; }

    public virtual DbSet<Answer> Answers { get; set; }

    public virtual DbSet<AnswerValue> AnswerValues { get; set; }

    public virtual DbSet<Child> Children { get; set; }

    public virtual DbSet<Client> Clients { get; set; }

    public virtual DbSet<ClientaChild> ClientaChildren { get; set; }

    public virtual DbSet<InsuranceRate> InsuranceRates { get; set; }

    public virtual DbSet<InsuranceRequest> InsuranceRequests { get; set; }

    public virtual DbSet<InsuranceStatus> InsuranceStatuses { get; set; }

    public virtual DbSet<InsuranceSurvey> InsuranceSurveys { get; set; }
    public virtual DbSet<InsuredPerson> InsuredPersons { get; set; }

    public virtual DbSet<InsuranceTypeSurvey> InsuranceTypeSurveys { get; set; }

    public virtual DbSet<Position> Positions { get; set; }

    public virtual DbSet<PositionClient> PositionClients { get; set; }

    public virtual DbSet<Question> Questions { get; set; }

    public virtual DbSet<QuestionSurvey> QuestionSurveys { get; set; }

    public virtual DbSet<QuestionType> QuestionTypes { get; set; }

    public virtual DbSet<RuleRequest> RuleRequests { get; set; }

    public virtual DbSet<RuleTypeRequest> RuleTypeRequests { get; set; }

    public virtual DbSet<TypeRequest> TypeRequests { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
         => optionsBuilder
        .UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=InsuranceCompany;Trusted_Connection=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfiguration(new RoleConfiguration());

        modelBuilder.Entity<Agent>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Agent__3214EC075B5E885F");

            entity.ToTable("Agent");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.DateOfBirth).HasColumnType("datetime");
            entity.Property(e => e.DateOfStart).HasColumnType("datetime");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Surname)
                .HasMaxLength(255)
                .IsUnicode(false);

            entity.HasOne(d => d.Position).WithMany(p => p.Agents)
                .HasForeignKey(d => d.PositionId)
                .HasConstraintName("FK__Agent__PositionI__25869641");
        });

        modelBuilder.Entity<Answer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Answer__3214EC075FAE5581");

            entity.ToTable("Answer");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.QuestionAnswer)
                .HasMaxLength(1024)
                .IsUnicode(false)
                .HasColumnName("Answer");

            entity.HasOne(d => d.Question).WithMany(p => p.Answers)
                .HasForeignKey(d => d.QuestionId)
                .HasConstraintName("FK__Answer__Question__49C3F6B7");
        });

        modelBuilder.Entity<AnswerValue>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__AnswerVa__3214EC0713DBBB4E");

            entity.ToTable("AnswerValue");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Value)
                .HasMaxLength(1024)
                .IsUnicode(false);

            entity.HasOne(d => d.InsuranceRequest).WithMany(p => p.AnswerValues)
                .HasForeignKey(d => d.InsuranceRequestId)
                .HasConstraintName("FK__AnswerVal__Insur__5070F446");

            entity.HasOne(d => d.Question).WithMany(p => p.AnswerValues)
                .HasForeignKey(d => d.QuestionId)
                .HasConstraintName("FK__AnswerVal__Quest__5165187F");
        });

        modelBuilder.Entity<Child>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Child__3214EC07A1E18C97");

            entity.ToTable("Child");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Surname)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Client>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Client__3214EC075E2227B5");

            entity.ToTable("Client");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.DateOfBirth).HasColumnType("datetime");
        });

        modelBuilder.Entity<ClientaChild>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ClientaC__3214EC07D0A9F915");

            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.Child).WithMany(p => p.ClientaChildren)
                .HasForeignKey(d => d.ChildId)
                .HasConstraintName("FK__ClientaCh__Child__38996AB5");

            entity.HasOne(d => d.Client).WithMany(p => p.ClientaChildren)
                .HasForeignKey(d => d.ClientId)
                .HasConstraintName("FK__ClientaCh__Clien__37A5467C");
        });

        modelBuilder.Entity<InsuranceRate>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Insuranc__3214EC07497406FD");

            entity.ToTable("InsuranceRate");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.BasePayment).HasColumnType("money");
            entity.Property(e => e.UnitPayment).HasColumnType("money");
        });

        modelBuilder.Entity<InsuranceRequest>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Insuranc__3214EC070023678D");

            entity.ToTable("InsuranceRequest");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.DateOfEnd).HasColumnType("datetime");
            entity.Property(e => e.DateOfStart).HasColumnType("datetime");

            entity.HasOne(d => d.Agent).WithMany(p => p.InsuranceRequests)
                .HasForeignKey(d => d.AgentId)
                .HasConstraintName("FK__Insurance__Agent__2E1BDC42");

            entity.HasOne(d => d.InsuranceRate).WithMany(p => p.InsuranceRequests)
                .HasForeignKey(d => d.InsuranceRateId)
                .HasConstraintName("FK__Insurance__Insur__2F10007B");

            entity.HasOne(d => d.InsuranceStatus).WithMany(p => p.InsuranceRequests)
                .HasForeignKey(d => d.InsuranceStatusId)
                .HasConstraintName("FK__Insurance__Insur__5CD6CB2B");
        });

        modelBuilder.Entity<InsuranceStatus>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Insuranc__3214EC07B4801EDD");

            entity.ToTable("InsuranceStatus");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Color)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Status)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<InsuranceSurvey>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Insuranc__3214EC073B40440C");

            entity.ToTable("InsuranceSurvey");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Description)
                .HasMaxLength(1024)
                .IsUnicode(false);
            entity.Property(e => e.Title)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<InsuranceTypeSurvey>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Insuranc__3214EC07877F6247");

            entity.ToTable("InsuranceTypeSurvey");

            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.InsuranceSurvey).WithMany(p => p.InsuranceTypeSurveys)
                .HasForeignKey(d => d.InsuranceSurveyId)
                .HasConstraintName("FK__Insurance__Insur__6C190EBB");

            entity.HasOne(d => d.TypeRequest).WithMany(p => p.InsuranceTypeSurveys)
                .HasForeignKey(d => d.TypeRequestId)
                .HasConstraintName("FK__Insurance__TypeR__6D0D32F4");
        });

        modelBuilder.Entity<Position>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Position__3214EC07F7254960");

            entity.ToTable("Position");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Title)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<PositionClient>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Position__3214EC0715E303CD");

            entity.ToTable("PositionClient");

            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.Client).WithMany(p => p.PositionClients)
                .HasForeignKey(d => d.ClientId)
                .HasConstraintName("FK__PositionC__Clien__31EC6D26");

            entity.HasOne(d => d.Position).WithMany(p => p.PositionClients)
                .HasForeignKey(d => d.PositionId)
                .HasConstraintName("FK__PositionC__Posit__32E0915F");
        });

        modelBuilder.Entity<Question>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Question__3214EC070BC0CEF7");

            entity.ToTable("Question");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Text)
                .HasMaxLength(1024)
                .IsUnicode(false);

            entity.HasOne(d => d.QuestionType).WithMany(p => p.Questions)
                .HasForeignKey(d => d.QuestionTypeId)
                .HasConstraintName("FK__Question__Questi__46E78A0C");
        });

        modelBuilder.Entity<QuestionSurvey>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Question__3214EC07B61A0500");

            entity.ToTable("QuestionSurvey");

            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.Question).WithMany(p => p.QuestionSurveys)
                .HasForeignKey(d => d.QuestionId)
                .HasConstraintName("FK__QuestionS__Quest__4D94879B");

            entity.HasOne(d => d.Survey).WithMany(p => p.QuestionSurveys)
                .HasForeignKey(d => d.SurveyId)
                .HasConstraintName("FK__QuestionS__Surve__4CA06362");
        });

        modelBuilder.Entity<QuestionType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Question__3214EC072C41760D");

            entity.ToTable("QuestionType");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Text)
                .HasMaxLength(1024)
                .IsUnicode(false);
        });

        modelBuilder.Entity<RuleRequest>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__RuleRequ__3214EC074FC3163A");

            entity.ToTable("RuleRequest");

            entity.Property(e => e.Id).ValueGeneratedNever();
        });

        modelBuilder.Entity<RuleTypeRequest>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__RuleType__3214EC078EC75B84");

            entity.ToTable("RuleTypeRequest");

            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.Rule).WithMany(p => p.RuleTypeRequests)
                .HasForeignKey(d => d.RuleId)
                .HasConstraintName("FK__RuleTypeR__RuleI__3F466844");

            entity.HasOne(d => d.Type).WithMany(p => p.RuleTypeRequests)
                .HasForeignKey(d => d.TypeId)
                .HasConstraintName("FK__RuleTypeR__TypeI__403A8C7D");
        });

        modelBuilder.Entity<TypeRequest>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__TypeRequ__3214EC07B54222AA");

            entity.ToTable("TypeRequest");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Title)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
