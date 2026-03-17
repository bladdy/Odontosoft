using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Odontosoft.Backend.Services;
using Odontosoft.Backend.UnitsOfWork.Interfaces;
using Odontosoft.Shared.DTOs.Paciente;
using Odontosoft.Shared.Entities;

namespace Odontosoft.Backend.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PacienteController : GenericController<Paciente>
{
    private readonly ITenantService _tenantService;
    private readonly IGenericUnitOfWork<Paciente> _unitOfWork;
    private readonly IPacienteRepository _pacienteRepository;

    public PacienteController(
        IGenericUnitOfWork<Paciente> unitOfWork,
        ITenantService tenantService,
        IPacienteRepository pacienteRepository
    ) : base(unitOfWork, tenantService)
    {
        _tenantService = tenantService;
        _unitOfWork = unitOfWork;
        _pacienteRepository = pacienteRepository;
    }

    [HttpPost("full")]
    public async Task<IActionResult> AddFullAsync(PacienteCreateDTO paciente)
    {
        var action = await _pacienteRepository.AddFullAsync(paciente);
        if (action.WasSuccess)
            return Ok(action.Result);
        return BadRequest(action.Message);
    }

    [HttpPut("full")]
    public async Task<IActionResult> UpdateFullAsync(PacienteUpdateDTO paciente)
    {
        var action = await _pacienteRepository.UpdateFullAsync(paciente);
        if (action.WasSuccess)
            return Ok(action.Result);
        return BadRequest(action.Message);
    }

    [HttpPut("ActivateToggle")]
    public async Task<IActionResult> InactivateAsync(Guid pacienteId)
    {
        var action = await _pacienteRepository.InactivateAsync(pacienteId);
        if (action.WasSuccess)
            return Ok(action.Result);
        return BadRequest(action.Message);
    }

    [HttpGet("{id}")]
    public override async Task<IActionResult> GetAsync(Guid id)
    {
        var action = await _pacienteRepository.GetPacienteCompletoAsync(id);
        if (action.WasSuccess)
            return Ok(action.Result);
        return BadRequest(action.Message);
    }
}