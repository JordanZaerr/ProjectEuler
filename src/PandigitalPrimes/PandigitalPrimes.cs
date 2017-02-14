using System;
using System.Linq;
using Shared;

namespace PandigitalPrimes
{
    // 7652413
    class PandigitalPrimes
    {
        static void Main()
        {
            Timer.Record(FirstAttempt);
            Console.ReadLine();
        }

        private static void FirstAttempt()
        {
            var result = Primes.FindPrimesBySieveOfAtkins(8000000)
                .Last(x => x.IsPandigital());

            Console.WriteLine(result);
        }
    }
}
