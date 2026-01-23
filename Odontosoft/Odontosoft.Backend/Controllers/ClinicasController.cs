using Microsoft.AspNetCore.Mvc;
using Odontosoft.Backend.UnitsOfWork.Interfaces;
using Odontosoft.Shared.Entities;

namespace Odontosoft.Backend.Controllers;
[ApiController]
[Route("api/[controller]")]
public class ClinicasController : GenericController<Clinica>
{
    //DiagnosticosController
    public ClinicasController(IGenericUnitOfWork<Clinica> unitOfWork) : base(unitOfWork)
    {
    }
}