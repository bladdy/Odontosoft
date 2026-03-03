using Odontosoft.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odontosoft.Shared.Entities
{
    public class PagoSubscription
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public Guid SubscriptionId { get; set; }
        public Subscription Subscription { get; set; } = null!;

        public decimal Monto { get; set; }

        public DateTime FechaPago { get; set; }

        public string MetodoPago { get; set; } = null!;

        public string? ReferenciaExterna { get; set; }

        public PagoStatus Status { get; set; }
    }
}