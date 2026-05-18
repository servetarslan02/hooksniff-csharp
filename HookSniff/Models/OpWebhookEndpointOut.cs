#nullable enable
namespace HookSniff.Models
{
    public class OpWebhookEndpointOut
    {
        public string Id { get; set; } = "";
        public string Url { get; set; } = "";
        public string? Description { get; set; }
        public List<string> EventTypes { get; set; } = new();
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }

    public class CreateOpWebhookEndpointRequest
    {
        public string Url { get; set; } = "";
        public string? Description { get; set; }
        public List<string> EventTypes { get; set; } = new();
    }

    public class UpdateOpWebhookEndpointRequest
    {
        public string? Url { get; set; }
        public string? Description { get; set; }
        public List<string>? EventTypes { get; set; }
        public bool? IsActive { get; set; }
    }

    public class OpWebhookDeliveryOut
    {
        public string Id { get; set; } = "";
        public string EndpointId { get; set; } = "";
        public string EventType { get; set; } = "";
        public int StatusCode { get; set; }
        public string? ResponseBody { get; set; }
        public string? Error { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
