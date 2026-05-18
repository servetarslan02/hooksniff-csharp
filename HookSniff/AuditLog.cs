#nullable enable
using Microsoft.Extensions.Logging;
using HookSniff.Models;

namespace HookSniff
{
    public class AuditLogQueryOptions : HookSniffOptionsBase
    {
        public ulong? Limit { get; set; }
        public string? Action { get; set; }
        public string? ResourceType { get; set; }
        public DateTime? From { get; set; }
        public DateTime? To { get; set; }

        public new Dictionary<string, string> QueryParams()
        {
            return SerializeParams(new Dictionary<string, object?> {
                { "limit", Limit }, { "action", Action }, { "resource_type", ResourceType },
                { "from", From }, { "to", To }
            });
        }
    }

    public class AuditLog(HookSniffClient client)
    {
        readonly HookSniffClient _client = client;

        public async Task<AuditLogResponse> ListAsync(AuditLogQueryOptions? options = null, CancellationToken ct = default)
        {
            var r = await _client.HookSniffHttpClient.SendRequestAsync<AuditLogResponse>(HttpMethod.Get, "/v1/audit-log", queryParams: options?.QueryParams(), cancellationToken: ct);
            return r.Data;
        }

        public AuditLogResponse List(AuditLogQueryOptions? options = null)
        {
            var r = _client.HookSniffHttpClient.SendRequest<AuditLogResponse>(HttpMethod.Get, "/v1/audit-log", queryParams: options?.QueryParams());
            return r.Data;
        }

        public async Task<AuditEntryOut> GetAsync(string id, CancellationToken ct = default)
        {
            var r = await _client.HookSniffHttpClient.SendRequestAsync<AuditEntryOut>(HttpMethod.Get, $"/v1/audit-log/{id}", cancellationToken: ct);
            return r.Data;
        }

        public AuditEntryOut Get(string id)
        {
            var r = _client.HookSniffHttpClient.SendRequest<AuditEntryOut>(HttpMethod.Get, $"/v1/audit-log/{id}");
            return r.Data;
        }
    }
}
