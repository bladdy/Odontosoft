using Odontosoft.Backend.UnitsOfWork.Interfaces;
using Odontosoft.Shared.Entities;

namespace Odontosoft.Backend.Controllers;

public class EvolucionesController : GenericController<Evolucion>
{
    //EvolucionesController
    public EvolucionesController(IGenericUnitOfWork<Evolucion> unitOfWork) : base(unitOfWork)
    {
    }
}