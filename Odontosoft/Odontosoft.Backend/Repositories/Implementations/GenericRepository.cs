using Microsoft.EntityFrameworkCore;
using Odontosoft.Backend.Data;
using Odontosoft.Backend.Repositories.Interfaces;
using Odontosoft.Shared.DTOs;
using Odontosoft.Shared.Helpers;
using Odontosoft.Shared.Interfaces;
using Odontosoft.Shared.Responses;

namespace Odontosoft.Backend.Repositories.Implementations;

public class GenericRepository<T> : IGenericRepository<T>
    where T : class, ITenantEntity
{
    private readonly DataContext _context;
    private readonly DbSet<T> _entity;

    public GenericRepository(DataContext context)
    {
        _context = context;
        _entity = context.Set<T>();
    }

    public virtual async Task<ActionResponse<IEnumerable<T>>> GetAsync(PaginationDTO pagination)
    {
        var queryable = _entity.AsQueryable();

        return new ActionResponse<IEnumerable<T>>
        {
            WasSuccess = true,
            Result = await queryable
                .Paginate(pagination)
                .ToListAsync()
        };
    }

    public virtual async Task<ActionResponse<int>> GetTotalRecordsAsync(PaginationDTO pagination)
    {
        return new ActionResponse<int>
        {
            WasSuccess = true,
            Result = await _entity.CountAsync()
        };
    }

    public virtual async Task<ActionResponse<T>> GetAsync(Guid id)
    {
        var row = await _entity
            .FirstOrDefaultAsync(x => x.Id == id);

        if (row == null)
            return new ActionResponse<T> { Message = "Registro no encontrado" };

        return new ActionResponse<T>
        {
            WasSuccess = true,
            Result = row
        };
    }

    public virtual async Task<ActionResponse<IEnumerable<T>>> GetAsync()
    {
        return new ActionResponse<IEnumerable<T>>
        {
            WasSuccess = true,
            Result = await _entity.ToListAsync()
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
        var current = await _entity
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == entity.Id);

        if (current == null)
            return new ActionResponse<T> { Message = "Registro no encontrado" };

        entity.TenantId = current.TenantId;

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
        var row = await _entity
            .FirstOrDefaultAsync(x => x.Id == id);

        if (row == null)
            return new ActionResponse<T> { Message = "Registro no encontrado" };

        _entity.Remove(row);
        await _context.SaveChangesAsync();

        return new ActionResponse<T>
        {
            WasSuccess = true
        };
    }
}