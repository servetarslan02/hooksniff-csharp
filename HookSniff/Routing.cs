#nullable enable
using Microsoft.Extensions.Logging;
using HookSniff.Models;

namespace HookSniff
{
    public class Routing(HookSniffClient client)
    {
        readonly HookSniffClient _client = client;

        public async Task<RoutingInfoOut> GetAsync(string endpointId, CancellationToken ct = default)
        {
            var r = await _client.HookSniffHttpClient.SendRequestAsync<RoutingInfoOut>(HttpMethod.Get, $"/api/v1/routing/{endpointId}/routing", cancellationToken: ct);
            return r.Data;
        }

        public RoutingInfoOut Get(string endpointId)
        {
            var r = _client.HookSniffHttpClient.SendRequest<RoutingInfoOut>(HttpMethod.Get, $"/api/v1/routing/{endpointId}/routing");
            return r.Data;
        }

        public async Task<RoutingInfoOut> UpdateAsync(string endpointId, UpdateRoutingRequest req, CancellationToken ct = default)
        {
            var r = await _client.HookSniffHttpClient.SendRequestAsync<RoutingInfoOut>(HttpMethod.Put, $"/api/v1/routing/{endpointId}/routing", content: req, cancellationToken: ct);
            return r.Data;
        }

        public RoutingInfoOut Update(string endpointId, UpdateRoutingRequest req)
        {
            var r = _client.HookSniffHttpClient.SendRequest<RoutingInfoOut>(HttpMethod.Put, $"/api/v1/routing/{endpointId}/routing", content: req);
            return r.Data;
        }

        public async Task<EndpointHealthOut> GetHealthAsync(string endpointId, CancellationToken ct = default)
        {
            var r = await _client.HookSniffHttpClient.SendRequestAsync<EndpointHealthOut>(HttpMethod.Get, $"/api/v1/routing/{endpointId}/health", cancellationToken: ct);
            return r.Data;
        }

        public EndpointHealthOut GetHealth(string endpointId)
        {
            var r = _client.HookSniffHttpClient.SendRequest<EndpointHealthOut>(HttpMethod.Get, $"/api/v1/routing/{endpointId}/health");
            return r.Data;
        }
    }
}
