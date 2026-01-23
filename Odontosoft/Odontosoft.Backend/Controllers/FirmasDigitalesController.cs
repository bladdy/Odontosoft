using Microsoft.AspNetCore.Mvc;
using Odontosoft.Backend.UnitsOfWork.Interfaces;
using Odontosoft.Shared.Entities;

namespace Odontosoft.Backend.Controllers;
[ApiController]
[Route("api/[controller]")]
public class FirmasDigitalesController : GenericController<FirmaDigital>
{
    //FirmasDigitalesController
    public FirmasDigitalesController(IGenericUnitOfWork<FirmaDigital> unitOfWork) : base(unitOfWork)
    {
    }
}