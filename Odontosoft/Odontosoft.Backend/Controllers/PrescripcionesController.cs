using Microsoft.AspNetCore.Mvc;
using Odontosoft.Backend.UnitsOfWork.Interfaces;
using Odontosoft.Shared.Entities;

namespace Odontosoft.Backend.Controllers;
[ApiController]
[Route("api/[controller]")]
public class PrescripcionesController : GenericController<Prescripcion>
{
    //PrescripcionesController
    public PrescripcionesController(IGenericUnitOfWork<Prescripcion> unitOfWork) : base(unitOfWork)
    {
    }
}