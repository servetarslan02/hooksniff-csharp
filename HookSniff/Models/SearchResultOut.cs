#nullable enable
namespace HookSniff.Models
{
    public class SearchResultOut
    {
        public List<SearchDeliveryResult> Results { get; set; } = new();
        public int Total { get; set; }
    }

    public class SearchDeliveryResult
    {
        public string Id { get; set; } = "";
        public string? EndpointId { get; set; }
        public string EventType { get; set; } = "";
        public string Status { get; set; } = "";
        public string? Payload { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
