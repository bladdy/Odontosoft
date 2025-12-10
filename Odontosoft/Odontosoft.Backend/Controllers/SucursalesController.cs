using Odontosoft.Backend.UnitsOfWork.Interfaces;
using Odontosoft.Shared.Entities;

namespace Odontosoft.Backend.Controllers;

public class SucursalesController : GenericController<Sucursal>
{
    //SucursalesController
    public SucursalesController(IGenericUnitOfWork<Sucursal> unitOfWork) : base(unitOfWork)
    {
    }
}