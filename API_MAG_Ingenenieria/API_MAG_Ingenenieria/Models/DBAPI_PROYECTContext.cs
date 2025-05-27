using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace API_MAG_Ingenenieria.Models
{
    public partial class DBAPI_PROYECTContext : DbContext
    {
        public DBAPI_PROYECTContext()
        {
        }

        public DBAPI_PROYECTContext(DbContextOptions<DBAPI_PROYECTContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Area> Areas { get; set; } = null!;
        public virtual DbSet<Cliente> Clientes { get; set; } = null!;
        public virtual DbSet<Maquina> Maquinas { get; set; } = null!;
        public virtual DbSet<Trabajo> Trabajos { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Area>(entity =>
            {
                entity.HasKey(e => e.IdArea)
                    .HasName("PK__Area__2FC141AA40AA098C");

                entity.ToTable("Area");

                entity.Property(e => e.NombreArea).HasMaxLength(50);

                entity.HasOne(d => d.IdClienteNavigation)
                    .WithMany(p => p.Areas)
                    .HasForeignKey(d => d.IdCliente)
                    .HasConstraintName("FK__Area__IdCliente__48CFD27E");
            });

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.HasKey(e => e.IdCliente)
                    .HasName("PK__Cliente__D59466424D514FA1");

                entity.ToTable("Cliente");

                entity.Property(e => e.Descripcion).HasMaxLength(300);

                entity.Property(e => e.NombreCliente).HasMaxLength(50);
            });

            modelBuilder.Entity<Maquina>(entity =>
            {
                entity.HasKey(e => e.IdMaquina)
                    .HasName("PK__Maquina__08E38C83CCA5F58A");

                entity.ToTable("Maquina");

                entity.Property(e => e.ArregloDescripcion).HasMaxLength(300);

                entity.Property(e => e.NombreMaquina).HasMaxLength(50);

                entity.Property(e => e.Precio).HasColumnType("decimal(10, 2)");

                entity.HasOne(d => d.IdAreaNavigation)
                    .WithMany(p => p.Maquinas)
                    .HasForeignKey(d => d.IdArea)
                    .HasConstraintName("FK__Maquina__IdArea__4BAC3F29");
            });

            modelBuilder.Entity<Trabajo>(entity =>
            {
                entity.HasKey(e => e.IdTrabajo)
                    .HasName("PK__Trabajo__4FB29E340744A402");

                entity.ToTable("Trabajo");

                entity.Property(e => e.Descripcion).HasMaxLength(300);

                entity.Property(e => e.FechaTrabajo)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.PagoTrabajo).HasMaxLength(15);

                entity.HasOne(d => d.IdMaquinaNavigation)
                    .WithMany(p => p.Trabajos)
                    .HasForeignKey(d => d.IdMaquina)
                    .HasConstraintName("FK__Trabajo__IdMaqui__5070F446");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
