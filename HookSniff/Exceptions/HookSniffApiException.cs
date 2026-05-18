using System;
using System.Collections.Generic;
using System.Net;

namespace HookSniff.Exceptions
{
    /// <summary>
    /// Base exception for all HookSniff API errors.
    /// </summary>
    public class HookSniffApiException : Exception
    {
        public int StatusCode { get; }
        public string ResponseBody { get; }
        public IDictionary<string, string> Headers { get; }

        public HookSniffApiException(string message, int statusCode, string responseBody = null, IDictionary<string, string> headers = null)
            : base(message)
        {
            StatusCode = statusCode;
            ResponseBody = responseBody;
            Headers = headers ?? new Dictionary<string, string>();
        }
    }

    /// <summary>400 Bad Request — The request was malformed or missing required fields</summary>
    public class BadRequestException : HookSniffApiException
    {
        public BadRequestException(string detail = null, IDictionary<string, string> headers = null)
            : base(detail ?? "Bad request", 400, detail, headers) { }
    }

    /// <summary>401 Unauthorized — Invalid or missing authentication</summary>
    public class UnauthorizedException : HookSniffApiException
    {
        public UnauthorizedException(string message = null, IDictionary<string, string> headers = null)
            : base(message ?? "Unauthorized", 401, message, headers) { }
    }

    /// <summary>403 Forbidden — Insufficient permissions</summary>
    public class ForbiddenException : HookSniffApiException
    {
        public ForbiddenException(string message = null, IDictionary<string, string> headers = null)
            : base(message ?? "Forbidden", 403, message, headers) { }
    }

    /// <summary>404 Not Found — Resource does not exist</summary>
    public class NotFoundException : HookSniffApiException
    {
        public NotFoundException(string message = null, IDictionary<string, string> headers = null)
            : base(message ?? "Not found", 404, message, headers) { }
    }

    /// <summary>409 Conflict — Resource already exists or conflict</summary>
    public class ConflictException : HookSniffApiException
    {
        public ConflictException(string message = null, IDictionary<string, string> headers = null)
            : base(message ?? "Conflict", 409, message, headers) { }
    }

    /// <summary>422 Unprocessable Entity — Validation error</summary>
    public class UnprocessableEntityException : HookSniffApiException
    {
        public IList<ValidationErrorItem> ValidationErrors { get; }

        public UnprocessableEntityException(IList<ValidationErrorItem> validationErrors = null, string message = null, IDictionary<string, string> headers = null)
            : base(message ?? "Unprocessable entity", 422, message, headers)
        {
            ValidationErrors = validationErrors ?? new List<ValidationErrorItem>();
        }
    }

    /// <summary>429 Too Many Requests — Rate limit exceeded</summary>
    public class RateLimitException : HookSniffApiException
    {
        public int? RetryAfter { get; }

        public RateLimitException(int? retryAfter = null, IDictionary<string, string> headers = null)
            : base($"Rate limit exceeded{(retryAfter.HasValue ? $" (retry after {retryAfter}s)" : "")}", 429, null, headers)
        {
            RetryAfter = retryAfter;
        }
    }

    /// <summary>500 Internal Server Error</summary>
    public class InternalServerException : HookSniffApiException
    {
        public InternalServerException(string message = null, IDictionary<string, string> headers = null)
            : base(message ?? "Internal server error", 500, message, headers) { }
    }

    /// <summary>502 Bad Gateway</summary>
    public class BadGatewayException : HookSniffApiException
    {
        public BadGatewayException(string message = null, IDictionary<string, string> headers = null)
            : base(message ?? "Bad gateway", 502, message, headers) { }
    }

    /// <summary>503 Service Unavailable</summary>
    public class ServiceUnavailableException : HookSniffApiException
    {
        public ServiceUnavailableException(string message = null, IDictionary<string, string> headers = null)
            : base(message ?? "Service unavailable", 503, message, headers) { }
    }

