using Microsoft.EntityFrameworkCore;
using Odontosoft.Shared.Entities;

namespace Odontosoft.Backend.Data
{
    public class DatabaseSeeder
    {
        private readonly DataContext _context;

        public DatabaseSeeder(DataContext context)
        {
            _context = context;
        }

        public async Task SeedDatabase()
        {
            await _context.Database.MigrateAsync();

            // ==============================
            // 1️⃣ CREAR TENANT PRINCIPAL
            // ==============================

            if (!_context.Tenants.Any())
            {
                var tenant = new Tenant
                {
                    Id = Guid.NewGuid(),
                    Name = "Tenant Principal",
                    Subdomain = "localhost",
                    IsActive = true
                };

                _context.Tenants.Add(tenant);
                await _context.SaveChangesAsync(); // ← Guardar primero el tenant
            }

            // ==============================
            // 2️⃣ SEED NORMAL
            // ==============================

            if (!_context.Modulos.Any())
                SeedModulos();

            if (!_context.Especialidades.Any())
                SeedEspecialidades();

            if (!_context.Medicamentos.Any())
                SeedMedicamentos();

            if (!_context.EstudiosLaboratorio.Any())
                SeedEstudiosLaboratorio();

            if (!_context.EstudiosImagen.Any())
                SeedEstudiosImagen();

            if (!_context.Roles.Any())
                SeedRoles();

            if (!_context.CatalogoTratamientosDentales.Any())
                SeedCatalogoTratamientos();

            if (!_context.MaterialesDentales.Any())
                SeedMaterialesDentales();

            await _context.SaveChangesAsync();
        }

        // ==============================
        // ROLES
        // ==============================

        private void SeedRoles()
        {
            var roles = new List<Rol>
            {
                new Rol { Nombre = "Administrador", Descripcion = "Acceso completo al sistema", Activo = true },
                new Rol { Nombre = "Médico", Descripcion = "Acceso a consultas y órdenes", Activo = true },
                new Rol { Nombre = "Recepcionista", Descripcion = "Gestión de agenda", Activo = true },
                new Rol { Nombre = "Laboratorista", Descripcion = "Módulo de laboratorio", Activo = true }
            };

            _context.Roles.AddRange(roles);
        }

        private void SeedEspecialidades()
        {
            var especialidades = new List<Especialidad>
            {
                new Especialidad { Nombre = "Medicina General", Descripcion = "Atención médica general", Activo = true },
                new Especialidad { Nombre = "Odontología", Descripcion = "Salud bucal", Activo = true },
                new Especialidad { Nombre = "Cardiología", Descripcion = "Enfermedades del corazón", Activo = true }
            };

            _context.Especialidades.AddRange(especialidades);
        }

        private void SeedMedicamentos()
        {
            var medicamentos = new List<Medicamento>
            {
                new Medicamento
                {
                    Nombre = "Paracetamol 500mg",
                    NombreGenerico = "Paracetamol",
                    Presentacion = "Tabletas",
                    Concentracion = "500mg",
                    Descripcion ="Dolor de cabeza",
                    Via = "Oral",
                    Laboratorio="BGL",
                    RequiereReceta = false,
                    Activo = true
                }
            };

            _context.Medicamentos.AddRange(medicamentos);
        }

        private void SeedEstudiosLaboratorio()
        {
            var estudios = new List<EstudioLaboratorio>
            {
                new EstudioLaboratorio
                {
                    Nombre = "Biometría Hemática Completa",
                    Codigo = "BHC",
                    Categoria = "Hematología",
                    Descripcion = "Análisis completo de células sanguíneas",
                    Precio = 150,
                    Preparacion = "No requiere ayuno",
                    Activo = true
                }
            };

            _context.EstudiosLaboratorio.AddRange(estudios);
        }

        private void SeedEstudiosImagen()
        {
            var estudios = new List<EstudioImagen>
            {
                new EstudioImagen
                {
                    Nombre = "Radiografía de Tórax",
                    Codigo = "RX-TORAX",
                    Tipo = "Rayos X",
                    Descripcion = "Imagen del tórax para evaluación pulmonar",
                    Precio = 250,
                    Preparacion = "No requiere preparación",
                    Activo = true
                }
            };

            _context.EstudiosImagen.AddRange(estudios);
        }

        private void SeedCatalogoTratamientos()
        {
            var tratamientos = new List<CatalogoTratamientoDental>
            {
                new CatalogoTratamientoDental
                {
                    Nombre = "Limpieza Dental",
                    Codigo = "PROF001",
                    Categoria = "Preventiva",
                    Descripcion = "Profilaxis dental",
                    PrecioBase = 500,
                    DuracionEstimadaMinutos = 30,
                    RequiereConsentimiento = false,
                    Activo = true
                }
            };

            _context.CatalogoTratamientosDentales.AddRange(tratamientos);
        }

        private void SeedMaterialesDentales()
        {
            var materiales = new List<MaterialDental>
            {
                new MaterialDental
                {
                    Nombre = "Resina Compuesta A2",
                    Codigo = "RES001",
                    Categoria = "Resinas",
                    Marca = "3M",
                    UnidadMedida = "Jeringa",
                    PrecioUnitario = 350,
                    StockMinimo = 5,
                    Activo = true
                }
            };

            _context.MaterialesDentales.AddRange(materiales);
        }

        private void SeedModulos()
        {
            var modulos = new List<Modulo>
            {
                new Modulo
                {
                    Nombre = "Dashboard",
                    Codigo = "DASHBOARD",
                    Descripcion = "Panel principal",
                    Icono = "dashboard",
                    Orden = 1,
                    Ruta = "/dashboard",
                    Activo = true
                }
            };

            _context.Modulos.AddRange(modulos);
        }
    }
}