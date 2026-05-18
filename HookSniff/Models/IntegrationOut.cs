#nullable enable
namespace HookSniff.Models
{
    public class IntegrationOut
    {
        public string Id { get; set; } = "";
        public string Name { get; set; } = "";
        public string Type { get; set; } = "";
        public string? Description { get; set; }
        public string Status { get; set; } = "";
        public Dictionary<string, object>? Config { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }

    public class CreateIntegrationRequest
    {
        public string Name { get; set; } = "";
        public string Type { get; set; } = "";
        public string? Description { get; set; }
        public Dictionary<string, object>? Config { get; set; }
    }

    public class UpdateIntegrationRequest
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public Dictionary<string, object>? Config { get; set; }
    }

    public class IntegrationEventOut
    {
        public string Id { get; set; } = "";
        public string IntegrationId { get; set; } = "";
        public string EventType { get; set; } = "";
        public string? Payload { get; set; }
        public string Status { get; set; } = "";
        public DateTime CreatedAt { get; set; }
    }

    public class IntegrationStatsOut
    {
        public int TotalEvents { get; set; }
        public int SuccessCount { get; set; }
        public int ErrorCount { get; set; }
        public double? AvgLatencyMs { get; set; }
    }

    public class ListResponseIntegrationOut
    {
        public List<IntegrationOut> Data { get; set; } = new();
    }
}
