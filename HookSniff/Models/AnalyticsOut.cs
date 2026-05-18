#nullable enable
namespace HookSniff.Models
{
    public class DeliveryTrendResponse
    {
        public List<TimeBucket> Buckets { get; set; } = new();
        public long Total { get; set; }
    }

    public class TimeBucket
    {
        public DateTime Timestamp { get; set; }
        public int Count { get; set; }
    }

    public class SuccessRateResponse
    {
        public double Rate { get; set; }
        public int Total { get; set; }
        public int Success { get; set; }
        public int Failed { get; set; }
    }

    public class LatencyBucket
    {
        public DateTime Timestamp { get; set; }
        public double AvgMs { get; set; }
        public double P95Ms { get; set; }
        public double P99Ms { get; set; }
    }

    public class LatencyTrendResponse
    {
        public List<LatencyBucket> Buckets { get; set; } = new();
    }
}
