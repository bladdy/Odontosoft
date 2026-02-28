using Odontosoft.Shared.Entities;
using Odontosoft.Shared.Responses;
using Odontosoft.Backend.Repositories.Interfaces;

public interface IClinicaRepository : IGenericRepository<Clinica>
{
    Task<ActionResponse<Clinica>> GetClinicaConSucursalesAsync(int clinicaId);

    Task<ActionResponse<Clinica>> GetClinicaConModulosAsync(int clinicaId);

    Task<ActionResponse<Clinica>> GetByRFCAsync(string rfc);

    Task<ActionResponse<IEnumerable<Clinica>>> GetClinicasActivasAsync();
}