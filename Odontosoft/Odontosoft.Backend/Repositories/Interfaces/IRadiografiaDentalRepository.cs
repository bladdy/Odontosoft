using Odontosoft.Shared.Entities;
using Odontosoft.Shared.Responses;

namespace Odontosoft.Backend.Repositories.Interfaces;

public interface IRadiografiaDentalRepository : IGenericRepository<RadiografiaDental>
{
    Task<ActionResponse<IEnumerable<RadiografiaDental>>> GetRadiografiasPacienteAsync(Guid pacienteId);

    Task<ActionResponse<IEnumerable<RadiografiaDental>>> GetRadiografiasPorTipoAsync(Guid pacienteId, string tipo);

    Task<ActionResponse<string>> GenerarNumeroRadiografiaAsync();
}