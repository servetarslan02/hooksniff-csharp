#nullable enable
namespace HookSniff.Models
{
    public class PolledMessageOut
    {
        public string Id { get; set; } = "";
        public string EventType { get; set; } = "";
        public string? Payload { get; set; }
        public string? Channel { get; set; }
        public DateTime Timestamp { get; set; }
    }

    public class PollResponse
    {
        public List<PolledMessageOut> Messages { get; set; } = new();
        public CursorInfo? Cursor { get; set; }
    }

    public class CursorInfo
    {
        public string? Cursor { get; set; }
        public bool HasMore { get; set; }
    }

    public class SeekRequest
    {
        public string? Cursor { get; set; }
        public DateTime? Timestamp { get; set; }
    }

    public class SeekResponse
    {
        public string Cursor { get; set; } = "";
    }

    public class CommitRequest
    {
        public string Cursor { get; set; } = "";
    }

    public class CommitResponse
    {
        public bool Success { get; set; }
    }
}
