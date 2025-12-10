using Odontosoft.Backend.UnitsOfWork.Interfaces;
using Odontosoft.Shared.Entities;

namespace Odontosoft.Backend.Controllers;

public class TratamientosController : GenericController<Tratamiento>
{
    //TratamientosController
    public TratamientosController(IGenericUnitOfWork<Tratamiento> unitOfWork) : base(unitOfWork)
    {
    }
}