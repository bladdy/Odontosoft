using Microsoft.AspNetCore.Mvc;
using Odontosoft.Backend.UnitsOfWork.Interfaces;
using Odontosoft.Shared.Entities;

namespace Odontosoft.Backend.Controllers;
[ApiController]
[Route("api/[controller]")]
public class TratamientosController : GenericController<Tratamiento>
{
    //TratamientosController
    public TratamientosController(IGenericUnitOfWork<Tratamiento> unitOfWork) : base(unitOfWork)
    {
    }
}