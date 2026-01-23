using Microsoft.AspNetCore.Mvc;
using Odontosoft.Backend.UnitsOfWork.Interfaces;
using Odontosoft.Shared.Entities;

namespace Odontosoft.Backend.Controllers;
[ApiController]
[Route("api/[controller]")]
public class EvolucionesController : GenericController<Evolucion>
{
    //EvolucionesController
    public EvolucionesController(IGenericUnitOfWork<Evolucion> unitOfWork) : base(unitOfWork)
    {
    }
}