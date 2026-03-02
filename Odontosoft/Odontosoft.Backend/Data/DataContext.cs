using Microsoft.EntityFrameworkCore;
using Odontosoft.Backend.Services;
using Odontosoft.Shared.Entities;
using Odontosoft.Shared.Interfaces;
using System.Reflection;

namespace Odontosoft.Backend.Data;

public class DataContext : DbContext
{
    private readonly ITenantService _tenantService;

    public DataContext(
        DbContextOptions<DataContext> options,
        ITenantService tenantService)
        : base(options)
    {
        _tenantService = tenantService;
    }

    // Tenants (multi-tenant)
    public DbSet<Tenant> Tenants { get; set; }

    // DbSets principales
    public DbSet<Clinica> Clinicas { get; set; }

    public DbSet<Sucursal> Sucursales { get; set; }
    public DbSet<Modulo> Modulos { get; set; }
    public DbSet<ClinicaModulo> ClinicaModulos { get; set; }

    // Usuarios y permisos
    public DbSet<Usuario> Usuarios { get; set; }

    public DbSet<UsuarioSucursal> UsuarioSucursales { get; set; }
    public DbSet<PermisoModulo> PermisosModulo { get; set; }
    public DbSet<Rol> Roles { get; set; }
    public DbSet<RolPermiso> RolPermisos { get; set; }
    public DbSet<UsuarioRol> UsuarioRoles { get; set; }

    // Pacientes
    public DbSet<Paciente> Pacientes { get; set; }

    public DbSet<Alergia> Alergias { get; set; }
    public DbSet<Antecedente> Antecedentes { get; set; }

    // Médicos
    public DbSet<Medico> Medicos { get; set; }

    public DbSet<Especialidad> Especialidades { get; set; }
    public DbSet<MedicoEspecialidad> MedicoEspecialidades { get; set; }
    public DbSet<HorarioMedico> HorariosMedico { get; set; }

    // Citas y Consultorios
    public DbSet<Cita> Citas { get; set; }

    public DbSet<Consultorio> Consultorios { get; set; }

    // Consultas
    public DbSet<Consulta> Consultas { get; set; }

    public DbSet<HistoriaClinica> HistoriasClinicas { get; set; }

    // Recetas
    public DbSet<Receta> Recetas { get; set; }

    public DbSet<RecetaDetalle> RecetaDetalles { get; set; }
    public DbSet<Medicamento> Medicamentos { get; set; }

    // Laboratorio
    public DbSet<OrdenLaboratorio> OrdenesLaboratorio { get; set; }

    public DbSet<OrdenLaboratorioDetalle> OrdenLaboratorioDetalles { get; set; }
    public DbSet<EstudioLaboratorio> EstudiosLaboratorio { get; set; }

    // Imagenología
    public DbSet<OrdenImagen> OrdenesImagen { get; set; }

    public DbSet<OrdenImagenDetalle> OrdenImagenDetalles { get; set; }
    public DbSet<EstudioImagen> EstudiosImagen { get; set; }

    // Facturación
    public DbSet<Factura> Facturas { get; set; }

    public DbSet<FacturaDetalle> FacturaDetalles { get; set; }
    public DbSet<Servicio> Servicios { get; set; }
    public DbSet<Pago> Pagos { get; set; }

    // Inventario
    public DbSet<Producto> Productos { get; set; }

    public DbSet<MovimientoInventario> MovimientosInventario { get; set; }

    // Auditoría y configuración
    public DbSet<AuditoriaAcceso> AuditoriasAcceso { get; set; }

    public DbSet<AuditoriaCambios> AuditoriasCambios { get; set; }
    public DbSet<ConfiguracionGeneral> ConfiguracionesGenerales { get; set; }
    public DbSet<Notificacion> Notificaciones { get; set; }

    // ==================== DBSETS ODONTOLOGÍA (NUEVOS) ====================
    public DbSet<Odontograma> Odontogramas { get; set; }

