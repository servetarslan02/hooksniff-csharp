#nullable enable
namespace HookSniff.Models
{
    public class BillingSubscriptionOut
    {
        public string Id { get; set; } = "";
        public string PlanId { get; set; } = "";
        public string Status { get; set; } = "";
        public DateTime? CurrentPeriodStart { get; set; }
        public DateTime? CurrentPeriodEnd { get; set; }
        public bool CancelAtPeriodEnd { get; set; }
    }

    public class BillingUsageOut
    {
        public int CurrentUsage { get; set; }
        public int Limit { get; set; }
        public string Period { get; set; } = "";
    }

    public class BillingInvoiceOut
    {
        public string Id { get; set; } = "";
        public int Amount { get; set; }
        public string Currency { get; set; } = "usd";
        public string Status { get; set; } = "";
        public DateTime CreatedAt { get; set; }
    }

    public class BillingPlanOut
    {
        public string Id { get; set; } = "";
        public string Name { get; set; } = "";
        public int Price { get; set; }
        public string Currency { get; set; } = "usd";
        public string Interval { get; set; } = "month";
    }

    public class UpgradePlanRequest
    {
        public string PlanId { get; set; } = "";
    }

    public class ListResponseInvoiceOut
    {
        public List<BillingInvoiceOut> Data { get; set; } = new();
    }
}
