using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Odontosoft.Backend.UnitsOfWork.Interfaces;
using Odontosoft.Shared.DTOs;
using Odontosoft.Shared.Entities;

namespace Odontosoft.Backend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PacientesController : GenericController<Paciente>
{
    //ClinicasController
    public PacientesController(IGenericUnitOfWork<Paciente> unitOfWork) : base(unitOfWork)
    {
    }
}