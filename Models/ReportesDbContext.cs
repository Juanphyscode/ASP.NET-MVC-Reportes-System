using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ReportesMVC.Models;

public partial class ReportesDbContext : DbContext
{
    public ReportesDbContext()
    {
    }

    public ReportesDbContext(DbContextOptions<ReportesDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Compañium> Compañia { get; set; }

    public virtual DbSet<DetalleFactura> DetalleFacturas { get; set; }

    public virtual DbSet<Dium> Dia { get; set; }

    public virtual DbSet<EnfermedadesIntervencionesPersona> EnfermedadesIntervencionesPersonas { get; set; }

    public virtual DbSet<ExpedienteVacunacion> ExpedienteVacunacions { get; set; }

    public virtual DbSet<Factura> Facturas { get; set; }

    public virtual DbSet<FichaMedica> FichaMedicas { get; set; }

    public virtual DbSet<GrupoSanguineo> GrupoSanguineos { get; set; }

    public virtual DbSet<Hora> Horas { get; set; }

    public virtual DbSet<HoraDiaActividadPersona> HoraDiaActividadPersonas { get; set; }

    public virtual DbSet<MarcaVacuna> MarcaVacunas { get; set; }

    public virtual DbSet<MedicamentoConsumoPersona> MedicamentoConsumoPersonas { get; set; }

    public virtual DbSet<MedicoTelefonoPersona> MedicoTelefonoPersonas { get; set; }

    public virtual DbSet<ObservacionesPersona> ObservacionesPersonas { get; set; }

    public virtual DbSet<Persona> Personas { get; set; }

    public virtual DbSet<Producto> Productos { get; set; }

    public virtual DbSet<Sexo> Sexos { get; set; }

    public virtual DbSet<SistemaSalud> SistemaSaluds { get; set; }

    public virtual DbSet<TipoAlergium> TipoAlergia { get; set; }

    public virtual DbSet<TipoDocumentoIdentificacion> TipoDocumentoIdentificacions { get; set; }

    public virtual DbSet<TratamientoMedicoPersona> TratamientoMedicoPersonas { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=localhost;Database=BDReportes;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<DetalleFactura>(entity =>
        {
            entity.HasKey(e => e.Iiddetallefactura).HasName("PK_DetalleFacturas");

            entity.HasOne(d => d.IidfacturaNavigation).WithMany(p => p.DetalleFacturas).HasConstraintName("FK_DetalleFacturas_Factura");

            entity.HasOne(d => d.IidproductoNavigation).WithMany(p => p.DetalleFacturas).HasConstraintName("FK_DetalleFacturas_Producto");
        });

        modelBuilder.Entity<EnfermedadesIntervencionesPersona>(entity =>
        {
            entity.HasKey(e => e.Iidenfermedadesintervenciones).HasName("PK_EnfermedadesIntervenciones");

            entity.HasOne(d => d.IidpersonaNavigation).WithMany(p => p.EnfermedadesIntervencionesPersonas).HasConstraintName("FK_EnfermedadesIntervencionesPersona_EnfermedadesIntervencionesPersona");
        });

        modelBuilder.Entity<ExpedienteVacunacion>(entity =>
        {
            entity.HasOne(d => d.IidmarcavacunaNavigation).WithMany(p => p.ExpedienteVacunacions).HasConstraintName("FK_ExpedienteVacunacion_MarcaVacuna");

            entity.HasOne(d => d.IidpersonaNavigation).WithMany(p => p.ExpedienteVacunacions).HasConstraintName("FK_ExpedienteVacunacion_Persona");
        });

        modelBuilder.Entity<Factura>(entity =>
        {
            entity.HasKey(e => e.Iidfactura).HasName("PK_Facturas");

            entity.HasOne(d => d.IidcompaniaNavigation).WithMany(p => p.Facturas).HasConstraintName("FK_Facturas_Compañia");
        });

        modelBuilder.Entity<FichaMedica>(entity =>
        {
            entity.HasOne(d => d.IidgruposanguineoNavigation).WithMany(p => p.FichaMedicas).HasConstraintName("FK_FichaMedica_GrupoSanguineo");

            entity.HasOne(d => d.IidpersonaNavigation).WithMany(p => p.FichaMedicas).HasConstraintName("FK_FichaMedica_Persona");

            entity.HasOne(d => d.IidsistemasaludNavigation).WithMany(p => p.FichaMedicas).HasConstraintName("FK_FichaMedica_SistemaSalud");

            entity.HasOne(d => d.IidtipoalergiaNavigation).WithMany(p => p.FichaMedicas).HasConstraintName("FK_FichaMedica_TipoAlergia");
        });

        modelBuilder.Entity<Hora>(entity =>
        {
            entity.HasKey(e => e.Iidhora).HasName("PK_Horass");
        });

        modelBuilder.Entity<HoraDiaActividadPersona>(entity =>
        {
            entity.HasOne(d => d.IiddiaNavigation).WithMany(p => p.HoraDiaActividadPersonas).HasConstraintName("FK_HoraDiaActividadPersona_Dia");

            entity.HasOne(d => d.IidhoraNavigation).WithMany(p => p.HoraDiaActividadPersonas).HasConstraintName("FK_HoraDiaActividadPersona_Hora");

            entity.HasOne(d => d.IidpersonaNavigation).WithMany(p => p.HoraDiaActividadPersonas).HasConstraintName("FK_HoraDiaActividadPersona_Persona");
        });

        modelBuilder.Entity<MedicamentoConsumoPersona>(entity =>
        {
            entity.HasOne(d => d.IidpersonaNavigation).WithMany(p => p.MedicamentoConsumoPersonas).HasConstraintName("FK_MedicamentoConsumoPersona_Persona");
        });

        modelBuilder.Entity<MedicoTelefonoPersona>(entity =>
        {
            entity.HasOne(d => d.IidpersonaNavigation).WithMany(p => p.MedicoTelefonoPersonas).HasConstraintName("FK_MedicoTelefonoPersona_Persona");
        });

        modelBuilder.Entity<ObservacionesPersona>(entity =>
        {
            entity.HasOne(d => d.IidpersonaNavigation).WithMany(p => p.ObservacionesPersonas).HasConstraintName("FK_ObservacionesPersona_Persona");
        });

        modelBuilder.Entity<Persona>(entity =>
        {
            entity.HasOne(d => d.IidsexoNavigation).WithMany(p => p.Personas).HasConstraintName("FK_Persona_Sexo1");

            entity.HasOne(d => d.IidtipodocumentoNavigation).WithMany(p => p.Personas).HasConstraintName("FK_Persona_Sexo");
        });

        modelBuilder.Entity<TipoAlergium>(entity =>
        {
            entity.Property(e => e.Bhabilitado).IsFixedLength();
        });

        modelBuilder.Entity<TratamientoMedicoPersona>(entity =>
        {
            entity.HasOne(d => d.IidpersonaNavigation).WithMany(p => p.TratamientoMedicoPersonas).HasConstraintName("FK_TratamientoMedicoPersona_Persona");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
