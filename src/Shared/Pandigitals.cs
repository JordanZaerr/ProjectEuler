using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shared
{
    public static class Pandigitals
    {
        public static bool IsPandigital(this int num)
        {
            return IsPandigital(num.ToString());
        }

        public static bool IsPandigital(this long num)
        {
            return IsPandigital(num.ToString());
        }

        public static bool IsPandigital(this string str)
        {
            return IsPandigital(str, BuildComparison(str.Length));
        }

        public static List<int> Generate(int length)
        {
            //TODO: use the lexigraphical thing from the StringExtensions.GetPermutations.cs
            var lowerBound = (int)Math.Pow(10, length - 1);
            var upperBound = (int)Math.Pow(10, length);

            var list = new ConcurrentBag<int>();
            var comparison = BuildComparison(length);
            Parallel.For(lowerBound, upperBound, x => 
            {
                if(x.ToString().IsPandigital(comparison))
                    list.Add(x);
            });

            return list.ToList();
        }

        private static string BuildComparison(int length)
        {
            return Enumerable.Range(1, length).Join();
        }

        private static bool IsPandigital(this string str, string comparison)
        {
            return str.OrderBy(x => x).Join() == comparison;
        }
    }
}