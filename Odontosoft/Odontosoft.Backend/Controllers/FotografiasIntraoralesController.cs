using Microsoft.AspNetCore.Mvc;
using Odontosoft.Backend.UnitsOfWork.Interfaces;
using Odontosoft.Shared.Entities;

namespace Odontosoft.Backend.Controllers;
[ApiController]
[Route("api/[controller]")]
public class FotografiasIntraoralesController : GenericController<FotografiaIntraoral>
{
    //FotografiasIntraoralesController
    public FotografiasIntraoralesController(IGenericUnitOfWork<FotografiaIntraoral> unitOfWork) : base(unitOfWork)
    {
    }
}