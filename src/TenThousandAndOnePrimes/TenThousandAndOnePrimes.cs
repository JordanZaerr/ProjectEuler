using System;
using System.Collections.Generic;
using System.Linq;
using Shared;

namespace TenThousandAndOnePrimes
{
    //104743
    class TenThousandAndOnePrimes
    {
        private static void Main()
        {
            //Timer.Record(FirstAttempt);
            Timer.Record(SecondAttempt);
            Console.ReadLine();
        }

        private static void FirstAttempt()
        {
            //Hackish....
            var primes = Primes.FindPrimesBySieveOfAtkins(105000);
            Console.WriteLine(primes.Count);
            Console.WriteLine(primes[10000]);
        }

        //Pedro's idea
        private static void SecondAttempt()
        {
            var primes = new List<int>(10001){2};
            int current = 3;
            while (primes.Count < 10001)
            {
                if (primes.All(x => current%x != 0))
                    primes.Add(current);
                current += 2;
            }
            Console.WriteLine(primes[primes.Count - 1]);
        }
    }
}
