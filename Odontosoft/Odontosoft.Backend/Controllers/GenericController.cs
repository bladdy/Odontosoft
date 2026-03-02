using Microsoft.AspNetCore.Mvc;
using Odontosoft.Backend.Services;
using Odontosoft.Backend.UnitsOfWork.Interfaces;
using Odontosoft.Shared.DTOs;
using Odontosoft.Shared.Interfaces;

namespace Odontosoft.Backend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class GenericController<T> : Controller where T : class, ITenantEntity
{
    private readonly IGenericUnitOfWork<T> _unitOfWork;
    private readonly ITenantService _tenantService;

    public GenericController(
        IGenericUnitOfWork<T> unitOfWork,
        ITenantService tenantService)
    {
        _unitOfWork = unitOfWork;
        _tenantService = tenantService;
    }

    // ============================
    // VALIDACIÓN TENANT
    // ============================

    private Guid GetTenantIdOrThrow()
    {
        if (_tenantService.TenantId == Guid.Empty)
            throw new Exception("TenantId no resuelto en la petición.");

        return _tenantService.TenantId;
    }

    // ============================
    // GET PAGINADO
    // ============================

    [HttpGet("paginated")]
    public virtual async Task<IActionResult> GetAsync([FromQuery] PaginationDTO pagination)
    {
        GetTenantIdOrThrow();

        var action = await _unitOfWork.GetAsync(pagination);

        if (action.WasSuccess)
            return Ok(action.Result);

        return BadRequest(action.Message);
    }

    // ============================
    // TOTAL RECORDS
    // ============================

    [HttpGet("totalRecords")]
    public virtual async Task<IActionResult> GetTotalRecordsAsync([FromQuery] PaginationDTO pagination)
    {
        GetTenantIdOrThrow();

        var action = await _unitOfWork.GetTotalRecordsAsync(pagination);

        if (action.WasSuccess)
            return Ok(action.Result);

        return BadRequest(action.Message);
    }

    // ============================
    // GET ALL
    // ============================

    [HttpGet]
    public virtual async Task<IActionResult> GetAsync()
    {
        GetTenantIdOrThrow();

        var action = await _unitOfWork.GetAsync();

        if (action.WasSuccess)
            return Ok(action.Result);

        return BadRequest(action.Message);
    }

    // ============================
    // GET BY ID (PROTEGIDO)
    // ============================

    [HttpGet("{id}")]
    public virtual async Task<IActionResult> GetAsync(Guid id)
    {
        var tenantId = GetTenantIdOrThrow();

        var action = await _unitOfWork.GetAsync(id);

        if (!action.WasSuccess || action.Result == null)
            return NotFound();

        // 🔐 Validar que pertenezca al tenant actual
        if (action.Result.TenantId != tenantId)
            return Forbid();

        return Ok(action.Result);
    }

    // ============================
    // POST (ASIGNA TENANT)
    // ============================

    [HttpPost]
    public virtual async Task<IActionResult> PostAsync(T model)
    {
        var tenantId = GetTenantIdOrThrow();

        // 🔐 Forzar TenantId
        model.TenantId = tenantId;

        var action = await _unitOfWork.AddAsync(model);

        if (action.WasSuccess)
            return Ok(action.Result);

        return BadRequest(action.Message);
    }

    // ============================
    // PUT (PROTEGIDO)
    // ============================

    [HttpPut]
    public virtual async Task<IActionResult> PutAsync(T model)
    {
        var tenantId = GetTenantIdOrThrow();

        // 🔐 Forzar TenantId siempre
        model.TenantId = tenantId;

        var action = await _unitOfWork.UpdateAsync(model);

        if (action.WasSuccess)
            return Ok(action.Result);

        return BadRequest(action.Message);
    }

    // ============================
    // DELETE (PROTEGIDO)
    // ============================

    [HttpDelete("{id}")]
    public virtual async Task<IActionResult> DeleteAsync(Guid id)
    {
        var tenantId = GetTenantIdOrThrow();

        var action = await _unitOfWork.GetAsync(id);

        if (!action.WasSuccess || action.Result == null)
            return NotFound();

        // 🔐 Validar tenant antes de borrar
        if (action.Result.TenantId != tenantId)
            return Forbid();

        var deleteAction = await _unitOfWork.DeleteAsync(id);

        if (deleteAction.WasSuccess)
            return NoContent();

        return BadRequest(deleteAction.Message);
    }
}