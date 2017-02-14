using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace Shared
{
    public static class MathFunctions
    {
        //http://en.wikipedia.org/wiki/Euclidean_algorithm
        public static int GreatestCommonFactor(int a, int b)
        {
            while (b != 0)
            {
                var t = b;
                b = a % t;
                a = t;
            }
            return a;
        }

        //http://en.wikipedia.org/wiki/Least_common_multiple#Reduction_by_the_greatest_common_divisor
        public static int LowestCommonMultiple(int a, int b)
        {
            return (a / GreatestCommonFactor(a, b)) * b;
        }

        public static long Factorial(this int start)
        {
            return Enumerable.Range(1, start).Product();
        }

        public static BigInteger FactorialBig(this int start)
        {
            return Enumerable.Range(1, start)
                .Aggregate(new BigInteger(1), (t, c) => BigInteger.Multiply(t, new BigInteger(c)));
        }

        public static long Product(this IEnumerable<int> src)
        {
            return src.Aggregate(1l, (total, current) => total * current);
        }
    }
}