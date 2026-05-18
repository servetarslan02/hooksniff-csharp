# Changelog

## 1.2.0 (2026-05-18)

### Bug Fixes
- **Fixed all API paths**: `/api/v1/*` → `/v1/*` (296 occurrences) — HookSniff native format
- **Fixed DEFAULT_SERVER_URL**: `api.hooksniff-*` → `hooksniff-api-*` (correct Cloud Run URL)
- **Fixed WebhookTest**: Svix branded headers → HookSniff branded headers
- **Fixed WebhookTest**: Dictionary-based headers now use proper `Func<string?, string?>` overload

### New Features
- **Environment** resource — Manage environments (dev/staging/prod) and their variables
- **BackgroundTask** resource — List, get, and cancel async background tasks
- **OperationalWebhook** resource — Operational webhook endpoint management
- **MessagePoller** resource — Long-polling consumer API (poll, seek, commit)
- **Inbound** resource — Inbound webhook proxy configurations
- **Connector** resource — Third-party connector management
- **Integrations** resource — Full integration CRUD with test, events, and stats
- **Stream** resource — Real-time streaming channels, subscriptions, and message publishing
- **18 additional resources**: Application, ApiKey, Search, Alert, Analytics, Billing, Portal, Team, Notification, SSO, AuditLog, CustomDomain, RateLimit, Routing, Template, Schema, Playground, ServiceToken

## 1.1.0 (2026-05-17)

- Initial release with core resources
- Webhook signature verification (HMAC-SHA256)
- Automatic retry with exponential backoff
- Rate limit handling (429)

## 1.0.0 (2026-05-10)

- Initial SDK based on Svix SDK
