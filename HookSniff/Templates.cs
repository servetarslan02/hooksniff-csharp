#nullable enable
using Microsoft.Extensions.Logging;
using HookSniff.Models;

namespace HookSniff
{
    public class Template(HookSniffClient client)
    {
        readonly HookSniffClient _client = client;

        public async Task<ListResponseTemplateOut> ListAsync(CancellationToken ct = default)
        {
            var r = await _client.HookSniffHttpClient.SendRequestAsync<ListResponseTemplateOut>(HttpMethod.Get, "/api/v1/templates", cancellationToken: ct);
            return r.Data;
        }

        public ListResponseTemplateOut List()
        {
            var r = _client.HookSniffHttpClient.SendRequest<ListResponseTemplateOut>(HttpMethod.Get, "/api/v1/templates");
            return r.Data;
        }

        public async Task<TemplateOut> GetAsync(string id, CancellationToken ct = default)
        {
            var r = await _client.HookSniffHttpClient.SendRequestAsync<TemplateOut>(HttpMethod.Get, $"/api/v1/templates/{id}", cancellationToken: ct);
            return r.Data;
        }

        public TemplateOut Get(string id)
        {
            var r = _client.HookSniffHttpClient.SendRequest<TemplateOut>(HttpMethod.Get, $"/api/v1/templates/{id}");
            return r.Data;
        }

        public async Task<ApplyTemplateResponse> ApplyAsync(string id, ApplyTemplateRequest req, CancellationToken ct = default)
        {
            var r = await _client.HookSniffHttpClient.SendRequestAsync<ApplyTemplateResponse>(HttpMethod.Post, $"/api/v1/templates/{id}/apply", content: req, cancellationToken: ct);
            return r.Data;
        }

        public ApplyTemplateResponse Apply(string id, ApplyTemplateRequest req)
        {
            var r = _client.HookSniffHttpClient.SendRequest<ApplyTemplateResponse>(HttpMethod.Post, $"/api/v1/templates/{id}/apply", content: req);
            return r.Data;
        }
    }
}
