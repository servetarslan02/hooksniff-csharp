#nullable enable
namespace HookSniff.Models
{
    public class AlertRuleOut
    {
        public string Id { get; set; } = "";
        public string Name { get; set; } = "";
        public string Type { get; set; } = "";
        public string? Condition { get; set; }
        public double? Threshold { get; set; }
        public string? EndpointId { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }

    public class CreateAlertRequest
    {
        public string Name { get; set; } = "";
        public string Type { get; set; } = "";
        public string? Condition { get; set; }
        public double? Threshold { get; set; }
        public string? EndpointId { get; set; }
    }

    public class UpdateAlertRequest
    {
        public string? Name { get; set; }
        public string? Condition { get; set; }
        public double? Threshold { get; set; }
        public bool? IsActive { get; set; }
    }

    public class ListResponseAlertRuleOut
    {
        public List<AlertRuleOut> Data { get; set; } = new();
    }
}
