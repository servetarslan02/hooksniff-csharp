using System.Text.Json.Serialization;

namespace HookSniff
{
    /// <summary>Data payload for endpoint.created events.</summary>
    public class EndpointCreatedData {
        [JsonPropertyName("appId")] public string AppId { get; set; } = "";
        [JsonPropertyName("endpointId")] public string EndpointId { get; set; } = "";
        [JsonPropertyName("appUid")] public string? AppUid { get; set; }
    }

    /// <summary>Data payload for endpoint.updated events.</summary>
    public class EndpointUpdatedData {
        [JsonPropertyName("appId")] public string AppId { get; set; } = "";
        [JsonPropertyName("endpointId")] public string EndpointId { get; set; } = "";
        [JsonPropertyName("appUid")] public string? AppUid { get; set; }
    }

    /// <summary>Data payload for endpoint.deleted events.</summary>
    public class EndpointDeletedData {
        [JsonPropertyName("appId")] public string AppId { get; set; } = "";
        [JsonPropertyName("endpointId")] public string EndpointId { get; set; } = "";
        [JsonPropertyName("appUid")] public string? AppUid { get; set; }
    }

    /// <summary>Data payload for endpoint.enabled events.</summary>
    public class EndpointEnabledData {
        [JsonPropertyName("appId")] public string AppId { get; set; } = "";
        [JsonPropertyName("endpointId")] public string EndpointId { get; set; } = "";
        [JsonPropertyName("appUid")] public string? AppUid { get; set; }
    }

    /// <summary>Data payload for endpoint.disabled events.</summary>
    public class EndpointDisabledData {
        [JsonPropertyName("appId")] public string AppId { get; set; } = "";
        [JsonPropertyName("endpointId")] public string EndpointId { get; set; } = "";
        [JsonPropertyName("appUid")] public string? AppUid { get; set; }
        [JsonPropertyName("failSince")] public string? FailSince { get; set; }
        [JsonPropertyName("trigger")] public string? Trigger { get; set; }
    }

    /// <summary>Info about the last delivery attempt.</summary>
    public class LastAttemptInfo {
        [JsonPropertyName("id")] public string Id { get; set; } = "";
        [JsonPropertyName("timestamp")] public string Timestamp { get; set; } = "";
        [JsonPropertyName("responseStatusCode")] public int ResponseStatusCode { get; set; }
    }

    /// <summary>Info about a delivery attempt.</summary>
    public class AttemptInfo {
        [JsonPropertyName("id")] public string Id { get; set; } = "";
        [JsonPropertyName("timestamp")] public string Timestamp { get; set; } = "";
        [JsonPropertyName("responseStatusCode")] public int ResponseStatusCode { get; set; }
    }

    /// <summary>Data payload for message.attempt.exhausted events.</summary>
    public class MessageAttemptExhaustedData {
        [JsonPropertyName("appId")] public string AppId { get; set; } = "";
        [JsonPropertyName("msgId")] public string MsgId { get; set; } = "";
        [JsonPropertyName("lastAttempt")] public LastAttemptInfo LastAttempt { get; set; } = new();
        [JsonPropertyName("appUid")] public string? AppUid { get; set; }
    }

    /// <summary>Data payload for message.attempt.failing events.</summary>
    public class MessageAttemptFailingData {
        [JsonPropertyName("appId")] public string AppId { get; set; } = "";
        [JsonPropertyName("msgId")] public string MsgId { get; set; } = "";
        [JsonPropertyName("attempt")] public AttemptInfo Attempt { get; set; } = new();
        [JsonPropertyName("appUid")] public string? AppUid { get; set; }
    }

    /// <summary>Data payload for message.attempt.recovered events.</summary>
    public class MessageAttemptRecoveredData {
        [JsonPropertyName("appId")] public string AppId { get; set; } = "";
        [JsonPropertyName("msgId")] public string MsgId { get; set; } = "";
        [JsonPropertyName("attempt")] public AttemptInfo Attempt { get; set; } = new();
        [JsonPropertyName("appUid")] public string? AppUid { get; set; }
    }
}
