using Odontosoft.Shared.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odontosoft.Shared.Entities;

public class ExamenPeriodontal : ITenantEntity
{
    public int Id { get; set; }

    public Tenant Tenant { get; set; }
    public Guid TenantId { get; set; }
    public int PacienteId { get; set; }
    public int MedicoId { get; set; }

    [Required]
    public DateTime FechaExamen { get; set; }

    [MaxLength(50)]
    public string? IndiceHigiene { get; set; } // Excelente, Bueno, Regular, Malo

    [MaxLength(50)]
    public string? IndiceGingival { get; set; } // 0-3 (Leve, Moderado, Severo)

    public bool Sangrado { get; set; }
    public bool PresenciaPlaca { get; set; }
    public bool PresenciaSarro { get; set; }
    public bool Movilidad { get; set; }

    [MaxLength(2000)]
    public string? Diagnostico { get; set; }

    [MaxLength(2000)]
    public string? PlanTratamiento { get; set; }

    [MaxLength(2000)]
    public string? Observaciones { get; set; }

    // Relaciones
    public Paciente Paciente { get; set; }

    public Medico Medico { get; set; }
    public ICollection<BolsaPeriodontal> BolsasPeriodontales { get; set; }
}