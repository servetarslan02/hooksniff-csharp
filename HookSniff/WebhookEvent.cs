using System;
using System.Collections.Generic;

namespace HookSniff
{
    /// <summary>
    /// Represents a parsed webhook event from HookSniff.
    /// </summary>
    public class WebhookEvent
    {
        /// <summary>
        /// Event type name (e.g., "endpoint.created").
        /// </summary>
        public string Event { get; }

        /// <summary>
        /// Alias for Event — the event type name.
        /// </summary>
        public string EventType => Event;

        /// <summary>
        /// Event payload data.
        /// </summary>
        public Dictionary<string, object> Data { get; }

        /// <summary>
        /// ISO 8601 timestamp string.
        /// </summary>
        public string Timestamp { get; }

        public WebhookEvent(string @event, Dictionary<string, object> data, string timestamp)
        {
            Event = @event;
            Data = data ?? new Dictionary<string, object>();
            Timestamp = timestamp;
        }

        /// <summary>
        /// Get a value from the data dictionary by key.
        /// </summary>
        public object Get(string key)
        {
            return Data.TryGetValue(key, out var value) ? value : null;
        }

        /// <summary>
        /// Access data values with bracket notation.
        /// </summary>
        public object this[string key] => Get(key);

        public override string ToString()
        {
            return $"WebhookEvent{{event='{Event}', timestamp='{Timestamp}'}}";
        }

        /// <summary>
        /// Parse a webhook payload dictionary into a WebhookEvent.
        /// </summary>
        public static WebhookEvent Parse(Dictionary<string, object> data)
        {
            var @event = data.TryGetValue("event", out var e) ? e?.ToString() :
                         data.TryGetValue("eventType", out var et) ? et?.ToString() : "";
            var payload = data.TryGetValue("data", out var d) && d is Dictionary<string, object> dict
                ? dict : new Dictionary<string, object>();
            var timestamp = data.TryGetValue("timestamp", out var ts) ? ts?.ToString() : "";

            return new WebhookEvent(@event, payload, timestamp);
        }
    }
}
