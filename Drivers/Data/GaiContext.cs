using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;

namespace Drivers.Data;

public partial class GaiContext : DbContext
{
    public GaiContext()
    {
    }

    public GaiContext(DbContextOptions<GaiContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Driver> Drivers { get; set; }

    public virtual DbSet<Photo> Photos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=127.0.0.1;database=gai;uid=root;pwd=12345", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.40-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Driver>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("driver", tb => tb.HasComment("	"));

            entity.HasIndex(e => e.PhotoId, "photoId_UNIQUE").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Description)
                .HasMaxLength(345)
                .HasColumnName("description");
            entity.Property(e => e.Email)
                .HasMaxLength(145)
                .HasColumnName("email");
            entity.Property(e => e.Guid)
                .HasMaxLength(45)
                .HasColumnName("guid");
            entity.Property(e => e.LivingAddress)
                .HasMaxLength(145)
                .HasColumnName("livingAddress");
            entity.Property(e => e.LivingCity)
                .HasMaxLength(45)
                .HasColumnName("livingCity");
            entity.Property(e => e.MobPhone)
                .HasMaxLength(15)
                .HasColumnName("mobPhone");
            entity.Property(e => e.Name)
                .HasMaxLength(45)
                .HasColumnName("name");
            entity.Property(e => e.PasportNumber)
                .HasMaxLength(45)
                .HasColumnName("pasportNumber");
            entity.Property(e => e.PasportSerial)
                .HasMaxLength(45)
                .HasColumnName("pasportSerial");
            entity.Property(e => e.Patronimic)
                .HasMaxLength(45)
                .HasColumnName("patronimic");
            entity.Property(e => e.PhotoId).HasColumnName("photoId");
            entity.Property(e => e.RegistrationAddress)
                .HasMaxLength(145)
                .HasColumnName("registrationAddress");
            entity.Property(e => e.RegistrationCity)
                .HasMaxLength(45)
                .HasColumnName("registrationCity");
            entity.Property(e => e.Surname)
                .HasMaxLength(45)
                .HasColumnName("surname");
            entity.Property(e => e.WorkPlace)
                .HasMaxLength(45)
                .HasColumnName("workPlace");
            entity.Property(e => e.WorkRole)
                .HasMaxLength(45)
                .HasColumnName("workRole");

            entity.HasOne(d => d.Photo).WithOne(p => p.Driver)
                .HasForeignKey<Driver>(d => d.PhotoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("aaa");
        });

        modelBuilder.Entity<Photo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("photo");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Photo1)
                .HasColumnType("blob")
                .HasColumnName("photo");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
