#nullable enable
using Microsoft.Extensions.Logging;
using HookSniff.Models;

namespace HookSniff
{
    public class BackgroundTaskListOptions : HookSniffOptionsBase
    {
        public ulong? Limit { get; set; }
        public string? Status { get; set; }

        public new Dictionary<string, string> QueryParams()
        {
            return SerializeParams(new Dictionary<string, object?> {
                { "limit", Limit }, { "status", Status }
            });
        }
    }

    public class BackgroundTask(HookSniffClient client)
    {
        readonly HookSniffClient _client = client;

        public async Task<List<BackgroundTaskOut>> ListAsync(BackgroundTaskListOptions? options = null, CancellationToken ct = default)
        {
            var r = await _client.HookSniffHttpClient.SendRequestAsync<List<BackgroundTaskOut>>(HttpMethod.Get, "/v1/background-tasks", queryParams: options?.QueryParams(), cancellationToken: ct);
            return r.Data;
        }

        public List<BackgroundTaskOut> List(BackgroundTaskListOptions? options = null)
        {
            var r = _client.HookSniffHttpClient.SendRequest<List<BackgroundTaskOut>>(HttpMethod.Get, "/v1/background-tasks", queryParams: options?.QueryParams());
            return r.Data;
        }

        public async Task<BackgroundTaskOut> GetAsync(string id, CancellationToken ct = default)
        {
            var r = await _client.HookSniffHttpClient.SendRequestAsync<BackgroundTaskOut>(HttpMethod.Get, $"/v1/background-tasks/{id}", cancellationToken: ct);
            return r.Data;
        }

        public BackgroundTaskOut Get(string id)
        {
            var r = _client.HookSniffHttpClient.SendRequest<BackgroundTaskOut>(HttpMethod.Get, $"/v1/background-tasks/{id}");
            return r.Data;
        }

        public async Task<BackgroundTaskOut> CancelAsync(string id, CancellationToken ct = default)
        {
            var r = await _client.HookSniffHttpClient.SendRequestAsync<BackgroundTaskOut>(HttpMethod.Put, $"/v1/background-tasks/{id}", cancellationToken: ct);
            return r.Data;
        }

        public BackgroundTaskOut Cancel(string id)
        {
            var r = _client.HookSniffHttpClient.SendRequest<BackgroundTaskOut>(HttpMethod.Put, $"/v1/background-tasks/{id}");
            return r.Data;
        }
    }
}
