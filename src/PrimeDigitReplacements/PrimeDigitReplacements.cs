using System;
using Shared;

namespace PrimeDigitReplacements
{
    //Unsolved
    class PrimeDigitReplacements
    {
        static void Main()
        {
            Timer.Record(FirstAttempt);
            Console.ReadLine();
        }

        private static void FirstAttempt()
        {
            var primes = Primes.FindPrimesBySieveOfAtkins(1000000);
            Console.WriteLine(primes.Count);
        }
    }
}
