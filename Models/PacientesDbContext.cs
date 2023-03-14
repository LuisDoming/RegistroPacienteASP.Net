using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace PacientesRegister.Models;

public partial class PacientesDbContext : DbContext
{
    public PacientesDbContext()
    {
    }

    public PacientesDbContext(DbContextOptions<PacientesDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<DatosPaciente> DatosPacientes { get; set; }

    public virtual DbSet<TipoSangre> TipoSangres { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=LUISARTUROD;DataBase=PacientesDB;Trusted_Connection=True;Trust Server Certificate=true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<DatosPaciente>(entity =>
        {
            entity.Property(e => e.Apellidos)
                .HasMaxLength(50)
                .IsFixedLength();
            entity.Property(e => e.Clavepaciente)
                .HasMaxLength(20)
                .IsFixedLength();
            entity.Property(e => e.DireccionPac)
                .HasMaxLength(80)
                .IsFixedLength();
            entity.Property(e => e.EmailPac)
                .HasMaxLength(50)
                .IsFixedLength();
            entity.Property(e => e.NombrePac)
                .HasMaxLength(50)
                .IsFixedLength();
            entity.Property(e => e.TelefonoCasa)
                .HasMaxLength(30)
                .IsFixedLength();
            entity.Property(e => e.TelefonoCelular)
                .HasMaxLength(30)
                .IsFixedLength();
            entity.Property(e => e.TipoSangreId).HasColumnName("TipoSangreID");

            entity.HasOne(d => d.TipoSangre).WithMany(p => p.DatosPacientes)
                .HasForeignKey(d => d.TipoSangreId)
                .HasConstraintName("FK_DatosPacientes_TipoSangre");
        });

        modelBuilder.Entity<TipoSangre>(entity =>
        {
            entity.ToTable("TipoSangre");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Tipo).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
