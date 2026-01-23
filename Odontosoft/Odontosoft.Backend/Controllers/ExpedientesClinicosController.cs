using Microsoft.AspNetCore.Mvc;
using Odontosoft.Backend.UnitsOfWork.Interfaces;
using Odontosoft.Shared.Entities;

namespace Odontosoft.Backend.Controllers;
[ApiController]
[Route("api/[controller]")]
public class ExpedientesClinicosController : GenericController<ExpedienteClinico>
{
    //ExpedientesClinicosController
    public ExpedientesClinicosController(IGenericUnitOfWork<ExpedienteClinico> unitOfWork) : base(unitOfWork)
    {
    }
}