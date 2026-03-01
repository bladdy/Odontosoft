using Microsoft.EntityFrameworkCore;
using Odontosoft.Backend.Data;
using Odontosoft.Shared.Entities;
using Odontosoft.Shared.Responses;

namespace Odontosoft.Backend.Repositories.Implementations;

public class RecetaRepository : GenericRepository<Receta>, IRecetaRepository
{
    private readonly DataContext _context;

    public RecetaRepository(DataContext context) : base(context)
    {
        _context = context;
    }

    public async Task<ActionResponse<Receta>> GetRecetaConDetallesAsync(int recetaId)
    {
        try
        {
            var receta = await _context.Recetas
                .Include(r => r.Paciente)
                .Include(r => r.Medico).ThenInclude(m => m.Usuario)
                .Include(r => r.Consulta)
                .Include(r => r.RecetaDetalles).ThenInclude(rd => rd.Medicamento)
                .FirstOrDefaultAsync(r => r.Id == recetaId);

            if (receta == null)
            {
                return new ActionResponse<Receta>
                {
                    WasSuccess = false,
                    Message = "Receta no encontrada"
                };
            }

            return new ActionResponse<Receta>
            {
                WasSuccess = true,
                Result = receta
            };
        }
        catch (Exception ex)
        {
            return new ActionResponse<Receta>
            {
                WasSuccess = false,
                Message = ex.Message
            };
        }
    }

    public async Task<ActionResponse<IEnumerable<Receta>>> GetRecetasPacienteAsync(int pacienteId)
    {
        try
        {
            var recetas = await _context.Recetas
                .Include(r => r.Medico).ThenInclude(m => m.Usuario)
                .Where(r => r.PacienteId == pacienteId)
                .OrderByDescending(r => r.FechaEmision)
                .ToListAsync();

            return new ActionResponse<IEnumerable<Receta>>
            {
                WasSuccess = true,
                Result = recetas
            };
        }
        catch (Exception ex)
        {
            return new ActionResponse<IEnumerable<Receta>>
            {
                WasSuccess = false,
                Message = ex.Message
            };
        }
    }

    public async Task<ActionResponse<IEnumerable<Receta>>> GetRecetasActivasAsync(int pacienteId)
    {
        try
        {
            var fechaActual = DateTime.UtcNow;

            var recetas = await _context.Recetas
                .Include(r => r.Medico).ThenInclude(m => m.Usuario)
                .Include(r => r.RecetaDetalles).ThenInclude(rd => rd.Medicamento)
                .Where(r => r.PacienteId == pacienteId &&
                           r.Estado == "Activa" &&
                           (!r.FechaVencimiento.HasValue || r.FechaVencimiento.Value >= fechaActual))
                .OrderByDescending(r => r.FechaEmision)
                .ToListAsync();

            return new ActionResponse<IEnumerable<Receta>>
            {
                WasSuccess = true,
                Result = recetas
            };
        }
        catch (Exception ex)
        {
            return new ActionResponse<IEnumerable<Receta>>
            {
                WasSuccess = false,
                Message = ex.Message
            };
        }
    }

    public async Task<ActionResponse<string>> GenerarNumeroRecetaAsync()
    {
        try
        {
            var ultimaReceta = await _context.Recetas
                .OrderByDescending(r => r.Id)
                .Select(r => r.NumeroReceta)
                .FirstOrDefaultAsync();

            int numero = 1;
            if (!string.IsNullOrEmpty(ultimaReceta))
            {
                var partes = ultimaReceta.Split('-');
                if (partes.Length > 2 && int.TryParse(partes[2], out int ultimoNumero))
                {
                    numero = ultimoNumero + 1;
                }
            }

            return new ActionResponse<string>
            {
                WasSuccess = true,
                Result = $"REC-{DateTime.Now:yyyyMM}-{numero:D6}"
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