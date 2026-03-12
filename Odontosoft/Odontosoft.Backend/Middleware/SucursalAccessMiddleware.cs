using Microsoft.EntityFrameworkCore;
using Odontosoft.Backend.Data;
using System.Security.Claims;

public class SucursalAccessMiddleware
{
    private readonly RequestDelegate _next;

    public SucursalAccessMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context, DataContext dbContext)
    {
        // Solo validar si el usuario está autenticado
        if (context.User.Identity?.IsAuthenticated == true)
        {
            var userIdClaim = context.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (string.IsNullOrEmpty(userIdClaim))
            {
                context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                return;
            }

            // Leer sucursal del header
            if (!context.Request.Headers.TryGetValue("X-Sucursal-Id", out var sucursalHeader))
            {
                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                await context.Response.WriteAsync("Debe enviar el header X-Sucursal-Id.");
                return;
            }

            if (!Guid.TryParse(sucursalHeader, out Guid sucursalId))
            {
                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                await context.Response.WriteAsync("SucursalId inválido.");
                return;
            }

            var userId = Guid.Parse(userIdClaim);

            // Obtener TenantId del usuario
            var usuario = await dbContext.Usuarios
                .Where(u => u.Id == userId)
                .Select(u => new { u.TenantId })
                .FirstOrDefaultAsync();

            if (usuario == null)
            {
                context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                return;
            }

            var tieneAcceso = await dbContext.UsuarioSucursales
                .Include(x => x.Sucursal)
                .AnyAsync(x =>
                    x.UsuarioId == userId &&
                    x.SucursalId == sucursalId &&
                    x.Sucursal.TenantId == usuario.TenantId // seguridad extra
                );

            if (!tieneAcceso)
            {
                context.Response.StatusCode = StatusCodes.Status403Forbidden;
                await context.Response.WriteAsync("No tiene acceso a esta sucursal.");
                return;
            }

            // Guardar sucursal activa para usarla después
            context.Items["SucursalId"] = sucursalId;
        }

        await _next(context);
    }
}