#nullable enable
using Microsoft.Extensions.Logging;
using HookSniff.Models;

namespace HookSniff
{
    public class MessagePollerPollOptions : HookSniffOptionsBase
    {
        public string? Channel { get; set; }
        public ulong? Limit { get; set; }

        public new Dictionary<string, string> QueryParams()
        {
            return SerializeParams(new Dictionary<string, object?> {
                { "channel", Channel }, { "limit", Limit }
            });
        }
    }

    public class MessagePoller(HookSniffClient client)
    {
        readonly HookSniffClient _client = client;

        public async Task<PollResponse> PollAsync(MessagePollerPollOptions? options = null, CancellationToken ct = default)
        {
            var r = await _client.HookSniffHttpClient.SendRequestAsync<PollResponse>(HttpMethod.Get, "/api/v1/message-poller/poll", queryParams: options?.QueryParams(), cancellationToken: ct);
            return r.Data;
        }

        public PollResponse Poll(MessagePollerPollOptions? options = null)
        {
            var r = _client.HookSniffHttpClient.SendRequest<PollResponse>(HttpMethod.Get, "/api/v1/message-poller/poll", queryParams: options?.QueryParams());
            return r.Data;
        }

        public async Task<SeekResponse> SeekAsync(SeekRequest req, CancellationToken ct = default)
        {
            var r = await _client.HookSniffHttpClient.SendRequestAsync<SeekResponse>(HttpMethod.Post, "/api/v1/message-poller/seek", content: req, cancellationToken: ct);
            return r.Data;
        }

        public SeekResponse Seek(SeekRequest req)
        {
            var r = _client.HookSniffHttpClient.SendRequest<SeekResponse>(HttpMethod.Post, "/api/v1/message-poller/seek", content: req);
            return r.Data;
        }

        public async Task<CommitResponse> CommitAsync(CommitRequest req, CancellationToken ct = default)
        {
            var r = await _client.HookSniffHttpClient.SendRequestAsync<CommitResponse>(HttpMethod.Post, "/api/v1/message-poller/commit", content: req, cancellationToken: ct);
            return r.Data;
        }

        public CommitResponse Commit(CommitRequest req)
        {
            var r = _client.HookSniffHttpClient.SendRequest<CommitResponse>(HttpMethod.Post, "/api/v1/message-poller/commit", content: req);
            return r.Data;
        }
    }
}
