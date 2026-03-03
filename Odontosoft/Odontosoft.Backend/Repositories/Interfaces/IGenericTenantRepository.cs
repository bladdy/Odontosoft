using Odontosoft.Shared.DTOs;
using Odontosoft.Shared.Interfaces;
using Odontosoft.Shared.Responses;

namespace Odontosoft.Backend.Repositories.Interfaces;

public interface IGenericTenantRepository<T> where T : class, ITenantEntity
{
    Task<ActionResponse<IEnumerable<T>>> GetAsync(PaginationDTO pagination);

    Task<ActionResponse<int>> GetTotalRecordsAsync(PaginationDTO pagination);

    Task<ActionResponse<T>> GetAsync(Guid id);

    Task<ActionResponse<IEnumerable<T>>> GetAsync();

    Task<ActionResponse<T>> AddAsync(T entity);

    Task<ActionResponse<T>> DeleteAsync(Guid id);

    Task<ActionResponse<T>> UpdateAsync(T entity);
}