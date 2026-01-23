using Microsoft.AspNetCore.Mvc;
using Odontosoft.Backend.UnitsOfWork.Interfaces;
using Odontosoft.Shared.Entities;

namespace Odontosoft.Backend.Controllers;
[ApiController]
[Route("api/[controller]")]
public class SucursalesController : GenericController<Sucursal>
{
    //SucursalesController
    public SucursalesController(IGenericUnitOfWork<Sucursal> unitOfWork) : base(unitOfWork)
    {
    }
}