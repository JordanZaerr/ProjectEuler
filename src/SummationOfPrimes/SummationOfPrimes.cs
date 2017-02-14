using System;
using System.Linq;
using Shared;

namespace SummationOfPrimes
{
    //142,913,828,922
    class SummationOfPrimes
    {
        static void Main()
        {
            Timer.Record(FirstAttempt);
            Console.ReadLine();
        }

        private static void FirstAttempt()
        {
            //TODO:Not sure why .Cast<long>() doesn't work here, invalid cast exception
            Console.WriteLine(Primes
                .FindPrimesBySieveOfAtkins(2000000).Select(x => (long)x).Sum());
        }
    }
}
