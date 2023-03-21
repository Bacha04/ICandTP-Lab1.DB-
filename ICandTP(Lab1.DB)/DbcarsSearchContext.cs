using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ICandTP_Lab1.DB_;

public partial class DbcarsSearchContext : DbContext
{
    public DbcarsSearchContext()
    {
    }

    public DbcarsSearchContext(DbContextOptions<DbcarsSearchContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Brand> Brands { get; set; }

    public virtual DbSet<Country> Countries { get; set; }

    public virtual DbSet<Insuarence> Insuarences { get; set; }

    public virtual DbSet<Model> Models { get; set; }

    public virtual DbSet<Owner> Owners { get; set; }

    public virtual DbSet<Vechicle> Vechicles { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)

        => optionsBuilder.UseSqlServer("Server= Mi_G_Laptop\\SQLEXPRESS;\nDatabase=DBCarsSearch; Trusted_Connection=True; Trust Server Certificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Brand>(entity =>
        {
            entity.ToTable("Brand");

            entity.Property(e => e.BrandName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Brand_name");
            entity.Property(e => e.Concern)
                .HasMaxLength(40)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.CountryId).HasColumnName("Country_id");

            entity.HasOne(d => d.Country).WithMany(p => p.Brands)
                .HasForeignKey(d => d.CountryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Brand_Country");
        });

        modelBuilder.Entity<Country>(entity =>
        {
            entity.ToTable("Country");

            entity.Property(e => e.CountryName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("Country_name");
        });

        modelBuilder.Entity<Insuarence>(entity =>
        {
            entity.ToTable("Insuarence");

            entity.Property(e => e.ExpirationDate)
                .HasColumnType("date")
                .HasColumnName("Expiration_date");
            entity.Property(e => e.IssueDate)
                .HasColumnType("date")
                .HasColumnName("Issue_date");
            entity.Property(e => e.Type)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.VechicleVin)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("VechicleVIN");
        });

        modelBuilder.Entity<Model>(entity =>
        {
            entity.ToTable("Model");

            entity.Property(e => e.BodyTypes)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Body_types");
            entity.Property(e => e.BrandId).HasColumnName("Brand_id");
            entity.Property(e => e.Localisation)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ModelName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Model_name");

            entity.HasOne(d => d.Brand).WithMany(p => p.Models)
                .HasForeignKey(d => d.BrandId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Model_Brand");
        });

        modelBuilder.Entity<Owner>(entity =>
        {
            entity.HasKey(e => e.Tin);

            entity.Property(e => e.Tin).HasColumnName("TIN");
            entity.Property(e => e.City)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CountryId).HasColumnName("Country_id");
            entity.Property(e => e.DateOfBirth)
                .HasColumnType("date")
                .HasColumnName("Date_of_birth");
            entity.Property(e => e.FullName).HasMaxLength(50);

            entity.HasOne(d => d.Country).WithMany(p => p.Owners)
                .HasForeignKey(d => d.CountryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Owners_Country");
        });

        modelBuilder.Entity<Vechicle>(entity =>
        {
            entity.HasKey(e => e.Vin);

            entity.ToTable("Vechicle");

            entity.Property(e => e.Vin)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("VIN");
            entity.Property(e => e.DateOfIssue)
                .HasColumnType("date")
                .HasColumnName("Date_of_issue");
            entity.Property(e => e.EngineCapacity).HasColumnName("Engine_capacity");
            entity.Property(e => e.InsuarenceId).HasColumnName("Insuarence_id");
            entity.Property(e => e.ModelId).HasColumnName("Model_id");
            entity.Property(e => e.OwnerTin).HasColumnName("Owner_TIN");
            entity.Property(e => e.PlateNum)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("Plate_Num");

            entity.HasOne(d => d.Insuarence).WithMany(p => p.Vechicles)
                .HasForeignKey(d => d.InsuarenceId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Vechicle_Insuarence");

            entity.HasOne(d => d.Model).WithMany(p => p.Vechicles)
                .HasForeignKey(d => d.ModelId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Vechicle_Model");

            entity.HasOne(d => d.OwnerTinNavigation).WithMany(p => p.Vechicles)
                .HasForeignKey(d => d.OwnerTin)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Vechicle_Owners");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
