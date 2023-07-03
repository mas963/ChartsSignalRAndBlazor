using System;
using System.Collections.Generic;
using ChartsSignalRAndBlazor.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace ChartsSignalRAndBlazor.Server.Data;

public partial class SatisDbContext : DbContext
{
    public SatisDbContext()
    {
    }

    public SatisDbContext(DbContextOptions<SatisDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Personeller> Personellers { get; set; }

    public virtual DbSet<Satislar> Satislars { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Server=.;Database=SatisDb;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Personeller>(entity =>
        {
            entity.ToTable("Personeller", tb => tb.HasTrigger("tr_dbo_Personeller_d0db6a69-30fb-4e0c-a833-e627c9d57fa1_Sender"));
            entity.Property(e => e.Adi).HasMaxLength(50);
            entity.Property(e => e.Soyadi).HasMaxLength(50);
        });

        modelBuilder.Entity<Satislar>(entity =>
        {
            entity.ToTable("Satislar", tb => tb.HasTrigger("tr_dbo_Satislar_3736d129-4ede-4d4e-a0d9-36734d62b9e0_Sender"));
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
