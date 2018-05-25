using System;
using System.Collections.Generic;
using System.Numerics;

namespace Shared
{
    public static class NumberGenerators
    {
        public static IEnumerable<long> GetTriangleNumbers()
        {
            //n(n+1)/2
            return OnDemandIterator<long>(x => x * (x + 1) / 2);
        }

        public static IEnumerable<long> GetSquareNumbers()
        {
            //n*n
            return OnDemandIterator<long>(x => x * x);
        }

        public static IEnumerable<long> GetPentagonalNumbers()
        {
            //n(3n−1)/2
            return OnDemandIterator<long>(x => x * (3 * x - 1) / 2);
        }

        public static IEnumerable<long> GetHexagonalNumbers()
        {
            //n(2n−1)
            return OnDemandIterator<long>(x => x * (2 * x - 1));
        }

        public static IEnumerable<long> GetHeptagonalNumbers()
        {
            //n(5n−3)/2
            return OnDemandIterator<long>(x => x * (5 * x - 3) / 2);
        }

        public static IEnumerable<long> GetOctagonalNumbers()
        {
            //n(3n−2)
            return OnDemandIterator<long>(x => x * (3 * x - 2));
        }

        public static IEnumerable<long> GetTriangleNumbers(int count)
        {
            //n(n+1)/2
            return Iterator<long>(count, x => x * (x + 1) / 2);
        }

        public static IEnumerable<long> GetSquareNumbers(int count)
        {
            //n*n
            return Iterator<long>(count, x => x * x);
        }

        public static IEnumerable<long> GetPentagonalNumbers(int count)
        {
            //n(3n−1)/2
            return Iterator<long>(count, x => x * (3 * x - 1) / 2);
        }

        public static IEnumerable<long> GetHexagonalNumbers(int count)
        {
            //n(2n−1)
            return Iterator<long>(count, x => x * (2 * x - 1));
        }

        public static IEnumerable<long> GetHeptagonalNumbers(int count)
        {
            //n(5n−3)/2
            return Iterator<long>(count, x => x * (5 * x - 3) / 2);
        }

        public static IEnumerable<long> GetOctagonalNumbers(int count)
        {
            //n(3n−2)
            return Iterator<long>(count, x => x * (3 * x - 2));
        }

        public static IEnumerable<BigInteger> GetTriangleNumbersBig(int count)
        {
            //n(n+1)/2
            return Iterator(count,
                x =>
                {
                    var inside = BigInteger.Add(x, 1);
                    var numerator = BigInteger.Multiply(x, inside);
                    return BigInteger.Divide(numerator, 2);
                });
        }

        public static IEnumerable<BigInteger> GetPentagonalNumbersBig(int count)
        {
            //n(3n−1)/2
            return Iterator(count, x =>
            {
                var inside = BigInteger.Subtract(BigInteger.Multiply(x, 3), 1);
                var numerator = BigInteger.Multiply(inside, x);
                return BigInteger.Divide(numerator, 2);
            });
        }

        public static IEnumerable<BigInteger> GetHexagonalNumbersBig(int count)
        {
            //n(2n−1)
            return Iterator(count, x =>
            {
                var inside = BigInteger.Subtract(BigInteger.Multiply(x, 2), 1);
                return BigInteger.Multiply(inside, x);
            });
        }

        private static IEnumerable<T> Iterator<T>(int count, Func<int, T> formula)
        {
            var x = 1;
            while (count >= x)
            {
                yield return formula(x);
                x++;
            }
        }

        private static IEnumerable<T> OnDemandIterator<T>(Func<int, T> formula)
        {
            var x = 1;
            while (true)
            {
                yield return formula(x);
                x++;
            }
        }
    }
}