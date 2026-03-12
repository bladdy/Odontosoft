using Microsoft.AspNetCore.Mvc;
using Odontosoft.Backend.Controllers;
using Odontosoft.Backend.Services;
using Odontosoft.Backend.UnitsOfWork.Interfaces;
using Odontosoft.Shared.Entities;

[Route("api/[controller]")]
[ApiController]
public class ProductosController : GenericController<Producto>
{
    private readonly ITenantService _tenantService;
    private readonly IGenericUnitOfWork<Producto> _unitOfWork;

    public ProductosController(
        IGenericUnitOfWork<Producto> unitOfWork,
        ITenantService tenantService
    ) : base(unitOfWork, tenantService)
    {
        _tenantService = tenantService;
        _unitOfWork = unitOfWork;
    }
}