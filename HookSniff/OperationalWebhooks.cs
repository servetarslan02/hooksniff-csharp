#nullable enable
using Microsoft.Extensions.Logging;
using HookSniff.Models;

namespace HookSniff
{
    public class OperationalWebhookListOptions : HookSniffOptionsBase
    {
        public ulong? Limit { get; set; }
        public string? Iterator { get; set; }

        public new Dictionary<string, string> QueryParams()
        {
            return SerializeParams(new Dictionary<string, object?> {
                { "limit", Limit }, { "iterator", Iterator }
            });
        }
    }

    public class OperationalWebhook(HookSniffClient client)
    {
        readonly HookSniffClient _client = client;

        public async Task<List<OpWebhookEndpointOut>> ListEndpointsAsync(OperationalWebhookListOptions? options = null, CancellationToken ct = default)
        {
            var r = await _client.HookSniffHttpClient.SendRequestAsync<List<OpWebhookEndpointOut>>(HttpMethod.Get, "/api/v1/operational-webhooks", queryParams: options?.QueryParams(), cancellationToken: ct);
            return r.Data;
        }

        public List<OpWebhookEndpointOut> ListEndpoints(OperationalWebhookListOptions? options = null)
        {
            var r = _client.HookSniffHttpClient.SendRequest<List<OpWebhookEndpointOut>>(HttpMethod.Get, "/api/v1/operational-webhooks", queryParams: options?.QueryParams());
            return r.Data;
        }

        public async Task<OpWebhookEndpointOut> GetEndpointAsync(string id, CancellationToken ct = default)
        {
            var r = await _client.HookSniffHttpClient.SendRequestAsync<OpWebhookEndpointOut>(HttpMethod.Get, $"/api/v1/operational-webhooks/{id}", cancellationToken: ct);
            return r.Data;
        }

        public OpWebhookEndpointOut GetEndpoint(string id)
        {
            var r = _client.HookSniffHttpClient.SendRequest<OpWebhookEndpointOut>(HttpMethod.Get, $"/api/v1/operational-webhooks/{id}");
            return r.Data;
        }

        public async Task<OpWebhookEndpointOut> CreateEndpointAsync(CreateOpWebhookEndpointRequest req, CancellationToken ct = default)
        {
            var r = await _client.HookSniffHttpClient.SendRequestAsync<OpWebhookEndpointOut>(HttpMethod.Post, "/api/v1/operational-webhooks", content: req, cancellationToken: ct);
            return r.Data;
        }

        public OpWebhookEndpointOut CreateEndpoint(CreateOpWebhookEndpointRequest req)
        {
            var r = _client.HookSniffHttpClient.SendRequest<OpWebhookEndpointOut>(HttpMethod.Post, "/api/v1/operational-webhooks", content: req);
            return r.Data;
        }

        public async Task<OpWebhookEndpointOut> UpdateEndpointAsync(string id, UpdateOpWebhookEndpointRequest req, CancellationToken ct = default)
        {
            var r = await _client.HookSniffHttpClient.SendRequestAsync<OpWebhookEndpointOut>(HttpMethod.Put, $"/api/v1/operational-webhooks/{id}", content: req, cancellationToken: ct);
            return r.Data;
        }

        public OpWebhookEndpointOut UpdateEndpoint(string id, UpdateOpWebhookEndpointRequest req)
        {
            var r = _client.HookSniffHttpClient.SendRequest<OpWebhookEndpointOut>(HttpMethod.Put, $"/api/v1/operational-webhooks/{id}", content: req);
            return r.Data;
        }

        public async Task DeleteEndpointAsync(string id, CancellationToken ct = default)
        {
            await _client.HookSniffHttpClient.SendRequestAsync<bool>(HttpMethod.Delete, $"/api/v1/operational-webhooks/{id}", cancellationToken: ct);
        }

        public void DeleteEndpoint(string id)
        {
            _client.HookSniffHttpClient.SendRequest<bool>(HttpMethod.Delete, $"/api/v1/operational-webhooks/{id}");
        }

        public async Task<List<OpWebhookDeliveryOut>> ListDeliveriesAsync(string endpointId, CancellationToken ct = default)
        {
            var r = await _client.HookSniffHttpClient.SendRequestAsync<List<OpWebhookDeliveryOut>>(HttpMethod.Get, $"/api/v1/operational-webhooks/{endpointId}/deliveries", cancellationToken: ct);
            return r.Data;
        }

        public List<OpWebhookDeliveryOut> ListDeliveries(string endpointId)
        {
            var r = _client.HookSniffHttpClient.SendRequest<List<OpWebhookDeliveryOut>>(HttpMethod.Get, $"/api/v1/operational-webhooks/{endpointId}/deliveries");
            return r.Data;
        }
    }
}
