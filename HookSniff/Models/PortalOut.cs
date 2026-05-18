#nullable enable
namespace HookSniff.Models
{
    public class PortalProfileOut
    {
        public string Id { get; set; } = "";
        public string? Name { get; set; }
        public string Email { get; set; } = "";
        public string? AvatarUrl { get; set; }
    }

    public class UpdatePortalProfileRequest
    {
        public string? Name { get; set; }
        public string? AvatarUrl { get; set; }
    }

    public class PortalUsageOut
    {
        public int CurrentUsage { get; set; }
        public int Limit { get; set; }
        public string Period { get; set; } = "";
    }

    public class PortalPlanOut
    {
        public string Id { get; set; } = "";
        public string Name { get; set; } = "";
        public int Price { get; set; }
    }

    public class PortalNotificationOut
    {
        public string Id { get; set; } = "";
        public string Title { get; set; } = "";
        public string? Message { get; set; }
        public bool IsRead { get; set; }
        public DateTime CreatedAt { get; set; }
    }

    public class UpdatePortalNotificationsRequest
    {
        public bool? EmailEnabled { get; set; }
        public bool? PushEnabled { get; set; }
    }
}
