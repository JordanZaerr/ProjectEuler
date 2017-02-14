using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Shared;

namespace PrimePermutations
{
    //296962999629 - 2969,6299,9629
    class PrimePermutations
    {
        static void Main()
        {
            Timer.Record(SecondAttemt);
            Console.ReadLine();
        }

        private static void FirstAttempt()
        {
            var fourDigitPrimes = Primes.FindPrimesBySieveOfAtkins(10000)
                .Where(x => x.ToString().Length == 4).ToList();

            //1487, 4817, 8147
            var col = new[]{1487}.Select(x => 
                new 
                {
                    Prime = x, 
                    Primes = x.ToString().GetPermutations()
                              .Select(int.Parse).Intersect(fourDigitPrimes)
                              .OrderBy(y=>y).ToList() 
                }).Where(x => x.Primes.Count > 0).ToList();

            var listsOfDiff = col.SelectMany(x => 
                x.Primes.SelectMany(y => 
                    x.Primes.Select(z =>  new {y,z, diff = (y-z)} )
                    .Where(xx => xx.diff > 0).ToList())
                    .ToList()).ToList();

            var listOfGroups = listsOfDiff.GroupBy(x => x.diff)
                .Select(y => y.OrderBy(z => z.z))
                .Where(x => x.Count() > 1).ToList();

            Console.WriteLine();
        }

        private static void SecondAttemt()
        {
            var fourDigitPrimes = Primes.FindPrimesBySieveOfAtkins(100000)
               .Where(x => x.ToString().Length == 4).ToList();

            var test = new[] {1487, 4817, 8147};

            //1487, 4817, 8147
            var result = fourDigitPrimes.Select(x =>
                new PrimeHolder
                    (
                        x,
                        x.ToString().GetPermutations()
                            .Select(int.Parse).Intersect(fourDigitPrimes)
                            .OrderBy(y => y).Except(new[] {x}).ToList()
                    )).Select(x =>
                    {
                        var r = HasDupes(x.Prime, x.Primes);
                        if (r.Any() && !test.Contains(x.Prime))
                            return r.First();
                        return null;
                    }).First(x => x != null);

            Console.WriteLine(result.P1.ToString() + result.P2 + result.P3);
        }

        private static IEnumerable<Holder>  HasDupes(int prime, IEnumerable<int> primes)
        {
            return primes.Select(p => new {prime, diff= p - prime})
                .Select(x => new Holder {P1 = x.prime, Diff = x.diff, P2= prime + x.diff, P3 = prime+x.diff*2 })
                .Where(x => x.Diff > 0 && primes.Contains(x.P2) && primes.Contains(x.P3));
        }

        [DebuggerDisplay("{P1}, {P2}, {P3}, Diff={Diff}")]
        private class Holder
        {
            public int P1 { get; set; }
            public int P2 { get; set; }
            public int P3 { get; set; }
            public int Diff { get; set; }
        }

        [DebuggerDisplay("{Prime}")]
        private class PrimeHolder
        {
            public int Prime { get; private set; }
            public IList<int> Primes { get; private set; }

            public PrimeHolder(int prime, IList<int> primes)
            {
                Prime = prime;
                Primes = primes;
            }
        }
    }
}
