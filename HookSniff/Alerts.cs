#nullable enable
using Microsoft.Extensions.Logging;
using HookSniff.Models;

namespace HookSniff
{
    public class Alert(HookSniffClient client)
    {
        readonly HookSniffClient _client = client;

        public async Task<ListResponseAlertRuleOut> ListAsync(CancellationToken ct = default)
        {
            var r = await _client.HookSniffHttpClient.SendRequestAsync<ListResponseAlertRuleOut>(HttpMethod.Get, "/api/v1/alerts", cancellationToken: ct);
            return r.Data;
        }

        public ListResponseAlertRuleOut List()
        {
            var r = _client.HookSniffHttpClient.SendRequest<ListResponseAlertRuleOut>(HttpMethod.Get, "/api/v1/alerts");
            return r.Data;
        }

        public async Task<AlertRuleOut> GetAsync(string id, CancellationToken ct = default)
        {
            var r = await _client.HookSniffHttpClient.SendRequestAsync<AlertRuleOut>(HttpMethod.Get, $"/api/v1/alerts/{id}", cancellationToken: ct);
            return r.Data;
        }

        public AlertRuleOut Get(string id)
        {
            var r = _client.HookSniffHttpClient.SendRequest<AlertRuleOut>(HttpMethod.Get, $"/api/v1/alerts/{id}");
            return r.Data;
        }

        public async Task<AlertRuleOut> CreateAsync(CreateAlertRequest req, CancellationToken ct = default)
        {
            var r = await _client.HookSniffHttpClient.SendRequestAsync<AlertRuleOut>(HttpMethod.Post, "/api/v1/alerts", content: req, cancellationToken: ct);
            return r.Data;
        }

        public AlertRuleOut Create(CreateAlertRequest req)
        {
            var r = _client.HookSniffHttpClient.SendRequest<AlertRuleOut>(HttpMethod.Post, "/api/v1/alerts", content: req);
            return r.Data;
        }

        public async Task<AlertRuleOut> UpdateAsync(string id, UpdateAlertRequest req, CancellationToken ct = default)
        {
            var r = await _client.HookSniffHttpClient.SendRequestAsync<AlertRuleOut>(HttpMethod.Put, $"/api/v1/alerts/{id}", content: req, cancellationToken: ct);
            return r.Data;
        }

        public AlertRuleOut Update(string id, UpdateAlertRequest req)
        {
            var r = _client.HookSniffHttpClient.SendRequest<AlertRuleOut>(HttpMethod.Put, $"/api/v1/alerts/{id}", content: req);
            return r.Data;
        }

        public async Task DeleteAsync(string id, CancellationToken ct = default)
        {
            await _client.HookSniffHttpClient.SendRequestAsync<bool>(HttpMethod.Delete, $"/api/v1/alerts/{id}", cancellationToken: ct);
        }

        public void Delete(string id)
        {
            _client.HookSniffHttpClient.SendRequest<bool>(HttpMethod.Delete, $"/api/v1/alerts/{id}");
        }

        public async Task TestAsync(string id, CancellationToken ct = default)
        {
            await _client.HookSniffHttpClient.SendRequestAsync<bool>(HttpMethod.Post, $"/api/v1/alerts/{id}/test", cancellationToken: ct);
        }

        public void Test(string id)
        {
            _client.HookSniffHttpClient.SendRequest<bool>(HttpMethod.Post, $"/api/v1/alerts/{id}/test");
        }
    }
}
