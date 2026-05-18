#nullable enable
namespace HookSniff.Models
{
    public class ConnectorOut
    {
        public string Id { get; set; } = "";
        public string Name { get; set; } = "";
        public string Type { get; set; } = "";
        public string? Description { get; set; }
        public string? IconUrl { get; set; }
        public bool IsEnabled { get; set; }
        public DateTime CreatedAt { get; set; }
    }

    public class ConnectorConfigOut
    {
        public string Id { get; set; } = "";
        public string ConnectorId { get; set; } = "";
        public string Name { get; set; } = "";
        public Dictionary<string, object>? Config { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }

    public class CreateConnectorConfigRequest
    {
        public string Name { get; set; } = "";
        public Dictionary<string, object>? Config { get; set; }
    }

    public class UpdateConnectorConfigRequest
    {
        public string? Name { get; set; }
        public Dictionary<string, object>? Config { get; set; }
        public bool? IsActive { get; set; }
    }
}
