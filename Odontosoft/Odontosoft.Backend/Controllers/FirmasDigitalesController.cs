using Odontosoft.Backend.UnitsOfWork.Interfaces;
using Odontosoft.Shared.Entities;

namespace Odontosoft.Backend.Controllers;

public class FirmasDigitalesController : GenericController<FirmaDigital>
{
    //FirmasDigitalesController
    public FirmasDigitalesController(IGenericUnitOfWork<FirmaDigital> unitOfWork) : base(unitOfWork)
    {
    }
}