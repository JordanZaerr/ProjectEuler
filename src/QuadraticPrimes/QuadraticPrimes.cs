using System;
using System.Collections.Generic;
using System.Linq;
using Shared;

namespace QuadraticPrimes
{
    //-59231
    class QuadraticPrimes
    {
        private static List<int> primesNumbers;

        static void Main()
        {
            QuadraticPrimes.primesNumbers = Primes.FindPrimesBySieveOfAtkins(10000);
            Timer.Record(FirstAttempt);
            Console.ReadLine();
        }

        private static void FirstAttempt()
        {
            var range = Enumerable.Range(-1000, 2000).ToList();

            var result = range.SelectMany(a => range.Select(b => new {a, b, total= GetMaxPrimes(a, b)}))
                .FirstOrderedBy(x => x.total);

            Console.WriteLine(result);
            Console.WriteLine(result.a * result.b);
        }

        private static int GetMaxPrimes(int a, int b)
        {
            int n = 0;
            while(primesNumbers.Contains(Formula(a,b,n)))
            {
                n++;
            }
            return n;
        }

        private static int Formula(int a, int b, int n)
        {
            return (int)Math.Pow(n, 2) + a*n + b;
        }
    }
}
