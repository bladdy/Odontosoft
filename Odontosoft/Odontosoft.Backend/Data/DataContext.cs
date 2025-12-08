using Microsoft.EntityFrameworkCore;
using Odontosoft.Shared.Entities;

namespace Odontosoft.Backend.Data;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }

    public DbSet<Clinica> Clinicas { get; set; }
    public DbSet<Sucursal> Sucursales { get; set; }
    public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<UsuarioSucursal> UsuarioSucursales { get; set; }
    public DbSet<ExpedienteClinico> ExpedientesClinicos { get; set; }
    public DbSet<Paciente> Pacientes { get; set; }
    public DbSet<NotaClinica> NotasClinicas { get; set; }
    public DbSet<Diagnostico> Diagnosticos { get; set; }
    public DbSet<Tratamiento> Tratamientos { get; set; }
    public DbSet<Radiografia> Radiografias { get; set; }
    public DbSet<FotografiaIntraoral> FotografiasIntraorales { get; set; }
    public DbSet<Evolucion> Evoluciones { get; set; }
    public DbSet<FirmaDigital> FirmasDigitales { get; set; }
    public DbSet<Prescripcion> Prescripciones { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<UsuarioSucursal>()
            .HasKey(us => new { us.UsuarioId, us.SucursalId });

        modelBuilder.Entity<UsuarioSucursal>()
            .HasOne(us => us.Usuario)
            .WithMany(u => u.UsuarioSucursales)
            .HasForeignKey(us => us.UsuarioId);

        modelBuilder.Entity<UsuarioSucursal>()
            .HasOne(us => us.Sucursal)
            .WithMany(s => s.UsuarioSucursales)
            .HasForeignKey(us => us.SucursalId);

        modelBuilder.Entity<ExpedienteClinico>()
            .HasOne(e => e.Sucursal)
            .WithMany(s => s.ExpedientesClinicos)
            .HasForeignKey(e => e.SucursalId);

        modelBuilder.Entity<Tratamiento>()
            .Property(t => t.Costo)
            .HasColumnType("decimal(18,2)");
    }
}