using Microsoft.EntityFrameworkCore;
using Odontosoft.Backend.Data;
using Odontosoft.Backend.Repositories.Interfaces;
using Odontosoft.Shared.Entities;
using Odontosoft.Shared.Responses;

using Odontosoft.Backend.Services;

namespace Odontosoft.Backend.Repositories.Implementations;

public class RadiografiaDentalRepository : GenericRepository<RadiografiaDental>, IRadiografiaDentalRepository
{
    private readonly DataContext _context;

    public RadiografiaDentalRepository(DataContext context, ITenantService tenantService) : base(context, tenantService)
    {
        _context = context;
    }

    public async Task<ActionResponse<IEnumerable<RadiografiaDental>>> GetRadiografiasPacienteAsync(Guid pacienteId)
    {
        try
        {
            var radiografias = await _context.RadiografiasDentales
                .Include(r => r.Medico).ThenInclude(m => m.Usuario)
                .Where(r => r.PacienteId == pacienteId)
                .OrderByDescending(r => r.FechaToma)
                .ToListAsync();

            return new ActionResponse<IEnumerable<RadiografiaDental>>
            {
                WasSuccess = true,
                Result = radiografias
            };
        }
        catch (Exception ex)
        {
            return new ActionResponse<IEnumerable<RadiografiaDental>>
            {
                WasSuccess = false,
                Message = ex.Message
            };
        }
    }

    public async Task<ActionResponse<IEnumerable<RadiografiaDental>>> GetRadiografiasPorTipoAsync(Guid pacienteId, string tipo)
    {
        try
        {
            var radiografias = await _context.RadiografiasDentales
                .Include(r => r.Medico).ThenInclude(m => m.Usuario)
                .Where(r => r.PacienteId == pacienteId && r.TipoRadiografia == tipo)
                .OrderByDescending(r => r.FechaToma)
                .ToListAsync();

            return new ActionResponse<IEnumerable<RadiografiaDental>>
            {
                WasSuccess = true,
                Result = radiografias
            };
        }
        catch (Exception ex)
        {
            return new ActionResponse<IEnumerable<RadiografiaDental>>
            {
                WasSuccess = false,
                Message = ex.Message
            };
        }
    }

    public async Task<ActionResponse<string>> GenerarNumeroRadiografiaAsync()
    {
        try
        {
            var ultimaRadiografia = await _context.RadiografiasDentales
                .OrderByDescending(r => r.Id)
                .Select(r => r.NumeroRadiografia)
                .FirstOrDefaultAsync();

            int numero = 1;
            if (!string.IsNullOrEmpty(ultimaRadiografia))
            {
                var partes = ultimaRadiografia.Split('-');
                if (partes.Length > 2 && int.TryParse(partes[2], out int ultimoNumero))
                {
                    numero = ultimoNumero + 1;
                }
            }

            return new ActionResponse<string>
            {
                WasSuccess = true,
                Result = $"RAD-{DateTime.Now:yyyyMM}-{numero:D6}"
            };
        }
        catch (Exception ex)
        {
            return new ActionResponse<string>
            {
                WasSuccess = false,
                Message = ex.Message
            };
        }
    }
}