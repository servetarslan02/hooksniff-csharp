#nullable enable
using Microsoft.Extensions.Logging;
using HookSniff.Models;

namespace HookSniff
{
    public class IntegrationListOptions : HookSniffOptionsBase
    {
        public ulong? Limit { get; set; }
        public string? Type { get; set; }

        public new Dictionary<string, string> QueryParams()
        {
            return SerializeParams(new Dictionary<string, object?> {
                { "limit", Limit }, { "type", Type }
            });
        }
    }

    public class Integrations(HookSniffClient client)
    {
        readonly HookSniffClient _client = client;

        public async Task<List<IntegrationOut>> ListAsync(IntegrationListOptions? options = null, CancellationToken ct = default)
        {
            var r = await _client.HookSniffHttpClient.SendRequestAsync<List<IntegrationOut>>(HttpMethod.Get, "/api/v1/integrations", queryParams: options?.QueryParams(), cancellationToken: ct);
            return r.Data;
        }

        public List<IntegrationOut> List(IntegrationListOptions? options = null)
        {
            var r = _client.HookSniffHttpClient.SendRequest<List<IntegrationOut>>(HttpMethod.Get, "/api/v1/integrations", queryParams: options?.QueryParams());
            return r.Data;
        }

        public async Task<IntegrationOut> GetAsync(string id, CancellationToken ct = default)
        {
            var r = await _client.HookSniffHttpClient.SendRequestAsync<IntegrationOut>(HttpMethod.Get, $"/api/v1/integrations/{id}", cancellationToken: ct);
            return r.Data;
        }

        public IntegrationOut Get(string id)
        {
            var r = _client.HookSniffHttpClient.SendRequest<IntegrationOut>(HttpMethod.Get, $"/api/v1/integrations/{id}");
            return r.Data;
        }

        public async Task<IntegrationOut> CreateAsync(CreateIntegrationRequest req, CancellationToken ct = default)
        {
            var r = await _client.HookSniffHttpClient.SendRequestAsync<IntegrationOut>(HttpMethod.Post, "/api/v1/integrations", content: req, cancellationToken: ct);
            return r.Data;
        }

        public IntegrationOut Create(CreateIntegrationRequest req)
        {
            var r = _client.HookSniffHttpClient.SendRequest<IntegrationOut>(HttpMethod.Post, "/api/v1/integrations", content: req);
            return r.Data;
        }

        public async Task<IntegrationOut> UpdateAsync(string id, UpdateIntegrationRequest req, CancellationToken ct = default)
        {
            var r = await _client.HookSniffHttpClient.SendRequestAsync<IntegrationOut>(HttpMethod.Put, $"/api/v1/integrations/{id}", content: req, cancellationToken: ct);
            return r.Data;
        }

        public IntegrationOut Update(string id, UpdateIntegrationRequest req)
        {
            var r = _client.HookSniffHttpClient.SendRequest<IntegrationOut>(HttpMethod.Put, $"/api/v1/integrations/{id}", content: req);
            return r.Data;
        }

        public async Task DeleteAsync(string id, CancellationToken ct = default)
        {
            await _client.HookSniffHttpClient.SendRequestAsync<bool>(HttpMethod.Delete, $"/api/v1/integrations/{id}", cancellationToken: ct);
        }

        public void Delete(string id)
        {
            _client.HookSniffHttpClient.SendRequest<bool>(HttpMethod.Delete, $"/api/v1/integrations/{id}");
        }

        public async Task TestAsync(string id, CancellationToken ct = default)
        {
            await _client.HookSniffHttpClient.SendRequestAsync<bool>(HttpMethod.Post, $"/api/v1/integrations/{id}/test", cancellationToken: ct);
        }

        public void Test(string id)
        {
            _client.HookSniffHttpClient.SendRequest<bool>(HttpMethod.Post, $"/api/v1/integrations/{id}/test");
        }

        public async Task<List<IntegrationEventOut>> ListEventsAsync(string id, CancellationToken ct = default)
        {
            var r = await _client.HookSniffHttpClient.SendRequestAsync<List<IntegrationEventOut>>(HttpMethod.Get, $"/api/v1/integrations/{id}/events", cancellationToken: ct);
            return r.Data;
        }

        public List<IntegrationEventOut> ListEvents(string id)
        {
            var r = _client.HookSniffHttpClient.SendRequest<List<IntegrationEventOut>>(HttpMethod.Get, $"/api/v1/integrations/{id}/events");
            return r.Data;
        }

        public async Task<IntegrationStatsOut> GetStatsAsync(string id, CancellationToken ct = default)
        {
            var r = await _client.HookSniffHttpClient.SendRequestAsync<IntegrationStatsOut>(HttpMethod.Get, $"/api/v1/integrations/{id}/stats", cancellationToken: ct);
            return r.Data;
        }

        public IntegrationStatsOut GetStats(string id)
        {
            var r = _client.HookSniffHttpClient.SendRequest<IntegrationStatsOut>(HttpMethod.Get, $"/api/v1/integrations/{id}/stats");
            return r.Data;
        }
    }
}
