using Microsoft.EntityFrameworkCore;
using Odontosoft.Backend.Data;
using Odontosoft.Backend.Repositories.Interfaces;
using Odontosoft.Backend.Services;
using Odontosoft.Shared.DTOs;
using Odontosoft.Shared.Responses;

namespace Odontosoft.Backend.Repositories.Implementations;

public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    protected readonly DataContext _context;
    protected readonly DbSet<T> _entity;
    protected readonly ITenantService _tenantService;

    public GenericRepository(DataContext context, ITenantService tenantService)
    {
        _context = context;
        _entity = context.Set<T>();
        _tenantService = tenantService;
    }

    public virtual async Task<ActionResponse<IEnumerable<T>>> GetAsync()
    {
        var list = await _entity.ToListAsync();

        return new ActionResponse<IEnumerable<T>>
        {
            WasSuccess = true,
            Result = list
        };
    }

    public virtual async Task<ActionResponse<IEnumerable<T>>> GetAsync(PaginationDTO pagination)
    {
        var query = _entity.AsQueryable();

        var list = await query
            .Skip((pagination.Page - 1) * pagination.RecordsNumber)
            .Take(pagination.RecordsNumber)
            .ToListAsync();

        return new ActionResponse<IEnumerable<T>>
        {
            WasSuccess = true,
            Result = list
        };
    }

    public virtual async Task<ActionResponse<int>> GetTotalRecordsAsync(PaginationDTO pagination)
    {
        var query = _entity.AsQueryable();
        double totalRecords = await query.CountAsync();

        var total = (int)Math.Ceiling(totalRecords / pagination.RecordsNumber);

        return new ActionResponse<int>
        {
            WasSuccess = true,
            Result = total
        };
    }

    public virtual async Task<ActionResponse<T>> GetAsync(Guid id)
    {
        var entity = await _entity.FindAsync(id);

        if (entity == null)
        {
            return new ActionResponse<T>
            {
                WasSuccess = false,
                Message = "Registro no encontrado"
            };
        }

        return new ActionResponse<T>
        {
            WasSuccess = true,
            Result = entity
        };
    }

    public virtual async Task<ActionResponse<T>> AddAsync(T entity)
    {
        _entity.Add(entity);
        await _context.SaveChangesAsync();

        return new ActionResponse<T>
        {
            WasSuccess = true,
            Result = entity
        };
    }

    public virtual async Task<ActionResponse<T>> UpdateAsync(T entity)
    {
        _entity.Update(entity);
        await _context.SaveChangesAsync();

        return new ActionResponse<T>
        {
            WasSuccess = true,
            Result = entity
        };
    }

    public virtual async Task<ActionResponse<T>> DeleteAsync(Guid id)
    {
        var entity = await _entity.FindAsync(id);

        if (entity == null)
        {
            return new ActionResponse<T>
            {
                WasSuccess = false,
                Message = "Registro no encontrado"
            };
        }

        _entity.Remove(entity);
        await _context.SaveChangesAsync();

        return new ActionResponse<T>
        {
            WasSuccess = true,
            Result = entity
        };
    }

    public virtual IQueryable<T> GetQueryable()
    {
        return _entity.AsQueryable();
    }
}