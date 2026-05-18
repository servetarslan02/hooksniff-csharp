#nullable enable
using Microsoft.Extensions.Logging;
using HookSniff.Models;

namespace HookSniff
{
    public class Notification(HookSniffClient client)
    {
        readonly HookSniffClient _client = client;

        public async Task<NotificationListResponse> ListAsync(CancellationToken ct = default)
        {
            var r = await _client.HookSniffHttpClient.SendRequestAsync<NotificationListResponse>(HttpMethod.Get, "/v1/notifications", cancellationToken: ct);
            return r.Data;
        }

        public NotificationListResponse List()
        {
            var r = _client.HookSniffHttpClient.SendRequest<NotificationListResponse>(HttpMethod.Get, "/v1/notifications");
            return r.Data;
        }

        public async Task<UnreadCountResponse> UnreadCountAsync(CancellationToken ct = default)
        {
            var r = await _client.HookSniffHttpClient.SendRequestAsync<UnreadCountResponse>(HttpMethod.Get, "/v1/notifications/unread-count", cancellationToken: ct);
            return r.Data;
        }

        public UnreadCountResponse UnreadCount()
        {
            var r = _client.HookSniffHttpClient.SendRequest<UnreadCountResponse>(HttpMethod.Get, "/v1/notifications/unread-count");
            return r.Data;
        }

        public async Task MarkAllReadAsync(CancellationToken ct = default)
        {
            await _client.HookSniffHttpClient.SendRequestAsync<bool>(HttpMethod.Put, "/v1/notifications/read-all", cancellationToken: ct);
        }

        public void MarkAllRead()
        {
            _client.HookSniffHttpClient.SendRequest<bool>(HttpMethod.Put, "/v1/notifications/read-all");
        }

        public async Task MarkReadAsync(string id, CancellationToken ct = default)
        {
            await _client.HookSniffHttpClient.SendRequestAsync<bool>(HttpMethod.Put, $"/v1/notifications/{id}/read", cancellationToken: ct);
        }

        public void MarkRead(string id)
        {
            _client.HookSniffHttpClient.SendRequest<bool>(HttpMethod.Put, $"/v1/notifications/{id}/read");
        }

        public async Task DeleteAsync(string id, CancellationToken ct = default)
        {
            await _client.HookSniffHttpClient.SendRequestAsync<bool>(HttpMethod.Delete, $"/v1/notifications/{id}", cancellationToken: ct);
        }

        public void Delete(string id)
        {
            _client.HookSniffHttpClient.SendRequest<bool>(HttpMethod.Delete, $"/v1/notifications/{id}");
        }
    }
}
