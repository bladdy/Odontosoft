using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Odontosoft.Backend.Services;
using Odontosoft.Backend.UnitsOfWork.Interfaces;
using Odontosoft.Shared.Entities;

namespace Odontosoft.Backend.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PacienteController : GenericController<Paciente>
{
    private readonly ITenantService _tenantService;
    private readonly IGenericUnitOfWork<Paciente> _unitOfWork;

    public PacienteController(
        IGenericUnitOfWork<Paciente> unitOfWork,
        ITenantService tenantService
    ) : base(unitOfWork, tenantService)
    {
        _tenantService = tenantService;
        _unitOfWork = unitOfWork;
    }
}