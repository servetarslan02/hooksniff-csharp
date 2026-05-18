#nullable enable
using Microsoft.Extensions.Logging;
using HookSniff.Models;

namespace HookSniff
{
    public class Portal(HookSniffClient client)
    {
        readonly HookSniffClient _client = client;

        public async Task<PortalProfileOut> GetProfileAsync(CancellationToken ct = default)
        {
            var r = await _client.HookSniffHttpClient.SendRequestAsync<PortalProfileOut>(HttpMethod.Get, "/api/v1/portal/me", cancellationToken: ct);
            return r.Data;
        }

        public PortalProfileOut GetProfile()
        {
            var r = _client.HookSniffHttpClient.SendRequest<PortalProfileOut>(HttpMethod.Get, "/api/v1/portal/me");
            return r.Data;
        }

        public async Task<PortalProfileOut> UpdateProfileAsync(UpdatePortalProfileRequest req, CancellationToken ct = default)
        {
            var r = await _client.HookSniffHttpClient.SendRequestAsync<PortalProfileOut>(HttpMethod.Put, "/api/v1/portal/me", content: req, cancellationToken: ct);
            return r.Data;
        }

        public PortalProfileOut UpdateProfile(UpdatePortalProfileRequest req)
        {
            var r = _client.HookSniffHttpClient.SendRequest<PortalProfileOut>(HttpMethod.Put, "/api/v1/portal/me", content: req);
            return r.Data;
        }

        public async Task<PortalUsageOut> GetUsageAsync(CancellationToken ct = default)
        {
            var r = await _client.HookSniffHttpClient.SendRequestAsync<PortalUsageOut>(HttpMethod.Get, "/api/v1/portal/usage", cancellationToken: ct);
            return r.Data;
        }

        public PortalUsageOut GetUsage()
        {
            var r = _client.HookSniffHttpClient.SendRequest<PortalUsageOut>(HttpMethod.Get, "/api/v1/portal/usage");
            return r.Data;
        }

        public async Task<PortalPlanOut> GetPlanAsync(CancellationToken ct = default)
        {
            var r = await _client.HookSniffHttpClient.SendRequestAsync<PortalPlanOut>(HttpMethod.Get, "/api/v1/portal/plan", cancellationToken: ct);
            return r.Data;
        }

        public PortalPlanOut GetPlan()
        {
            var r = _client.HookSniffHttpClient.SendRequest<PortalPlanOut>(HttpMethod.Get, "/api/v1/portal/plan");
            return r.Data;
        }

        public async Task<List<PortalNotificationOut>> GetNotificationsAsync(CancellationToken ct = default)
        {
            var r = await _client.HookSniffHttpClient.SendRequestAsync<List<PortalNotificationOut>>(HttpMethod.Get, "/api/v1/portal/notifications", cancellationToken: ct);
            return r.Data;
        }

        public List<PortalNotificationOut> GetNotifications()
        {
            var r = _client.HookSniffHttpClient.SendRequest<List<PortalNotificationOut>>(HttpMethod.Get, "/api/v1/portal/notifications");
            return r.Data;
        }

        public async Task UpdateNotificationsAsync(UpdatePortalNotificationsRequest req, CancellationToken ct = default)
        {
            await _client.HookSniffHttpClient.SendRequestAsync<bool>(HttpMethod.Put, "/api/v1/portal/notifications", content: req, cancellationToken: ct);
        }

        public void UpdateNotifications(UpdatePortalNotificationsRequest req)
        {
            _client.HookSniffHttpClient.SendRequest<bool>(HttpMethod.Put, "/api/v1/portal/notifications", content: req);
        }
    }
}
