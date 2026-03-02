using Odontosoft.Shared.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odontosoft.Shared.Entities;

public class Especialidad : ITenantEntity
{
    public int Id { get; set; }

    public Tenant Tenant { get; set; }
    public Guid TenantId { get; set; }

    [Required, MaxLength(200)]
    public string Nombre { get; set; }

    [MaxLength(500)]
    public string Descripcion { get; set; }

    public bool Activo { get; set; } = true;

    // Relaciones
    public ICollection<MedicoEspecialidad> MedicoEspecialidades { get; set; }
}