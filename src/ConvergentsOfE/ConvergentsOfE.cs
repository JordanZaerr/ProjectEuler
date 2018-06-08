using System;
using System.Linq;
using System.Numerics;
using Shared;

namespace ConvergentsOfE
{
    //272
    class ConvergentsOfE
    {
        static void Main()
        {
            //30ms
            Timer.Record(FirstAttempt);
            Console.ReadLine();
        }

        private static void FirstAttempt()
        {
            var range = Enumerable.Range(2, 99).ToList();
            var e = range.Select(x =>
            {
                var q = Math.DivRem(x, 3, out int rem);
                return rem == 0 ? 2 * q : 1;
            }).ToList();

            BigInteger prev = 1;
            BigInteger cur = 2;

            var result = range.Select(x =>
            {
                var temp = prev;
                prev = cur;
                cur = e[x-2] * prev + temp;
                return cur;
            }).Last();

            Console.WriteLine(result.SumDigits());
        }
    }
}
