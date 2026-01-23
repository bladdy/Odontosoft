using Microsoft.AspNetCore.Mvc;
using Odontosoft.Backend.UnitsOfWork.Interfaces;
using Odontosoft.Shared.Entities;

namespace Odontosoft.Backend.Controllers;
[ApiController]
[Route("api/[controller]")]
public class RadiografiasController : GenericController<Radiografia>
{
    //RadiografiasController
    public RadiografiasController(IGenericUnitOfWork<Radiografia> unitOfWork) : base(unitOfWork)
    {
    }
}