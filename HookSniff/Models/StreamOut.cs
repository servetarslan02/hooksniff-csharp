#nullable enable
namespace HookSniff.Models
{
    public class StreamChannelOut
    {
        public string Id { get; set; } = "";
        public string Name { get; set; } = "";
        public string? Description { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }

    public class CreateChannelRequest
    {
        public string Name { get; set; } = "";
        public string? Description { get; set; }
    }

    public class UpdateChannelRequest
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
    }

    public class StreamSubscriptionOut
    {
        public string Id { get; set; } = "";
        public string ChannelId { get; set; } = "";
        public string? EndpointId { get; set; }
        public string Status { get; set; } = "";
        public DateTime CreatedAt { get; set; }
    }

    public class StreamMessageOut
    {
        public string Id { get; set; } = "";
        public string ChannelId { get; set; } = "";
        public string EventType { get; set; } = "";
        public string? Payload { get; set; }
        public DateTime CreatedAt { get; set; }
    }

    public class PublishEventRequest
    {
        public string ChannelId { get; set; } = "";
        public string EventType { get; set; } = "";
        public string? Payload { get; set; }
    }

    public class ChannelDetailOut
    {
        public StreamChannelOut Channel { get; set; } = new();
        public int SubscriberCount { get; set; }
        public int MessageCount { get; set; }
    }

    public class ListResponseStreamChannelOut
    {
        public List<StreamChannelOut> Data { get; set; } = new();
    }

    public class ListResponseStreamSubscriptionOut
    {
        public List<StreamSubscriptionOut> Data { get; set; } = new();
    }

    public class ListResponseStreamMessageOut
    {
        public List<StreamMessageOut> Data { get; set; } = new();
    }
}
