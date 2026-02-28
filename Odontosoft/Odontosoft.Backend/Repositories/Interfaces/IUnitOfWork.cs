using Odontosoft.Shared.Entities;
using Odontosoft.Shared.Responses;
using Odontosoft.Backend.Repositories.Interfaces;

public interface IUnitOfWork : IDisposable
{
    // Repositorios de Odontología
    IOdontogramaRepository Odontogramas { get; }

    ITratamientoDentalRepository TratamientosDentales { get; }
    IPresupuestoDentalRepository PresupuestosDentales { get; }
    IRadiografiaDentalRepository RadiografiasDentales { get; }
    IExamenPeriodontalRepository ExamenesPeriodontales { get; }
    ITratamientoOrtodonciaRepository TratamientosOrtodoncia { get; }

    // Repositorios Base
    IClinicaRepository Clinicas { get; }

    ISucursalRepository Sucursales { get; }
    IUsuarioRepository Usuarios { get; }
    IPacienteRepository Pacientes { get; }
    IMedicoRepository Medicos { get; }
    ICitaRepository Citas { get; }
    IConsultaRepository Consultas { get; }
    IRecetaRepository Recetas { get; }
    IFacturaRepository Facturas { get; }
    IProductoRepository Productos { get; }

    // Repositorios de Catálogos
    ICatalogoTratamientoDentalRepository CatalogosTratamientos { get; }

    IGenericRepository<Especialidad> Especialidades { get; }
    IGenericRepository<Medicamento> Medicamentos { get; }
    IGenericRepository<Servicio> Servicios { get; }
    IGenericRepository<MaterialDental> MaterialesDentales { get; }

    // Métodos
    Task<ActionResponse<bool>> SaveAsync();
}