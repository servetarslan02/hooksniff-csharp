#nullable enable
namespace HookSniff.Models
{
    public class NotificationOut
    {
        public string Id { get; set; } = "";
        public string Title { get; set; } = "";
        public string? Message { get; set; }
        public string Type { get; set; } = "";
        public bool IsRead { get; set; }
        public DateTime CreatedAt { get; set; }
    }

    public class NotificationListResponse
    {
        public List<NotificationOut> Data { get; set; } = new();
        public int UnreadCount { get; set; }
    }

    public class UnreadCountResponse
    {
        public int Count { get; set; }
    }
}
