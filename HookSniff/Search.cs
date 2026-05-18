#nullable enable
using Microsoft.Extensions.Logging;
using HookSniff.Models;

namespace HookSniff
{
    public class SearchOptions : HookSniffOptionsBase
    {
        public string? Q { get; set; }
        public string? EndpointId { get; set; }
        public string? Status { get; set; }
        public ulong? Limit { get; set; }

        public new Dictionary<string, string> QueryParams()
        {
            return SerializeParams(new Dictionary<string, object?> {
                { "q", Q }, { "endpoint_id", EndpointId }, { "status", Status }, { "limit", Limit }
            });
        }
    }

    public class Search(HookSniffClient client)
    {
        readonly HookSniffClient _client = client;

        public async Task<SearchResultOut> SearchAsync(SearchOptions options, CancellationToken ct = default)
        {
            var r = await _client.HookSniffHttpClient.SendRequestAsync<SearchResultOut>(HttpMethod.Get, "/api/v1/search", queryParams: options.QueryParams(), cancellationToken: ct);
            return r.Data;
        }

        public SearchResultOut DoSearch(SearchOptions options)
        {
            var r = _client.HookSniffHttpClient.SendRequest<SearchResultOut>(HttpMethod.Get, "/api/v1/search", queryParams: options.QueryParams());
            return r.Data;
        }
    }
}
