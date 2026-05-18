#nullable enable
namespace HookSniff.Models
{
    public class BackgroundTaskOut
    {
        public string Id { get; set; } = "";
        public string Type { get; set; } = "";
        public string Status { get; set; } = "";
        public string? Result { get; set; }
        public string? Error { get; set; }
        public int Progress { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? CompletedAt { get; set; }
    }
}
