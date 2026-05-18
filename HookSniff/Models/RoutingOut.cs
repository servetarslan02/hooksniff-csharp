#nullable enable
namespace HookSniff.Models
{
    public class RoutingInfoOut
    {
        public string EndpointId { get; set; } = "";
        public List<RoutingRule> Rules { get; set; } = new();
        public string? DefaultAction { get; set; }
        public DateTime UpdatedAt { get; set; }
    }

    public class RoutingRule
    {
        public string Field { get; set; } = "";
        public string Operator { get; set; } = "";
        public string Value { get; set; } = "";
        public string Action { get; set; } = "";
    }

    public class UpdateRoutingRequest
    {
        public List<RoutingRule>? Rules { get; set; }
        public string? DefaultAction { get; set; }
    }

    public class EndpointHealthOut
    {
        public string EndpointId { get; set; } = "";
        public string Status { get; set; } = "";
        public double? SuccessRate { get; set; }
        public double? AvgLatencyMs { get; set; }
        public DateTime? LastDeliveryAt { get; set; }
    }
}
