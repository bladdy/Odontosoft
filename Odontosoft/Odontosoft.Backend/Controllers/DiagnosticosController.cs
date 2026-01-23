using Microsoft.AspNetCore.Mvc;
using Odontosoft.Backend.UnitsOfWork.Interfaces;
using Odontosoft.Shared.Entities;

namespace Odontosoft.Backend.Controllers;
[ApiController]
[Route("api/[controller]")]
public class DiagnosticosController : GenericController<Diagnostico>
{
    //TratamientosController
    public DiagnosticosController(IGenericUnitOfWork<Diagnostico> unitOfWork) : base(unitOfWork)
    {
    }
}