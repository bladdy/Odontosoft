using Microsoft.AspNetCore.Mvc;
using Odontosoft.Backend.Controllers;
using Odontosoft.Backend.Repositories.Implementations;
using Odontosoft.Backend.Services;
using Odontosoft.Backend.UnitsOfWork.Interfaces;
using Odontosoft.Shared.Entities;

[Route("api/[controller]")]
[ApiController]
public class MedicosController : GenericController<Medico>
{
    private readonly ITenantService _tenantService;
    private readonly IGenericUnitOfWork<Medico> _unitOfWork;

    public MedicosController(
        IGenericUnitOfWork<Medico> unitOfWork,
        ITenantService tenantService
    ) : base(unitOfWork, tenantService)
    {
        _tenantService = tenantService;
        _unitOfWork = unitOfWork;
    }
}