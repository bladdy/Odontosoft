using Microsoft.EntityFrameworkCore;
using Odontosoft.Backend.Data;
using Odontosoft.Backend.Repositories.Implementations;
using Odontosoft.Backend.Repositories.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DataContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("LocalConnection")));

// ==================== REGISTRAR UNIT OF WORK ====================
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

// ==================== REGISTRAR REPOSITORIOS (OPCIONAL) ====================
// Solo si quieres inyectarlos individualmente además del UnitOfWork
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped<IOdontogramaRepository, OdontogramaRepository>();
builder.Services.AddScoped<ITratamientoDentalRepository, TratamientoDentalRepository>();
builder.Services.AddScoped<IPresupuestoDentalRepository, PresupuestoDentalRepository>();
builder.Services.AddScoped<IRadiografiaDentalRepository, RadiografiaDentalRepository>();
builder.Services.AddScoped<IExamenPeriodontalRepository, ExamenPeriodontalRepository>();
builder.Services.AddScoped<ITratamientoOrtodonciaRepository, TratamientoOrtodonciaRepository>();
builder.Services.AddScoped<IClinicaRepository, ClinicaRepository>();
builder.Services.AddScoped<ISucursalRepository, SucursalRepository>();
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddScoped<IPacienteRepository, PacienteRepository>();
builder.Services.AddScoped<IMedicoRepository, MedicoRepository>();
builder.Services.AddScoped<ICitaRepository, CitaRepository>();
builder.Services.AddScoped<IConsultaRepository, ConsultaRepository>();
builder.Services.AddScoped<IRecetaRepository, RecetaRepository>();
builder.Services.AddScoped<IFacturaRepository, FacturaRepository>();
builder.Services.AddScoped<IProductoRepository, ProductoRepository>();
builder.Services.AddScoped<ICatalogoTratamientoDentalRepository, CatalogoTratamientoDentalRepository>();

var app = builder.Build();
app.UseCors(x => x
    .AllowAnyMethod()
    .AllowAnyHeader()
    .SetIsOriginAllowed(origin => true)
    .AllowCredentials());
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

//appclinicsoft.com goodaddy.com 229

//clinisystem.com