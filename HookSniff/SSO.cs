#nullable enable
using Microsoft.Extensions.Logging;
using HookSniff.Models;

namespace HookSniff
{
    public class Sso(HookSniffClient client)
    {
        readonly HookSniffClient _client = client;

        public async Task<SsoConfigOut> GetConfigAsync(CancellationToken ct = default)
        {
            var r = await _client.HookSniffHttpClient.SendRequestAsync<SsoConfigOut>(HttpMethod.Get, "/api/v1/sso/config", cancellationToken: ct);
            return r.Data;
        }

        public SsoConfigOut GetConfig()
        {
            var r = _client.HookSniffHttpClient.SendRequest<SsoConfigOut>(HttpMethod.Get, "/api/v1/sso/config");
            return r.Data;
        }

        public async Task<SsoConfigOut> UpsertConfigAsync(UpsertSsoRequest req, CancellationToken ct = default)
        {
            var r = await _client.HookSniffHttpClient.SendRequestAsync<SsoConfigOut>(HttpMethod.Post, "/api/v1/sso/config", content: req, cancellationToken: ct);
            return r.Data;
        }

        public SsoConfigOut UpsertConfig(UpsertSsoRequest req)
        {
            var r = _client.HookSniffHttpClient.SendRequest<SsoConfigOut>(HttpMethod.Post, "/api/v1/sso/config", content: req);
            return r.Data;
        }

        public async Task DeleteConfigAsync(CancellationToken ct = default)
        {
            await _client.HookSniffHttpClient.SendRequestAsync<bool>(HttpMethod.Delete, "/api/v1/sso/config", cancellationToken: ct);
        }

        public void DeleteConfig()
        {
            _client.HookSniffHttpClient.SendRequest<bool>(HttpMethod.Delete, "/api/v1/sso/config");
        }

        public async Task TestAsync(CancellationToken ct = default)
        {
            await _client.HookSniffHttpClient.SendRequestAsync<bool>(HttpMethod.Post, "/api/v1/sso/test", cancellationToken: ct);
        }

        public void Test()
        {
            _client.HookSniffHttpClient.SendRequest<bool>(HttpMethod.Post, "/api/v1/sso/test");
        }
    }
}
