using Microsoft.EntityFrameworkCore;
using Odontosoft.Backend.Data;
using Odontosoft.Shared.Entities;
using Odontosoft.Shared.Responses;

using Odontosoft.Backend.Services;

namespace Odontosoft.Backend.Repositories.Implementations;

public class UsuarioRepository : GenericRepository<Usuario>, IUsuarioRepository
{
    private readonly DataContext _context;

    public UsuarioRepository(
        DataContext context,
        ITenantService tenantService)
        : base(context, tenantService)
    {
        _context = context;
    }

    public async Task<ActionResponse<Usuario>> GetByEmailAsync(string email)
    {
        try
        {
            var usuario = await _context.Usuarios
                .FirstOrDefaultAsync(u => u.Email == email);

            if (usuario == null)
            {
                return new ActionResponse<Usuario>
                {
                    WasSuccess = false,
                    Message = "Usuario no encontrado"
                };
            }

            return new ActionResponse<Usuario>
            {
                WasSuccess = true,
                Result = usuario
            };
        }
        catch (Exception ex)
        {
            return new ActionResponse<Usuario>
            {
                WasSuccess = false,
                Message = ex.Message
            };
        }
    }

    public async Task<ActionResponse<Usuario>> GetByNombreUsuarioAsync(string nombreUsuario)
    {
        try
        {
            var usuario = await _context.Usuarios
                .FirstOrDefaultAsync(u => u.NombreUsuario == nombreUsuario);

            if (usuario == null)
            {
                return new ActionResponse<Usuario>
                {
                    WasSuccess = false,
                    Message = "Usuario no encontrado"
                };
            }

            return new ActionResponse<Usuario>
            {
                WasSuccess = true,
                Result = usuario
            };
        }
        catch (Exception ex)
        {
            return new ActionResponse<Usuario>
            {
                WasSuccess = false,
                Message = ex.Message
            };
        }
    }

    public async Task<ActionResponse<Usuario>> GetUsuarioConSucursalesAsync(Guid usuarioId)
    {
        try
        {
            var usuario = await _context.Usuarios
                .Include(u => u.UsuarioSucursales)
                    .ThenInclude(us => us.Sucursal)
                        .ThenInclude(s => s.Clinica)
                .FirstOrDefaultAsync(u => u.Id == usuarioId);

            if (usuario == null)
            {
                return new ActionResponse<Usuario>
                {
                    WasSuccess = false,
                    Message = "Usuario no encontrado"
                };
            }

            return new ActionResponse<Usuario>
            {
                WasSuccess = true,
                Result = usuario
            };
        }
        catch (Exception ex)
        {
            return new ActionResponse<Usuario>
            {
                WasSuccess = false,
                Message = ex.Message
            };
        }
    }

    public async Task<ActionResponse<Usuario>> GetUsuarioConPermisosAsync(Guid usuarioId, Guid sucursalId)
    {
        try
        {
            var usuario = await _context.Usuarios
                .Include(u => u.UsuarioSucursales.Where(us => us.SucursalId == sucursalId))
                    .ThenInclude(us => us.PermisosModulo)
                        .ThenInclude(pm => pm.Modulo)
                .FirstOrDefaultAsync(u => u.Id == usuarioId);

            if (usuario == null)
            {
                return new ActionResponse<Usuario>
                {
                    WasSuccess = false,
                    Message = "Usuario no encontrado"
                };
            }

            return new ActionResponse<Usuario>
            {
                WasSuccess = true,
                Result = usuario
            };
        }
        catch (Exception ex)
        {
            return new ActionResponse<Usuario>
            {
                WasSuccess = false,
                Message = ex.Message
            };
        }
    }

    public async Task<ActionResponse<bool>> ValidarCredencialesAsync(string email, string passwordHash)
    {
        try
        {
            var usuario = await _context.Usuarios
                .FirstOrDefaultAsync(u => u.Email == email && u.PasswordHash == passwordHash && u.Activo);

            if (usuario == null)
            {
                return new ActionResponse<bool>
                {
                    WasSuccess = false,
                    Message = "Credenciales inválidas"
                };
            }

            return new ActionResponse<bool>
            {
                WasSuccess = true,
                Result = true
            };
        }
        catch (Exception ex)
        {
            return new ActionResponse<bool>
            {
                WasSuccess = false,
                Message = ex.Message
            };
        }
    }
}