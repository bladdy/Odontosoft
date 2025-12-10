using Odontosoft.Backend.UnitsOfWork.Interfaces;
using Odontosoft.Shared.Entities;

namespace Odontosoft.Backend.Controllers;

public class PrescripcionesController : GenericController<Prescripcion>
{
    //PrescripcionesController
    public PrescripcionesController(IGenericUnitOfWork<Prescripcion> unitOfWork) : base(unitOfWork)
    {
    }
}