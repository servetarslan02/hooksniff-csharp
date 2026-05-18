#nullable enable
using Microsoft.Extensions.Logging;
using HookSniff.Models;

namespace HookSniff
{
    public class Stream(HookSniffClient client)
    {
        readonly HookSniffClient _client = client;

        // Channels
        public async Task<List<StreamChannelOut>> ListChannelsAsync(CancellationToken ct = default)
        {
            var r = await _client.HookSniffHttpClient.SendRequestAsync<List<StreamChannelOut>>(HttpMethod.Get, "/v1/stream/channels", cancellationToken: ct);
            return r.Data;
        }

        public List<StreamChannelOut> ListChannels()
        {
            var r = _client.HookSniffHttpClient.SendRequest<List<StreamChannelOut>>(HttpMethod.Get, "/v1/stream/channels");
            return r.Data;
        }

        public async Task<StreamChannelOut> CreateChannelAsync(CreateChannelRequest req, CancellationToken ct = default)
        {
            var r = await _client.HookSniffHttpClient.SendRequestAsync<StreamChannelOut>(HttpMethod.Post, "/v1/stream/channels", content: req, cancellationToken: ct);
            return r.Data;
        }

        public StreamChannelOut CreateChannel(CreateChannelRequest req)
        {
            var r = _client.HookSniffHttpClient.SendRequest<StreamChannelOut>(HttpMethod.Post, "/v1/stream/channels", content: req);
            return r.Data;
        }

        public async Task<ChannelDetailOut> GetChannelAsync(string id, CancellationToken ct = default)
        {
            var r = await _client.HookSniffHttpClient.SendRequestAsync<ChannelDetailOut>(HttpMethod.Get, $"/v1/stream/channels/{id}", cancellationToken: ct);
            return r.Data;
        }

        public ChannelDetailOut GetChannel(string id)
        {
            var r = _client.HookSniffHttpClient.SendRequest<ChannelDetailOut>(HttpMethod.Get, $"/v1/stream/channels/{id}");
            return r.Data;
        }

        public async Task<StreamChannelOut> UpdateChannelAsync(string id, UpdateChannelRequest req, CancellationToken ct = default)
        {
            var r = await _client.HookSniffHttpClient.SendRequestAsync<StreamChannelOut>(HttpMethod.Put, $"/v1/stream/channels/{id}", content: req, cancellationToken: ct);
            return r.Data;
        }

        public StreamChannelOut UpdateChannel(string id, UpdateChannelRequest req)
        {
            var r = _client.HookSniffHttpClient.SendRequest<StreamChannelOut>(HttpMethod.Put, $"/v1/stream/channels/{id}", content: req);
            return r.Data;
        }

        public async Task DeleteChannelAsync(string id, CancellationToken ct = default)
        {
            await _client.HookSniffHttpClient.SendRequestAsync<bool>(HttpMethod.Delete, $"/v1/stream/channels/{id}", cancellationToken: ct);
        }

        public void DeleteChannel(string id)
        {
            _client.HookSniffHttpClient.SendRequest<bool>(HttpMethod.Delete, $"/v1/stream/channels/{id}");
        }

        // Subscribe
        public async Task<StreamSubscriptionOut> SubscribeAsync(string channelId, CancellationToken ct = default)
        {
            var r = await _client.HookSniffHttpClient.SendRequestAsync<StreamSubscriptionOut>(HttpMethod.Get, $"/v1/stream/channels/{channelId}/subscribe", cancellationToken: ct);
            return r.Data;
        }

        public StreamSubscriptionOut Subscribe(string channelId)
        {
            var r = _client.HookSniffHttpClient.SendRequest<StreamSubscriptionOut>(HttpMethod.Get, $"/v1/stream/channels/{channelId}/subscribe");
            return r.Data;
        }

        // Channel Messages
        public async Task<List<StreamMessageOut>> ListChannelMessagesAsync(string channelId, CancellationToken ct = default)
        {
            var r = await _client.HookSniffHttpClient.SendRequestAsync<List<StreamMessageOut>>(HttpMethod.Get, $"/v1/stream/channels/{channelId}/messages", cancellationToken: ct);
            return r.Data;
        }

        public List<StreamMessageOut> ListChannelMessages(string channelId)
        {
            var r = _client.HookSniffHttpClient.SendRequest<List<StreamMessageOut>>(HttpMethod.Get, $"/v1/stream/channels/{channelId}/messages");
            return r.Data;
        }

        // Subscriptions
        public async Task<List<StreamSubscriptionOut>> ListSubscriptionsAsync(CancellationToken ct = default)
        {
            var r = await _client.HookSniffHttpClient.SendRequestAsync<List<StreamSubscriptionOut>>(HttpMethod.Get, "/v1/stream/subscriptions", cancellationToken: ct);
            return r.Data;
        }

        public List<StreamSubscriptionOut> ListSubscriptions()
        {
            var r = _client.HookSniffHttpClient.SendRequest<List<StreamSubscriptionOut>>(HttpMethod.Get, "/v1/stream/subscriptions");
            return r.Data;
        }

        public async Task<StreamSubscriptionOut> GetSubscriptionAsync(string id, CancellationToken ct = default)
        {
            var r = await _client.HookSniffHttpClient.SendRequestAsync<StreamSubscriptionOut>(HttpMethod.Get, $"/v1/stream/subscriptions/{id}", cancellationToken: ct);
            return r.Data;
        }

        public StreamSubscriptionOut GetSubscription(string id)
        {
            var r = _client.HookSniffHttpClient.SendRequest<StreamSubscriptionOut>(HttpMethod.Get, $"/v1/stream/subscriptions/{id}");
            return r.Data;
        }

        public async Task DisconnectSubscriptionAsync(string id, CancellationToken ct = default)
        {
            await _client.HookSniffHttpClient.SendRequestAsync<bool>(HttpMethod.Delete, $"/v1/stream/subscriptions/{id}", cancellationToken: ct);
        }

        public void DisconnectSubscription(string id)
        {
            _client.HookSniffHttpClient.SendRequest<bool>(HttpMethod.Delete, $"/v1/stream/subscriptions/{id}");
        }

        // Publish
        public async Task PublishAsync(PublishEventRequest req, CancellationToken ct = default)
        {
            await _client.HookSniffHttpClient.SendRequestAsync<bool>(HttpMethod.Post, "/v1/stream/publish", content: req, cancellationToken: ct);
        }

        public void Publish(PublishEventRequest req)
        {
            _client.HookSniffHttpClient.SendRequest<bool>(HttpMethod.Post, "/v1/stream/publish", content: req);
        }
    }
}
