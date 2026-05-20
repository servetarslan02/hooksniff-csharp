// this file is @generated
using System.Text;
using Newtonsoft.Json;

namespace HookSniff.Models
{
    public class MessageIn
    {
        [JsonProperty("channels")]
        public List<string>? Channels { get; set; } = null;

        [JsonProperty("deliver_at")]
        public DateTime? DeliverAt { get; set; } = null;

        [JsonProperty("event_id")]
        public string? EventId { get; set; } = null;

        [JsonProperty("event", Required = Required.Always)]
        public required string EventType { get; set; }

        [JsonProperty("data", Required = Required.Always)]
        public required Object Payload { get; set; }

        [JsonProperty("payload_retention_hours")]
        public long? PayloadRetentionHours { get; set; } = null;

        [JsonProperty("payload_retention_period")]
        public long? PayloadRetentionPeriod { get; set; } = null;

        [JsonProperty("tags")]
        public List<string>? Tags { get; set; } = null;

        [JsonProperty("transformations_params")]
        public Object? TransformationsParams { get; set; } = null;

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("class MessageIn {\n");
            sb.Append("  Channels: ").Append(Channels).Append('\n');
            sb.Append("  DeliverAt: ").Append(DeliverAt).Append('\n');
            sb.Append("  EventId: ").Append(EventId).Append('\n');
            sb.Append("  EventType: ").Append(EventType).Append('\n');
            sb.Append("  Payload: ").Append(Payload).Append('\n');
            sb.Append("  PayloadRetentionHours: ").Append(PayloadRetentionHours).Append('\n');
            sb.Append("  PayloadRetentionPeriod: ").Append(PayloadRetentionPeriod).Append('\n');
            sb.Append("  Tags: ").Append(Tags).Append('\n');
            sb.Append("  TransformationsParams: ").Append(TransformationsParams).Append('\n');
            sb.Append("}\n");
            return sb.ToString();
        }
    }
}
