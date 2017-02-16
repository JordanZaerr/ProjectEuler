using System.Collections.Generic;
using System.Linq;

namespace Shared
{
    public static class StringExtensions
    {
        public static string Join<T>(this IEnumerable<T> src)
        {
            return string.Join(string.Empty, src);
        }

        public static IEnumerable<string> GetPermutations(this string str)
        {
            var input = str.Select(x => x.ToString()).ToList();
            return input.For((x, i) =>
            {
                if (input.Count == 1) return input;
                var current = input[i];
                var subSet = new List<string>(input);
                subSet.Remove(current);
                return GetPermutations(subSet.Join()).Select(y => current + y);
                //return GetPermutations(input.Except(new[] { current }).Join()).Select(y => current + y);
            }).SelectMany(x => x);
        }
    }
}