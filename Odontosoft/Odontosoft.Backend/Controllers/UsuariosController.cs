using Microsoft.AspNetCore.Mvc;
using Odontosoft.Backend.Controllers;
using Odontosoft.Backend.Services;
using Odontosoft.Backend.UnitsOfWork.Interfaces;
using Odontosoft.Shared.Entities;

[Route("api/[controller]")]
[ApiController]
public class UsuariosController : GenericController<Usuario>
{
    private readonly ITenantService _tenantService;
    private readonly IGenericUnitOfWork<Usuario> _unitOfWork;

    public UsuariosController(
        IGenericUnitOfWork<Usuario> unitOfWork,
        ITenantService tenantService
    ) : base(unitOfWork, tenantService)
    {
        _tenantService = tenantService;
        _unitOfWork = unitOfWork;
    }
}