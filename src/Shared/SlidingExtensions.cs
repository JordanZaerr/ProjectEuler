using System.Collections.Generic;
using System.Linq;

namespace Shared
{
    public static class SlidingExtensions
    {
        //Only grabs full windows.
        //1,2,3,4 window size 2 => [1,2], [2,3], [3,4]
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

        //Grab all of the values and pad the remaining window slots with default values.
        //1,2,3,4 window size 2 => [1,2], [2,3], [3,4], [4,0]
        public static IEnumerable<IEnumerable<T>> SlideWithPadding<T>(this IEnumerable<T> src, int window)
        {
            var current = 0;
            var source = src.ToList();
            while (current + window <= source.Count + (window - 1))
            {
                var result = source.Skip(current).Take(window).ToList();
                var resultCount = result.Count();
                if (resultCount < window)
                    yield return result.Concat(Enumerable.Repeat(default(T), window - resultCount));
                else
                    yield return result;
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