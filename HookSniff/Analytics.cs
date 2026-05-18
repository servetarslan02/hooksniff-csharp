#nullable enable
using Microsoft.Extensions.Logging;
using HookSniff.Models;

namespace HookSniff
{
    public class AnalyticsQueryOptions : HookSniffOptionsBase
    {
        public string? Period { get; set; }
        public string? EndpointId { get; set; }
        public DateTime? From { get; set; }
        public DateTime? To { get; set; }

        public new Dictionary<string, string> QueryParams()
        {
            return SerializeParams(new Dictionary<string, object?> {
                { "period", Period }, { "endpoint_id", EndpointId }, { "from", From }, { "to", To }
            });
        }
    }

    public class Analytics(HookSniffClient client)
    {
        readonly HookSniffClient _client = client;

        public async Task<DeliveryTrendResponse> DeliveryTrendAsync(AnalyticsQueryOptions? options = null, CancellationToken ct = default)
        {
            var r = await _client.HookSniffHttpClient.SendRequestAsync<DeliveryTrendResponse>(HttpMethod.Get, "/v1/analytics/deliveries", queryParams: options?.QueryParams(), cancellationToken: ct);
            return r.Data;
        }

        public DeliveryTrendResponse DeliveryTrend(AnalyticsQueryOptions? options = null)
        {
            var r = _client.HookSniffHttpClient.SendRequest<DeliveryTrendResponse>(HttpMethod.Get, "/v1/analytics/deliveries", queryParams: options?.QueryParams());
            return r.Data;
        }

        public async Task<SuccessRateResponse> SuccessRateAsync(AnalyticsQueryOptions? options = null, CancellationToken ct = default)
        {
            var r = await _client.HookSniffHttpClient.SendRequestAsync<SuccessRateResponse>(HttpMethod.Get, "/v1/analytics/success-rate", queryParams: options?.QueryParams(), cancellationToken: ct);
            return r.Data;
        }

        public SuccessRateResponse SuccessRate(AnalyticsQueryOptions? options = null)
        {
            var r = _client.HookSniffHttpClient.SendRequest<SuccessRateResponse>(HttpMethod.Get, "/v1/analytics/success-rate", queryParams: options?.QueryParams());
            return r.Data;
        }

        public async Task<LatencyTrendResponse> LatencyAsync(AnalyticsQueryOptions? options = null, CancellationToken ct = default)
        {
            var r = await _client.HookSniffHttpClient.SendRequestAsync<LatencyTrendResponse>(HttpMethod.Get, "/v1/analytics/latency", queryParams: options?.QueryParams(), cancellationToken: ct);
            return r.Data;
        }

        public LatencyTrendResponse Latency(AnalyticsQueryOptions? options = null)
        {
            var r = _client.HookSniffHttpClient.SendRequest<LatencyTrendResponse>(HttpMethod.Get, "/v1/analytics/latency", queryParams: options?.QueryParams());
            return r.Data;
        }
    }
}
