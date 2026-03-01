using Microsoft.EntityFrameworkCore;
using Odontosoft.Backend.Data;
using Odontosoft.Shared.Entities;
using Odontosoft.Shared.Responses;

namespace Odontosoft.Backend.Repositories.Implementations;

public class SucursalRepository : GenericRepository<Sucursal>, ISucursalRepository
{
    private readonly DataContext _context;

    public SucursalRepository(DataContext context) : base(context)
    {
        _context = context;
    }

    public async Task<ActionResponse<IEnumerable<Sucursal>>> GetSucursalesPorClinicaAsync(int clinicaId)
    {
        try
        {
            var sucursales = await _context.Sucursales
                .Include(s => s.Clinica)
                .Where(s => s.ClinicaId == clinicaId && s.Activo)
                .OrderBy(s => s.Nombre)
                .ToListAsync();

            return new ActionResponse<IEnumerable<Sucursal>>
            {
                WasSuccess = true,
                Result = sucursales
            };
        }
        catch (Exception ex)
        {
            return new ActionResponse<IEnumerable<Sucursal>>
            {
                WasSuccess = false,
                Message = ex.Message
            };
        }
    }

    public async Task<ActionResponse<Sucursal>> GetSucursalConConsultoriosAsync(int sucursalId)
    {
        try
        {
            var sucursal = await _context.Sucursales
                .Include(s => s.Clinica)
                .Include(s => s.Consultorios.Where(c => c.Activo))
                .FirstOrDefaultAsync(s => s.Id == sucursalId);

            if (sucursal == null)
            {
                return new ActionResponse<Sucursal>
                {
                    WasSuccess = false,
                    Message = "Sucursal no encontrada"
                };
            }

            return new ActionResponse<Sucursal>
            {
                WasSuccess = true,
                Result = sucursal
            };
        }
        catch (Exception ex)
        {
            return new ActionResponse<Sucursal>
            {
                WasSuccess = false,
                Message = ex.Message
            };
        }
    }

    public async Task<ActionResponse<Sucursal>> GetByCodigoAsync(int clinicaId, string codigo)
    {
        try
        {
            var sucursal = await _context.Sucursales
                .Include(s => s.Clinica)
                .FirstOrDefaultAsync(s => s.ClinicaId == clinicaId && s.Codigo == codigo);

            if (sucursal == null)
            {
                return new ActionResponse<Sucursal>
                {
                    WasSuccess = false,
                    Message = "Sucursal no encontrada"
                };
            }

            return new ActionResponse<Sucursal>
            {
                WasSuccess = true,
                Result = sucursal
            };
        }
        catch (Exception ex)
        {
            return new ActionResponse<Sucursal>
            {
                WasSuccess = false,
                Message = ex.Message
            };
        }
    }
}