using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odontosoft.Shared.Entities
{
    public class PresupuestoDental
    {
        public int Id { get; set; }
        public int PacienteId { get; set; }
        public int MedicoId { get; set; }
        public int SucursalId { get; set; }

        [Required, MaxLength(30)]
        public string NumeroPresupuesto { get; set; } = null!;

        [Required]
        public DateTime FechaEmision { get; set; }

        public DateTime? FechaVencimiento { get; set; }

        [MaxLength(50)]
        public string Estado { get; set; } = "Pendiente"; // Pendiente, Aprobado, Rechazado, EnProceso, Completado

        [MaxLength(2000)]
        public string? DiagnosticoGeneral { get; set; }

        public decimal Subtotal { get; set; }
        public decimal Descuento { get; set; } = 0;
        public decimal Total { get; set; }

        [MaxLength(50)]
        public string? FormaPago { get; set; } // Contado, Cuotas, Seguro

        public int? NumeroCuotas { get; set; }

        [MaxLength(2000)]
        public string? Observaciones { get; set; }

        public DateTime? FechaAprobacion { get; set; }
        public DateTime? FechaInicio { get; set; }
        public DateTime? FechaFinalizacion { get; set; }

        // Relaciones
        public Paciente Paciente { get; set; }

        public Medico Medico { get; set; }
        public Sucursal Sucursal { get; set; }
        public ICollection<PresupuestoDetalle> Detalles { get; set; }
    }
}