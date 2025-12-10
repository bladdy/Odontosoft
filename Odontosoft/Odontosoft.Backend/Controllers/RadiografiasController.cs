using Odontosoft.Backend.UnitsOfWork.Interfaces;
using Odontosoft.Shared.Entities;

namespace Odontosoft.Backend.Controllers;

public class RadiografiasController : GenericController<Radiografia>
{
    //RadiografiasController
    public RadiografiasController(IGenericUnitOfWork<Radiografia> unitOfWork) : base(unitOfWork)
    {
    }
}