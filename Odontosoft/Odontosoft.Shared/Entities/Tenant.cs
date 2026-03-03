using Odontosoft.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odontosoft.Shared.Entities;

public class Tenant
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public Guid? PlanId { get; set; }
    public Guid? CurrentSubscriptionId { get; set; }
    public string Name { get; set; } = null!;
    public string Subdomain { get; set; } = null!;
    public bool IsActive { get; set; } = true;
    public TenantStatus Status { get; set; }
    public DateTime? SubscriptionExpiresAt { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public Plan? Plan { get; set; }
    public Subscription? CurrentSubscription { get; set; }
}