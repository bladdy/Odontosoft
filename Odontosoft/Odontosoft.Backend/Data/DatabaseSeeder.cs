using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Odontosoft.Backend.Services;
using Odontosoft.Shared.Entities;

namespace Odontosoft.Backend.Data
{
    public class DatabaseSeeder
    {
        private readonly DataContext _context;
        private readonly ITenantService _tenantService;

        public DatabaseSeeder(DataContext context, ITenantService tenantService)
        {
            _context = context;
            _tenantService = tenantService;
        }

        public async Task SeedDatabase()
        {
            await _context.Database.MigrateAsync();

            // =====================================================
            // 1️⃣ TENANT DEMO (IGNORANDO FILTRO GLOBAL)
            // =====================================================

            var tenant = await _context.Tenants
                .IgnoreQueryFilters()
                .FirstOrDefaultAsync(t => t.Subdomain == "demo");

            if (tenant == null)
            {
                tenant = new Tenant
                {
                    Id = Guid.NewGuid(),
                    Name = "Clínica Demo",
                    Subdomain = "demo",
                    IsActive = true
                };

                _context.Tenants.Add(tenant);
                await _context.SaveChangesAsync();
            }

            // 🔥 SET TENANT PARA MULTI-TENANT
            _tenantService.SetTenant(tenant);

            // =====================================================
            // 2️⃣ ROLES
            // =====================================================

            if (!_context.Roles.Any())
            {
                var adminRol = new Rol
                {
                    Nombre = "Administrador",
                    Descripcion = "Acceso total",
                    Activo = true
                };

                var medicoRol = new Rol
                {
                    Nombre = "Medico",
                    Descripcion = "Atención médica",
                    Activo = true
                };

                _context.Roles.AddRange(adminRol, medicoRol);
                await _context.SaveChangesAsync();
            }

            var rolAdmin = await _context.Roles.FirstAsync(r => r.Nombre == "Administrador");
            var rolMedico = await _context.Roles.FirstAsync(r => r.Nombre == "Medico");

            // =====================================================
            // 3️⃣ CLINICA
            // =====================================================

            if (!_context.Clinicas.Any())
            {
                var clinica = new Clinica
                {
                    Nombre = "Clínica Odontológica Demo",
                    RazonSocial = "Clínica Demo SAC",
                    RFC = "12345678901",
                    Direccion = "Av. Salud 123",
                    Telefono = "999888777",
                    Email = "info@demo.com",
                    Ciudad = "Santiago",
                    CodigoPostal = "2566333",
                    Estado = "Santiago",
                    Logo = "Unlogo",
                    Activo = true
                };

                _context.Clinicas.Add(clinica);
                await _context.SaveChangesAsync();
            }

            var clinicaDemo = await _context.Clinicas.FirstAsync();

            // =====================================================
            // 4️⃣ SUCURSAL
            // =====================================================

            if (!_context.Sucursales.Any())
            {
                var sucursal = new Sucursal
                {
                    Nombre = "Sucursal Central",
                    Direccion = "Av. Salud 123",
                    Telefono = "999888777",
                    Ciudad = "Santiago",
                    Estado = "Santiago",
                    CodigoPostal = "888888",
                    Email = "demo@ducursaldemo.com",
                    Codigo = "CDS-7885",
                    ClinicaId = clinicaDemo.Id,
                    Activo = true
                };

                _context.Sucursales.Add(sucursal);
                await _context.SaveChangesAsync();
            }

            var sucursalDemo = await _context.Sucursales.FirstAsync();

            // =====================================================
            // 5️⃣ USUARIO ADMIN
            // =====================================================

            if (!_context.Usuarios.Any())
            {
                var admin = new Usuario
                {
                    Nombre = "Admin",
                    UsuarioSucursales = sucursalDemo.UsuarioSucursales,

                    NombreUsuario = "@admin",
                    Avatar = "avatar",
                    Telefono = "888888888",
                    FechaCreacion = DateTime.UtcNow,
                    Apellidos = "Sistema",
                    Email = "admin@demo.com",
                    PasswordHash = BCrypt.Net.BCrypt.HashPassword("Admin123*"),
                    Activo = true
                };

                _context.Usuarios.Add(admin);
                await _context.SaveChangesAsync();

                _context.UsuarioRoles.Add(new UsuarioRol
                {
                    UsuarioSucursalId = admin.Id,
                    RolId = rolAdmin.Id
                });

                _context.UsuarioSucursales.Add(new UsuarioSucursal
                {
                    UsuarioId = admin.Id,
                    SucursalId = sucursalDemo.Id
                });

                await _context.SaveChangesAsync();
            }

            // =====================================================
            // 6️⃣ ESPECIALIDAD
            // =====================================================

            if (!_context.Especialidades.Any())
            {
                var especialidad = new Especialidad
                {
                    Nombre = "Odontología General",
                    Descripcion = "Atención odontológica integral",
                    Activo = true
                };

                _context.Especialidades.Add(especialidad);
                await _context.SaveChangesAsync();
            }

            var especialidadDemo = await _context.Especialidades.FirstAsync();

            // =====================================================
            // 7️⃣ MEDICO
            // =====================================================

            if (!_context.Medicos.Any())
            {
                var medico = new Medico
                {
                    Sello = "Dr. Juan Pérez",
                    CedulaProfesional = "78889",
                    Especialidades = _context.Especialidades.FirstOrDefaultAsync().Result!.Nombre,
                    Universidad = "NULA",
                    Firma = "Firma",
                    Activo = true,
                    UsuarioId = _context.Usuarios.FirstOrDefaultAsync().Result!.Id
                };

                _context.Medicos.Add(medico);
                await _context.SaveChangesAsync();

                _context.MedicoEspecialidades.Add(new MedicoEspecialidad
                {
                    MedicoId = medico.Id,
                    CedulaEspecialidad = medico.CedulaProfesional,
                    EspecialidadId = especialidadDemo.Id
                });

                await _context.SaveChangesAsync();
            }

            // =====================================================
            // 8️⃣ PACIENTE DEMO
            // =====================================================

            if (!_context.Pacientes.Any())
            {
                var paciente = new Paciente
                {
                    Nombre = "Carlos",
                    RFC = "7885555555555555555",
                    FechaRegistro = DateTime.UtcNow,
                    Sexo = "M",
                    TelefonoEmergencia = "787999999989",
                    SucursalId = sucursalDemo.Id,
                    Ocupacion = "Constructor",
                    Apellidos = "Ramírez Gómez",
                    Foto = "Una Foto",
                    CURP = "87654321",
                    GrupoSanguineo = "AB+",
                    Telefono = "988777666",
                    Email = "paciente@demo.com",
                    CodigoPostal = "78996",
                    EstadoCivil = "Soltero",
                    Ciudad = "Santiago",
                    ContactoEmergencia = "7899998",
                    Estado = "Santiago",
                    Direccion = "Calle siempre viva",
                    NumeroExpediente = "PTR-78-7888855",
                    FechaNacimiento = new DateTime(1990, 1, 1),
                    Activo = true
                };

                _context.Pacientes.Add(paciente);
                await _context.SaveChangesAsync();
            }

            // =====================================================
            // 9️⃣ MODULOS
            // =====================================================

            if (!_context.Modulos.Any())
            {
                _context.Modulos.AddRange(
                    new Modulo
                    {
                        Nombre = "Dashboard",
                        Codigo = "DASH",
                        Ruta = "/dashboard",
                        Icono = "Dashboard",
                        Descripcion = "Dashboard",
                        Activo = true
                    },
                    new Modulo { Nombre = "Pacientes", Descripcion = "Pacientes", Icono = "Dashboard", Codigo = "PAC", Ruta = "/pacientes", Activo = true },
                    new Modulo { Nombre = "Citas", Descripcion = "Citas", Codigo = "CIT", Icono = "Dashboard", Ruta = "/citas", Activo = true }
                );

                await _context.SaveChangesAsync();
            }

            // =====================================================
            // 🔟 MEDICAMENTOS
            // =====================================================

            if (!_context.Medicamentos.Any())
            {
                _context.Medicamentos.Add(new Medicamento
                {
                    Nombre = "Ibuprofeno 400mg",
                    NombreGenerico = "Ibuprofeno",
                    Presentacion = "Tabletas",
                    Concentracion = "400mg",
                    Descripcion = "Ibuprofeno",
                    Via = "Oral",
                    Laboratorio = "GBL",
                    RequiereReceta = false,
                    Activo = true
                });

                await _context.SaveChangesAsync();
            }

            // =====================================================
            // 11️⃣ PRODUCTO INVENTARIO
            // =====================================================

            if (!_context.Productos.Any())
            {
                _context.Productos.Add(new Producto
                {
                    Nombre = "Guantes quirúrgicos",
                    Codigo = "GUANTE001",
                    PrecioVenta = 25,
                    PrecioCompra = 20,
                    StockActual = 100,
                    StockMaximo = 200,
                    StockMinimo = 20,
                    CodigoBarras = "888888888888888888",
                    Marca = "SafeHands",
                    Descripcion = "Guantes guantes",
                    Categoria = "Material de Protección",
                    FechaCaducidad = DateTime.UtcNow.AddYears(2),
                    FechaCreacion = DateTime.UtcNow,
                    Presentacion = "Caja con 100 unidades",
                    SucursalId = sucursalDemo.Id,
                    Lote = "788",
                    TenantId = tenant.Id,
                    Activo = true
                });

                await _context.SaveChangesAsync();
            }

            // =====================================================
            // 12️⃣ SERVICIO FACTURABLE
            // =====================================================

            if (!_context.Servicios.Any())
            {
                _context.Servicios.Add(new Servicio
                {
                    Codigo = "FGR-4233",
                    Nombre = "Consulta Odontológica",
                    Descripcion = "Consulta general para evaluación y diagnóstico",
                    Categoria = "Cosnultas",
                    ClaveProdServ = "FE-333",
                    Precio = 80,
                    Activo = true
                });

                await _context.SaveChangesAsync();
            }
        }
    }
}