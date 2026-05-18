# HookSniff C# SDK

<p align="center">
  <a href="https://github.com/servetarslan02/HookSniff"><img src="https://img.shields.io/github/license/servetarslan02/HookSniff" alt="License"></a>
  <a href="https://www.nuget.org/packages/HookSniff"><img src="https://img.shields.io/nuget/v/HookSniff" alt="NuGet"></a>
</p>

C# SDK for the [HookSniff](https://hooksniff.com) webhook delivery platform.

## Installation

```bash
dotnet add package HookSniff
```

## Quick Start

```csharp
var client = new HookSniffClient("hs_xxx");

// List endpoints
var endpoints = await client.Endpoint.ListAsync();

// Create a webhook message
var msg = await client.Message.CreateAsync(new MessageIn { ... });

// Verify webhook signature
var wh = new Webhook("whsec_xxx");
wh.Verify(body, headers);
```

## Resources

| Resource | Description |
|----------|-------------|
| **Endpoint** | CRUD, secret rotation, health check |
| **Message** | Create, list, get messages |
| **MessageAttempt** | List by endpoint/msg, get, resend |
| **Authentication** | Logout |
| **EventType** | CRUD, import from OpenAPI |
| **Statistics** | Aggregate app stats |
| **Environment** | Environment & variable management (Faz 8) |
| **BackgroundTask** | List, get, cancel tasks (Faz 9) |
| **OperationalWebhook** | Endpoint & delivery management (Faz 10) |
| **MessagePoller** | Poll, seek, commit cursors (Faz 11) |
| **Inbound** | Inbound webhook configs (Faz 12) |
| **Connector** | Connector & config management (Faz 13) |
| **Integrations** | CRUD, test, events, stats (Faz 14) |
| **Stream** | Channels, subscriptions, publish (Faz 15) |
| **Application** | Application management |
| **ApiKey** | API key CRUD, rotate |
| **Search** | Full-text delivery search |
| **Alert** | Alert rule CRUD, test |
| **Analytics** | Delivery trends, success rate, latency |
| **Billing** | Subscription, usage, invoices, portal |
| **Portal** | Profile, plan, notifications |
| **Team** | Teams, invites, members, roles |
| **Notification** | List, read, unread count |
| **SSO** | SSO config management |
| **AuditLog** | Audit entry listing |
| **CustomDomain** | Domain management, verification |
| **RateLimit** | Per-endpoint rate limits |
| **Routing** | Routing rules, endpoint health |
| **Template** | Template listing, apply |
| **Schema** | Schema registry, validation |
| **Playground** | Test webhooks |
| **ServiceToken** | Service token management |

## Webhook Verification

```csharp
var wh = new Webhook("whsec_xxx");
var payload = wh.Verify(body, headers);
```

## Links

- [Documentation](https://docs.hooksniff.com)
- [API Reference](https://api.hooksniff.com)
- [GitHub](https://github.com/servetarslan02/HookSniff)
