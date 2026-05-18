#nullable enable
namespace HookSniff.Models
{
    public class EnvironmentOut
    {
        public string Id { get; set; } = "";
        public string Name { get; set; } = "";
        public string? Description { get; set; }
        public string? Slug { get; set; }
        public bool IsDefault { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }

    public class CreateEnvironmentRequest
    {
        public string Name { get; set; } = "";
        public string? Description { get; set; }
        public string? Slug { get; set; }
    }

    public class UpdateEnvironmentRequest
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
    }

    public class VariableOut
    {
        public string Id { get; set; } = "";
        public string Key { get; set; } = "";
        public string? Value { get; set; }
        public bool IsSecret { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }

    public class CreateVariableRequest
    {
        public string Key { get; set; } = "";
        public string? Value { get; set; }
        public bool IsSecret { get; set; }
    }

    public class UpdateVariableRequest
    {
        public string? Value { get; set; }
        public bool? IsSecret { get; set; }
    }

    public class BulkUpsertVariablesRequest
    {
        public List<CreateVariableRequest> Variables { get; set; } = new();
    }
}
