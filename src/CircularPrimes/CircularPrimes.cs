using System;
using System.Collections.Generic;
using System.Linq;
using Shared;

namespace CircularPrimes
{
    //55
    class CircularPrimes
    {
        static void Main()
        {
            Timer.Record(FirstAttempt);
            Console.ReadLine();
        }

        private static void FirstAttempt()
        {
            var primes = new HashSet<int>(Primes.FindPrimesBySieveOfAtkins(1000000));
            var result = Enumerable.Range(1, 1000000)
                .Where(x =>
                {
                        var xStr = x.ToString();
                        var values = CreateCircularStrings(xStr
                            .Select(y => y.ToString())
                            .ToList()).Select(int.Parse);
                    return primes.Contains(x) 
                        && values.All(primes.Contains);
                }).ToList();
            Console.WriteLine(result.Count);
        }

        private static IEnumerable<string> CreateCircularStrings(IEnumerable<string> input)
        {
            var first = input.Join();
            string current = first;
            do
            {
                var l = new List<string>(current.Select(x => x.ToString()));
                var f = l.First();
                l.RemoveAt(0);
                l.Add(f);
                yield return current = l.Join();
            } while (first != current);
        }
    }
}
