#nullable enable
using Microsoft.Extensions.Logging;
using HookSniff.Models;

namespace HookSniff
{
    public class ServiceToken(HookSniffClient client)
    {
        readonly HookSniffClient _client = client;

        public async Task<ListResponseServiceTokenOut> ListAsync(CancellationToken ct = default)
        {
            var r = await _client.HookSniffHttpClient.SendRequestAsync<ListResponseServiceTokenOut>(HttpMethod.Get, "/v1/service-tokens", cancellationToken: ct);
            return r.Data;
        }

        public ListResponseServiceTokenOut List()
        {
            var r = _client.HookSniffHttpClient.SendRequest<ListResponseServiceTokenOut>(HttpMethod.Get, "/v1/service-tokens");
            return r.Data;
        }

        public async Task<ServiceTokenOut> CreateAsync(CreateServiceTokenRequest req, CancellationToken ct = default)
        {
            var r = await _client.HookSniffHttpClient.SendRequestAsync<ServiceTokenOut>(HttpMethod.Post, "/v1/service-tokens", content: req, cancellationToken: ct);
            return r.Data;
        }

        public ServiceTokenOut Create(CreateServiceTokenRequest req)
        {
            var r = _client.HookSniffHttpClient.SendRequest<ServiceTokenOut>(HttpMethod.Post, "/v1/service-tokens", content: req);
            return r.Data;
        }

        public async Task DeleteAsync(string id, CancellationToken ct = default)
        {
            await _client.HookSniffHttpClient.SendRequestAsync<bool>(HttpMethod.Delete, $"/v1/service-tokens/{id}", cancellationToken: ct);
        }

        public void Delete(string id)
        {
            _client.HookSniffHttpClient.SendRequest<bool>(HttpMethod.Delete, $"/v1/service-tokens/{id}");
        }
    }
}
