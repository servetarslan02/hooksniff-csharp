#nullable enable
namespace HookSniff.Models
{
    public class SchemaOut
    {
        public string Id { get; set; } = "";
        public string Name { get; set; } = "";
        public string? Description { get; set; }
        public Dictionary<string, object>? Schema { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }

    public class RegisterSchemaRequest
    {
        public string Name { get; set; } = "";
        public string? Description { get; set; }
        public Dictionary<string, object>? Schema { get; set; }
    }

    public class ValidateEventRequest
    {
        public string Event { get; set; } = "";
        public string? Payload { get; set; }
    }

    public class ValidateEventResponse
    {
        public bool Valid { get; set; }
        public List<string>? Errors { get; set; }
    }

    public class ListResponseSchemaOut
    {
        public List<SchemaOut> Data { get; set; } = new();
    }
}
