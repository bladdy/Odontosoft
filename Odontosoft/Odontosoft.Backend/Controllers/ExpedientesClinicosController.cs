using Odontosoft.Backend.UnitsOfWork.Interfaces;
using Odontosoft.Shared.Entities;

namespace Odontosoft.Backend.Controllers;

public class ExpedientesClinicosController : GenericController<ExpedienteClinico>
{
    //ExpedientesClinicosController
    public ExpedientesClinicosController(IGenericUnitOfWork<ExpedienteClinico> unitOfWork) : base(unitOfWork)
    {
    }
}