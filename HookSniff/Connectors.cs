#nullable enable
using Microsoft.Extensions.Logging;
using HookSniff.Models;

namespace HookSniff
{
    public class ConnectorListOptions : HookSniffOptionsBase
    {
        public ulong? Limit { get; set; }

        public new Dictionary<string, string> QueryParams()
        {
            return SerializeParams(new Dictionary<string, object?> { { "limit", Limit } });
        }
    }

    public class Connector(HookSniffClient client)
    {
        readonly HookSniffClient _client = client;

        public async Task<List<ConnectorOut>> ListAsync(ConnectorListOptions? options = null, CancellationToken ct = default)
        {
            var r = await _client.HookSniffHttpClient.SendRequestAsync<List<ConnectorOut>>(HttpMethod.Get, "/v1/connectors", queryParams: options?.QueryParams(), cancellationToken: ct);
            return r.Data;
        }

        public List<ConnectorOut> List(ConnectorListOptions? options = null)
        {
            var r = _client.HookSniffHttpClient.SendRequest<List<ConnectorOut>>(HttpMethod.Get, "/v1/connectors", queryParams: options?.QueryParams());
            return r.Data;
        }

        public async Task<ConnectorOut> GetAsync(string id, CancellationToken ct = default)
        {
            var r = await _client.HookSniffHttpClient.SendRequestAsync<ConnectorOut>(HttpMethod.Get, $"/v1/connectors/{id}", cancellationToken: ct);
            return r.Data;
        }

        public ConnectorOut Get(string id)
        {
            var r = _client.HookSniffHttpClient.SendRequest<ConnectorOut>(HttpMethod.Get, $"/v1/connectors/{id}");
            return r.Data;
        }

        // Configs
        public async Task<List<ConnectorConfigOut>> ListConfigsAsync(CancellationToken ct = default)
        {
            var r = await _client.HookSniffHttpClient.SendRequestAsync<List<ConnectorConfigOut>>(HttpMethod.Get, "/v1/connectors/configs", cancellationToken: ct);
            return r.Data;
        }

        public List<ConnectorConfigOut> ListConfigs()
        {
            var r = _client.HookSniffHttpClient.SendRequest<List<ConnectorConfigOut>>(HttpMethod.Get, "/v1/connectors/configs");
            return r.Data;
        }

        public async Task<ConnectorConfigOut> GetConfigAsync(string id, CancellationToken ct = default)
        {
            var r = await _client.HookSniffHttpClient.SendRequestAsync<ConnectorConfigOut>(HttpMethod.Get, $"/v1/connectors/configs/{id}", cancellationToken: ct);
            return r.Data;
        }

        public ConnectorConfigOut GetConfig(string id)
        {
            var r = _client.HookSniffHttpClient.SendRequest<ConnectorConfigOut>(HttpMethod.Get, $"/v1/connectors/configs/{id}");
            return r.Data;
        }

        public async Task<ConnectorConfigOut> CreateConfigAsync(CreateConnectorConfigRequest req, CancellationToken ct = default)
        {
            var r = await _client.HookSniffHttpClient.SendRequestAsync<ConnectorConfigOut>(HttpMethod.Post, "/v1/connectors/configs", content: req, cancellationToken: ct);
            return r.Data;
        }

        public ConnectorConfigOut CreateConfig(CreateConnectorConfigRequest req)
        {
            var r = _client.HookSniffHttpClient.SendRequest<ConnectorConfigOut>(HttpMethod.Post, "/v1/connectors/configs", content: req);
            return r.Data;
        }

        public async Task<ConnectorConfigOut> UpdateConfigAsync(string id, UpdateConnectorConfigRequest req, CancellationToken ct = default)
        {
            var r = await _client.HookSniffHttpClient.SendRequestAsync<ConnectorConfigOut>(HttpMethod.Put, $"/v1/connectors/configs/{id}", content: req, cancellationToken: ct);
            return r.Data;
        }

        public ConnectorConfigOut UpdateConfig(string id, UpdateConnectorConfigRequest req)
        {
            var r = _client.HookSniffHttpClient.SendRequest<ConnectorConfigOut>(HttpMethod.Put, $"/v1/connectors/configs/{id}", content: req);
            return r.Data;
        }
    }
}
