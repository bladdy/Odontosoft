using Odontosoft.Backend.UnitsOfWork.Interfaces;
using Odontosoft.Shared.Entities;

namespace Odontosoft.Backend.Controllers;

public class ClinicasController : GenericController<Clinica>
{
    //DiagnosticosController
    public ClinicasController(IGenericUnitOfWork<Clinica> unitOfWork) : base(unitOfWork)
    {
    }
}