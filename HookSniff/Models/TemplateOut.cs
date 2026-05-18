#nullable enable
namespace HookSniff.Models
{
    public class TemplateOut
    {
        public string Id { get; set; } = "";
        public string Name { get; set; } = "";
        public string? Description { get; set; }
        public string Category { get; set; } = "";
        public string? Payload { get; set; }
        public DateTime CreatedAt { get; set; }
    }

    public class ApplyTemplateRequest
    {
        public string EndpointId { get; set; } = "";
        public Dictionary<string, object>? Variables { get; set; }
    }

    public class ApplyTemplateResponse
    {
        public bool Success { get; set; }
        public string? Message { get; set; }
    }

    public class ListResponseTemplateOut
    {
        public List<TemplateOut> Data { get; set; } = new();
    }
}
