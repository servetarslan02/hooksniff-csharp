#nullable enable
namespace HookSniff.Models
{
    public class AuditEntryOut
    {
        public string Id { get; set; } = "";
        public string Action { get; set; } = "";
        public string? ResourceType { get; set; }
        public string? ResourceId { get; set; }
        public string? ActorId { get; set; }
        public string? ActorEmail { get; set; }
        public Dictionary<string, object>? Details { get; set; }
        public string? IpAddress { get; set; }
        public DateTime CreatedAt { get; set; }
    }

    public class AuditLogResponse
    {
        public List<AuditEntryOut> Data { get; set; } = new();
        public int Total { get; set; }
    }
}
