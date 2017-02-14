using System;
using System.Collections.Generic;
using System.Linq;
using Shared;

namespace TruncatablePrimes
{
    //748317
    class TruncatablePrimes
    {
        static void Main()
        {
            Timer.Record(FirstAttempt);
            Console.ReadLine();
        }

        private static void FirstAttempt()
        {
            var primes = Primes.FindPrimesBySieveOfAtkins(1000000);
            var primesHash = new HashSet<int>(primes);

            var numbers = primes.Skip(4)
                .Where(x => x.LeftTrun().Concat(x.RightTrun())
                    .All(primesHash.Contains));

            Console.WriteLine(numbers.Sum());
        }
    }
}