    /// <summary>504 Gateway Timeout</summary>
    public class GatewayTimeoutException : HookSniffApiException
    {
        public GatewayTimeoutException(string message = null, IDictionary<string, string> headers = null)
            : base(message ?? "Gateway timeout", 504, message, headers) { }
    }

    /// <summary>Validation error item from 422 responses</summary>
    public class ValidationErrorItem
    {
        public string[] Loc { get; set; }
        public string Msg { get; set; }
        public string Type { get; set; }
    }

    /// <summary>
    /// Factory to create the appropriate exception from a status code.
    /// </summary>
    public static class HookSniffApiExceptionFactory
    {
        public static HookSniffApiException Create(int statusCode, string body, IDictionary<string, string> headers = null)
        {
            return statusCode switch
            {
                400 => new BadRequestException(body, headers),
                401 => new UnauthorizedException(body, headers),
                403 => new ForbiddenException(body, headers),
                404 => new NotFoundException(body, headers),
                409 => new ConflictException(body, headers),
                422 => new UnprocessableEntityException(null, body, headers),
                429 => new RateLimitException(
                    headers?.ContainsKey("retry-after") == true && int.TryParse(headers["retry-after"], out var ra) ? ra : null,
                    headers),
                500 => new InternalServerException(body, headers),
                502 => new BadGatewayException(body, headers),
                503 => new ServiceUnavailableException(body, headers),
                504 => new GatewayTimeoutException(body, headers),
                _ => new HookSniffApiException($"HTTP {statusCode}", statusCode, body, headers)
            };
        }
    }
}

    /// <summary>408 Request Timeout — The server timed out waiting for the request</summary>
    public class RequestTimeoutException : HookSniffApiException
    {
        public RequestTimeoutException(string message = null, IDictionary<string, string> headers = null)
            : base(message ?? "Request timeout", 408, message, headers) { }
    }

    /// <summary>410 Gone — The resource has been permanently removed</summary>
    public class GoneException : HookSniffApiException
    {
        public GoneException(string message = null, IDictionary<string, string> headers = null)
            : base(message ?? "Gone", 410, message, headers) { }
    }

    /// <summary>413 Payload Too Large</summary>
    public class PayloadTooLargeException : HookSniffApiException
    {
        public PayloadTooLargeException(string message = null, IDictionary<string, string> headers = null)
            : base(message ?? "Payload too large", 413, message, headers) { }
    }

    /// <summary>501 Not Implemented</summary>
    public class NotImplementedException : HookSniffApiException
    {
        public NotImplementedException(string message = null, IDictionary<string, string> headers = null)
            : base(message ?? "Not implemented", 501, message, headers) { }
    }

    /// <summary>507 Insufficient Storage</summary>
    public class InsufficientStorageException : HookSniffApiException
    {
        public InsufficientStorageException(string message = null, IDictionary<string, string> headers = null)
            : base(message ?? "Insufficient storage", 507, message, headers) { }
    }

    /// <summary>508 Loop Detected</summary>
    public class LoopDetectedException : HookSniffApiException
    {
        public LoopDetectedException(string message = null, IDictionary<string, string> headers = null)
            : base(message ?? "Loop detected", 508, message, headers) { }
    }

    /// <summary>Timeout — request exceeded the configured timeout</summary>
    public class TimeoutException : HookSniffApiException
    {
        public TimeoutException(string message = null)
            : base(message ?? "Request timeout", 0, null) { }
    }

    /// <summary>Network error — connection failed</summary>
    public class NetworkException : HookSniffApiException
    {
        public NetworkException(string message = null)
            : base(message ?? "Network error", 0, null) { }
    }

    /// <summary>Authentication error — token invalid, expired, or missing</summary>
    public class AuthenticationException : HookSniffApiException
    {
        public AuthenticationException(string message = null, IDictionary<string, string> headers = null)
            : base(message ?? "Authentication failed", 401, message, headers) { }
    }
}
