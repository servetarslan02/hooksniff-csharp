#nullable enable
namespace HookSniff.Models
{
    public class RateLimitOut
    {
        public string EndpointId { get; set; } = "";
        public int Limit { get; set; }
        public string Window { get; set; } = "";
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }

    public class SetRateLimitRequest
    {
        public int Limit { get; set; }
        public string Window { get; set; } = "1m";
    }
}
