using Odontosoft.Shared.Entities;
using Odontosoft.Shared.Responses;

using Odontosoft.Backend.Repositories.Interfaces;

public interface IUsuarioRepository : IGenericRepository<Usuario>
{
    Task<ActionResponse<Usuario>> GetByEmailAsync(string email);

    Task<ActionResponse<Usuario>> GetByNombreUsuarioAsync(string nombreUsuario);

    Task<ActionResponse<Usuario>> GetUsuarioConSucursalesAsync(Guid usuarioId);

    Task<ActionResponse<Usuario>> GetUsuarioConPermisosAsync(Guid usuarioId, Guid sucursalId);

    Task<ActionResponse<bool>> ValidarCredencialesAsync(string email, string passwordHash);
}