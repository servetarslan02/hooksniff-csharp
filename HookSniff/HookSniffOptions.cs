namespace HookSniff
{
    public class HookSniffOptions
    {
        public string? ServerUrl { get; }
        public List<int> RetryScheduleMilliseconds { get; } = [1000, 2000, 4000];
        public int TimeoutMilliseconds { get; } = 15000;
        public bool Debug { get; } = false;
        public Dictionary<string, string> Headers { get; } = new();

        public HookSniffOptions(
            string? serverUrl = null,
            int timeoutMilliseconds = 15000,
            List<int>? retryScheduleMilliseconds = null,
            bool debug = false,
            Dictionary<string, string>? headers = null
        )
        {
            ServerUrl = serverUrl;
            TimeoutMilliseconds = timeoutMilliseconds;
            Debug = debug;
            if (headers != null) Headers = headers;
            retryScheduleMilliseconds ??= [1000, 2000, 4000];
            if (retryScheduleMilliseconds.Count > 5)
            {
                throw new ArgumentException("number of retries must not exceed 5");
            }
            RetryScheduleMilliseconds = retryScheduleMilliseconds;
        }

        public HookSniffOptions Header(string name, string value)
        {
            Headers[name] = value;
            return this;
        }
    }
}
