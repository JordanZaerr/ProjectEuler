using System;
using System.Diagnostics;
using System.Linq;
using Shared;

namespace LargestPrimeFactor
{
    //6857
    class LargestPrimeFactor
    {
        static void Main()
        {
            var watch = Stopwatch.StartNew();
            long number = 600851475143;
            var largestPrimeFactor = Primes.FindPrimesBySieveOfAtkins((int)Math.Sqrt(number))
                .Last(x => number % x == 0);
            watch.Stop();
            Console.WriteLine(watch.ElapsedMilliseconds);
            Console.WriteLine(largestPrimeFactor);
            Console.ReadLine();
        }
    }
}
