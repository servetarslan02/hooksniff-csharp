#nullable enable
namespace HookSniff.Models
{
    public class InboundConfigOut
    {
        public string Id { get; set; } = "";
        public string Provider { get; set; } = "";
        public string? WebhookUrl { get; set; }
        public string? Secret { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
    }

    public class CreateInboundConfigRequest
    {
        public string Provider { get; set; } = "";
        public string? WebhookUrl { get; set; }
    }

    public class UpdateInboundConfigRequest
    {
        public string? WebhookUrl { get; set; }
        public bool? IsActive { get; set; }
    }

    public class ListResponseInboundConfigOut
    {
        public List<InboundConfigOut> Data { get; set; } = new();
    }
}
