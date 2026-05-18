#nullable enable
using Microsoft.Extensions.Logging;
using HookSniff.Models;

namespace HookSniff
{
    public class ApiKey(HookSniffClient client)
    {
        readonly HookSniffClient _client = client;

        public async Task<ListResponseApiKeyOut> ListAsync(CancellationToken ct = default)
        {
            var r = await _client.HookSniffHttpClient.SendRequestAsync<ListResponseApiKeyOut>(HttpMethod.Get, "/api/v1/api-keys", cancellationToken: ct);
            return r.Data;
        }

        public ListResponseApiKeyOut List()
        {
            var r = _client.HookSniffHttpClient.SendRequest<ListResponseApiKeyOut>(HttpMethod.Get, "/api/v1/api-keys");
            return r.Data;
        }

        public async Task<CreateApiKeyOut> CreateAsync(CreateApiKeyRequest req, CancellationToken ct = default)
        {
            var r = await _client.HookSniffHttpClient.SendRequestAsync<CreateApiKeyOut>(HttpMethod.Post, "/api/v1/api-keys", content: req, cancellationToken: ct);
            return r.Data;
        }

        public CreateApiKeyOut Create(CreateApiKeyRequest req)
        {
            var r = _client.HookSniffHttpClient.SendRequest<CreateApiKeyOut>(HttpMethod.Post, "/api/v1/api-keys", content: req);
            return r.Data;
        }

        public async Task DeleteAsync(string id, CancellationToken ct = default)
        {
            await _client.HookSniffHttpClient.SendRequestAsync<bool>(HttpMethod.Delete, $"/api/v1/api-keys/{id}", cancellationToken: ct);
        }

        public void Delete(string id)
        {
            _client.HookSniffHttpClient.SendRequest<bool>(HttpMethod.Delete, $"/api/v1/api-keys/{id}");
        }

        public async Task<CreateApiKeyOut> RotateAsync(string id, CancellationToken ct = default)
        {
            var r = await _client.HookSniffHttpClient.SendRequestAsync<CreateApiKeyOut>(HttpMethod.Post, $"/api/v1/api-keys/{id}/rotate", cancellationToken: ct);
            return r.Data;
        }

        public CreateApiKeyOut Rotate(string id)
        {
            var r = _client.HookSniffHttpClient.SendRequest<CreateApiKeyOut>(HttpMethod.Post, $"/api/v1/api-keys/{id}/rotate");
            return r.Data;
        }
    }
}
