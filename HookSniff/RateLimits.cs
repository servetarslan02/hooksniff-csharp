#nullable enable
using Microsoft.Extensions.Logging;
using HookSniff.Models;

namespace HookSniff
{
    public class RateLimit(HookSniffClient client)
    {
        readonly HookSniffClient _client = client;

        public async Task<List<RateLimitOut>> ListAsync(CancellationToken ct = default)
        {
            var r = await _client.HookSniffHttpClient.SendRequestAsync<List<RateLimitOut>>(HttpMethod.Get, "/v1/rate-limits", cancellationToken: ct);
            return r.Data;
        }

        public List<RateLimitOut> List()
        {
            var r = _client.HookSniffHttpClient.SendRequest<List<RateLimitOut>>(HttpMethod.Get, "/v1/rate-limits");
            return r.Data;
        }

        public async Task<RateLimitOut> GetAsync(string endpointId, CancellationToken ct = default)
        {
            var r = await _client.HookSniffHttpClient.SendRequestAsync<RateLimitOut>(HttpMethod.Get, $"/v1/rate-limits/{endpointId}", cancellationToken: ct);
            return r.Data;
        }

        public RateLimitOut Get(string endpointId)
        {
            var r = _client.HookSniffHttpClient.SendRequest<RateLimitOut>(HttpMethod.Get, $"/v1/rate-limits/{endpointId}");
            return r.Data;
        }

        public async Task SetAsync(string endpointId, SetRateLimitRequest req, CancellationToken ct = default)
        {
            await _client.HookSniffHttpClient.SendRequestAsync<bool>(HttpMethod.Post, $"/v1/rate-limits/{endpointId}", content: req, cancellationToken: ct);
        }

        public void Set(string endpointId, SetRateLimitRequest req)
        {
            _client.HookSniffHttpClient.SendRequest<bool>(HttpMethod.Post, $"/v1/rate-limits/{endpointId}", content: req);
        }

        public async Task DeleteAsync(string endpointId, CancellationToken ct = default)
        {
            await _client.HookSniffHttpClient.SendRequestAsync<bool>(HttpMethod.Delete, $"/v1/rate-limits/{endpointId}", cancellationToken: ct);
        }

        public void Delete(string endpointId)
        {
            _client.HookSniffHttpClient.SendRequest<bool>(HttpMethod.Delete, $"/v1/rate-limits/{endpointId}");
        }
    }
}
