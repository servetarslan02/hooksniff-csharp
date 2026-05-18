#nullable enable
namespace HookSniff.Models
{
    public class ServiceTokenOut
    {
        public string Id { get; set; } = "";
        public string Name { get; set; } = "";
        public string? Prefix { get; set; }
        public List<string> Scopes { get; set; } = new();
        public DateTime CreatedAt { get; set; }
        public DateTime? ExpiresAt { get; set; }
    }

    public class CreateServiceTokenRequest
    {
        public string Name { get; set; } = "";
        public List<string> Scopes { get; set; } = new();
        public DateTime? ExpiresAt { get; set; }
    }

    public class ListResponseServiceTokenOut
    {
        public List<ServiceTokenOut> Data { get; set; } = new();
    }
}
