using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using sistem_supplier._Models;
using sistem_supplier._Models.Models;

namespace sistem_supplier.DAL.DContext;

public partial class TekusDbContext : DbContext
{
    public TekusDbContext()
    {
    }

    public TekusDbContext(DbContextOptions<TekusDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Proveedor> Proveedors { get; set; }

    public virtual DbSet<Servicio> Servicios { get; set; }

    public virtual DbSet<ServicioProveedor> ServicioProveedors { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Proveedor>(entity =>
        {
            entity.HasKey(e => e.idProveedor).HasName("PK__Proveedo__A3FA8E6B81640441");

            entity.ToTable("Proveedor");

            entity.Property(e => e.idProveedor).HasColumnName("idProveedor");
            entity.Property(e => e.CampoAdicional)
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasColumnName("campo_Adicional");
            entity.Property(e => e.NitProveedor)
                .HasMaxLength(90)
                .IsUnicode(false)
                .HasColumnName("nit_Proveedor");
            entity.Property(e => e.nomProveedor)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nom_Proveedor");
        });

        modelBuilder.Entity<Servicio>(entity =>
        {
            entity.HasKey(e => e.IdServicio).HasName("PK__Servicio__CEB98119F7052861");

            entity.ToTable("Servicio");

            entity.Property(e => e.IdServicio).HasColumnName("idServicio");
            entity.Property(e => e.NomServicio)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nom_Servicio");
            entity.Property(e => e.Pais)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("pais");
            entity.Property(e => e.ValorHora)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("valor_hora");
        });

        modelBuilder.Entity<ServicioProveedor>(entity =>
        {
            entity.HasKey(e => e.IdServicioProveedor).HasName("PK__Servicio__496283A8F79518E6");

            entity.ToTable("ServicioProveedor");

            entity.Property(e => e.IdServicioProveedor).HasColumnName("idServicioProveedor");
            entity.Property(e => e.IdProveedor).HasColumnName("idProveedor");
            entity.Property(e => e.IdServicio).HasColumnName("idServicio");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
