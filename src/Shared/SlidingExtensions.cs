using System.Collections.Generic;
using System.Linq;

namespace Shared
{
    public static class SlidingExtensions
    {
        public static IEnumerable<IEnumerable<T>> Slide<T>(this IEnumerable<T> src, int window)
        {
            int current = 0;
            var source = src.ToList();
            while (current + window <= source.Count)
            {
                yield return source.Skip(current).Take(window);
                current++;
            }
        }

        public static long MaxSlidingProduct(this List<List<int>> src, int window)
        {
            return src.Select(x => x.Slide(window)
                .Aggregate(0L,
                    (high, current) =>
                    {
                        var product = current.Product();
                        return product > high ? product : high;
                    })).Max();
        }
    }
}