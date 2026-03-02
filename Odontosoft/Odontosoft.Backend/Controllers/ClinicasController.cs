using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Odontosoft.Backend.Services;
using Odontosoft.Backend.UnitsOfWork.Interfaces;
using Odontosoft.Shared.Entities;

namespace Odontosoft.Backend.Controllers;

[ApiController]
[Route("api/clinicas")]
[Authorize]
public class ClinicasController : GenericController<Clinica>
{
    private readonly ITenantService _tenantService;
    private readonly IGenericUnitOfWork<Clinica> _unitOfWork;

    public ClinicasController(
        IGenericUnitOfWork<Clinica> unitOfWork,
        ITenantService tenantService)
        : base(unitOfWork, tenantService)
    {
        _unitOfWork = unitOfWork;
        _tenantService = tenantService;
    }
}