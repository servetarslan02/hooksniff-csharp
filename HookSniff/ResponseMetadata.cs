using System.Collections.Generic;
using System.Net;

namespace HookSniff
{
    /// <summary>
    /// Response metadata from the last API request.
    /// Access via client.LastResponse after any API call.
    /// </summary>
    public class ResponseMetadata
    {
        /// <summary>HTTP status code.</summary>
        public int StatusCode { get; }

        /// <summary>x-request-id header (for debugging).</summary>
        public string RequestId { get; }

        /// <summary>x-ratelimit-remaining header.</summary>
        public int? RateLimitRemaining { get; }

        /// <summary>x-ratelimit-reset header (Unix timestamp).</summary>
        public int? RateLimitReset { get; }

        /// <summary>All response headers.</summary>
        public WebHeaderCollection Headers { get; }

        public ResponseMetadata(int statusCode, string requestId, int? rateLimitRemaining,
            int? rateLimitReset, WebHeaderCollection headers)
        {
            StatusCode = statusCode;
            RequestId = requestId;
            RateLimitRemaining = rateLimitRemaining;
            RateLimitReset = rateLimitReset;
            Headers = headers;
        }

        /// <summary>Get a header value by name.</summary>
        public string GetHeader(string name) => Headers?.Get(name);
    }
}
