#nullable enable
using Microsoft.Extensions.Logging;
using HookSniff.Models;

namespace HookSniff
{
    public class Schema(HookSniffClient client)
    {
        readonly HookSniffClient _client = client;

        public async Task<ListResponseSchemaOut> ListAsync(CancellationToken ct = default)
        {
            var r = await _client.HookSniffHttpClient.SendRequestAsync<ListResponseSchemaOut>(HttpMethod.Get, "/v1/schemas", cancellationToken: ct);
            return r.Data;
        }

        public ListResponseSchemaOut List()
        {
            var r = _client.HookSniffHttpClient.SendRequest<ListResponseSchemaOut>(HttpMethod.Get, "/v1/schemas");
            return r.Data;
        }

        public async Task<SchemaOut> GetAsync(string id, CancellationToken ct = default)
        {
            var r = await _client.HookSniffHttpClient.SendRequestAsync<SchemaOut>(HttpMethod.Get, $"/v1/schemas/{id}", cancellationToken: ct);
            return r.Data;
        }

        public SchemaOut Get(string id)
        {
            var r = _client.HookSniffHttpClient.SendRequest<SchemaOut>(HttpMethod.Get, $"/v1/schemas/{id}");
            return r.Data;
        }

        public async Task<SchemaOut> RegisterAsync(RegisterSchemaRequest req, CancellationToken ct = default)
        {
            var r = await _client.HookSniffHttpClient.SendRequestAsync<SchemaOut>(HttpMethod.Post, "/v1/schemas", content: req, cancellationToken: ct);
            return r.Data;
        }

        public SchemaOut Register(RegisterSchemaRequest req)
        {
            var r = _client.HookSniffHttpClient.SendRequest<SchemaOut>(HttpMethod.Post, "/v1/schemas", content: req);
            return r.Data;
        }

        public async Task<ValidateEventResponse> ValidateAsync(string id, ValidateEventRequest req, CancellationToken ct = default)
        {
            var r = await _client.HookSniffHttpClient.SendRequestAsync<ValidateEventResponse>(HttpMethod.Post, $"/v1/schemas/{id}/validate", content: req, cancellationToken: ct);
            return r.Data;
        }

        public ValidateEventResponse Validate(string id, ValidateEventRequest req)
        {
            var r = _client.HookSniffHttpClient.SendRequest<ValidateEventResponse>(HttpMethod.Post, $"/v1/schemas/{id}/validate", content: req);
            return r.Data;
        }
    }
}
