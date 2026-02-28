// ============================================================================
// UNIT OF WORK COMPLETO - ODONTOSOFT
// ============================================================================

using Odontosoft.Backend.Data;
using Odontosoft.Backend.Repositories.Interfaces;
using Odontosoft.Shared.Entities;
using Odontosoft.Shared.Responses;

namespace Odontosoft.Backend.Repositories.Implementations
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _context;

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

        public UnitOfWork(DataContext context)
        {
            _context = context;
        }

        // ==================== PROPIEDADES DE ODONTOLOGÍA ====================

        public IOdontogramaRepository Odontogramas =>
            _odontogramas ??= new OdontogramaRepository(_context);

        public ITratamientoDentalRepository TratamientosDentales =>
            _tratamientosDentales ??= new TratamientoDentalRepository(_context);

        public IPresupuestoDentalRepository PresupuestosDentales =>
            _presupuestosDentales ??= new PresupuestoDentalRepository(_context);

        public IRadiografiaDentalRepository RadiografiasDentales =>
            _radiografiasDentales ??= new RadiografiaDentalRepository(_context);

        public IExamenPeriodontalRepository ExamenesPeriodontales =>
            _examenesPeriodontales ??= new ExamenPeriodontalRepository(_context);

        public ITratamientoOrtodonciaRepository TratamientosOrtodoncia =>
            _tratamientosOrtodoncia ??= new TratamientoOrtodonciaRepository(_context);

        // ==================== PROPIEDADES BASE ====================

        public IClinicaRepository Clinicas =>
            _clinicas ??= new ClinicaRepository(_context);

        public ISucursalRepository Sucursales =>
            _sucursales ??= new SucursalRepository(_context);

        public IUsuarioRepository Usuarios =>
            _usuarios ??= new UsuarioRepository(_context);

        public IPacienteRepository Pacientes =>
            _pacientes ??= new PacienteRepository(_context);

        public IMedicoRepository Medicos =>
            _medicos ??= new MedicoRepository(_context);

        public ICitaRepository Citas =>
            _citas ??= new CitaRepository(_context);

        public IConsultaRepository Consultas =>
            _consultas ??= new ConsultaRepository(_context);

        public IRecetaRepository Recetas =>
            _recetas ??= new RecetaRepository(_context);

        public IFacturaRepository Facturas =>
            _facturas ??= new FacturaRepository(_context);

        public IProductoRepository Productos =>
            _productos ??= new ProductoRepository(_context);

        // ==================== PROPIEDADES DE CATÁLOGOS ====================

        public ICatalogoTratamientoDentalRepository CatalogosTratamientos =>
            _catalogosTratamientos ??= new CatalogoTratamientoDentalRepository(_context);

        public IGenericRepository<Especialidad> Especialidades =>
            _especialidades ??= new GenericRepository<Especialidad>(_context);

        public IGenericRepository<Medicamento> Medicamentos =>
            _medicamentos ??= new GenericRepository<Medicamento>(_context);

        public IGenericRepository<Servicio> Servicios =>
            _servicios ??= new GenericRepository<Servicio>(_context);

        public IGenericRepository<MaterialDental> MaterialesDentales =>
            _materialesDentales ??= new GenericRepository<MaterialDental>(_context);

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