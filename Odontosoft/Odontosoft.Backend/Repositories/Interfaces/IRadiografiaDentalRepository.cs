using Odontosoft.Shared.Entities;
using Odontosoft.Shared.Responses;

namespace Odontosoft.Backend.Repositories.Interfaces;

public interface IRadiografiaDentalRepository : IGenericRepository<RadiografiaDental>
{
    Task<ActionResponse<IEnumerable<RadiografiaDental>>> GetRadiografiasPacienteAsync(int pacienteId);

    Task<ActionResponse<IEnumerable<RadiografiaDental>>> GetRadiografiasPorTipoAsync(int pacienteId, string tipo);

    Task<ActionResponse<string>> GenerarNumeroRadiografiaAsync();
}