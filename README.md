# HookSniff C# SDK

<p align="center">
  <a href="https://www.nuget.org/packages/HookSniff"><img src="https://img.shields.io/nuget/v/HookSniff" alt="NuGet"></a>
  <a href="https://github.com/servetarslan02/hooksniff-csharp"><img src="https://img.shields.io/github/license/servetarslan02/hooksniff-csharp" alt="License"></a>
  <a href="https://hooksniff.vercel.app"><img src="https://img.shields.io/badge/webhook-platform-blue" alt="HookSniff"></a>
</p>

Official C# SDK for [HookSniff](https://hooksniff.vercel.app) — reliable webhook delivery for developers.

## Installation

```bash
dotnet add package HookSniff
```

### Package Reference

```xml
<PackageReference Include="HookSniff" Version="1.2.0" />
```

## Quick Start

```csharp
using HookSniff;

// Initialize client
var client = new HookSniffClient(
    "hs_xxx_your_api_key",
    new HookSniffOptions("https://hooksniff-api-e6ztf3x2ma-ew.a.run.app")
);

// List endpoints
var endpoints = await client.Endpoint.ListAsync("app_xxx");
Console.WriteLine($"Endpoints: {endpoints.Count}");

// Create an endpoint
var newEndpoint = await client.Endpoint.CreateAsync("app_xxx", new EndpointIn
{
    Url = "https://your-app.com/webhook"
});
Console.WriteLine($"Created: {newEndpoint.Id}");

// Send a webhook message
var message = await client.Message.CreateAsync("app_xxx", new MessageIn
{
    EventType = "order.created",
    Payload = new Dictionary<string, object>
    {
        { "order_id", "12345" },
        { "total", 99.99 }
    }
});
Console.WriteLine($"Message sent: {message.Id}");
```

## Authentication

Use your API key (starts with `hs_`) or a JWT token from the login endpoint.

```csharp
// With API key
var client = new HookSniffClient("hs_xxx");

// With custom base URL
var client = new HookSniffClient(
    "hs_xxx",
    new HookSniffOptions("https://hooksniff-api-e6ztf3x2ma-ew.a.run.app")
);

// With custom retry schedule (max 5 retries)
var client = new HookSniffClient(
    "hs_xxx",
    new HookSniffOptions(retryScheduleMilliseconds: new List<int> { 50, 100, 200, 500, 1000 })
);
```

## Webhook Verification

Verify incoming webhook signatures using HMAC-SHA256 (Standard Webhooks compliant).

```csharp
using HookSniff;
using HookSniff.Exceptions;

var webhook = new Webhook("whsec_your_signing_secret");

try
{
    // With a Func<string?, string?> headers provider
    webhook.Verify(payload, headerName => request.Headers[headerName]);
    Console.WriteLine("✅ Signature valid!");
}
catch (WebhookVerificationException ex)
{
    Console.WriteLine($"❌ Invalid signature: {ex.Message}");
}
```

### HookSniff Branded Headers

The SDK supports both branded and unbranded headers:

```csharp
// HookSniff branded
webhook.Verify(payload, key => headers.TryGetValue(key ?? "", out var val) ? val : null);
// Looks for: hooksniff-id, hooksniff-timestamp, hooksniff-signature

// Standard Webhooks (unbranded)
// Looks for: webhook-id, webhook-timestamp, webhook-signature
```

### Signing Webhooks

```csharp
var signature = webhook.Sign(
    msgId: "msg_xxx",
    timestamp: DateTimeOffset.UtcNow,
    payload: jsonString
);
// Returns: "v1,<base64-signature>"
```

## Resources

### Core

| Resource | Async Methods | Sync Methods | Description |
|----------|--------------|--------------|-------------|
| `Endpoint` | ListAsync, CreateAsync, GetAsync, UpdateAsync, DeleteAsync, PatchAsync, GetSecretAsync, RotateSecretAsync, GetHeadersAsync, UpdateHeadersAsync, PatchHeadersAsync, GetStatsAsync | List, Create, Get, Update, Delete, Patch, GetSecret, RotateSecret, GetHeaders, UpdateHeaders, PatchHeaders, GetStats | Manage webhook endpoints |
| `Message` | ListAsync, CreateAsync, GetAsync, ExpungeContentAsync | List, Create, Get, ExpungeContent | Send and manage webhook messages |
| `MessageAttempt` | ListByEndpointAsync, ListByMsgAsync, GetAsync, ExpungeContentAsync, ResendAsync | ListByEndpoint, ListByMsg, Get, ExpungeContent, Resend | Track delivery attempts |
| `EventType` | ListAsync, CreateAsync, GetAsync, UpdateAsync, DeleteAsync, PatchAsync, ImportOpenapiAsync | List, Create, Get, Update, Delete, Patch, ImportOpenapi | Manage event types |
| `Authentication` | LogoutAsync | Logout | Auth operations |
| `Statistics` | AggregateAppStatsAsync | AggregateAppStats | Usage statistics |
| `Health` | GetAsync | Get | API health check |

