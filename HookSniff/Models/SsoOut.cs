#nullable enable
namespace HookSniff.Models
{
    public class SsoConfigOut
    {
        public string Id { get; set; } = "";
        public string Provider { get; set; } = "";
        public string? IssuerUrl { get; set; }
        public string? ClientId { get; set; }
        public bool IsEnabled { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }

    public class UpsertSsoRequest
    {
        public string Provider { get; set; } = "";
        public string? IssuerUrl { get; set; }
        public string? ClientId { get; set; }
        public string? ClientSecret { get; set; }
    }
}
