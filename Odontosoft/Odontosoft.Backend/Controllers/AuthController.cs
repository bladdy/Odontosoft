using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Odontosoft.Backend.Data;
using Odontosoft.Backend.Services;
using Odontosoft.Shared.DTOs;

namespace Odontosoft.Backend.Controllers;

[ApiController]
[Route("api/auth")]
public class AuthController : ControllerBase
{
    private readonly DataContext _context;
    private readonly JwtService _jwtService;
    private readonly ITenantService _tenantService;

    public AuthController(
        DataContext context,
        JwtService jwtService,
        ITenantService tenantService)
    {
        _context = context;
        _jwtService = jwtService;
        _tenantService = tenantService;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginDTO dto)
    {
        var user = await _context.Usuarios
            .FirstOrDefaultAsync(u => u.Email == dto.Email);

        if (user == null)
            return Unauthorized("Usuario no existe");

        if (!BCrypt.Net.BCrypt.Verify(dto.Password, user.PasswordHash))
            return Unauthorized("Password incorrecto");

        var token = _jwtService.GenerateToken(user);

        return Ok(new { token });
    }
}