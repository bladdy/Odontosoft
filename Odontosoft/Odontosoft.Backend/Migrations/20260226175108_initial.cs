using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Odontosoft.Backend.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AuditoriasAcceso",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsuarioId = table.Column<int>(type: "int", nullable: false),
                    SucursalId = table.Column<int>(type: "int", nullable: false),
                    TipoAcceso = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DireccionIP = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    UserAgent = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    FechaHora = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Exitoso = table.Column<bool>(type: "bit", nullable: false),
                    MotivoFallo = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuditoriasAcceso", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AuditoriasCambios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsuarioId = table.Column<int>(type: "int", nullable: false),
                    Tabla = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Operacion = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    RegistroId = table.Column<int>(type: "int", nullable: false),
                    ValoresAnteriores = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ValoresNuevos = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaHora = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DireccionIP = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuditoriasCambios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CatalogoTratamientosDentales",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Codigo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Categoria = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Descripcion = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    PrecioBase = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: true),
                    DuracionEstimadaMinutos = table.Column<int>(type: "int", nullable: true),
                    RequiereConsentimiento = table.Column<bool>(type: "bit", nullable: false),
                    MaterialesNecesarios = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Activo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CatalogoTratamientosDentales", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Clinicas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    RazonSocial = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    RFC = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Ciudad = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Estado = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CodigoPostal = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Logo = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Activo = table.Column<bool>(type: "bit", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clinicas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ConfiguracionesGenerales",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClinicaId = table.Column<int>(type: "int", nullable: true),
                    SucursalId = table.Column<int>(type: "int", nullable: true),
                    Clave = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Valor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Tipo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConfiguracionesGenerales", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Especialidades",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Activo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Especialidades", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EstudiosImagen",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Codigo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Tipo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    Preparacion = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Precio = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: true),
                    Activo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstudiosImagen", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EstudiosLaboratorio",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Codigo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Categoria = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    Preparacion = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Precio = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: true),
                    Activo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstudiosLaboratorio", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MaterialesDentales",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Codigo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Categoria = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Marca = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Descripcion = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    UnidadMedida = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    PrecioUnitario = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: true),
                    StockMinimo = table.Column<int>(type: "int", nullable: true),
                    FechaCaducidad = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Lote = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Activo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaterialesDentales", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Medicamentos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    NombreGenerico = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    Presentacion = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Concentracion = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Via = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Laboratorio = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    RequiereReceta = table.Column<bool>(type: "bit", nullable: false),
                    Activo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medicamentos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Modulos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Codigo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Icono = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Orden = table.Column<int>(type: "int", nullable: false),
                    Activo = table.Column<bool>(type: "bit", nullable: false),
                    Ruta = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ModuloPadreId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Modulos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Modulos_Modulos_ModuloPadreId",
                        column: x => x.ModuloPadreId,
                        principalTable: "Modulos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Notificaciones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsuarioId = table.Column<int>(type: "int", nullable: false),
                    Titulo = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Mensaje = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    Tipo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Leida = table.Column<bool>(type: "bit", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaLectura = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Enlace = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notificaciones", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Activo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Servicios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Codigo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ClaveProdServ = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    Precio = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    IVA = table.Column<decimal>(type: "decimal(5,2)", precision: 5, scale: 2, nullable: false),
                    Categoria = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Activo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Servicios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreUsuario = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Apellidos = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Avatar = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Activo = table.Column<bool>(type: "bit", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UltimoAcceso = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sucursales",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClinicaId = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Codigo = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Ciudad = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Estado = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CodigoPostal = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Activo = table.Column<bool>(type: "bit", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sucursales", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sucursales_Clinicas_ClinicaId",
                        column: x => x.ClinicaId,
                        principalTable: "Clinicas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ClinicaModulos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClinicaId = table.Column<int>(type: "int", nullable: false),
                    ModuloId = table.Column<int>(type: "int", nullable: false),
                    FechaActivacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaVencimiento = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Activo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClinicaModulos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClinicaModulos_Clinicas_ClinicaId",
                        column: x => x.ClinicaId,
                        principalTable: "Clinicas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClinicaModulos_Modulos_ModuloId",
                        column: x => x.ModuloId,
                        principalTable: "Modulos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RolPermisos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RolId = table.Column<int>(type: "int", nullable: false),
                    ModuloId = table.Column<int>(type: "int", nullable: false),
                    PuedeLeer = table.Column<bool>(type: "bit", nullable: false),
                    PuedeCrear = table.Column<bool>(type: "bit", nullable: false),
                    PuedeEditar = table.Column<bool>(type: "bit", nullable: false),
                    PuedeEliminar = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RolPermisos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RolPermisos_Modulos_ModuloId",
                        column: x => x.ModuloId,
                        principalTable: "Modulos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RolPermisos_Roles_RolId",
                        column: x => x.RolId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Medicos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsuarioId = table.Column<int>(type: "int", nullable: false),
                    CedulaProfesional = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Universidad = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    AnioTitulacion = table.Column<int>(type: "int", nullable: false),
                    Especialidades = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false),
                    Firma = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Sello = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Activo = table.Column<bool>(type: "bit", nullable: false),
                    FechaRegistro = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medicos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Medicos_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Consultorios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SucursalId = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Numero = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Activo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Consultorios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Consultorios_Sucursales_SucursalId",
                        column: x => x.SucursalId,
                        principalTable: "Sucursales",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pacientes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SucursalId = table.Column<int>(type: "int", nullable: false),
                    NumeroExpediente = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Apellidos = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    FechaNacimiento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Sexo = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    CURP = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    RFC = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    TelefonoEmergencia = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    ContactoEmergencia = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Ciudad = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Estado = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CodigoPostal = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Ocupacion = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    EstadoCivil = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    GrupoSanguineo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Foto = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Activo = table.Column<bool>(type: "bit", nullable: false),
                    FechaRegistro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pacientes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pacientes_Sucursales_SucursalId",
                        column: x => x.SucursalId,
                        principalTable: "Sucursales",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Productos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SucursalId = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Codigo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CodigoBarras = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    Categoria = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Marca = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Presentacion = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PrecioCompra = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    PrecioVenta = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    StockMinimo = table.Column<int>(type: "int", nullable: false),
                    StockMaximo = table.Column<int>(type: "int", nullable: false),
                    StockActual = table.Column<int>(type: "int", nullable: false),
                    FechaCaducidad = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Lote = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Activo = table.Column<bool>(type: "bit", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Productos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Productos_Sucursales_SucursalId",
                        column: x => x.SucursalId,
                        principalTable: "Sucursales",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UsuarioSucursales",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsuarioId = table.Column<int>(type: "int", nullable: false),
                    SucursalId = table.Column<int>(type: "int", nullable: false),
                    EsSucursalPrincipal = table.Column<bool>(type: "bit", nullable: false),
                    FechaAsignacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Activo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuarioSucursales", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UsuarioSucursales_Sucursales_SucursalId",
                        column: x => x.SucursalId,
                        principalTable: "Sucursales",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UsuarioSucursales_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HorariosMedico",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MedicoId = table.Column<int>(type: "int", nullable: false),
                    SucursalId = table.Column<int>(type: "int", nullable: false),
                    DiaSemana = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    HoraInicio = table.Column<TimeSpan>(type: "time", nullable: false),
                    HoraFin = table.Column<TimeSpan>(type: "time", nullable: false),
                    DuracionCitaMinutos = table.Column<int>(type: "int", nullable: false),
                    Activo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HorariosMedico", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HorariosMedico_Medicos_MedicoId",
                        column: x => x.MedicoId,
                        principalTable: "Medicos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HorariosMedico_Sucursales_SucursalId",
                        column: x => x.SucursalId,
                        principalTable: "Sucursales",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MedicoEspecialidades",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MedicoId = table.Column<int>(type: "int", nullable: false),
                    EspecialidadId = table.Column<int>(type: "int", nullable: false),
                    CedulaEspecialidad = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FechaObtencion = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicoEspecialidades", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MedicoEspecialidades_Especialidades_EspecialidadId",
                        column: x => x.EspecialidadId,
                        principalTable: "Especialidades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MedicoEspecialidades_Medicos_MedicoId",
                        column: x => x.MedicoId,
                        principalTable: "Medicos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Alergias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PacienteId = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Tipo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Gravedad = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    FechaRegistro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Activo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alergias", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Alergias_Pacientes_PacienteId",
                        column: x => x.PacienteId,
                        principalTable: "Pacientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Antecedentes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PacienteId = table.Column<int>(type: "int", nullable: false),
                    Tipo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Observaciones = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false),
                    FechaRegistro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Activo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Antecedentes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Antecedentes_Pacientes_PacienteId",
                        column: x => x.PacienteId,
                        principalTable: "Pacientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Citas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SucursalId = table.Column<int>(type: "int", nullable: false),
                    PacienteId = table.Column<int>(type: "int", nullable: false),
                    MedicoId = table.Column<int>(type: "int", nullable: false),
                    ConsultorioId = table.Column<int>(type: "int", nullable: true),
                    NumeroCita = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    FechaHora = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DuracionMinutos = table.Column<int>(type: "int", nullable: false),
                    EstadoCita = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TipoCita = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    MotivoConsulta = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    Observaciones = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    ColorCalendario = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    FechaConfirmacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FechaCancelacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MotivoCancelacion = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Citas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Citas_Consultorios_ConsultorioId",
                        column: x => x.ConsultorioId,
                        principalTable: "Consultorios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Citas_Medicos_MedicoId",
                        column: x => x.MedicoId,
                        principalTable: "Medicos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Citas_Pacientes_PacienteId",
                        column: x => x.PacienteId,
                        principalTable: "Pacientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Citas_Sucursales_SucursalId",
                        column: x => x.SucursalId,
                        principalTable: "Sucursales",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ExamenesPeriodontales",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PacienteId = table.Column<int>(type: "int", nullable: false),
                    MedicoId = table.Column<int>(type: "int", nullable: false),
                    FechaExamen = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IndiceHigiene = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IndiceGingival = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Sangrado = table.Column<bool>(type: "bit", nullable: false),
                    PresenciaPlaca = table.Column<bool>(type: "bit", nullable: false),
                    PresenciaSarro = table.Column<bool>(type: "bit", nullable: false),
                    Movilidad = table.Column<bool>(type: "bit", nullable: false),
                    Diagnostico = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    PlanTratamiento = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    Observaciones = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExamenesPeriodontales", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExamenesPeriodontales_Medicos_MedicoId",
                        column: x => x.MedicoId,
                        principalTable: "Medicos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ExamenesPeriodontales_Pacientes_PacienteId",
                        column: x => x.PacienteId,
                        principalTable: "Pacientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Odontogramas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PacienteId = table.Column<int>(type: "int", nullable: false),
                    MedicoId = table.Column<int>(type: "int", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaActualizacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TipoOdontograma = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Observaciones = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    EsActivo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Odontogramas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Odontogramas_Medicos_MedicoId",
                        column: x => x.MedicoId,
                        principalTable: "Medicos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Odontogramas_Pacientes_PacienteId",
                        column: x => x.PacienteId,
                        principalTable: "Pacientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PresupuestosDentales",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PacienteId = table.Column<int>(type: "int", nullable: false),
                    MedicoId = table.Column<int>(type: "int", nullable: false),
                    SucursalId = table.Column<int>(type: "int", nullable: false),
                    NumeroPresupuesto = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    FechaEmision = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaVencimiento = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Estado = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DiagnosticoGeneral = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    Subtotal = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Descuento = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Total = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    FormaPago = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    NumeroCuotas = table.Column<int>(type: "int", nullable: true),
                    Observaciones = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    FechaAprobacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FechaInicio = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FechaFinalizacion = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PresupuestosDentales", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PresupuestosDentales_Medicos_MedicoId",
                        column: x => x.MedicoId,
                        principalTable: "Medicos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PresupuestosDentales_Pacientes_PacienteId",
                        column: x => x.PacienteId,
                        principalTable: "Pacientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PresupuestosDentales_Sucursales_SucursalId",
                        column: x => x.SucursalId,
                        principalTable: "Sucursales",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RadiografiasDentales",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PacienteId = table.Column<int>(type: "int", nullable: false),
                    MedicoId = table.Column<int>(type: "int", nullable: true),
                    NumeroRadiografia = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    FechaToma = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TipoRadiografia = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    NumeroDiente = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    ZonaAnatomica = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    RutaArchivo = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Hallazgos = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    Observaciones = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    CalidadImagen = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    RequiereAnalisis = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RadiografiasDentales", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RadiografiasDentales_Medicos_MedicoId",
                        column: x => x.MedicoId,
                        principalTable: "Medicos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_RadiografiasDentales_Pacientes_PacienteId",
                        column: x => x.PacienteId,
                        principalTable: "Pacientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TratamientosOrtodoncia",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PacienteId = table.Column<int>(type: "int", nullable: false),
                    MedicoId = table.Column<int>(type: "int", nullable: false),
                    NumeroTratamiento = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    FechaInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaEstimadaFin = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FechaRealFin = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TipoAparato = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DiagnosticoInicial = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    ObjetivosTratamiento = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    DuracionEstimadaMeses = table.Column<int>(type: "int", nullable: false),
                    CostoTotal = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Estado = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Observaciones = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TratamientosOrtodoncia", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TratamientosOrtodoncia_Medicos_MedicoId",
                        column: x => x.MedicoId,
                        principalTable: "Medicos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TratamientosOrtodoncia_Pacientes_PacienteId",
                        column: x => x.PacienteId,
                        principalTable: "Pacientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MovimientosInventario",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductoId = table.Column<int>(type: "int", nullable: false),
                    SucursalId = table.Column<int>(type: "int", nullable: false),
                    TipoMovimiento = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Cantidad = table.Column<int>(type: "int", nullable: false),
                    StockAnterior = table.Column<int>(type: "int", nullable: false),
                    StockNuevo = table.Column<int>(type: "int", nullable: false),
                    Motivo = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    Referencia = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    FechaMovimiento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UsuarioId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovimientosInventario", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MovimientosInventario_Productos_ProductoId",
                        column: x => x.ProductoId,
                        principalTable: "Productos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MovimientosInventario_Sucursales_SucursalId",
                        column: x => x.SucursalId,
                        principalTable: "Sucursales",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PermisosModulo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsuarioSucursalId = table.Column<int>(type: "int", nullable: false),
                    ModuloId = table.Column<int>(type: "int", nullable: false),
                    PuedeLeer = table.Column<bool>(type: "bit", nullable: false),
                    PuedeCrear = table.Column<bool>(type: "bit", nullable: false),
                    PuedeEditar = table.Column<bool>(type: "bit", nullable: false),
                    PuedeEliminar = table.Column<bool>(type: "bit", nullable: false),
                    FechaAsignacion = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PermisosModulo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PermisosModulo_Modulos_ModuloId",
                        column: x => x.ModuloId,
                        principalTable: "Modulos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PermisosModulo_UsuarioSucursales_UsuarioSucursalId",
                        column: x => x.UsuarioSucursalId,
                        principalTable: "UsuarioSucursales",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UsuarioRoles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsuarioSucursalId = table.Column<int>(type: "int", nullable: false),
                    RolId = table.Column<int>(type: "int", nullable: false),
                    FechaAsignacion = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuarioRoles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UsuarioRoles_Roles_RolId",
                        column: x => x.RolId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UsuarioRoles_UsuarioSucursales_UsuarioSucursalId",
                        column: x => x.UsuarioSucursalId,
                        principalTable: "UsuarioSucursales",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Consultas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CitaId = table.Column<int>(type: "int", nullable: false),
                    MedicoId = table.Column<int>(type: "int", nullable: false),
                    PacienteId = table.Column<int>(type: "int", nullable: false),
                    NumeroConsulta = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    FechaConsulta = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Peso = table.Column<decimal>(type: "decimal(5,2)", precision: 5, scale: 2, nullable: true),
                    Altura = table.Column<decimal>(type: "decimal(5,2)", precision: 5, scale: 2, nullable: true),
                    IMC = table.Column<decimal>(type: "decimal(5,2)", precision: 5, scale: 2, nullable: true),
                    Temperatura = table.Column<decimal>(type: "decimal(4,2)", precision: 4, scale: 2, nullable: true),
                    PresionArterial = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FrecuenciaCardiaca = table.Column<int>(type: "int", nullable: true),
                    FrecuenciaRespiratoria = table.Column<int>(type: "int", nullable: true),
                    SaturacionO2 = table.Column<int>(type: "int", nullable: true),
                    MotivoConsulta = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false),
                    PadecimientoActual = table.Column<string>(type: "nvarchar(max)", maxLength: 5000, nullable: false),
                    ExploracionFisica = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false),
                    Diagnostico = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    CodigoCIE10 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PlanTratamiento = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false),
                    Observaciones = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Consultas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Consultas_Citas_CitaId",
                        column: x => x.CitaId,
                        principalTable: "Citas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Consultas_Medicos_MedicoId",
                        column: x => x.MedicoId,
                        principalTable: "Medicos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Consultas_Pacientes_PacienteId",
                        column: x => x.PacienteId,
                        principalTable: "Pacientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Facturas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SucursalId = table.Column<int>(type: "int", nullable: false),
                    PacienteId = table.Column<int>(type: "int", nullable: false),
                    CitaId = table.Column<int>(type: "int", nullable: true),
                    NumeroFactura = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Serie = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Folio = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FechaEmision = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TipoComprobante = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    MetodoPago = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FormaPago = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Subtotal = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    IVA = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Total = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Descuento = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Estado = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    UUID = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ArchivoXML = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    ArchivoPDF = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Observaciones = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaCancelacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MotivoCancelacion = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Facturas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Facturas_Citas_CitaId",
                        column: x => x.CitaId,
                        principalTable: "Citas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Facturas_Pacientes_PacienteId",
                        column: x => x.PacienteId,
                        principalTable: "Pacientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Facturas_Sucursales_SucursalId",
                        column: x => x.SucursalId,
                        principalTable: "Sucursales",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BolsasPeriodontales",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExamenPeriodontalId = table.Column<int>(type: "int", nullable: false),
                    NumeroDiente = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    VestibularMesial = table.Column<int>(type: "int", nullable: true),
                    VestibularCentral = table.Column<int>(type: "int", nullable: true),
                    VestibularDistal = table.Column<int>(type: "int", nullable: true),
                    LingualMesial = table.Column<int>(type: "int", nullable: true),
                    LingualCentral = table.Column<int>(type: "int", nullable: true),
                    LingualDistal = table.Column<int>(type: "int", nullable: true),
                    Sangrado = table.Column<bool>(type: "bit", nullable: false),
                    Supuracion = table.Column<bool>(type: "bit", nullable: false),
                    Movilidad = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Observaciones = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BolsasPeriodontales", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BolsasPeriodontales_ExamenesPeriodontales_ExamenPeriodontalId",
                        column: x => x.ExamenPeriodontalId,
                        principalTable: "ExamenesPeriodontales",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DientesEstado",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OdontogramaId = table.Column<int>(type: "int", nullable: false),
                    NumeroDiente = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Estado = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    SuperficieOclusal = table.Column<bool>(type: "bit", nullable: false),
                    SuperficieMesial = table.Column<bool>(type: "bit", nullable: false),
                    SuperficieDistal = table.Column<bool>(type: "bit", nullable: false),
                    SuperficieVestibular = table.Column<bool>(type: "bit", nullable: false),
                    SuperficieLingual = table.Column<bool>(type: "bit", nullable: false),
                    Diagnostico = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    Observaciones = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    ColorNotacion = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    FechaRegistro = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DientesEstado", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DientesEstado_Odontogramas_OdontogramaId",
                        column: x => x.OdontogramaId,
                        principalTable: "Odontogramas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PresupuestosDetalle",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PresupuestoDentalId = table.Column<int>(type: "int", nullable: false),
                    Tratamiento = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    NumeroDiente = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Descripcion = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    Cantidad = table.Column<int>(type: "int", nullable: false),
                    PrecioUnitario = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Subtotal = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Descuento = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Total = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Prioridad = table.Column<int>(type: "int", nullable: false),
                    Estado = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    FechaEstimada = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FechaRealizada = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PresupuestosDetalle", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PresupuestosDetalle_PresupuestosDentales_PresupuestoDentalId",
                        column: x => x.PresupuestoDentalId,
                        principalTable: "PresupuestosDentales",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ControlesOrtodoncia",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TratamientoOrtodonciaId = table.Column<int>(type: "int", nullable: false),
                    FechaControl = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NumeroControl = table.Column<int>(type: "int", nullable: false),
                    ActividadesRealizadas = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    EvolucionPaciente = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    Observaciones = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    FechaProximoControl = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Fotografias = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ControlesOrtodoncia", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ControlesOrtodoncia_TratamientosOrtodoncia_TratamientoOrtodonciaId",
                        column: x => x.TratamientoOrtodonciaId,
                        principalTable: "TratamientosOrtodoncia",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HistoriasClinicas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PacienteId = table.Column<int>(type: "int", nullable: false),
                    ConsultaId = table.Column<int>(type: "int", nullable: true),
                    Tipo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Contenido = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaRegistro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UsuarioRegistroId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HistoriasClinicas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HistoriasClinicas_Consultas_ConsultaId",
                        column: x => x.ConsultaId,
                        principalTable: "Consultas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_HistoriasClinicas_Pacientes_PacienteId",
                        column: x => x.PacienteId,
                        principalTable: "Pacientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrdenesImagen",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ConsultaId = table.Column<int>(type: "int", nullable: false),
                    PacienteId = table.Column<int>(type: "int", nullable: false),
                    MedicoId = table.Column<int>(type: "int", nullable: false),
                    NumeroOrden = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    FechaEmision = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Estado = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Indicaciones = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    FechaResultado = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ArchivoResultado = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrdenesImagen", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrdenesImagen_Consultas_ConsultaId",
                        column: x => x.ConsultaId,
                        principalTable: "Consultas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrdenesImagen_Medicos_MedicoId",
                        column: x => x.MedicoId,
                        principalTable: "Medicos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrdenesImagen_Pacientes_PacienteId",
                        column: x => x.PacienteId,
                        principalTable: "Pacientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OrdenesLaboratorio",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ConsultaId = table.Column<int>(type: "int", nullable: false),
                    PacienteId = table.Column<int>(type: "int", nullable: false),
                    MedicoId = table.Column<int>(type: "int", nullable: false),
                    NumeroOrden = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    FechaEmision = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Estado = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Indicaciones = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    FechaResultado = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ArchivoResultado = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrdenesLaboratorio", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrdenesLaboratorio_Consultas_ConsultaId",
                        column: x => x.ConsultaId,
                        principalTable: "Consultas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrdenesLaboratorio_Medicos_MedicoId",
                        column: x => x.MedicoId,
                        principalTable: "Medicos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrdenesLaboratorio_Pacientes_PacienteId",
                        column: x => x.PacienteId,
                        principalTable: "Pacientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Recetas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ConsultaId = table.Column<int>(type: "int", nullable: false),
                    PacienteId = table.Column<int>(type: "int", nullable: false),
                    MedicoId = table.Column<int>(type: "int", nullable: false),
                    NumeroReceta = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    FechaEmision = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaVencimiento = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Indicaciones = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false),
                    Estado = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recetas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Recetas_Consultas_ConsultaId",
                        column: x => x.ConsultaId,
                        principalTable: "Consultas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Recetas_Medicos_MedicoId",
                        column: x => x.MedicoId,
                        principalTable: "Medicos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Recetas_Pacientes_PacienteId",
                        column: x => x.PacienteId,
                        principalTable: "Pacientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FacturaDetalles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FacturaId = table.Column<int>(type: "int", nullable: false),
                    ServicioId = table.Column<int>(type: "int", nullable: true),
                    Concepto = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    ClaveProdServ = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ClaveUnidad = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Cantidad = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    PrecioUnitario = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Subtotal = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    IVA = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Total = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Descuento = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FacturaDetalles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FacturaDetalles_Facturas_FacturaId",
                        column: x => x.FacturaId,
                        principalTable: "Facturas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FacturaDetalles_Servicios_ServicioId",
                        column: x => x.ServicioId,
                        principalTable: "Servicios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "Pagos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FacturaId = table.Column<int>(type: "int", nullable: false),
                    NumeroPago = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    FechaPago = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FormaPago = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Monto = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Referencia = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Observaciones = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pagos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pagos_Facturas_FacturaId",
                        column: x => x.FacturaId,
                        principalTable: "Facturas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TratamientosDentales",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PacienteId = table.Column<int>(type: "int", nullable: false),
                    MedicoId = table.Column<int>(type: "int", nullable: false),
                    ConsultaId = table.Column<int>(type: "int", nullable: true),
                    DienteEstadoId = table.Column<int>(type: "int", nullable: true),
                    NumeroTratamiento = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    FechaTratamiento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TipoTratamiento = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    NumeroDiente = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Descripcion = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    Estado = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    NumeroSesiones = table.Column<int>(type: "int", nullable: false),
                    SesionActual = table.Column<int>(type: "int", nullable: false),
                    Costo = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: true),
                    MaterialesUtilizados = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Observaciones = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    FechaProximaCita = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RequiereSeguimiento = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TratamientosDentales", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TratamientosDentales_Consultas_ConsultaId",
                        column: x => x.ConsultaId,
                        principalTable: "Consultas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_TratamientosDentales_DientesEstado_DienteEstadoId",
                        column: x => x.DienteEstadoId,
                        principalTable: "DientesEstado",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_TratamientosDentales_Medicos_MedicoId",
                        column: x => x.MedicoId,
                        principalTable: "Medicos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TratamientosDentales_Pacientes_PacienteId",
                        column: x => x.PacienteId,
                        principalTable: "Pacientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OrdenImagenDetalles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrdenImagenId = table.Column<int>(type: "int", nullable: false),
                    EstudioImagenId = table.Column<int>(type: "int", nullable: false),
                    Resultado = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false),
                    Observaciones = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrdenImagenDetalles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrdenImagenDetalles_EstudiosImagen_EstudioImagenId",
                        column: x => x.EstudioImagenId,
                        principalTable: "EstudiosImagen",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrdenImagenDetalles_OrdenesImagen_OrdenImagenId",
                        column: x => x.OrdenImagenId,
                        principalTable: "OrdenesImagen",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrdenLaboratorioDetalles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrdenLaboratorioId = table.Column<int>(type: "int", nullable: false),
                    EstudioLaboratorioId = table.Column<int>(type: "int", nullable: false),
                    Resultado = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    ValorReferencia = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Observaciones = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrdenLaboratorioDetalles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrdenLaboratorioDetalles_EstudiosLaboratorio_EstudioLaboratorioId",
                        column: x => x.EstudioLaboratorioId,
                        principalTable: "EstudiosLaboratorio",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrdenLaboratorioDetalles_OrdenesLaboratorio_OrdenLaboratorioId",
                        column: x => x.OrdenLaboratorioId,
                        principalTable: "OrdenesLaboratorio",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RecetaDetalles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RecetaId = table.Column<int>(type: "int", nullable: false),
                    MedicamentoId = table.Column<int>(type: "int", nullable: true),
                    MedicamentoNombre = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    Presentacion = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Dosis = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    Frecuencia = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    Duracion = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    Via = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Indicaciones = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    Cantidad = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecetaDetalles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RecetaDetalles_Medicamentos_MedicamentoId",
                        column: x => x.MedicamentoId,
                        principalTable: "Medicamentos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_RecetaDetalles_Recetas_RecetaId",
                        column: x => x.RecetaId,
                        principalTable: "Recetas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ConsentimientosInformados",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PacienteId = table.Column<int>(type: "int", nullable: false),
                    MedicoId = table.Column<int>(type: "int", nullable: false),
                    TratamientoDentalId = table.Column<int>(type: "int", nullable: true),
                    TipoProcedimiento = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    FechaConsentimiento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ContenidoConsentimiento = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Aceptado = table.Column<bool>(type: "bit", nullable: false),
                    FirmaDigitalPaciente = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    FirmaDigitalMedico = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    FirmaDigitalTestigo = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    NombreTestigo = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    DireccionIP = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Observaciones = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConsentimientosInformados", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ConsentimientosInformados_Medicos_MedicoId",
                        column: x => x.MedicoId,
                        principalTable: "Medicos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ConsentimientosInformados_Pacientes_PacienteId",
                        column: x => x.PacienteId,
                        principalTable: "Pacientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ConsentimientosInformados_TratamientosDentales_TratamientoDentalId",
                        column: x => x.TratamientoDentalId,
                        principalTable: "TratamientosDentales",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "SeguimientosTratamiento",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TratamientoDentalId = table.Column<int>(type: "int", nullable: false),
                    NumeroSesion = table.Column<int>(type: "int", nullable: false),
                    FechaSesion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    Observaciones = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    EstadoPaciente = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    MedicoId = table.Column<int>(type: "int", nullable: true),
                    Imagenes = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SeguimientosTratamiento", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SeguimientosTratamiento_Medicos_MedicoId",
                        column: x => x.MedicoId,
                        principalTable: "Medicos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_SeguimientosTratamiento_TratamientosDentales_TratamientoDentalId",
                        column: x => x.TratamientoDentalId,
                        principalTable: "TratamientosDentales",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Alergias_PacienteId",
                table: "Alergias",
                column: "PacienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Antecedentes_PacienteId",
                table: "Antecedentes",
                column: "PacienteId");

            migrationBuilder.CreateIndex(
                name: "IX_AuditoriasAcceso_DireccionIP",
                table: "AuditoriasAcceso",
                column: "DireccionIP");

            migrationBuilder.CreateIndex(
                name: "IX_AuditoriasAcceso_UsuarioId_FechaHora",
                table: "AuditoriasAcceso",
                columns: new[] { "UsuarioId", "FechaHora" });

            migrationBuilder.CreateIndex(
                name: "IX_AuditoriasCambios_Tabla_RegistroId_FechaHora",
                table: "AuditoriasCambios",
                columns: new[] { "Tabla", "RegistroId", "FechaHora" });

            migrationBuilder.CreateIndex(
                name: "IX_AuditoriasCambios_UsuarioId_FechaHora",
                table: "AuditoriasCambios",
                columns: new[] { "UsuarioId", "FechaHora" });

            migrationBuilder.CreateIndex(
                name: "IX_BolsasPeriodontales_ExamenPeriodontalId_NumeroDiente",
                table: "BolsasPeriodontales",
                columns: new[] { "ExamenPeriodontalId", "NumeroDiente" });

            migrationBuilder.CreateIndex(
                name: "IX_CatalogoTratamientosDentales_Categoria",
                table: "CatalogoTratamientosDentales",
                column: "Categoria");

            migrationBuilder.CreateIndex(
                name: "IX_CatalogoTratamientosDentales_Codigo",
                table: "CatalogoTratamientosDentales",
                column: "Codigo");

            migrationBuilder.CreateIndex(
                name: "IX_Citas_ConsultorioId",
                table: "Citas",
                column: "ConsultorioId");

            migrationBuilder.CreateIndex(
                name: "IX_Citas_EstadoCita",
                table: "Citas",
                column: "EstadoCita");

            migrationBuilder.CreateIndex(
                name: "IX_Citas_MedicoId_FechaHora",
                table: "Citas",
                columns: new[] { "MedicoId", "FechaHora" });

            migrationBuilder.CreateIndex(
                name: "IX_Citas_NumeroCita",
                table: "Citas",
                column: "NumeroCita",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Citas_PacienteId_FechaHora",
                table: "Citas",
                columns: new[] { "PacienteId", "FechaHora" });

            migrationBuilder.CreateIndex(
                name: "IX_Citas_SucursalId",
                table: "Citas",
                column: "SucursalId");

            migrationBuilder.CreateIndex(
                name: "IX_ClinicaModulos_ClinicaId_ModuloId",
                table: "ClinicaModulos",
                columns: new[] { "ClinicaId", "ModuloId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ClinicaModulos_ModuloId",
                table: "ClinicaModulos",
                column: "ModuloId");

            migrationBuilder.CreateIndex(
                name: "IX_Clinicas_Email",
                table: "Clinicas",
                column: "Email");

            migrationBuilder.CreateIndex(
                name: "IX_Clinicas_RFC",
                table: "Clinicas",
                column: "RFC",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ConfiguracionesGenerales_ClinicaId_SucursalId_Clave",
                table: "ConfiguracionesGenerales",
                columns: new[] { "ClinicaId", "SucursalId", "Clave" },
                unique: true,
                filter: "[ClinicaId] IS NOT NULL AND [SucursalId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ConsentimientosInformados_MedicoId",
                table: "ConsentimientosInformados",
                column: "MedicoId");

            migrationBuilder.CreateIndex(
                name: "IX_ConsentimientosInformados_PacienteId_FechaConsentimiento",
                table: "ConsentimientosInformados",
                columns: new[] { "PacienteId", "FechaConsentimiento" });

            migrationBuilder.CreateIndex(
                name: "IX_ConsentimientosInformados_TratamientoDentalId",
                table: "ConsentimientosInformados",
                column: "TratamientoDentalId");

            migrationBuilder.CreateIndex(
                name: "IX_Consultas_CitaId",
                table: "Consultas",
                column: "CitaId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Consultas_MedicoId",
                table: "Consultas",
                column: "MedicoId");

            migrationBuilder.CreateIndex(
                name: "IX_Consultas_NumeroConsulta",
                table: "Consultas",
                column: "NumeroConsulta",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Consultas_PacienteId_FechaConsulta",
                table: "Consultas",
                columns: new[] { "PacienteId", "FechaConsulta" });

            migrationBuilder.CreateIndex(
                name: "IX_Consultorios_SucursalId_Numero",
                table: "Consultorios",
                columns: new[] { "SucursalId", "Numero" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ControlesOrtodoncia_TratamientoOrtodonciaId_FechaControl",
                table: "ControlesOrtodoncia",
                columns: new[] { "TratamientoOrtodonciaId", "FechaControl" });

            migrationBuilder.CreateIndex(
                name: "IX_DientesEstado_OdontogramaId_NumeroDiente",
                table: "DientesEstado",
                columns: new[] { "OdontogramaId", "NumeroDiente" });

            migrationBuilder.CreateIndex(
                name: "IX_EstudiosImagen_Codigo",
                table: "EstudiosImagen",
                column: "Codigo");

            migrationBuilder.CreateIndex(
                name: "IX_EstudiosLaboratorio_Codigo",
                table: "EstudiosLaboratorio",
                column: "Codigo");

            migrationBuilder.CreateIndex(
                name: "IX_ExamenesPeriodontales_MedicoId",
                table: "ExamenesPeriodontales",
                column: "MedicoId");

            migrationBuilder.CreateIndex(
                name: "IX_ExamenesPeriodontales_PacienteId_FechaExamen",
                table: "ExamenesPeriodontales",
                columns: new[] { "PacienteId", "FechaExamen" });

            migrationBuilder.CreateIndex(
                name: "IX_FacturaDetalles_FacturaId",
                table: "FacturaDetalles",
                column: "FacturaId");

            migrationBuilder.CreateIndex(
                name: "IX_FacturaDetalles_ServicioId",
                table: "FacturaDetalles",
                column: "ServicioId");

            migrationBuilder.CreateIndex(
                name: "IX_Facturas_CitaId",
                table: "Facturas",
                column: "CitaId");

            migrationBuilder.CreateIndex(
                name: "IX_Facturas_NumeroFactura",
                table: "Facturas",
                column: "NumeroFactura",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Facturas_PacienteId_FechaEmision",
                table: "Facturas",
                columns: new[] { "PacienteId", "FechaEmision" });

            migrationBuilder.CreateIndex(
                name: "IX_Facturas_SucursalId",
                table: "Facturas",
                column: "SucursalId");

            migrationBuilder.CreateIndex(
                name: "IX_Facturas_UUID",
                table: "Facturas",
                column: "UUID");

            migrationBuilder.CreateIndex(
                name: "IX_HistoriasClinicas_ConsultaId",
                table: "HistoriasClinicas",
                column: "ConsultaId");

            migrationBuilder.CreateIndex(
                name: "IX_HistoriasClinicas_PacienteId_FechaRegistro",
                table: "HistoriasClinicas",
                columns: new[] { "PacienteId", "FechaRegistro" });

            migrationBuilder.CreateIndex(
                name: "IX_HorariosMedico_MedicoId_SucursalId_DiaSemana",
                table: "HorariosMedico",
                columns: new[] { "MedicoId", "SucursalId", "DiaSemana" });

            migrationBuilder.CreateIndex(
                name: "IX_HorariosMedico_SucursalId",
                table: "HorariosMedico",
                column: "SucursalId");

            migrationBuilder.CreateIndex(
                name: "IX_MaterialesDentales_Categoria",
                table: "MaterialesDentales",
                column: "Categoria");

            migrationBuilder.CreateIndex(
                name: "IX_MaterialesDentales_Codigo",
                table: "MaterialesDentales",
                column: "Codigo");

            migrationBuilder.CreateIndex(
                name: "IX_Medicamentos_Nombre",
                table: "Medicamentos",
                column: "Nombre");

            migrationBuilder.CreateIndex(
                name: "IX_MedicoEspecialidades_EspecialidadId",
                table: "MedicoEspecialidades",
                column: "EspecialidadId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicoEspecialidades_MedicoId_EspecialidadId",
                table: "MedicoEspecialidades",
                columns: new[] { "MedicoId", "EspecialidadId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Medicos_CedulaProfesional",
                table: "Medicos",
                column: "CedulaProfesional",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Medicos_UsuarioId",
                table: "Medicos",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Modulos_Codigo",
                table: "Modulos",
                column: "Codigo",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Modulos_ModuloPadreId",
                table: "Modulos",
                column: "ModuloPadreId");

            migrationBuilder.CreateIndex(
                name: "IX_MovimientosInventario_ProductoId_FechaMovimiento",
                table: "MovimientosInventario",
                columns: new[] { "ProductoId", "FechaMovimiento" });

            migrationBuilder.CreateIndex(
                name: "IX_MovimientosInventario_SucursalId",
                table: "MovimientosInventario",
                column: "SucursalId");

            migrationBuilder.CreateIndex(
                name: "IX_Notificaciones_UsuarioId_Leida_FechaCreacion",
                table: "Notificaciones",
                columns: new[] { "UsuarioId", "Leida", "FechaCreacion" });

            migrationBuilder.CreateIndex(
                name: "IX_Odontogramas_MedicoId",
                table: "Odontogramas",
                column: "MedicoId");

            migrationBuilder.CreateIndex(
                name: "IX_Odontogramas_PacienteId_FechaCreacion",
                table: "Odontogramas",
                columns: new[] { "PacienteId", "FechaCreacion" });

            migrationBuilder.CreateIndex(
                name: "IX_OrdenesImagen_ConsultaId",
                table: "OrdenesImagen",
                column: "ConsultaId");

            migrationBuilder.CreateIndex(
                name: "IX_OrdenesImagen_MedicoId",
                table: "OrdenesImagen",
                column: "MedicoId");

            migrationBuilder.CreateIndex(
                name: "IX_OrdenesImagen_NumeroOrden",
                table: "OrdenesImagen",
                column: "NumeroOrden",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_OrdenesImagen_PacienteId",
                table: "OrdenesImagen",
                column: "PacienteId");

            migrationBuilder.CreateIndex(
                name: "IX_OrdenesLaboratorio_ConsultaId",
                table: "OrdenesLaboratorio",
                column: "ConsultaId");

            migrationBuilder.CreateIndex(
                name: "IX_OrdenesLaboratorio_MedicoId",
                table: "OrdenesLaboratorio",
                column: "MedicoId");

            migrationBuilder.CreateIndex(
                name: "IX_OrdenesLaboratorio_NumeroOrden",
                table: "OrdenesLaboratorio",
                column: "NumeroOrden",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_OrdenesLaboratorio_PacienteId",
                table: "OrdenesLaboratorio",
                column: "PacienteId");

            migrationBuilder.CreateIndex(
                name: "IX_OrdenImagenDetalles_EstudioImagenId",
                table: "OrdenImagenDetalles",
                column: "EstudioImagenId");

            migrationBuilder.CreateIndex(
                name: "IX_OrdenImagenDetalles_OrdenImagenId",
                table: "OrdenImagenDetalles",
                column: "OrdenImagenId");

            migrationBuilder.CreateIndex(
                name: "IX_OrdenLaboratorioDetalles_EstudioLaboratorioId",
                table: "OrdenLaboratorioDetalles",
                column: "EstudioLaboratorioId");

            migrationBuilder.CreateIndex(
                name: "IX_OrdenLaboratorioDetalles_OrdenLaboratorioId",
                table: "OrdenLaboratorioDetalles",
                column: "OrdenLaboratorioId");

            migrationBuilder.CreateIndex(
                name: "IX_Pacientes_CURP",
                table: "Pacientes",
                column: "CURP");

            migrationBuilder.CreateIndex(
                name: "IX_Pacientes_Email",
                table: "Pacientes",
                column: "Email");

            migrationBuilder.CreateIndex(
                name: "IX_Pacientes_SucursalId_NumeroExpediente",
                table: "Pacientes",
                columns: new[] { "SucursalId", "NumeroExpediente" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pagos_FacturaId",
                table: "Pagos",
                column: "FacturaId");

            migrationBuilder.CreateIndex(
                name: "IX_Pagos_NumeroPago",
                table: "Pagos",
                column: "NumeroPago",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PermisosModulo_ModuloId",
                table: "PermisosModulo",
                column: "ModuloId");

            migrationBuilder.CreateIndex(
                name: "IX_PermisosModulo_UsuarioSucursalId_ModuloId",
                table: "PermisosModulo",
                columns: new[] { "UsuarioSucursalId", "ModuloId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PresupuestosDentales_MedicoId",
                table: "PresupuestosDentales",
                column: "MedicoId");

            migrationBuilder.CreateIndex(
                name: "IX_PresupuestosDentales_NumeroPresupuesto",
                table: "PresupuestosDentales",
                column: "NumeroPresupuesto",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PresupuestosDentales_PacienteId_FechaEmision",
                table: "PresupuestosDentales",
                columns: new[] { "PacienteId", "FechaEmision" });

            migrationBuilder.CreateIndex(
                name: "IX_PresupuestosDentales_SucursalId_Estado",
                table: "PresupuestosDentales",
                columns: new[] { "SucursalId", "Estado" });

            migrationBuilder.CreateIndex(
                name: "IX_PresupuestosDetalle_PresupuestoDentalId",
                table: "PresupuestosDetalle",
                column: "PresupuestoDentalId");

            migrationBuilder.CreateIndex(
                name: "IX_Productos_CodigoBarras",
                table: "Productos",
                column: "CodigoBarras");

            migrationBuilder.CreateIndex(
                name: "IX_Productos_SucursalId_Codigo",
                table: "Productos",
                columns: new[] { "SucursalId", "Codigo" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RadiografiasDentales_MedicoId",
                table: "RadiografiasDentales",
                column: "MedicoId");

            migrationBuilder.CreateIndex(
                name: "IX_RadiografiasDentales_NumeroRadiografia",
                table: "RadiografiasDentales",
                column: "NumeroRadiografia",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RadiografiasDentales_PacienteId_FechaToma",
                table: "RadiografiasDentales",
                columns: new[] { "PacienteId", "FechaToma" });

            migrationBuilder.CreateIndex(
                name: "IX_RadiografiasDentales_TipoRadiografia",
                table: "RadiografiasDentales",
                column: "TipoRadiografia");

            migrationBuilder.CreateIndex(
                name: "IX_RecetaDetalles_MedicamentoId",
                table: "RecetaDetalles",
                column: "MedicamentoId");

            migrationBuilder.CreateIndex(
                name: "IX_RecetaDetalles_RecetaId",
                table: "RecetaDetalles",
                column: "RecetaId");

            migrationBuilder.CreateIndex(
                name: "IX_Recetas_ConsultaId",
                table: "Recetas",
                column: "ConsultaId");

            migrationBuilder.CreateIndex(
                name: "IX_Recetas_MedicoId",
                table: "Recetas",
                column: "MedicoId");

            migrationBuilder.CreateIndex(
                name: "IX_Recetas_NumeroReceta",
                table: "Recetas",
                column: "NumeroReceta",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Recetas_PacienteId",
                table: "Recetas",
                column: "PacienteId");

            migrationBuilder.CreateIndex(
                name: "IX_RolPermisos_ModuloId",
                table: "RolPermisos",
                column: "ModuloId");

            migrationBuilder.CreateIndex(
                name: "IX_RolPermisos_RolId_ModuloId",
                table: "RolPermisos",
                columns: new[] { "RolId", "ModuloId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SeguimientosTratamiento_MedicoId",
                table: "SeguimientosTratamiento",
                column: "MedicoId");

            migrationBuilder.CreateIndex(
                name: "IX_SeguimientosTratamiento_TratamientoDentalId_NumeroSesion",
                table: "SeguimientosTratamiento",
                columns: new[] { "TratamientoDentalId", "NumeroSesion" });

            migrationBuilder.CreateIndex(
                name: "IX_Servicios_Codigo",
                table: "Servicios",
                column: "Codigo");

            migrationBuilder.CreateIndex(
                name: "IX_Sucursales_ClinicaId_Codigo",
                table: "Sucursales",
                columns: new[] { "ClinicaId", "Codigo" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TratamientosDentales_ConsultaId",
                table: "TratamientosDentales",
                column: "ConsultaId");

            migrationBuilder.CreateIndex(
                name: "IX_TratamientosDentales_DienteEstadoId",
                table: "TratamientosDentales",
                column: "DienteEstadoId");

            migrationBuilder.CreateIndex(
                name: "IX_TratamientosDentales_MedicoId_Estado",
                table: "TratamientosDentales",
                columns: new[] { "MedicoId", "Estado" });

            migrationBuilder.CreateIndex(
                name: "IX_TratamientosDentales_NumeroTratamiento",
                table: "TratamientosDentales",
                column: "NumeroTratamiento",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TratamientosDentales_PacienteId_FechaTratamiento",
                table: "TratamientosDentales",
                columns: new[] { "PacienteId", "FechaTratamiento" });

            migrationBuilder.CreateIndex(
                name: "IX_TratamientosOrtodoncia_MedicoId",
                table: "TratamientosOrtodoncia",
                column: "MedicoId");

            migrationBuilder.CreateIndex(
                name: "IX_TratamientosOrtodoncia_NumeroTratamiento",
                table: "TratamientosOrtodoncia",
                column: "NumeroTratamiento",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TratamientosOrtodoncia_PacienteId_Estado",
                table: "TratamientosOrtodoncia",
                columns: new[] { "PacienteId", "Estado" });

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioRoles_RolId",
                table: "UsuarioRoles",
                column: "RolId");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioRoles_UsuarioSucursalId_RolId",
                table: "UsuarioRoles",
                columns: new[] { "UsuarioSucursalId", "RolId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_Email",
                table: "Usuarios",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_NombreUsuario",
                table: "Usuarios",
                column: "NombreUsuario",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioSucursales_SucursalId",
                table: "UsuarioSucursales",
                column: "SucursalId");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioSucursales_UsuarioId_SucursalId",
                table: "UsuarioSucursales",
                columns: new[] { "UsuarioId", "SucursalId" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Alergias");

            migrationBuilder.DropTable(
                name: "Antecedentes");

            migrationBuilder.DropTable(
                name: "AuditoriasAcceso");

            migrationBuilder.DropTable(
                name: "AuditoriasCambios");

            migrationBuilder.DropTable(
                name: "BolsasPeriodontales");

            migrationBuilder.DropTable(
                name: "CatalogoTratamientosDentales");

            migrationBuilder.DropTable(
                name: "ClinicaModulos");

            migrationBuilder.DropTable(
                name: "ConfiguracionesGenerales");

            migrationBuilder.DropTable(
                name: "ConsentimientosInformados");

            migrationBuilder.DropTable(
                name: "ControlesOrtodoncia");

            migrationBuilder.DropTable(
                name: "FacturaDetalles");

            migrationBuilder.DropTable(
                name: "HistoriasClinicas");

            migrationBuilder.DropTable(
                name: "HorariosMedico");

            migrationBuilder.DropTable(
                name: "MaterialesDentales");

            migrationBuilder.DropTable(
                name: "MedicoEspecialidades");

            migrationBuilder.DropTable(
                name: "MovimientosInventario");

            migrationBuilder.DropTable(
                name: "Notificaciones");

            migrationBuilder.DropTable(
                name: "OrdenImagenDetalles");

            migrationBuilder.DropTable(
                name: "OrdenLaboratorioDetalles");

            migrationBuilder.DropTable(
                name: "Pagos");

            migrationBuilder.DropTable(
                name: "PermisosModulo");

            migrationBuilder.DropTable(
                name: "PresupuestosDetalle");

            migrationBuilder.DropTable(
                name: "RadiografiasDentales");

            migrationBuilder.DropTable(
                name: "RecetaDetalles");

            migrationBuilder.DropTable(
                name: "RolPermisos");

            migrationBuilder.DropTable(
                name: "SeguimientosTratamiento");

            migrationBuilder.DropTable(
                name: "UsuarioRoles");

            migrationBuilder.DropTable(
                name: "ExamenesPeriodontales");

            migrationBuilder.DropTable(
                name: "TratamientosOrtodoncia");

            migrationBuilder.DropTable(
                name: "Servicios");

            migrationBuilder.DropTable(
                name: "Especialidades");

            migrationBuilder.DropTable(
                name: "Productos");

            migrationBuilder.DropTable(
                name: "EstudiosImagen");

            migrationBuilder.DropTable(
                name: "OrdenesImagen");

            migrationBuilder.DropTable(
                name: "EstudiosLaboratorio");

            migrationBuilder.DropTable(
                name: "OrdenesLaboratorio");

            migrationBuilder.DropTable(
                name: "Facturas");

            migrationBuilder.DropTable(
                name: "PresupuestosDentales");

            migrationBuilder.DropTable(
                name: "Medicamentos");

            migrationBuilder.DropTable(
                name: "Recetas");

            migrationBuilder.DropTable(
                name: "Modulos");

            migrationBuilder.DropTable(
                name: "TratamientosDentales");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "UsuarioSucursales");

            migrationBuilder.DropTable(
                name: "Consultas");

            migrationBuilder.DropTable(
                name: "DientesEstado");

            migrationBuilder.DropTable(
                name: "Citas");

            migrationBuilder.DropTable(
                name: "Odontogramas");

            migrationBuilder.DropTable(
                name: "Consultorios");

            migrationBuilder.DropTable(
                name: "Medicos");

            migrationBuilder.DropTable(
                name: "Pacientes");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Sucursales");

            migrationBuilder.DropTable(
                name: "Clinicas");
        }
    }
}
