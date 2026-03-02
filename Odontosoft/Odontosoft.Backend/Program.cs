using Microsoft.EntityFrameworkCore;
using Odontosoft.Backend.Data;
using Odontosoft.Backend.Middleware;
using Odontosoft.Backend.Repositories.Implementations;
using Odontosoft.Backend.Repositories.Interfaces;
using Odontosoft.Backend.Services;
using System.Text.Json.Serialization;

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
builder.Services.AddSwaggerGen();

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

// ==================== SERVICIOS ====================
builder.Services.AddScoped<ITenantService, TenantService>();
builder.Services.AddScoped<DatabaseSeeder>(); // 🔥 IMPORTANTE

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
app.UseMiddleware<TenantMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();