#nullable enable
using Microsoft.Extensions.Logging;
using HookSniff.Models;

namespace HookSniff
{
    public class Billing(HookSniffClient client)
    {
        readonly HookSniffClient _client = client;

        public async Task<BillingSubscriptionOut> GetSubscriptionAsync(CancellationToken ct = default)
        {
            var r = await _client.HookSniffHttpClient.SendRequestAsync<BillingSubscriptionOut>(HttpMethod.Get, "/v1/billing/subscription", cancellationToken: ct);
            return r.Data;
        }

        public BillingSubscriptionOut GetSubscription()
        {
            var r = _client.HookSniffHttpClient.SendRequest<BillingSubscriptionOut>(HttpMethod.Get, "/v1/billing/subscription");
            return r.Data;
        }

        public async Task CancelSubscriptionAsync(CancellationToken ct = default)
        {
            await _client.HookSniffHttpClient.SendRequestAsync<bool>(HttpMethod.Delete, "/v1/billing/subscription", cancellationToken: ct);
        }

        public void CancelSubscription()
        {
            _client.HookSniffHttpClient.SendRequest<bool>(HttpMethod.Delete, "/v1/billing/subscription");
        }

        public async Task<BillingSubscriptionOut> UpgradeAsync(UpgradePlanRequest req, CancellationToken ct = default)
        {
            var r = await _client.HookSniffHttpClient.SendRequestAsync<BillingSubscriptionOut>(HttpMethod.Post, "/v1/billing/upgrade", content: req, cancellationToken: ct);
            return r.Data;
        }

        public BillingSubscriptionOut Upgrade(UpgradePlanRequest req)
        {
            var r = _client.HookSniffHttpClient.SendRequest<BillingSubscriptionOut>(HttpMethod.Post, "/v1/billing/upgrade", content: req);
            return r.Data;
        }

        public async Task<string> OpenPortalAsync(CancellationToken ct = default)
        {
            var r = await _client.HookSniffHttpClient.SendRequestAsync<Dictionary<string, string>>(HttpMethod.Post, "/v1/billing/portal", cancellationToken: ct);
            return r.Data.ContainsKey("url") ? r.Data["url"] : "";
        }

        public string OpenPortal()
        {
            var r = _client.HookSniffHttpClient.SendRequest<Dictionary<string, string>>(HttpMethod.Post, "/v1/billing/portal");
            return r.Data.ContainsKey("url") ? r.Data["url"] : "";
        }

        public async Task<BillingUsageOut> GetUsageAsync(CancellationToken ct = default)
        {
            var r = await _client.HookSniffHttpClient.SendRequestAsync<BillingUsageOut>(HttpMethod.Get, "/v1/billing/usage", cancellationToken: ct);
            return r.Data;
        }

        public BillingUsageOut GetUsage()
        {
            var r = _client.HookSniffHttpClient.SendRequest<BillingUsageOut>(HttpMethod.Get, "/v1/billing/usage");
            return r.Data;
        }

        public async Task<ListResponseInvoiceOut> GetInvoicesAsync(CancellationToken ct = default)
        {
            var r = await _client.HookSniffHttpClient.SendRequestAsync<ListResponseInvoiceOut>(HttpMethod.Get, "/v1/billing/invoices", cancellationToken: ct);
            return r.Data;
        }

        public ListResponseInvoiceOut GetInvoices()
        {
            var r = _client.HookSniffHttpClient.SendRequest<ListResponseInvoiceOut>(HttpMethod.Get, "/v1/billing/invoices");
            return r.Data;
        }
    }
}
