using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Odontosoft.Backend.Migrations
{
    /// <inheritdoc />
    public partial class initialDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clinicas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RazonSocial = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RFC = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clinicas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pacientes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaNacimiento = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sexo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pacientes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rol = table.Column<string>(type: "nvarchar(max)", nullable: false)
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
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Horarios = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sucursales", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sucursales_Clinicas_ClinicaId",
                        column: x => x.ClinicaId,
                        principalTable: "Clinicas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ExpedientesClinicos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PacienteId = table.Column<int>(type: "int", nullable: false),
                    SucursalId = table.Column<int>(type: "int", nullable: false),
                    UsuarioId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExpedientesClinicos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExpedientesClinicos_Pacientes_PacienteId",
                        column: x => x.PacienteId,
                        principalTable: "Pacientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExpedientesClinicos_Sucursales_SucursalId",
                        column: x => x.SucursalId,
                        principalTable: "Sucursales",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExpedientesClinicos_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UsuarioSucursales",
                columns: table => new
                {
                    UsuarioId = table.Column<int>(type: "int", nullable: false),
                    SucursalId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuarioSucursales", x => new { x.UsuarioId, x.SucursalId });
                    table.ForeignKey(
                        name: "FK_UsuarioSucursales_Sucursales_SucursalId",
                        column: x => x.SucursalId,
                        principalTable: "Sucursales",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UsuarioSucursales_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Diagnosticos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExpedienteClinicoId = table.Column<int>(type: "int", nullable: false),
                    DiagnosticoDescripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CodigoICD = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Diagnosticos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Diagnosticos_ExpedientesClinicos_ExpedienteClinicoId",
                        column: x => x.ExpedienteClinicoId,
                        principalTable: "ExpedientesClinicos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Evoluciones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExpedienteClinicoId = table.Column<int>(type: "int", nullable: false),
                    Observaciones = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Evoluciones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Evoluciones_ExpedientesClinicos_ExpedienteClinicoId",
                        column: x => x.ExpedienteClinicoId,
                        principalTable: "ExpedientesClinicos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FirmasDigitales",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExpedienteClinicoId = table.Column<int>(type: "int", nullable: false),
                    FirmaBase64 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FirmasDigitales", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FirmasDigitales_ExpedientesClinicos_ExpedienteClinicoId",
                        column: x => x.ExpedienteClinicoId,
                        principalTable: "ExpedientesClinicos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FotografiasIntraorales",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExpedienteClinicoId = table.Column<int>(type: "int", nullable: false),
                    UrlArchivo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FotografiasIntraorales", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FotografiasIntraorales_ExpedientesClinicos_ExpedienteClinicoId",
                        column: x => x.ExpedienteClinicoId,
                        principalTable: "ExpedientesClinicos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NotasClinicas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExpedienteClinicoId = table.Column<int>(type: "int", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NotasClinicas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NotasClinicas_ExpedientesClinicos_ExpedienteClinicoId",
                        column: x => x.ExpedienteClinicoId,
                        principalTable: "ExpedientesClinicos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Prescripciones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExpedienteClinicoId = table.Column<int>(type: "int", nullable: false),
                    Medicamento = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Dosis = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Instrucciones = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prescripciones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Prescripciones_ExpedientesClinicos_ExpedienteClinicoId",
                        column: x => x.ExpedienteClinicoId,
                        principalTable: "ExpedientesClinicos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Radiografias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExpedienteClinicoId = table.Column<int>(type: "int", nullable: false),
                    Tipo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UrlArchivo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Radiografias", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Radiografias_ExpedientesClinicos_ExpedienteClinicoId",
                        column: x => x.ExpedienteClinicoId,
                        principalTable: "ExpedientesClinicos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tratamientos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExpedienteClinicoId = table.Column<int>(type: "int", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Fase = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Costo = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FechaInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaFin = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tratamientos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tratamientos_ExpedientesClinicos_ExpedienteClinicoId",
                        column: x => x.ExpedienteClinicoId,
                        principalTable: "ExpedientesClinicos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Diagnosticos_ExpedienteClinicoId",
                table: "Diagnosticos",
                column: "ExpedienteClinicoId");

            migrationBuilder.CreateIndex(
                name: "IX_Evoluciones_ExpedienteClinicoId",
                table: "Evoluciones",
                column: "ExpedienteClinicoId");

            migrationBuilder.CreateIndex(
                name: "IX_ExpedientesClinicos_PacienteId",
                table: "ExpedientesClinicos",
                column: "PacienteId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ExpedientesClinicos_SucursalId",
                table: "ExpedientesClinicos",
                column: "SucursalId");

            migrationBuilder.CreateIndex(
                name: "IX_ExpedientesClinicos_UsuarioId",
                table: "ExpedientesClinicos",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_FirmasDigitales_ExpedienteClinicoId",
                table: "FirmasDigitales",
                column: "ExpedienteClinicoId");

            migrationBuilder.CreateIndex(
                name: "IX_FotografiasIntraorales_ExpedienteClinicoId",
                table: "FotografiasIntraorales",
                column: "ExpedienteClinicoId");

            migrationBuilder.CreateIndex(
                name: "IX_NotasClinicas_ExpedienteClinicoId",
                table: "NotasClinicas",
                column: "ExpedienteClinicoId");

            migrationBuilder.CreateIndex(
                name: "IX_Prescripciones_ExpedienteClinicoId",
                table: "Prescripciones",
                column: "ExpedienteClinicoId");

            migrationBuilder.CreateIndex(
                name: "IX_Radiografias_ExpedienteClinicoId",
                table: "Radiografias",
                column: "ExpedienteClinicoId");

            migrationBuilder.CreateIndex(
                name: "IX_Sucursales_ClinicaId",
                table: "Sucursales",
                column: "ClinicaId");

            migrationBuilder.CreateIndex(
                name: "IX_Tratamientos_ExpedienteClinicoId",
                table: "Tratamientos",
                column: "ExpedienteClinicoId");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioSucursales_SucursalId",
                table: "UsuarioSucursales",
                column: "SucursalId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Diagnosticos");

            migrationBuilder.DropTable(
                name: "Evoluciones");

            migrationBuilder.DropTable(
                name: "FirmasDigitales");

            migrationBuilder.DropTable(
                name: "FotografiasIntraorales");

            migrationBuilder.DropTable(
                name: "NotasClinicas");

            migrationBuilder.DropTable(
                name: "Prescripciones");

            migrationBuilder.DropTable(
                name: "Radiografias");

            migrationBuilder.DropTable(
                name: "Tratamientos");

            migrationBuilder.DropTable(
                name: "UsuarioSucursales");

            migrationBuilder.DropTable(
                name: "ExpedientesClinicos");

            migrationBuilder.DropTable(
                name: "Pacientes");

            migrationBuilder.DropTable(
                name: "Sucursales");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Clinicas");
        }
    }
}
