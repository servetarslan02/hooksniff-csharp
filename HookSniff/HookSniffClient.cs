using Microsoft.Extensions.Logging;

namespace HookSniff
{
    public class HookSniffClient
    {
        // ── Original Resources ──────────────────────────────
        public Authentication Authentication => new(this);
        public Endpoint Endpoint => new(this);
        public EventType EventType => new(this);
        public Health Health => new(this);
        public Message Message => new(this);
        public MessageAttempt MessageAttempt => new(this);
        public Statistics Statistics => new(this);

        // ── Faz 8-15 Resources ─────────────────────────────
        public Environment Environment => new(this);
        public BackgroundTask BackgroundTask => new(this);
        public OperationalWebhook OperationalWebhook => new(this);
        public MessagePoller MessagePoller => new(this);
        public Inbound Inbound => new(this);
        public Connector Connector => new(this);
        public Integrations Integrations => new(this);
        public Stream Stream => new(this);

        // ── Additional Resources ───────────────────────────
        public Application Application => new(this);
        public ApiKey ApiKey => new(this);
        public Search Search => new(this);
        public Alert Alert => new(this);
        public Analytics Analytics => new(this);
        public Billing Billing => new(this);
        public Portal Portal => new(this);
        public Team Team => new(this);
        public Notification Notification => new(this);
        public Sso Sso => new(this);
        public AuditLog AuditLog => new(this);
        public CustomDomain CustomDomain => new(this);
        public RateLimit RateLimit => new(this);
        public Routing Routing => new(this);
        public Template Template => new(this);
        public Schema Schema => new(this);
        public Playground Playground => new(this);
        public ServiceToken ServiceToken => new(this);

        public ILogger? Logger { get; }
        public HookSniffHttpClient HookSniffHttpClient;

        public HookSniffClient(
            string token,
            HookSniffOptions? options = null,
            ILogger<HookSniffClient>? logger = null,
            HookSniffHttpClient? hooksniffHttpClient = null
        )
        {
            Logger = logger;
            var opts = options ?? new HookSniffOptions(Utils.DefaultServerUrlFromToken(token));
            HookSniffHttpClient =
                hooksniffHttpClient
                ?? new HookSniffHttpClient(
                    token,
                    opts.RetryScheduleMilliseconds,
                    $"hooksniff-libs/{Version.version}/csharp",
                    opts.ServerUrl ?? Utils.DEFAULT_SERVER_URL,
                    opts.Debug
                );
        }
    }
}
