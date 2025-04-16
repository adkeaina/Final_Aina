using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Entertainment.API.Data;

public partial class EntertainmentDbContext : DbContext
{
    public EntertainmentDbContext()
    {
    }

    public EntertainmentDbContext(DbContextOptions<EntertainmentDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Agent> Agents { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Engagement> Engagements { get; set; }

    public virtual DbSet<Entertainer> Entertainers { get; set; }

    public virtual DbSet<EntertainerMember> EntertainerMembers { get; set; }

    public virtual DbSet<EntertainerStyle> EntertainerStyles { get; set; }

    public virtual DbSet<Member> Members { get; set; }

    public virtual DbSet<MusicalPreference> MusicalPreferences { get; set; }

    public virtual DbSet<MusicalStyle> MusicalStyles { get; set; }

    public virtual DbSet<ZtblDay> ZtblDays { get; set; }

    public virtual DbSet<ZtblMonth> ZtblMonths { get; set; }

    public virtual DbSet<ZtblSkipLabel> ZtblSkipLabels { get; set; }

    public virtual DbSet<ZtblWeek> ZtblWeeks { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=tcp:final-exam-aina.database.windows.net,1433;Initial Catalog=EntertainmentDB;Persist Security Info=False;User ID=adkeaina;Password=S4dCCrPJlleUUzZ3;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=True;Connection Timeout=30;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Agent>(entity =>
        {
            entity.HasKey(e => e.AgentId).HasName("PK__Agents__9AC3BFD1364EE9C7");

            entity.Property(e => e.AgentId)
                .ValueGeneratedNever()
                .HasColumnName("AgentID");
            entity.Property(e => e.AgtCity).IsUnicode(false);
            entity.Property(e => e.AgtFirstName).IsUnicode(false);
            entity.Property(e => e.AgtLastName).IsUnicode(false);
            entity.Property(e => e.AgtPhoneNumber).IsUnicode(false);
            entity.Property(e => e.AgtState).IsUnicode(false);
            entity.Property(e => e.AgtStreetAddress).IsUnicode(false);
            entity.Property(e => e.AgtZipCode).IsUnicode(false);
            entity.Property(e => e.CommissionRate).HasColumnType("numeric(18, 0)");
            entity.Property(e => e.DateHired).IsUnicode(false);
            entity.Property(e => e.Salary).HasColumnType("numeric(18, 0)");
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.CustomerId).HasName("PK__Customer__A4AE64B8ED9B054C");

            entity.Property(e => e.CustomerId)
                .ValueGeneratedNever()
                .HasColumnName("CustomerID");
            entity.Property(e => e.CustCity).IsUnicode(false);
            entity.Property(e => e.CustFirstName).IsUnicode(false);
            entity.Property(e => e.CustLastName).IsUnicode(false);
            entity.Property(e => e.CustPhoneNumber).IsUnicode(false);
            entity.Property(e => e.CustState).IsUnicode(false);
            entity.Property(e => e.CustStreetAddress).IsUnicode(false);
            entity.Property(e => e.CustZipCode).IsUnicode(false);
        });

        modelBuilder.Entity<Engagement>(entity =>
        {
            entity.HasKey(e => e.EngagementNumber).HasName("PK__Engageme__C1DAE6B9530BAB45");

            entity.Property(e => e.EngagementNumber).ValueGeneratedNever();
            entity.Property(e => e.AgentId).HasColumnName("AgentID");
            entity.Property(e => e.ContractPrice).HasColumnType("numeric(18, 0)");
            entity.Property(e => e.CustomerId).HasColumnName("CustomerID");
            entity.Property(e => e.EndDate).IsUnicode(false);
            entity.Property(e => e.EntertainerId).HasColumnName("EntertainerID");
            entity.Property(e => e.StartDate).IsUnicode(false);
            entity.Property(e => e.StartTime).IsUnicode(false);
            entity.Property(e => e.StopTime).IsUnicode(false);
        });

        modelBuilder.Entity<Entertainer>(entity =>
        {
            entity.HasKey(e => e.EntertainerId).HasName("PK__Entertai__89F70D23B5A21CD8");

            entity.Property(e => e.EntertainerId)
                .ValueGeneratedNever()
                .HasColumnName("EntertainerID");
            entity.Property(e => e.DateEntered).IsUnicode(false);
            entity.Property(e => e.EntCity).IsUnicode(false);
            entity.Property(e => e.EntEmailAddress)
                .IsUnicode(false)
                .HasColumnName("EntEMailAddress");
            entity.Property(e => e.EntPhoneNumber).IsUnicode(false);
            entity.Property(e => e.EntSsn)
                .IsUnicode(false)
                .HasColumnName("EntSSN");
            entity.Property(e => e.EntStageName).IsUnicode(false);
            entity.Property(e => e.EntState).IsUnicode(false);
            entity.Property(e => e.EntStreetAddress).IsUnicode(false);
            entity.Property(e => e.EntWebPage).IsUnicode(false);
            entity.Property(e => e.EntZipCode).IsUnicode(false);
        });

        modelBuilder.Entity<EntertainerMember>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Entertainer_Members");

            entity.Property(e => e.EntertainerId).HasColumnName("EntertainerID");
            entity.Property(e => e.MemberId).HasColumnName("MemberID");
        });

        modelBuilder.Entity<EntertainerStyle>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Entertainer_Styles");

            entity.Property(e => e.EntertainerId).HasColumnName("EntertainerID");
            entity.Property(e => e.StyleId).HasColumnName("StyleID");
        });

        modelBuilder.Entity<Member>(entity =>
        {
            entity.HasKey(e => e.MemberId).HasName("PK__Members__0CF04B38D8E7DB42");

            entity.Property(e => e.MemberId)
                .ValueGeneratedNever()
                .HasColumnName("MemberID");
            entity.Property(e => e.Gender).IsUnicode(false);
            entity.Property(e => e.MbrFirstName).IsUnicode(false);
            entity.Property(e => e.MbrLastName).IsUnicode(false);
            entity.Property(e => e.MbrPhoneNumber).IsUnicode(false);
        });

        modelBuilder.Entity<MusicalPreference>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Musical_Preferences");

            entity.Property(e => e.CustomerId).HasColumnName("CustomerID");
            entity.Property(e => e.StyleId).HasColumnName("StyleID");
        });

        modelBuilder.Entity<MusicalStyle>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Musical_Styles");

            entity.Property(e => e.StyleId).HasColumnName("StyleID");
            entity.Property(e => e.StyleName).IsUnicode(false);
        });

        modelBuilder.Entity<ZtblDay>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("ztblDays");

            entity.Property(e => e.DateField).IsUnicode(false);
        });

        modelBuilder.Entity<ZtblMonth>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("ztblMonths");

            entity.Property(e => e.MonthEnd).IsUnicode(false);
            entity.Property(e => e.MonthStart).IsUnicode(false);
            entity.Property(e => e.MonthYear).IsUnicode(false);
        });

        modelBuilder.Entity<ZtblSkipLabel>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("ztblSkipLabels");
        });

        modelBuilder.Entity<ZtblWeek>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("ztblWeeks");

            entity.Property(e => e.WeekEnd).IsUnicode(false);
            entity.Property(e => e.WeekStart).IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
