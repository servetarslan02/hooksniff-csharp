#nullable enable
using Microsoft.Extensions.Logging;
using HookSniff.Models;

namespace HookSniff
{
    public class ApplicationListOptions : HookSniffOptionsBase
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

    public class Application(HookSniffClient client)
    {
        readonly HookSniffClient _client = client;

        public async Task<ListResponseApplicationOut> ListAsync(ApplicationListOptions? options = null, CancellationToken ct = default)
        {
            var r = await _client.HookSniffHttpClient.SendRequestAsync<ListResponseApplicationOut>(HttpMethod.Get, "/api/v1/applications", queryParams: options?.QueryParams(), cancellationToken: ct);
            return r.Data;
        }

        public ListResponseApplicationOut List(ApplicationListOptions? options = null)
        {
            var r = _client.HookSniffHttpClient.SendRequest<ListResponseApplicationOut>(HttpMethod.Get, "/api/v1/applications", queryParams: options?.QueryParams());
            return r.Data;
        }

        public async Task<ApplicationOut> GetAsync(string id, CancellationToken ct = default)
        {
            var r = await _client.HookSniffHttpClient.SendRequestAsync<ApplicationOut>(HttpMethod.Get, $"/api/v1/applications/{id}", cancellationToken: ct);
            return r.Data;
        }

        public ApplicationOut Get(string id)
        {
            var r = _client.HookSniffHttpClient.SendRequest<ApplicationOut>(HttpMethod.Get, $"/api/v1/applications/{id}");
            return r.Data;
        }

        public async Task<ApplicationOut> CreateAsync(CreateApplicationRequest req, CancellationToken ct = default)
        {
            var r = await _client.HookSniffHttpClient.SendRequestAsync<ApplicationOut>(HttpMethod.Post, "/api/v1/applications", content: req, cancellationToken: ct);
            return r.Data;
        }

        public ApplicationOut Create(CreateApplicationRequest req)
        {
            var r = _client.HookSniffHttpClient.SendRequest<ApplicationOut>(HttpMethod.Post, "/api/v1/applications", content: req);
            return r.Data;
        }

        public async Task<ApplicationOut> UpdateAsync(string id, UpdateApplicationRequest req, CancellationToken ct = default)
        {
            var r = await _client.HookSniffHttpClient.SendRequestAsync<ApplicationOut>(HttpMethod.Put, $"/api/v1/applications/{id}", content: req, cancellationToken: ct);
            return r.Data;
        }

        public ApplicationOut Update(string id, UpdateApplicationRequest req)
        {
            var r = _client.HookSniffHttpClient.SendRequest<ApplicationOut>(HttpMethod.Put, $"/api/v1/applications/{id}", content: req);
            return r.Data;
        }

        public async Task DeleteAsync(string id, CancellationToken ct = default)
        {
            await _client.HookSniffHttpClient.SendRequestAsync<bool>(HttpMethod.Delete, $"/api/v1/applications/{id}", cancellationToken: ct);
        }

        public void Delete(string id)
        {
            _client.HookSniffHttpClient.SendRequest<bool>(HttpMethod.Delete, $"/api/v1/applications/{id}");
        }
    }
}
