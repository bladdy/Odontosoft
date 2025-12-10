using Odontosoft.Backend.UnitsOfWork.Interfaces;
using Odontosoft.Shared.Entities;

namespace Odontosoft.Backend.Controllers;

public class FotografiasIntraoralesController : GenericController<FotografiaIntraoral>
{
    //FotografiasIntraoralesController
    public FotografiasIntraoralesController(IGenericUnitOfWork<FotografiaIntraoral> unitOfWork) : base(unitOfWork)
    {
    }
}