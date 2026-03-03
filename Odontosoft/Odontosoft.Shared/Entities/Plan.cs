using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odontosoft.Shared.Entities
{
    public class Plan
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public string Nombre { get; set; } = null!;

        public decimal PrecioBase { get; set; }

        public decimal PrecioPorSucursalExtra { get; set; }

        public int SucursalesIncluidas { get; set; }

        public bool Activo { get; set; } = true;

        public ICollection<Subscription> Subscriptions { get; set; } = new List<Subscription>();
    }
}