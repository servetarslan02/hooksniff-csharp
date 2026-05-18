#nullable enable
using Microsoft.Extensions.Logging;
using HookSniff.Models;

namespace HookSniff
{
    public class Inbound(HookSniffClient client)
    {
        readonly HookSniffClient _client = client;

        public async Task<List<InboundConfigOut>> ListConfigsAsync(CancellationToken ct = default)
        {
            var r = await _client.HookSniffHttpClient.SendRequestAsync<List<InboundConfigOut>>(HttpMethod.Get, "/api/v1/inbound/configs", cancellationToken: ct);
            return r.Data;
        }

        public List<InboundConfigOut> ListConfigs()
        {
            var r = _client.HookSniffHttpClient.SendRequest<List<InboundConfigOut>>(HttpMethod.Get, "/api/v1/inbound/configs");
            return r.Data;
        }

        public async Task<InboundConfigOut> GetConfigAsync(string id, CancellationToken ct = default)
        {
            var r = await _client.HookSniffHttpClient.SendRequestAsync<InboundConfigOut>(HttpMethod.Get, $"/api/v1/inbound/configs/{id}", cancellationToken: ct);
            return r.Data;
        }

        public InboundConfigOut GetConfig(string id)
        {
            var r = _client.HookSniffHttpClient.SendRequest<InboundConfigOut>(HttpMethod.Get, $"/api/v1/inbound/configs/{id}");
            return r.Data;
        }

        public async Task<InboundConfigOut> CreateConfigAsync(CreateInboundConfigRequest req, CancellationToken ct = default)
        {
            var r = await _client.HookSniffHttpClient.SendRequestAsync<InboundConfigOut>(HttpMethod.Post, "/api/v1/inbound/configs", content: req, cancellationToken: ct);
            return r.Data;
        }

        public InboundConfigOut CreateConfig(CreateInboundConfigRequest req)
        {
            var r = _client.HookSniffHttpClient.SendRequest<InboundConfigOut>(HttpMethod.Post, "/api/v1/inbound/configs", content: req);
            return r.Data;
        }

        public async Task<InboundConfigOut> UpdateConfigAsync(string id, UpdateInboundConfigRequest req, CancellationToken ct = default)
        {
            var r = await _client.HookSniffHttpClient.SendRequestAsync<InboundConfigOut>(HttpMethod.Put, $"/api/v1/inbound/configs/{id}", content: req, cancellationToken: ct);
            return r.Data;
        }

        public InboundConfigOut UpdateConfig(string id, UpdateInboundConfigRequest req)
        {
            var r = _client.HookSniffHttpClient.SendRequest<InboundConfigOut>(HttpMethod.Put, $"/api/v1/inbound/configs/{id}", content: req);
            return r.Data;
        }

        public async Task DeleteConfigAsync(string id, CancellationToken ct = default)
        {
            await _client.HookSniffHttpClient.SendRequestAsync<bool>(HttpMethod.Delete, $"/api/v1/inbound/configs/{id}", cancellationToken: ct);
        }

        public void DeleteConfig(string id)
        {
            _client.HookSniffHttpClient.SendRequest<bool>(HttpMethod.Delete, $"/api/v1/inbound/configs/{id}");
        }
    }
}
