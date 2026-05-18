#nullable enable
using Microsoft.Extensions.Logging;
using HookSniff.Models;

namespace HookSniff
{
    public class Playground(HookSniffClient client)
    {
        readonly HookSniffClient _client = client;

        public async Task<PlaygroundOut> GetAsync(CancellationToken ct = default)
        {
            var r = await _client.HookSniffHttpClient.SendRequestAsync<PlaygroundOut>(HttpMethod.Get, "/api/v1/playground", cancellationToken: ct);
            return r.Data;
        }

        public PlaygroundOut Get()
        {
            var r = _client.HookSniffHttpClient.SendRequest<PlaygroundOut>(HttpMethod.Get, "/api/v1/playground");
            return r.Data;
        }

        public async Task<TestWebhookResponse> TestAsync(TestWebhookRequest req, CancellationToken ct = default)
        {
            var r = await _client.HookSniffHttpClient.SendRequestAsync<TestWebhookResponse>(HttpMethod.Post, "/api/v1/playground/test", content: req, cancellationToken: ct);
            return r.Data;
        }

        public TestWebhookResponse Test(TestWebhookRequest req)
        {
            var r = _client.HookSniffHttpClient.SendRequest<TestWebhookResponse>(HttpMethod.Post, "/api/v1/playground/test", content: req);
            return r.Data;
        }
    }
}
