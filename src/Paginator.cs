using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace HookSniff
{
    /// <summary>
    /// Pagination Helper for HookSniff C# SDK.
    ///
    /// Usage:
    ///   await foreach (var msg in hs.Message.ListAllAsync(limit: 100))
    ///   {
    ///       Console.WriteLine(msg.Id);
    ///   }
    /// </summary>
    public class Paginator<T> : IAsyncEnumerable<T>
    {
        private readonly Func<ListOptions, Task<ListResponse<T>>> _fetchPage;
        private readonly int? _limit;

        public Paginator(Func<ListOptions, Task<ListResponse<T>>> fetchPage, int? limit = null)
        {
            _fetchPage = fetchPage;
            _limit = limit;
        }

        public async IAsyncEnumerator<T> GetAsyncEnumerator(CancellationToken cancellationToken = default)
        {
            string? iterator = null;

            while (!cancellationToken.IsCancellationRequested)
            {
                var page = await _fetchPage(new ListOptions(_limit, iterator));

                foreach (var item in page.Data)
                {
                    yield return item;
                }

                if (page.Done || string.IsNullOrEmpty(page.Iterator))
                    break;

                iterator = page.Iterator;
            }
        }

        /// <summary>
        /// Collect all items into a list.
        /// </summary>
        public async Task<List<T>> ToListAsync(CancellationToken cancellationToken = default)
        {
            var items = new List<T>();
            await foreach (var item in this.WithCancellation(cancellationToken))
            {
                items.Add(item);
            }
            return items;
        }
    }

    public record ListOptions(int? Limit = null, string? Iterator = null);

    public record ListResponse<T>(
        List<T> Data,
        bool Done,
        string? Iterator
    );
}
