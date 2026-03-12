using Microsoft.AspNetCore.Mvc;
using Odontosoft.Backend.Controllers;
using Odontosoft.Backend.Repositories.Implementations;
using Odontosoft.Backend.Services;
using Odontosoft.Backend.UnitsOfWork.Interfaces;
using Odontosoft.Shared.Entities;

[Route("api/[controller]")]
[ApiController]
public class CitasController : GenericController<Cita>
{
    private readonly ITenantService _tenantService;
    private readonly IGenericUnitOfWork<Cita> _unitOfWork;

    public CitasController(
        IGenericUnitOfWork<Cita> unitOfWork,
        ITenantService tenantService
    ) : base(unitOfWork, tenantService)
    {
        _tenantService = tenantService;
        _unitOfWork = unitOfWork;
    }
}