    public DbSet<DienteEstado> DientesEstado { get; set; }
    public DbSet<TratamientoDental> TratamientosDentales { get; set; }
    public DbSet<SeguimientoTratamiento> SeguimientosTratamiento { get; set; }
    public DbSet<PresupuestoDental> PresupuestosDentales { get; set; }
    public DbSet<PresupuestoDetalle> PresupuestosDetalle { get; set; }
    public DbSet<RadiografiaDental> RadiografiasDentales { get; set; }
    public DbSet<ExamenPeriodontal> ExamenesPeriodontales { get; set; }
    public DbSet<BolsaPeriodontal> BolsasPeriodontales { get; set; }
    public DbSet<TratamientoOrtodoncia> TratamientosOrtodoncia { get; set; }
    public DbSet<ControlOrtodoncia> ControlesOrtodoncia { get; set; }
    public DbSet<ConsentimientoInformado> ConsentimientosInformados { get; set; }
    public DbSet<CatalogoTratamientoDental> CatalogoTratamientosDentales { get; set; }
    public DbSet<MaterialDental> MaterialesDentales { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // ==================== TU CONFIGURACIÓN ORIGINAL (SIN CAMBIOS) ====================

        foreach (var entityType in modelBuilder.Model.GetEntityTypes())
        {
            if (typeof(ITenantEntity).IsAssignableFrom(entityType.ClrType))
            {
                var method = typeof(DataContext)
                    .GetMethod(nameof(SetTenantFilter), BindingFlags.NonPublic | BindingFlags.Instance)!
                    .MakeGenericMethod(entityType.ClrType);

                method.Invoke(this, new object[] { modelBuilder });
            }
        }

        modelBuilder.Entity<Clinica>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.ToTable("Clinicas");
            entity.HasIndex(e => e.RFC).IsUnique();
            entity.HasIndex(e => e.Email);
        });

        modelBuilder.Entity<Sucursal>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.ToTable("Sucursales");
            entity.HasIndex(e => new { e.ClinicaId, e.Codigo }).IsUnique();

            entity.HasOne(e => e.Clinica)
                .WithMany(e => e.Sucursales)
                .HasForeignKey(e => e.ClinicaId)
                .OnDelete(DeleteBehavior.Restrict);
        });

        modelBuilder.Entity<Modulo>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.ToTable("Modulos");
            entity.HasIndex(e => e.Codigo).IsUnique();

            entity.HasOne(e => e.ModuloPadre)
                .WithMany(e => e.SubModulos)
                .HasForeignKey(e => e.ModuloPadreId)
                .OnDelete(DeleteBehavior.Restrict);
        });

        modelBuilder.Entity<ClinicaModulo>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.ToTable("ClinicaModulos");
            entity.HasIndex(e => new { e.ClinicaId, e.ModuloId }).IsUnique();

            entity.HasOne(e => e.Clinica)
                .WithMany(e => e.ClinicaModulos)
                .HasForeignKey(e => e.ClinicaId)
                .OnDelete(DeleteBehavior.Cascade);

            entity.HasOne(e => e.Modulo)
                .WithMany(e => e.ClinicaModulos)
                .HasForeignKey(e => e.ModuloId)
                .OnDelete(DeleteBehavior.Restrict);
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.ToTable("Usuarios");
            entity.HasIndex(e => e.Email).IsUnique();
            entity.HasIndex(e => e.NombreUsuario).IsUnique();
        });

        modelBuilder.Entity<UsuarioSucursal>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.ToTable("UsuarioSucursales");
            entity.HasIndex(e => new { e.UsuarioId, e.SucursalId }).IsUnique();

            entity.HasOne(e => e.Usuario)
                .WithMany(e => e.UsuarioSucursales)
                .HasForeignKey(e => e.UsuarioId)
                .OnDelete(DeleteBehavior.Cascade);

            entity.HasOne(e => e.Sucursal)
                .WithMany(e => e.UsuarioSucursales)
                .HasForeignKey(e => e.SucursalId)
                .OnDelete(DeleteBehavior.Restrict);
        });

        modelBuilder.Entity<PermisoModulo>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.ToTable("PermisosModulo");
            entity.HasIndex(e => new { e.UsuarioSucursalId, e.ModuloId }).IsUnique();

            entity.HasOne(e => e.UsuarioSucursal)
                .WithMany(e => e.PermisosModulo)
                .HasForeignKey(e => e.UsuarioSucursalId)
                .OnDelete(DeleteBehavior.Cascade);

            entity.HasOne(e => e.Modulo)
                .WithMany(e => e.PermisosModulo)
                .HasForeignKey(e => e.ModuloId)
                .OnDelete(DeleteBehavior.Restrict);
        });

        modelBuilder.Entity<Rol>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.ToTable("Roles");
        });

        modelBuilder.Entity<RolPermiso>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.ToTable("RolPermisos");
            entity.HasIndex(e => new { e.RolId, e.ModuloId }).IsUnique();

            entity.HasOne(e => e.Rol)
                .WithMany(e => e.RolPermisos)
                .HasForeignKey(e => e.RolId)
                .OnDelete(DeleteBehavior.Cascade);

            entity.HasOne(e => e.Modulo)
                .WithMany()
                .HasForeignKey(e => e.ModuloId)
                .OnDelete(DeleteBehavior.Restrict);
        });

        modelBuilder.Entity<UsuarioRol>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.ToTable("UsuarioRoles");
            entity.HasIndex(e => new { e.UsuarioSucursalId, e.RolId }).IsUnique();

            entity.HasOne(e => e.UsuarioSucursal)
                .WithMany()
                .HasForeignKey(e => e.UsuarioSucursalId)
                .OnDelete(DeleteBehavior.Cascade);

            entity.HasOne(e => e.Rol)
                .WithMany(e => e.UsuarioRoles)
                .HasForeignKey(e => e.RolId)
                .OnDelete(DeleteBehavior.Restrict);
        });

        modelBuilder.Entity<Paciente>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.ToTable("Pacientes");
            entity.HasIndex(e => new { e.SucursalId, e.NumeroExpediente }).IsUnique();
            entity.HasIndex(e => e.CURP);
            entity.HasIndex(e => e.Email);

            entity.HasOne(e => e.Sucursal)
                .WithMany(e => e.Pacientes)
                .HasForeignKey(e => e.SucursalId)
                .OnDelete(DeleteBehavior.Restrict);
        });

        modelBuilder.Entity<Alergia>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.ToTable("Alergias");

            entity.HasOne(e => e.Paciente)
                .WithMany(e => e.Alergias)
                .HasForeignKey(e => e.PacienteId)
                .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<Antecedente>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.ToTable("Antecedentes");

            entity.HasOne(e => e.Paciente)
                .WithMany(e => e.Antecedentes)
                .HasForeignKey(e => e.PacienteId)
                .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<Medico>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.ToTable("Medicos");
            entity.HasIndex(e => e.CedulaProfesional).IsUnique();

            entity.HasOne(e => e.Usuario)
                .WithMany(e => e.Medicos)
                .HasForeignKey(e => e.UsuarioId)
                .OnDelete(DeleteBehavior.Restrict);
        });

        modelBuilder.Entity<Especialidad>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.ToTable("Especialidades");
        });

        modelBuilder.Entity<MedicoEspecialidad>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.ToTable("MedicoEspecialidades");
            entity.HasIndex(e => new { e.MedicoId, e.EspecialidadId }).IsUnique();

            entity.HasOne(e => e.Medico)
                .WithMany(e => e.MedicoEspecialidades)
                .HasForeignKey(e => e.MedicoId)
                .OnDelete(DeleteBehavior.Cascade);

            entity.HasOne(e => e.Especialidad)
                .WithMany(e => e.MedicoEspecialidades)
                .HasForeignKey(e => e.EspecialidadId)
                .OnDelete(DeleteBehavior.Restrict);
        });

        modelBuilder.Entity<HorarioMedico>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.ToTable("HorariosMedico");
            entity.HasIndex(e => new { e.MedicoId, e.SucursalId, e.DiaSemana });

            entity.HasOne(e => e.Medico)
                .WithMany(e => e.HorariosMedico)
                .HasForeignKey(e => e.MedicoId)
                .OnDelete(DeleteBehavior.Cascade);

            entity.HasOne(e => e.Sucursal)
                .WithMany()
                .HasForeignKey(e => e.SucursalId)
                .OnDelete(DeleteBehavior.Restrict);
        });

        modelBuilder.Entity<Cita>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.ToTable("Citas");
            entity.HasIndex(e => e.NumeroCita).IsUnique();
            entity.HasIndex(e => new { e.MedicoId, e.FechaHora });
            entity.HasIndex(e => new { e.PacienteId, e.FechaHora });
            entity.HasIndex(e => e.EstadoCita);

            entity.HasOne(e => e.Sucursal)
                .WithMany(e => e.Citas)
                .HasForeignKey(e => e.SucursalId)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(e => e.Paciente)
                .WithMany(e => e.Citas)
                .HasForeignKey(e => e.PacienteId)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(e => e.Medico)
                .WithMany(e => e.Citas)
                .HasForeignKey(e => e.MedicoId)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(e => e.Consultorio)
                .WithMany(e => e.Citas)
                .HasForeignKey(e => e.ConsultorioId)
                .OnDelete(DeleteBehavior.SetNull);
        });

        modelBuilder.Entity<Consultorio>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.ToTable("Consultorios");
            entity.HasIndex(e => new { e.SucursalId, e.Numero }).IsUnique();

            entity.HasOne(e => e.Sucursal)
                .WithMany(e => e.Consultorios)
                .HasForeignKey(e => e.SucursalId)
                .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<Consulta>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.ToTable("Consultas");
            entity.HasIndex(e => e.NumeroConsulta).IsUnique();
            entity.HasIndex(e => new { e.PacienteId, e.FechaConsulta });

            entity.HasOne(e => e.Cita)
                .WithOne(e => e.Consulta)
                .HasForeignKey<Consulta>(e => e.CitaId)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(e => e.Medico)
                .WithMany(e => e.Consultas)
                .HasForeignKey(e => e.MedicoId)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(e => e.Paciente)
                .WithMany()
                .HasForeignKey(e => e.PacienteId)
                .OnDelete(DeleteBehavior.Restrict);

            entity.Property(e => e.Peso).HasPrecision(5, 2);
            entity.Property(e => e.Altura).HasPrecision(5, 2);
            entity.Property(e => e.IMC).HasPrecision(5, 2);
            entity.Property(e => e.Temperatura).HasPrecision(4, 2);
        });

        modelBuilder.Entity<HistoriaClinica>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.ToTable("HistoriasClinicas");
            entity.HasIndex(e => new { e.PacienteId, e.FechaRegistro });

            entity.HasOne(e => e.Paciente)
                .WithMany(e => e.HistoriasClinicas)
                .HasForeignKey(e => e.PacienteId)
                .OnDelete(DeleteBehavior.Cascade);

            entity.HasOne(e => e.Consulta)
                .WithMany()
                .HasForeignKey(e => e.ConsultaId)
                .OnDelete(DeleteBehavior.SetNull);
        });

        modelBuilder.Entity<Receta>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.ToTable("Recetas");
            entity.HasIndex(e => e.NumeroReceta).IsUnique();

            entity.HasOne(e => e.Consulta)
                .WithMany(e => e.Recetas)
                .HasForeignKey(e => e.ConsultaId)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(e => e.Paciente)
                .WithMany(e => e.Recetas)
                .HasForeignKey(e => e.PacienteId)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(e => e.Medico)
                .WithMany()
                .HasForeignKey(e => e.MedicoId)
                .OnDelete(DeleteBehavior.Restrict);
        });

        modelBuilder.Entity<RecetaDetalle>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.ToTable("RecetaDetalles");

            entity.HasOne(e => e.Receta)
                .WithMany(e => e.RecetaDetalles)
                .HasForeignKey(e => e.RecetaId)
                .OnDelete(DeleteBehavior.Cascade);

            entity.HasOne(e => e.Medicamento)
                .WithMany(e => e.RecetaDetalles)
                .HasForeignKey(e => e.MedicamentoId)
                .OnDelete(DeleteBehavior.SetNull);
        });

        modelBuilder.Entity<Medicamento>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.ToTable("Medicamentos");
            entity.HasIndex(e => e.Nombre);
        });

        modelBuilder.Entity<OrdenLaboratorio>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.ToTable("OrdenesLaboratorio");
            entity.HasIndex(e => e.NumeroOrden).IsUnique();

            entity.HasOne(e => e.Consulta)
                .WithMany(e => e.OrdenesLaboratorio)
                .HasForeignKey(e => e.ConsultaId)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(e => e.Paciente)
                .WithMany(e => e.OrdenesLaboratorio)
                .HasForeignKey(e => e.PacienteId)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(e => e.Medico)
                .WithMany()
                .HasForeignKey(e => e.MedicoId)
                .OnDelete(DeleteBehavior.Restrict);
        });

        modelBuilder.Entity<OrdenLaboratorioDetalle>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.ToTable("OrdenLaboratorioDetalles");

            entity.HasOne(e => e.OrdenLaboratorio)
                .WithMany(e => e.OrdenLaboratorioDetalles)
                .HasForeignKey(e => e.OrdenLaboratorioId)
                .OnDelete(DeleteBehavior.Cascade);

            entity.HasOne(e => e.EstudioLaboratorio)
                .WithMany(e => e.OrdenLaboratorioDetalles)
                .HasForeignKey(e => e.EstudioLaboratorioId)
                .OnDelete(DeleteBehavior.Restrict);
        });

        modelBuilder.Entity<EstudioLaboratorio>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.ToTable("EstudiosLaboratorio");
            entity.HasIndex(e => e.Codigo);

            entity.Property(e => e.Precio).HasPrecision(10, 2);
        });

        modelBuilder.Entity<OrdenImagen>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.ToTable("OrdenesImagen");
            entity.HasIndex(e => e.NumeroOrden).IsUnique();

            entity.HasOne(e => e.Consulta)
                .WithMany(e => e.OrdenesImagen)
                .HasForeignKey(e => e.ConsultaId)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(e => e.Paciente)
                .WithMany(e => e.OrdenesImagen)
                .HasForeignKey(e => e.PacienteId)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(e => e.Medico)
                .WithMany()
                .HasForeignKey(e => e.MedicoId)
                .OnDelete(DeleteBehavior.Restrict);
        });

        modelBuilder.Entity<OrdenImagenDetalle>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.ToTable("OrdenImagenDetalles");

            entity.HasOne(e => e.OrdenImagen)
                .WithMany(e => e.OrdenImagenDetalles)
                .HasForeignKey(e => e.OrdenImagenId)
                .OnDelete(DeleteBehavior.Cascade);

            entity.HasOne(e => e.EstudioImagen)
                .WithMany(e => e.OrdenImagenDetalles)
                .HasForeignKey(e => e.EstudioImagenId)
                .OnDelete(DeleteBehavior.Restrict);
        });

        modelBuilder.Entity<EstudioImagen>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.ToTable("EstudiosImagen");
            entity.HasIndex(e => e.Codigo);

            entity.Property(e => e.Precio).HasPrecision(10, 2);
        });

        modelBuilder.Entity<Factura>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.ToTable("Facturas");
            entity.HasIndex(e => e.NumeroFactura).IsUnique();
            entity.HasIndex(e => e.UUID);
            entity.HasIndex(e => new { e.PacienteId, e.FechaEmision });

            entity.HasOne(e => e.Sucursal)
                .WithMany()
                .HasForeignKey(e => e.SucursalId)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(e => e.Paciente)
                .WithMany(e => e.Facturas)
                .HasForeignKey(e => e.PacienteId)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(e => e.Cita)
                .WithMany()
                .HasForeignKey(e => e.CitaId)
                .OnDelete(DeleteBehavior.SetNull);

            entity.Property(e => e.Subtotal).HasPrecision(18, 2);
            entity.Property(e => e.IVA).HasPrecision(18, 2);
            entity.Property(e => e.Total).HasPrecision(18, 2);
            entity.Property(e => e.Descuento).HasPrecision(18, 2);
        });

        modelBuilder.Entity<FacturaDetalle>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.ToTable("FacturaDetalles");

            entity.HasOne(e => e.Factura)
                .WithMany(e => e.FacturaDetalles)
                .HasForeignKey(e => e.FacturaId)
                .OnDelete(DeleteBehavior.Cascade);

            entity.HasOne(e => e.Servicio)
                .WithMany(e => e.FacturaDetalles)
                .HasForeignKey(e => e.ServicioId)
                .OnDelete(DeleteBehavior.SetNull);

            entity.Property(e => e.Cantidad).HasPrecision(18, 2);
            entity.Property(e => e.PrecioUnitario).HasPrecision(18, 2);
            entity.Property(e => e.Subtotal).HasPrecision(18, 2);
            entity.Property(e => e.IVA).HasPrecision(18, 2);
            entity.Property(e => e.Total).HasPrecision(18, 2);
            entity.Property(e => e.Descuento).HasPrecision(18, 2);
        });

        modelBuilder.Entity<Servicio>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.ToTable("Servicios");
            entity.HasIndex(e => e.Codigo);

            entity.Property(e => e.Precio).HasPrecision(18, 2);
            entity.Property(e => e.IVA).HasPrecision(5, 2);
        });

        modelBuilder.Entity<Pago>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.ToTable("Pagos");
            entity.HasIndex(e => e.NumeroPago).IsUnique();

            entity.HasOne(e => e.Factura)
                .WithMany(e => e.Pagos)
                .HasForeignKey(e => e.FacturaId)
                .OnDelete(DeleteBehavior.Restrict);

            entity.Property(e => e.Monto).HasPrecision(18, 2);
        });

        modelBuilder.Entity<Producto>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.ToTable("Productos");
            entity.HasIndex(e => new { e.SucursalId, e.Codigo }).IsUnique();
            entity.HasIndex(e => e.CodigoBarras);

            entity.HasOne(e => e.Sucursal)
                .WithMany()
                .HasForeignKey(e => e.SucursalId)
                .OnDelete(DeleteBehavior.Restrict);

            entity.Property(e => e.PrecioCompra).HasPrecision(18, 2);
            entity.Property(e => e.PrecioVenta).HasPrecision(18, 2);
        });

        modelBuilder.Entity<MovimientoInventario>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.ToTable("MovimientosInventario");
            entity.HasIndex(e => new { e.ProductoId, e.FechaMovimiento });

            entity.HasOne(e => e.Producto)
                .WithMany(e => e.MovimientosInventario)
                .HasForeignKey(e => e.ProductoId)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(e => e.Sucursal)
                .WithMany()
                .HasForeignKey(e => e.SucursalId)
                .OnDelete(DeleteBehavior.Restrict);
        });

        modelBuilder.Entity<AuditoriaAcceso>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.ToTable("AuditoriasAcceso");
            entity.HasIndex(e => new { e.UsuarioId, e.FechaHora });
            entity.HasIndex(e => e.DireccionIP);
        });

        modelBuilder.Entity<AuditoriaCambios>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.ToTable("AuditoriasCambios");
            entity.HasIndex(e => new { e.Tabla, e.RegistroId, e.FechaHora });
            entity.HasIndex(e => new { e.UsuarioId, e.FechaHora });
        });

        modelBuilder.Entity<ConfiguracionGeneral>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.ToTable("ConfiguracionesGenerales");
            entity.HasIndex(e => new { e.ClinicaId, e.SucursalId, e.Clave }).IsUnique();
        });

        modelBuilder.Entity<Notificacion>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.ToTable("Notificaciones");
            entity.HasIndex(e => new { e.UsuarioId, e.Leida, e.FechaCreacion });
        });

        // ==================== CONFIGURACIÓN ODONTOLOGÍA (NUEVO - SIN _tenantService) ====================

        modelBuilder.Entity<Odontograma>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.ToTable("Odontogramas");
            entity.HasIndex(e => new { e.PacienteId, e.FechaCreacion });

            entity.HasOne(e => e.Paciente)
                .WithMany()
                .HasForeignKey(e => e.PacienteId)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(e => e.Medico)
                .WithMany()
                .HasForeignKey(e => e.MedicoId)
                .OnDelete(DeleteBehavior.Restrict);
        });

        modelBuilder.Entity<DienteEstado>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.ToTable("DientesEstado");
            entity.HasIndex(e => new { e.OdontogramaId, e.NumeroDiente });

            entity.HasOne(e => e.Odontograma)
                .WithMany(e => e.DientesEstado)
                .HasForeignKey(e => e.OdontogramaId)
                .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<TratamientoDental>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.ToTable("TratamientosDentales");
            entity.HasIndex(e => e.NumeroTratamiento).IsUnique();
            entity.HasIndex(e => new { e.PacienteId, e.FechaTratamiento });
            entity.HasIndex(e => new { e.MedicoId, e.Estado });

            entity.HasOne(e => e.Paciente)
                .WithMany()
                .HasForeignKey(e => e.PacienteId)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(e => e.Medico)
                .WithMany()
                .HasForeignKey(e => e.MedicoId)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(e => e.Consulta)
                .WithMany()
                .HasForeignKey(e => e.ConsultaId)
                .OnDelete(DeleteBehavior.SetNull);

            entity.HasOne(e => e.DienteEstado)
                .WithMany(d => d.Tratamientos)
                .HasForeignKey(e => e.DienteEstadoId)
                .OnDelete(DeleteBehavior.SetNull);

            entity.Property(e => e.Costo).HasPrecision(18, 2);
        });

        modelBuilder.Entity<SeguimientoTratamiento>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.ToTable("SeguimientosTratamiento");
            entity.HasIndex(e => new { e.TratamientoDentalId, e.NumeroSesion });

            entity.HasOne(e => e.TratamientoDental)
                .WithMany(t => t.Seguimientos)
                .HasForeignKey(e => e.TratamientoDentalId)
                .OnDelete(DeleteBehavior.Cascade);

            entity.HasOne(e => e.Medico)
                .WithMany()
                .HasForeignKey(e => e.MedicoId)
                .OnDelete(DeleteBehavior.SetNull);
        });

        modelBuilder.Entity<PresupuestoDental>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.ToTable("PresupuestosDentales");
            entity.HasIndex(e => e.NumeroPresupuesto).IsUnique();
            entity.HasIndex(e => new { e.PacienteId, e.FechaEmision });
            entity.HasIndex(e => new { e.SucursalId, e.Estado });

            entity.HasOne(e => e.Paciente)
                .WithMany()
                .HasForeignKey(e => e.PacienteId)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(e => e.Medico)
                .WithMany()
                .HasForeignKey(e => e.MedicoId)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(e => e.Sucursal)
                .WithMany()
                .HasForeignKey(e => e.SucursalId)
                .OnDelete(DeleteBehavior.Restrict);

            entity.Property(e => e.Subtotal).HasPrecision(18, 2);
            entity.Property(e => e.Descuento).HasPrecision(18, 2);
            entity.Property(e => e.Total).HasPrecision(18, 2);
        });

        modelBuilder.Entity<PresupuestoDetalle>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.ToTable("PresupuestosDetalle");

            entity.HasOne(e => e.PresupuestoDental)
                .WithMany(p => p.Detalles)
                .HasForeignKey(e => e.PresupuestoDentalId)
                .OnDelete(DeleteBehavior.Cascade);

            entity.Property(e => e.PrecioUnitario).HasPrecision(18, 2);
            entity.Property(e => e.Subtotal).HasPrecision(18, 2);
            entity.Property(e => e.Descuento).HasPrecision(18, 2);
            entity.Property(e => e.Total).HasPrecision(18, 2);
        });

        modelBuilder.Entity<RadiografiaDental>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.ToTable("RadiografiasDentales");
            entity.HasIndex(e => e.NumeroRadiografia).IsUnique();
            entity.HasIndex(e => new { e.PacienteId, e.FechaToma });
            entity.HasIndex(e => e.TipoRadiografia);

            entity.HasOne(e => e.Paciente)
                .WithMany()
                .HasForeignKey(e => e.PacienteId)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(e => e.Medico)
                .WithMany()
                .HasForeignKey(e => e.MedicoId)
                .OnDelete(DeleteBehavior.SetNull);
        });

        modelBuilder.Entity<ExamenPeriodontal>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.ToTable("ExamenesPeriodontales");
            entity.HasIndex(e => new { e.PacienteId, e.FechaExamen });

            entity.HasOne(e => e.Paciente)
                .WithMany()
                .HasForeignKey(e => e.PacienteId)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(e => e.Medico)
                .WithMany()
                .HasForeignKey(e => e.MedicoId)
                .OnDelete(DeleteBehavior.Restrict);
        });

        modelBuilder.Entity<BolsaPeriodontal>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.ToTable("BolsasPeriodontales");
            entity.HasIndex(e => new { e.ExamenPeriodontalId, e.NumeroDiente });

            entity.HasOne(e => e.ExamenPeriodontal)
                .WithMany(ex => ex.BolsasPeriodontales)
                .HasForeignKey(e => e.ExamenPeriodontalId)
                .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<TratamientoOrtodoncia>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.ToTable("TratamientosOrtodoncia");
            entity.HasIndex(e => e.NumeroTratamiento).IsUnique();
            entity.HasIndex(e => new { e.PacienteId, e.Estado });

            entity.HasOne(e => e.Paciente)
                .WithMany()
                .HasForeignKey(e => e.PacienteId)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(e => e.Medico)
                .WithMany()
                .HasForeignKey(e => e.MedicoId)
                .OnDelete(DeleteBehavior.Restrict);

            entity.Property(e => e.CostoTotal).HasPrecision(18, 2);
        });

        modelBuilder.Entity<ControlOrtodoncia>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.ToTable("ControlesOrtodoncia");
            entity.HasIndex(e => new { e.TratamientoOrtodonciaId, e.FechaControl });

            entity.HasOne(e => e.TratamientoOrtodoncia)
                .WithMany(t => t.Controles)
                .HasForeignKey(e => e.TratamientoOrtodonciaId)
                .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<ConsentimientoInformado>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.ToTable("ConsentimientosInformados");
            entity.HasIndex(e => new { e.PacienteId, e.FechaConsentimiento });
            entity.HasIndex(e => e.TratamientoDentalId);

            entity.HasOne(e => e.Paciente)
                .WithMany()
                .HasForeignKey(e => e.PacienteId)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(e => e.Medico)
                .WithMany()
                .HasForeignKey(e => e.MedicoId)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(e => e.TratamientoDental)
                .WithMany()
                .HasForeignKey(e => e.TratamientoDentalId)
                .OnDelete(DeleteBehavior.SetNull);
        });

        modelBuilder.Entity<CatalogoTratamientoDental>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.ToTable("CatalogoTratamientosDentales");
            entity.HasIndex(e => e.Codigo);
            entity.HasIndex(e => e.Categoria);

            entity.Property(e => e.PrecioBase).HasPrecision(18, 2);
        });

        modelBuilder.Entity<MaterialDental>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.ToTable("MaterialesDentales");
            entity.HasIndex(e => e.Codigo);
            entity.HasIndex(e => e.Categoria);

            entity.Property(e => e.PrecioUnitario).HasPrecision(18, 2);
        });
    }

    private void SetTenantFilter<TEntity>(ModelBuilder modelBuilder)
    where TEntity : class, ITenantEntity
    {
        modelBuilder.Entity<TEntity>()
            .HasQueryFilter(e =>
                _tenantService.TenantId != Guid.Empty &&
                e.TenantId == _tenantService.TenantId);
    }

    public override async Task<int> SaveChangesAsync(
    CancellationToken cancellationToken = default)
    {
        foreach (var entry in ChangeTracker
            .Entries<ITenantEntity>()
            .Where(e => e.State == EntityState.Added))
        {
            if (_tenantService.TenantId == Guid.Empty)
                throw new Exception("TenantId no resuelto en la petición.");

            entry.Entity.TenantId = _tenantService.TenantId;
        }

        return await base.SaveChangesAsync(cancellationToken);
    }
}