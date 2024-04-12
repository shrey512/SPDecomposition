using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using RateCalculator.Domain.Entities;

namespace RateCalculator.Infrastructure.Data;

public partial class RateCalcDbContext : DbContext
{
    public RateCalcDbContext()
    {
    }

    public RateCalcDbContext(DbContextOptions<RateCalcDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TbMicroservice> TbMicroservices { get; set; }

    public virtual DbSet<XrxEmpEvent> XrxEmpEvents { get; set; }

    public virtual DbSet<XrxProposal> XrxProposals { get; set; }

    public virtual DbSet<XrxSubscriber> XrxSubscribers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=RateCalcDB;Integrated Security=true;TrustServerCertificate=true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TbMicroservice>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Tb_Microservice");

            entity.Property(e => e.Bene1Xml)
                .HasMaxLength(50)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("Bene1XML");
            entity.Property(e => e.Bene2Xml)
                .HasMaxLength(50)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("Bene2XML");
            entity.Property(e => e.CalcVarXml)
                .HasMaxLength(50)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("CalcVarXML");
            entity.Property(e => e.DepXml)
                .HasMaxLength(50)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("DepXML");
            entity.Property(e => e.EmpXml)
                .HasMaxLength(50)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("EmpXML");
            entity.Property(e => e.Plan1Xml)
                .HasMaxLength(50)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("Plan1XML");
        });

        modelBuilder.Entity<XrxEmpEvent>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Xrx_EmpEvent");

            entity.Property(e => e.Eventcode).HasColumnName("eventcode");
            entity.Property(e => e.Eventid).HasColumnName("eventid");
        });

        modelBuilder.Entity<XrxProposal>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Xrx_Proposal");

            entity.Property(e => e.PlanEffectiveDate).HasColumnType("date");
            entity.Property(e => e.ProposalId).HasColumnName("proposal_id");
        });

        modelBuilder.Entity<XrxSubscriber>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Xrx_Subscriber");

            entity.Property(e => e.ClassId).HasColumnName("class_id");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

}
