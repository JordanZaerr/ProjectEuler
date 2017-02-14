using System;
using System.Linq;
using System.Numerics;
using Shared;

namespace DistinctPowers
{
    //9183
    class DistinctPowers
    {
        static void Main()
        {
            Timer.Record(FirstAttempt);
            Console.ReadLine();
        }

        private static void FirstAttempt()
        {
            var range = Enumerable.Range(2, 99);
            var rangeBig = range.Select(x => new BigInteger(x)).ToList();
            var result = rangeBig.SelectMany(a => range.Select(b => BigInteger.Pow(a, b))).Distinct();
            Console.WriteLine(result.Count());
        }
    }
}
