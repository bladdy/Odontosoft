using Microsoft.EntityFrameworkCore;
using Odontosoft.Backend.Data;
using Odontosoft.Backend.Repositories.Interfaces;
using Odontosoft.Backend.Services;
using Odontosoft.Shared.DTOs;
using Odontosoft.Shared.Helpers;
using Odontosoft.Shared.Interfaces;
using Odontosoft.Shared.Responses;

namespace Odontosoft.Backend.Repositories.Implementations;

public class GenericTenantRepository<T> : IGenericTenantRepository<T>
    where T : class, ITenantEntity
{
    private readonly DataContext _context;
    private readonly ITenantService _tenantService;
    private readonly DbSet<T> _entity;

    public GenericTenantRepository(
        DataContext context,
        ITenantService tenantService)
    {
        _context = context;
        _tenantService = tenantService;
        _entity = context.Set<T>();
    }

    private Guid TenantId => _tenantService.TenantId;

    public async Task<ActionResponse<IEnumerable<T>>> GetAsync(PaginationDTO pagination)
    {
        var query = _entity
            .Where(x => x.TenantId == TenantId);

        return new ActionResponse<IEnumerable<T>>
        {
            WasSuccess = true,
            Result = await query
                .Paginate(pagination)
                .ToListAsync()
        };
    }

    public async Task<ActionResponse<int>> GetTotalRecordsAsync(PaginationDTO pagination)
    {
        var total = await _entity
            .Where(x => x.TenantId == TenantId)
            .CountAsync();

        return new ActionResponse<int>
        {
            WasSuccess = true,
            Result = total
        };
    }

    public async Task<ActionResponse<T>> GetAsync(Guid id)
    {
        var row = await _entity
            .FirstOrDefaultAsync(x =>
                x.Id == id &&
                x.TenantId == TenantId);

        if (row == null)
            return new ActionResponse<T>
            {
                Message = "Registro no encontrado"
            };

        return new ActionResponse<T>
        {
            WasSuccess = true,
            Result = row
        };
    }

    public async Task<ActionResponse<IEnumerable<T>>> GetAsync()
    {
        var data = await _entity
            .Where(x => x.TenantId == TenantId)
            .ToListAsync();

        return new ActionResponse<IEnumerable<T>>
        {
            WasSuccess = true,
            Result = data
        };
    }

    public async Task<ActionResponse<T>> AddAsync(T entity)
    {
        entity.TenantId = TenantId;

        _entity.Add(entity);
        await _context.SaveChangesAsync();

        return new ActionResponse<T>
        {
            WasSuccess = true,
            Result = entity
        };
    }

    public async Task<ActionResponse<T>> UpdateAsync(T entity)
    {
        var current = await _entity
            .AsNoTracking()
            .FirstOrDefaultAsync(x =>
                x.Id == entity.Id &&
                x.TenantId == TenantId);

        if (current == null)
            return new ActionResponse<T>
            {
                Message = "Registro no encontrado"
            };

        entity.TenantId = current.TenantId; // Protege TenantId

        _entity.Update(entity);
        await _context.SaveChangesAsync();

        return new ActionResponse<T>
        {
            WasSuccess = true,
            Result = entity
        };
    }

    public async Task<ActionResponse<T>> DeleteAsync(Guid id)
    {
        var row = await _entity
            .FirstOrDefaultAsync(x =>
                x.Id == id &&
                x.TenantId == TenantId);

        if (row == null)
            return new ActionResponse<T>
            {
                Message = "Registro no encontrado"
            };

        _entity.Remove(row);
        await _context.SaveChangesAsync();

        return new ActionResponse<T>
        {
            WasSuccess = true
        };
    }
}