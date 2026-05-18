#nullable enable
using Microsoft.Extensions.Logging;
using HookSniff.Models;

namespace HookSniff
{
    public class CustomDomain(HookSniffClient client)
    {
        readonly HookSniffClient _client = client;

        public async Task<List<CustomDomainOut>> ListAsync(CancellationToken ct = default)
        {
            var r = await _client.HookSniffHttpClient.SendRequestAsync<List<CustomDomainOut>>(HttpMethod.Get, "/api/v1/custom-domains", cancellationToken: ct);
            return r.Data;
        }

        public List<CustomDomainOut> List()
        {
            var r = _client.HookSniffHttpClient.SendRequest<List<CustomDomainOut>>(HttpMethod.Get, "/api/v1/custom-domains");
            return r.Data;
        }

        public async Task<CustomDomainOut> AddAsync(AddDomainRequest req, CancellationToken ct = default)
        {
            var r = await _client.HookSniffHttpClient.SendRequestAsync<CustomDomainOut>(HttpMethod.Post, "/api/v1/custom-domains", content: req, cancellationToken: ct);
            return r.Data;
        }

        public CustomDomainOut Add(AddDomainRequest req)
        {
            var r = _client.HookSniffHttpClient.SendRequest<CustomDomainOut>(HttpMethod.Post, "/api/v1/custom-domains", content: req);
            return r.Data;
        }

        public async Task DeleteAsync(string id, CancellationToken ct = default)
        {
            await _client.HookSniffHttpClient.SendRequestAsync<bool>(HttpMethod.Delete, $"/api/v1/custom-domains/{id}", cancellationToken: ct);
        }

        public void Delete(string id)
        {
            _client.HookSniffHttpClient.SendRequest<bool>(HttpMethod.Delete, $"/api/v1/custom-domains/{id}");
        }

        public async Task VerifyAsync(string id, CancellationToken ct = default)
        {
            await _client.HookSniffHttpClient.SendRequestAsync<bool>(HttpMethod.Post, $"/api/v1/custom-domains/{id}/verify", cancellationToken: ct);
        }

        public void Verify(string id)
        {
            _client.HookSniffHttpClient.SendRequest<bool>(HttpMethod.Post, $"/api/v1/custom-domains/{id}/verify");
        }
    }
}