### Faz 8-15 — New Features

| Resource | Async Methods | Description |
|----------|--------------|-------------|
| `Environment` | ListAsync, GetAsync, CreateAsync, UpdateAsync, DeleteAsync, ListVariablesAsync, CreateVariableAsync, UpdateVariableAsync, DeleteVariableAsync | Manage environments (dev/staging/prod) |
| `BackgroundTask` | ListAsync, GetAsync, CancelAsync | Manage async background tasks |
| `OperationalWebhook` | ListAsync, GetAsync, CreateAsync, UpdateAsync, DeleteAsync, ListDeliveriesAsync | Operational webhook endpoints |
| `MessagePoller` | PollAsync, SeekAsync, CommitAsync | Long-polling consumer API |
| `Inbound` | ListConfigsAsync, CreateConfigAsync, HandleInboundAsync | Inbound webhook proxy |
| `Connector` | ListAsync, GetAsync, ListConfigsAsync, CreateConfigAsync, UpdateConfigAsync, DeleteConfigAsync | Third-party connectors |
| `Integrations` | ListAsync, GetAsync, CreateAsync, UpdateAsync, DeleteAsync, TestAsync, ListEventsAsync, GetStatsAsync | Integration management |
| `Stream` | ListChannelsAsync, GetChannelAsync, CreateChannelAsync, UpdateChannelAsync, DeleteChannelAsync, ListMessagesAsync, ListSubscriptionsAsync, DisconnectSubscriptionAsync, PublishEventAsync | Real-time streaming |

### Additional Resources

| Resource | Description |
|----------|-------------|
| `Application` | Application management |
| `ApiKey` | API key CRUD, rotate |
| `Search` | Full-text delivery search |
| `Alert` | Alert rule CRUD, test |
| `Analytics` | Delivery trends, success rate, latency |
| `Billing` | Subscription, usage, invoices, portal |
| `Portal` | Profile, plan, notifications |
| `Team` | Teams, invites, members, roles |
| `Notification` | List, read, unread count |
| `Sso` | SSO config management |
| `AuditLog` | Audit entry listing |
| `CustomDomain` | Domain management, verification |
| `RateLimit` | Per-endpoint rate limits |
| `Routing` | Routing rules, endpoint health |
| `Template` | Template listing, apply |
| `Schema` | Schema registry, validation |
| `Playground` | Test webhooks |
| `ServiceToken` | Service token management |

## Error Handling

The SDK throws `ApiException` for HTTP errors with status code and response body:

```csharp
using HookSniff;

try
{
    var endpoint = await client.Endpoint.GetAsync("app_xxx", "ep_xxx");
}
catch (ApiException ex)
{
    Console.WriteLine($"Status: {ex.ErrorCode}");     // e.g., 404
    Console.WriteLine($"Body: {ex.ErrorContent}");     // JSON error response
    Console.WriteLine($"Message: {ex.Message}");       // Error description
}
```

### Common Status Codes

| Code | Meaning |
|------|---------|
| 400 | Bad Request — check your input |
| 401 | Unauthorized — invalid or missing token |
| 403 | Forbidden — insufficient permissions |
| 404 | Not Found — resource doesn't exist |
| 409 | Conflict — duplicate resource |
| 422 | Validation Error — invalid parameters |
| 429 | Rate Limited — auto-retry with backoff |
| 500 | Server Error — retry later |

## Rate Limiting

The SDK automatically handles 429 rate limit responses:
- Reads the `Retry-After` header
- Waits the specified duration
- Retries the request automatically

For 5xx server errors, the SDK retries with exponential backoff using the configured retry schedule.

## Requirements

- .NET 8.0+
- Newtonsoft.Json 13.0+

## Links

- 📖 [Documentation](https://hooksniff.vercel.app/docs)
- 🔑 [API Reference](https://hooksniff.vercel.app/docs)
- 💰 [Pricing](https://hooksniff.vercel.app/pricing)
- 🐛 [Report a Bug](https://github.com/servetarslan02/hooksniff-csharp/issues)
- 💬 [GitHub Discussions](https://github.com/servetarslan02/HookSniff/discussions)

## License

MIT — see [LICENSE](LICENSE) for details.
