namespace Odontosoft.Shared.Entities
{
    public class Subscription
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public Guid TenantId { get; set; }
        public Tenant Tenant { get; set; } = null!;

        public Guid PlanId { get; set; }
        public Plan Plan { get; set; } = null!;

        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }

        public decimal PrecioMensual { get; set; }

        public bool Activa { get; set; }

        public ICollection<PagoSubscription> Pagos { get; set; } = new List<PagoSubscription>();
    }
}