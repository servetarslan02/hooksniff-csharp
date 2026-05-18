#nullable enable
using Microsoft.Extensions.Logging;
using HookSniff.Models;

namespace HookSniff
{
    public class EnvironmentListOptions : HookSniffOptionsBase
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

    public class Environment(HookSniffClient client)
    {
        readonly HookSniffClient _client = client;

        public async Task<List<EnvironmentOut>> ListAsync(EnvironmentListOptions? options = null, CancellationToken ct = default)
        {
            var r = await _client.HookSniffHttpClient.SendRequestAsync<List<EnvironmentOut>>(HttpMethod.Get, "/v1/environments", queryParams: options?.QueryParams(), cancellationToken: ct);
            return r.Data;
        }

        public List<EnvironmentOut> List(EnvironmentListOptions? options = null)
        {
            var r = _client.HookSniffHttpClient.SendRequest<List<EnvironmentOut>>(HttpMethod.Get, "/v1/environments", queryParams: options?.QueryParams());
            return r.Data;
        }

        public async Task<EnvironmentOut> GetAsync(string id, CancellationToken ct = default)
        {
            var r = await _client.HookSniffHttpClient.SendRequestAsync<EnvironmentOut>(HttpMethod.Get, $"/v1/environments/{id}", cancellationToken: ct);
            return r.Data;
        }

        public EnvironmentOut Get(string id)
        {
            var r = _client.HookSniffHttpClient.SendRequest<EnvironmentOut>(HttpMethod.Get, $"/v1/environments/{id}");
            return r.Data;
        }

        public async Task<EnvironmentOut> CreateAsync(CreateEnvironmentRequest req, CancellationToken ct = default)
        {
            var r = await _client.HookSniffHttpClient.SendRequestAsync<EnvironmentOut>(HttpMethod.Post, "/v1/environments", content: req, cancellationToken: ct);
            return r.Data;
        }

        public EnvironmentOut Create(CreateEnvironmentRequest req)
        {
            var r = _client.HookSniffHttpClient.SendRequest<EnvironmentOut>(HttpMethod.Post, "/v1/environments", content: req);
            return r.Data;
        }

        public async Task<EnvironmentOut> UpdateAsync(string id, UpdateEnvironmentRequest req, CancellationToken ct = default)
        {
            var r = await _client.HookSniffHttpClient.SendRequestAsync<EnvironmentOut>(HttpMethod.Put, $"/v1/environments/{id}", content: req, cancellationToken: ct);
            return r.Data;
        }

        public EnvironmentOut Update(string id, UpdateEnvironmentRequest req)
        {
            var r = _client.HookSniffHttpClient.SendRequest<EnvironmentOut>(HttpMethod.Put, $"/v1/environments/{id}", content: req);
            return r.Data;
        }

        public async Task DeleteAsync(string id, CancellationToken ct = default)
        {
            await _client.HookSniffHttpClient.SendRequestAsync<bool>(HttpMethod.Delete, $"/v1/environments/{id}", cancellationToken: ct);
        }

        public void Delete(string id)
        {
            _client.HookSniffHttpClient.SendRequest<bool>(HttpMethod.Delete, $"/v1/environments/{id}");
        }

        // Variables
        public async Task<List<VariableOut>> ListVariablesAsync(string envId, CancellationToken ct = default)
        {
            var r = await _client.HookSniffHttpClient.SendRequestAsync<List<VariableOut>>(HttpMethod.Get, $"/v1/environments/{envId}/variables", cancellationToken: ct);
            return r.Data;
        }

        public List<VariableOut> ListVariables(string envId)
        {
            var r = _client.HookSniffHttpClient.SendRequest<List<VariableOut>>(HttpMethod.Get, $"/v1/environments/{envId}/variables");
            return r.Data;
        }

        public async Task<VariableOut> CreateVariableAsync(string envId, CreateVariableRequest req, CancellationToken ct = default)
        {
            var r = await _client.HookSniffHttpClient.SendRequestAsync<VariableOut>(HttpMethod.Post, $"/v1/environments/{envId}/variables", content: req, cancellationToken: ct);
            return r.Data;
        }

        public VariableOut CreateVariable(string envId, CreateVariableRequest req)
        {
            var r = _client.HookSniffHttpClient.SendRequest<VariableOut>(HttpMethod.Post, $"/v1/environments/{envId}/variables", content: req);
            return r.Data;
        }

        public async Task<VariableOut> UpdateVariableAsync(string envId, string varId, UpdateVariableRequest req, CancellationToken ct = default)
        {
            var r = await _client.HookSniffHttpClient.SendRequestAsync<VariableOut>(HttpMethod.Put, $"/v1/environments/{envId}/variables/{varId}", content: req, cancellationToken: ct);
            return r.Data;
        }

        public VariableOut UpdateVariable(string envId, string varId, UpdateVariableRequest req)
        {
            var r = _client.HookSniffHttpClient.SendRequest<VariableOut>(HttpMethod.Put, $"/v1/environments/{envId}/variables/{varId}", content: req);
            return r.Data;
        }

        public async Task DeleteVariableAsync(string envId, string varId, CancellationToken ct = default)
        {
            await _client.HookSniffHttpClient.SendRequestAsync<bool>(HttpMethod.Delete, $"/v1/environments/{envId}/variables/{varId}", cancellationToken: ct);
        }

        public void DeleteVariable(string envId, string varId)
        {
            _client.HookSniffHttpClient.SendRequest<bool>(HttpMethod.Delete, $"/v1/environments/{envId}/variables/{varId}");
        }
    }
}
