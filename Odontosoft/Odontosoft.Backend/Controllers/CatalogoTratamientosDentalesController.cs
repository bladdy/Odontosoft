using Microsoft.AspNetCore.Mvc;
using Odontosoft.Backend.Controllers;
using Odontosoft.Backend.Services;
using Odontosoft.Backend.UnitsOfWork.Interfaces;
using Odontosoft.Shared.Entities;

[Route("api/[controller]")]
[ApiController]
public class CatalogoTratamientosDentalesController : GenericController<CatalogoTratamientoDental>
{
    private readonly ITenantService _tenantService;
    private readonly IGenericUnitOfWork<CatalogoTratamientoDental> _unitOfWork;

    public CatalogoTratamientosDentalesController(
        IGenericUnitOfWork<CatalogoTratamientoDental> unitOfWork,
        ITenantService tenantService
    ) : base(unitOfWork, tenantService)
    {
        _tenantService = tenantService;
        _unitOfWork = unitOfWork;
    }
}