using Microsoft.EntityFrameworkCore;
using Odontosoft.Backend.Data;
using Odontosoft.Backend.Middleware;
using Odontosoft.Backend.Repositories.Implementations;
using Odontosoft.Backend.Repositories.Interfaces;
using Odontosoft.Backend.Services;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.OpenApi.Models;
using Odontosoft.Backend.UnitsOfWork.Implementations;
using Odontosoft.Backend.UnitsOfWork.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// ==================== CONTROLLERS ====================
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
        options.JsonSerializerOptions.DefaultIgnoreCondition =
            JsonIgnoreCondition.WhenWritingNull;
    });

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo { Title = "Odontosoft", Version = "1.0.0" });
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = @"JWT Authorization header using the Bearer scheme. <br /> <br />
                      Enter 'Bearer' [space] and then your token in the text input below.<br /> <br />
                      Example: 'Bearer 12345abcdef'<br /> <br />",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });
    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                },
                Scheme = "oauth2",
                Name = "Bearer",
                In = ParameterLocation.Header
            },
            new string[] {}
        }
    });
});

// ==================== DATABASE ====================
builder.Services.AddDbContext<DataContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("LocalConnection")));

// ==================== UNIT OF WORK ====================
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

// ==================== REPOSITORIOS ====================
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped<IOdontogramaRepository, OdontogramaRepository>();
builder.Services.AddScoped<ITratamientoDentalRepository, TratamientoDentalRepository>();
builder.Services.AddScoped<IPacienteRepository, PacienteRepository>();
builder.Services.AddScoped<IMedicoRepository, MedicoRepository>();
builder.Services.AddScoped<IPresupuestoDentalRepository, PresupuestoDentalRepository>();
builder.Services.AddScoped<IRadiografiaDentalRepository, RadiografiaDentalRepository>();
builder.Services.AddScoped<IExamenPeriodontalRepository, ExamenPeriodontalRepository>();
builder.Services.AddScoped<ITratamientoOrtodonciaRepository, TratamientoOrtodonciaRepository>();
builder.Services.AddScoped<IClinicaRepository, ClinicaRepository>();
builder.Services.AddScoped<ISucursalRepository, SucursalRepository>();
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddScoped<ICitaRepository, CitaRepository>();
builder.Services.AddScoped<IConsultaRepository, ConsultaRepository>();
builder.Services.AddScoped<IRecetaRepository, RecetaRepository>();
builder.Services.AddScoped<IFacturaRepository, FacturaRepository>();
builder.Services.AddScoped<IProductoRepository, ProductoRepository>();
builder.Services.AddScoped<ICatalogoTratamientoDentalRepository, CatalogoTratamientoDentalRepository>();

builder.Services.AddScoped(typeof(IGenericUnitOfWork<>),
                           typeof(GenericUnitOfWork<>));
// ==================== SERVICIOS ====================

builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<ITenantService, TenantService>();
builder.Services.AddScoped<DatabaseSeeder>(); // 🔥 IMPORTANTE
builder.Services.AddScoped<JwtService>();
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]!))
    };
});

var app = builder.Build();

// ==================== MIGRATIONS + SEED ====================
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<DataContext>();
    await context.Database.MigrateAsync();

    var seeder = scope.ServiceProvider.GetRequiredService<DatabaseSeeder>();
    await seeder.SeedDatabase();
}

// ==================== CORS ====================
app.UseCors(x => x
    .AllowAnyMethod()
    .AllowAnyHeader()
    .SetIsOriginAllowed(origin => true)
    .AllowCredentials());

// ==================== SWAGGER ====================
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// ==================== MIDDLEWARE ====================

// 1️⃣ Resolver el tenant (SUBDOMINIO o HEADER)
app.UseMiddleware<TenantMiddleware>();

// 2️⃣ Validar que el usuario pertenece al tenant
app.UseMiddleware<TenantAccessMiddleware>();

// 3️⃣ Validar sucursal
app.UseMiddleware<SucursalAccessMiddleware>();

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();

//Tool: Nginx Proxy Manager

//ToDo: Verificar porque el middleware de TenantAccessMiddleware no funciona correctamente, agregar un sistema de logging para registrar errores y eventos importantes, agregar un sistema de manejo global de errores para capturar excepciones no manejadas y devolver respuestas consistentes, agregar validaciones a los modelos de entrada utilizando FluentValidation, agregar caching con Redis para mejorar el rendimiento en consultas frecuentes, agregar versionamiento a la API para mantener compatibilidad con versiones anteriores, agregar health checks para monitorear el estado de la aplicación, agregar rate limiting para proteger la API contra abusos, agregar localization para soportar múltiples idiomas, agregar tests unitarios y de integración para asegurar la calidad del código.

//ToDo: Agregar logging, agregar global error handling, agregar validaciones con FluentValidation, agregar caching con Redis, agregar versionamiento a la API, agregar health checks, agregar rate limiting, agregar localization, agregar tests unitarios y de integración.
//ToDo: Agregar un endpoint para renovar el token JWT, agregar refresh tokens, agregar roles y claims para control de acceso, agregar un sistema de notificaciones (ej: SignalR), agregar integración con servicios externos (ej: pasarela de pagos), agregar un sistema de auditoría para registrar cambios en la base de datos, agregar un sistema de archivos para almacenar documentos relacionados a pacientes y tratamientos, agregar un sistema de reportes para generar estadísticas y análisis sobre los datos.
//ToDo: Agregar un sistema de colas para procesar tareas en segundo plano (ej: envío de emails, generación de reportes pesados), agregar un sistema de monitoreo y alertas para detectar problemas en producción, agregar un sistema de internacionalización para soportar múltiples idiomas, agregar un sistema de personalización para que cada clínica pueda configurar su propia apariencia y funcionalidades, agregar un sistema de integración continua y despliegue continuo (CI/CD) para automatizar el proceso de desarrollo y despliegue.