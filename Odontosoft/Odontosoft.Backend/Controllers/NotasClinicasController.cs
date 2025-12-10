using Odontosoft.Backend.UnitsOfWork.Interfaces;
using Odontosoft.Shared.Entities;

namespace Odontosoft.Backend.Controllers;

public class NotasClinicasController : GenericController<NotaClinica>
{
    //NotasClinicasController
    public NotasClinicasController(IGenericUnitOfWork<NotaClinica> unitOfWork) : base(unitOfWork)
    {
    }
}