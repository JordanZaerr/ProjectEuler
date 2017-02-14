using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Shared;

namespace DistinctPrimeFactors
{
    //134043
    class DistinctPrimeFactors
    {
        static void Main()
        {
            Timer.Record(FirstAttempt);
            Console.ReadLine();
        }

        private static void FirstAttempt()
        {
            var primes = new HashSet<long>(Primes.FindPrimesBySieveOfAtkins(100000).Select(x => (long)x));

            var results = Enumerable.Range(100000, 50000)
                .Select(x =>
                {
                    var hash = new HashSet<long>(x.GetFactors());
                    hash.IntersectWith(primes);
                    return new FactorsObj(x, hash);
                })
                .Slide(4).First(x => x.All(y => y.Count == 4)).ToList();

            Console.WriteLine(results.First().Number);
        }

        [DebuggerDisplay("{Number}: {FactorsStr}")]
        private class FactorsObj
        {
            public int Count { get; private set; }
            public long Number { get; private set; }
            public string FactorsStr { get; private set; }

            public FactorsObj(long number, IEnumerable<long> factors)
            {
                Number = number;
                var factorsList = factors.ToList();
                FactorsStr = string.Join(",", factorsList);
                Count = factorsList.Count;
            }
        }
    }
}
