using Microsoft.AspNetCore.Mvc;
using Odontosoft.Backend.UnitsOfWork.Interfaces;
using Odontosoft.Shared.Entities;

namespace Odontosoft.Backend.Controllers;
[ApiController]
[Route("api/[controller]")]
public class NotasClinicasController : GenericController<NotaClinica>
{
    //NotasClinicasController
    public NotasClinicasController(IGenericUnitOfWork<NotaClinica> unitOfWork) : base(unitOfWork)
    {
    }
}