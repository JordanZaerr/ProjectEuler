using System;
using System.Collections.Generic;

namespace Shared
{
    public static class Truncate
    {
        public static IEnumerable<int> LeftTrun(this int i)
        {
            return Trun(i, ii =>
            {
                if (ii < 10) return ii;
                return int.Parse(ii.ToString().Remove(0, 1));
            });
        }

        public static IEnumerable<int> RightTrun(this int i)
        {
            return Trun(i, ii =>
            {
                if (ii < 10) return ii;
                var str = ii.ToString();
                return int.Parse(str.Substring(0, str.Length - 1));
            });
        }

        private static IEnumerable<int> Trun(int i, Func<int, int> func)
        {
            var current = i;
            yield return current;
            while (current > 10)
            {
                yield return current = func(current);
            }
        }
    }
}