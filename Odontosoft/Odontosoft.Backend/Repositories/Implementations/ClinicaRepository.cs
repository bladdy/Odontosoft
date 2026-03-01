using Microsoft.EntityFrameworkCore;
using Odontosoft.Backend.Data;
using Odontosoft.Shared.Entities;
using Odontosoft.Shared.Responses;

namespace Odontosoft.Backend.Repositories.Implementations;

public class ClinicaRepository : GenericRepository<Clinica>, IClinicaRepository
{
    private readonly DataContext _context;

    public ClinicaRepository(DataContext context) : base(context)
    {
        _context = context;
    }

    public async Task<ActionResponse<Clinica>> GetClinicaConSucursalesAsync(int clinicaId)
    {
        try
        {
            var clinica = await _context.Clinicas
                .Include(c => c.Sucursales.Where(s => s.Activo))
                .FirstOrDefaultAsync(c => c.Id == clinicaId);

            if (clinica == null)
            {
                return new ActionResponse<Clinica>
                {
                    WasSuccess = false,
                    Message = "Clínica no encontrada"
                };
            }

            return new ActionResponse<Clinica>
            {
                WasSuccess = true,
                Result = clinica
            };
        }
        catch (Exception ex)
        {
            return new ActionResponse<Clinica>
            {
                WasSuccess = false,
                Message = ex.Message
            };
        }
    }

    public async Task<ActionResponse<Clinica>> GetClinicaConModulosAsync(int clinicaId)
    {
        try
        {
            var clinica = await _context.Clinicas
                .Include(c => c.ClinicaModulos)
                    .ThenInclude(cm => cm.Modulo)
                .FirstOrDefaultAsync(c => c.Id == clinicaId);

            if (clinica == null)
            {
                return new ActionResponse<Clinica>
                {
                    WasSuccess = false,
                    Message = "Clínica no encontrada"
                };
            }

            return new ActionResponse<Clinica>
            {
                WasSuccess = true,
                Result = clinica
            };
        }
        catch (Exception ex)
        {
            return new ActionResponse<Clinica>
            {
                WasSuccess = false,
                Message = ex.Message
            };
        }
    }

    public async Task<ActionResponse<Clinica>> GetByRFCAsync(string rfc)
    {
        try
        {
            var clinica = await _context.Clinicas
                .FirstOrDefaultAsync(c => c.RFC == rfc);

            if (clinica == null)
            {
                return new ActionResponse<Clinica>
                {
                    WasSuccess = false,
                    Message = "Clínica no encontrada"
                };
            }

            return new ActionResponse<Clinica>
            {
                WasSuccess = true,
                Result = clinica
            };
        }
        catch (Exception ex)
        {
            return new ActionResponse<Clinica>
            {
                WasSuccess = false,
                Message = ex.Message
            };
        }
    }

    public async Task<ActionResponse<IEnumerable<Clinica>>> GetClinicasActivasAsync()
    {
        try
        {
            var clinicas = await _context.Clinicas
                .Where(c => c.Activo)
                .OrderBy(c => c.Nombre)
                .ToListAsync();

            return new ActionResponse<IEnumerable<Clinica>>
            {
                WasSuccess = true,
                Result = clinicas
            };
        }
        catch (Exception ex)
        {
            return new ActionResponse<IEnumerable<Clinica>>
            {
                WasSuccess = false,
                Message = ex.Message
            };
        }
    }
}