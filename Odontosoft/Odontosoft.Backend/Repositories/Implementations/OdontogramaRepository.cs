using Microsoft.EntityFrameworkCore;
using Odontosoft.Backend.Data;
using Odontosoft.Backend.Repositories.Interfaces;
using Odontosoft.Shared.Entities;
using Odontosoft.Shared.Responses;

namespace Odontosoft.Backend.Repositories.Implementations;

public class OdontogramaRepository : GenericRepository<Odontograma>, IOdontogramaRepository
{
    private readonly DataContext _context;

    public OdontogramaRepository(DataContext context) : base(context)
    {
        _context = context;
    }

    public async Task<ActionResponse<Odontograma>> GetOdontogramaActualAsync(int pacienteId)
    {
        try
        {
            var odontograma = await _context.Odontogramas
                .Include(o => o.DientesEstado)
                .Where(o => o.PacienteId == pacienteId && o.EsActivo)
                .OrderByDescending(o => o.FechaCreacion)
                .FirstOrDefaultAsync();

            if (odontograma == null)
            {
                return new ActionResponse<Odontograma>
                {
                    WasSuccess = false,
                    Message = "No hay odontograma activo para este paciente"
                };
            }

            return new ActionResponse<Odontograma>
            {
                WasSuccess = true,
                Result = odontograma
            };
        }
        catch (Exception ex)
        {
            return new ActionResponse<Odontograma>
            {
                WasSuccess = false,
                Message = ex.Message
            };
        }
    }

    public async Task<ActionResponse<Odontograma>> GetOdontogramaCompletoAsync(int odontogramaId)
    {
        try
        {
            var odontograma = await _context.Odontogramas
                .Include(o => o.DientesEstado)
                    .ThenInclude(d => d.Tratamientos)
                .Include(o => o.Paciente)
                .Include(o => o.Medico)
                    .ThenInclude(m => m.Usuario)
                .FirstOrDefaultAsync(o => o.Id == odontogramaId);

            if (odontograma == null)
            {
                return new ActionResponse<Odontograma>
                {
                    WasSuccess = false,
                    Message = "Odontograma no encontrado"
                };
            }

            return new ActionResponse<Odontograma>
            {
                WasSuccess = true,
                Result = odontograma
            };
        }
        catch (Exception ex)
        {
            return new ActionResponse<Odontograma>
            {
                WasSuccess = false,
                Message = ex.Message
            };
        }
    }

    public async Task<ActionResponse<IEnumerable<Odontograma>>> GetHistorialAsync(int pacienteId)
    {
        try
        {
            var odontogramas = await _context.Odontogramas
                .Include(o => o.Medico)
                    .ThenInclude(m => m.Usuario)
                .Where(o => o.PacienteId == pacienteId)
                .OrderByDescending(o => o.FechaCreacion)
                .ToListAsync();

            return new ActionResponse<IEnumerable<Odontograma>>
            {
                WasSuccess = true,
                Result = odontogramas
            };
        }
        catch (Exception ex)
        {
            return new ActionResponse<IEnumerable<Odontograma>>
            {
                WasSuccess = false,
                Message = ex.Message
            };
        }
    }

    public async Task<ActionResponse<Odontograma>> CrearOdontogramaInicialAsync(int pacienteId, int medicoId, string tipo)
    {
        try
        {
            var odontograma = new Odontograma
            {
                PacienteId = pacienteId,
                MedicoId = medicoId,
                TipoOdontograma = tipo,
                FechaCreacion = DateTime.UtcNow,
                EsActivo = true,
                DientesEstado = new List<DienteEstado>()
            };

            // Crear dientes según el tipo
            if (tipo == "Permanente")
            {
                // Dientes superiores
                for (int i = 11; i <= 18; i++)
                    odontograma.DientesEstado.Add(new DienteEstado { NumeroDiente = i.ToString(), Estado = "Sano" });
                for (int i = 21; i <= 28; i++)
                    odontograma.DientesEstado.Add(new DienteEstado { NumeroDiente = i.ToString(), Estado = "Sano" });

                // Dientes inferiores
                for (int i = 31; i <= 38; i++)
                    odontograma.DientesEstado.Add(new DienteEstado { NumeroDiente = i.ToString(), Estado = "Sano" });
                for (int i = 41; i <= 48; i++)
                    odontograma.DientesEstado.Add(new DienteEstado { NumeroDiente = i.ToString(), Estado = "Sano" });
            }
            else if (tipo == "Temporal")
            {
                // Dientes temporales (de 51 a 85)
                for (int i = 51; i <= 55; i++)
                    odontograma.DientesEstado.Add(new DienteEstado { NumeroDiente = i.ToString(), Estado = "Sano" });
                for (int i = 61; i <= 65; i++)
                    odontograma.DientesEstado.Add(new DienteEstado { NumeroDiente = i.ToString(), Estado = "Sano" });
                for (int i = 71; i <= 75; i++)
                    odontograma.DientesEstado.Add(new DienteEstado { NumeroDiente = i.ToString(), Estado = "Sano" });
                for (int i = 81; i <= 85; i++)
                    odontograma.DientesEstado.Add(new DienteEstado { NumeroDiente = i.ToString(), Estado = "Sano" });
            }

            await _context.Odontogramas.AddAsync(odontograma);
            await _context.SaveChangesAsync();

            return new ActionResponse<Odontograma>
            {
                WasSuccess = true,
                Result = odontograma
            };
        }
        catch (Exception ex)
        {
            return new ActionResponse<Odontograma>
            {
                WasSuccess = false,
                Message = ex.Message
            };
        }
    }
}