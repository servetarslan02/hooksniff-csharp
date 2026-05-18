#nullable enable
namespace HookSniff.Models
{
    public class PlaygroundOut
    {
        public List<PlaygroundEndpointInfo> Endpoints { get; set; } = new();
        public List<SamplePayload> SamplePayloads { get; set; } = new();
    }

    public class PlaygroundEndpointInfo
    {
        public string Id { get; set; } = "";
        public string Url { get; set; } = "";
        public string? Description { get; set; }
    }

    public class SamplePayload
    {
        public string EventType { get; set; } = "";
        public string Payload { get; set; } = "";
    }

    public class TestWebhookRequest
    {
        public string? EndpointId { get; set; }
        public string EventType { get; set; } = "";
        public string? Payload { get; set; }
    }

    public class TestWebhookResponse
    {
        public bool Success { get; set; }
        public int StatusCode { get; set; }
        public string? ResponseBody { get; set; }
        public double? LatencyMs { get; set; }
    }
}
