#nullable enable
namespace HookSniff.Models
{
    public class ApiKeyOut
    {
        public string Id { get; set; } = "";
        public string Name { get; set; } = "";
        public string? Prefix { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? LastUsedAt { get; set; }
        public DateTime? ExpiresAt { get; set; }
    }

    public class CreateApiKeyOut
    {
        public string Id { get; set; } = "";
        public string Name { get; set; } = "";
        public string Key { get; set; } = "";
        public DateTime CreatedAt { get; set; }
    }

    public class CreateApiKeyRequest
    {
        public string Name { get; set; } = "";
        public DateTime? ExpiresAt { get; set; }
    }

    public class ListResponseApiKeyOut
    {
        public List<ApiKeyOut> Data { get; set; } = new();
    }
}
