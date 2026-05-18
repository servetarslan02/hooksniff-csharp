namespace HookSniff
{
    public class HookSniffOptions
    {
        [Obsolete("BaseUrl is deprecated, please use ServerUrl instead.")]
        public string? BaseUrl
        {
            get => ServerUrl;
        }
        public string? ServerUrl { get; }
        public List<int> RetryScheduleMilliseconds { get; } = [1000, 2000, 4000];
        public int TimeoutMilliseconds { get; } = 15000;

        /// <param name="serverUrl">The server URL to connect to.</param>
        /// <param name="baseUrl">[Deprecated] Please use serverUrl parameter instead.</param>
#pragma warning disable CS0618
        public HookSniffOptions(
            string? serverUrl = null,
            int timeoutMilliseconds = 15000,
            List<int>? retryScheduleMilliseconds = null,
            string? baseUrl = null
        )
        {
            ServerUrl = serverUrl ?? baseUrl;
            TimeoutMilliseconds = timeoutMilliseconds;
            retryScheduleMilliseconds ??= [1000, 2000, 4000];
            if (retryScheduleMilliseconds.Count > 5)
            {
                throw new ArgumentException("number of retries must not exceed 5");
            }
            RetryScheduleMilliseconds = retryScheduleMilliseconds;
        }
#pragma warning restore CS0618
    }
}
