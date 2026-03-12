// ============================================================================
// UNIT OF WORK COMPLETO - ODONTOSOFT
// ============================================================================

using Odontosoft.Backend.Data;
using Odontosoft.Backend.Repositories.Interfaces;
using Odontosoft.Backend.Services;
using Odontosoft.Shared.Entities;
using Odontosoft.Shared.Responses;

namespace Odontosoft.Backend.Repositories.Implementations
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _context;
        private readonly ITenantService _tenantService;

        // Repositorios de Odontología
        private IOdontogramaRepository? _odontogramas;

        private ITratamientoDentalRepository? _tratamientosDentales;
        private IPresupuestoDentalRepository? _presupuestosDentales;
        private IRadiografiaDentalRepository? _radiografiasDentales;
        private IExamenPeriodontalRepository? _examenesPeriodontales;
        private ITratamientoOrtodonciaRepository? _tratamientosOrtodoncia;

        // Repositorios Base
        private IClinicaRepository? _clinicas;

        private ISucursalRepository? _sucursales;
        private IUsuarioRepository? _usuarios;
        private IPacienteRepository? _pacientes;
        private IMedicoRepository? _medicos;
        private ICitaRepository? _citas;
        private IConsultaRepository? _consultas;
        private IRecetaRepository? _recetas;
        private IFacturaRepository? _facturas;
        private IProductoRepository? _productos;

        // Repositorios de Catálogos
        private ICatalogoTratamientoDentalRepository? _catalogosTratamientos;

        private IGenericRepository<Especialidad>? _especialidades;
        private IGenericRepository<Medicamento>? _medicamentos;
        private IGenericRepository<Servicio>? _servicios;
        private IGenericRepository<MaterialDental>? _materialesDentales;

        public UnitOfWork(DataContext context, ITenantService tenantService)
        {
            _context = context;
            _tenantService = tenantService;
        }

        // ==================== PROPIEDADES DE ODONTOLOGÍA ====================

        public IOdontogramaRepository Odontogramas =>
            _odontogramas ??= new OdontogramaRepository(_context, _tenantService);

        public ITratamientoDentalRepository TratamientosDentales =>
            _tratamientosDentales ??= new TratamientoDentalRepository(_context, _tenantService);

        public IPresupuestoDentalRepository PresupuestosDentales =>
            _presupuestosDentales ??= new PresupuestoDentalRepository(_context, _tenantService);

        public IRadiografiaDentalRepository RadiografiasDentales =>
            _radiografiasDentales ??= new RadiografiaDentalRepository(_context, _tenantService);

        public IExamenPeriodontalRepository ExamenesPeriodontales =>
            _examenesPeriodontales ??= new ExamenPeriodontalRepository(_context, _tenantService);

        public ITratamientoOrtodonciaRepository TratamientosOrtodoncia =>
            _tratamientosOrtodoncia ??= new TratamientoOrtodonciaRepository(_context, _tenantService);

        // ==================== PROPIEDADES BASE ====================

        public IClinicaRepository Clinicas =>
            _clinicas ??= new ClinicaRepository(_context, _tenantService);

        public ISucursalRepository Sucursales =>
            _sucursales ??= new SucursalRepository(_context, _tenantService);

        public IUsuarioRepository Usuarios =>
            _usuarios ??= new UsuarioRepository(_context, _tenantService);

        public IPacienteRepository Pacientes =>
            _pacientes ??= new PacienteRepository(_context, _tenantService);

        public IMedicoRepository Medicos =>
            _medicos ??= new MedicoRepository(_context, _tenantService);

        public ICitaRepository Citas =>
            _citas ??= new CitaRepository(_context, _tenantService);

        public IConsultaRepository Consultas =>
            _consultas ??= new ConsultaRepository(_context, _tenantService);

        public IRecetaRepository Recetas =>
            _recetas ??= new RecetaRepository(_context, _tenantService);

        public IFacturaRepository Facturas =>
            _facturas ??= new FacturaRepository(_context, _tenantService);

        public IProductoRepository Productos =>
            _productos ??= new ProductoRepository(_context, _tenantService);

        // ==================== PROPIEDADES DE CATÁLOGOS ====================

        public ICatalogoTratamientoDentalRepository CatalogosTratamientos =>
            _catalogosTratamientos ??= new CatalogoTratamientoDentalRepository(_context, _tenantService);

        public IGenericRepository<Especialidad> Especialidades =>
            _especialidades ??= new GenericRepository<Especialidad>(_context, _tenantService);

        public IGenericRepository<Medicamento> Medicamentos =>
            _medicamentos ??= new GenericRepository<Medicamento>(_context, _tenantService);

        public IGenericRepository<Servicio> Servicios =>
            _servicios ??= new GenericRepository<Servicio>(_context, _tenantService);

        public IGenericRepository<MaterialDental> MaterialesDentales =>
            _materialesDentales ??= new GenericRepository<MaterialDental>(_context, _tenantService);

        // ==================== MÉTODOS ====================

        public async Task<ActionResponse<bool>> SaveAsync()
        {
            try
            {
                await _context.SaveChangesAsync();
                return new ActionResponse<bool>
                {
                    WasSuccess = true,
                    Result = true
                };
            }
            catch (Exception ex)
            {
                return new ActionResponse<bool>
                {
                    WasSuccess = false,
                    Message = ex.Message
                };
            }
        }

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}