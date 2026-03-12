using Microsoft.AspNetCore.Mvc;
using Odontosoft.Backend.Controllers;
using Odontosoft.Backend.Repositories.Implementations;
using Odontosoft.Backend.Services;
using Odontosoft.Backend.UnitsOfWork.Interfaces;
using Odontosoft.Shared.Entities;

[Route("api/[controller]")]
[ApiController]
public class SucursalesController : GenericController<Sucursal>
{
    private readonly ITenantService _tenantService;
    private readonly IGenericUnitOfWork<Sucursal> _unitOfWork;

    public SucursalesController(
        IGenericUnitOfWork<Sucursal> unitOfWork,
        ITenantService tenantService
    ) : base(unitOfWork, tenantService)
    {
        _tenantService = tenantService;
        _unitOfWork = unitOfWork;
    }
}