using System.Collections.Generic;
using System.Linq;

namespace Shared
{
    /// <summary>
    /// This class assumes that the input grid is a 
    /// List<List<T>> where the inner lists are the 
    /// horizontal rows of the grid.
    /// </summary>
    public static class GridExtensions
    {
        public static List<List<T>> FlattenRightDiagonal<T>(this List<List<T>> src, int minLength = 0)
        {
            var topRightToMiddle = Enumerable.Range(0, src.Count).Reverse()
               .Select(c => Enumerable.Range(0, src.Count - c)
                   .Zip(Enumerable.Range(c, src.Count - c), (x, y) => src[x][y]).ToList());

            var middleToBottomLeft = Enumerable.Range(1, src.Count)
               .Select(c => Enumerable.Range(c, src.Count - c)
                   .Zip(Enumerable.Range(0, src.Count - c), (x, y) => src[x][y]).ToList());

            return topRightToMiddle.Concat(middleToBottomLeft).Where(x => x.Count > minLength).ToList();
        }

        public static List<List<T>> FlattenLeftDiagonal<T>(this List<List<T>> src, int minLength = 0)
        {
            var topLeftToMiddle = Enumerable.Range(0, src.Count).Reverse()
                .Select(c => Enumerable.Range(0, src.Count - c).Reverse()
                    .Zip(Enumerable.Range(0, src.Count - c), (x, y) => src[x][y]).ToList());

            var middleToBottomRight = Enumerable.Range(1, src.Count)
               .Select(c => Enumerable.Range(0, src.Count).Reverse()
                .Zip(Enumerable.Range(c, src.Count - c), (x, y) => src[x][y]).ToList());

            return topLeftToMiddle.Concat(middleToBottomRight).Where(x => x.Count > minLength).ToList();
        }

        public static List<List<T>> FlattenVertical<T>(this List<List<T>> src)
        {
            return Enumerable.Range(0, src.Count).Select(x => src.Select(y => y[x]).ToList()).ToList();
        }
    }
}