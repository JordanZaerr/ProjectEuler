using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shared
{
    public static class Primes
    {
        //http://en.wikipedia.org/wiki/Sieve_of_Atkin
        public static List<int> FindPrimesBySieveOfAtkins(int max)
        {
            var sqrt = (int)Math.Sqrt(max);
            var isPrime = new bool[max + 1];
            Parallel.For(1,
                sqrt,
                x =>
                {
                    var xx = x*x;
                    for (int y = 1; y <= sqrt; y++)
                    {
                        var yy = y*y;
                        var n = 4*xx + yy;
                        if (n <= max && (n%12 == 1 || n%12 == 5))
                            isPrime[n] ^= true;

                        n = 3*xx + yy;
                        if (n <= max && n%12 == 7)
                            isPrime[n] ^= true;

                        n = 3*xx - yy;
                        if (x > y && n <= max && n%12 == 11)
                            isPrime[n] ^= true;
                    }
                });

            var primes = new List<int>() {2, 3};
            for (int n = 5; n <= sqrt; n++)
            {
                if (isPrime[n])
                {
                    primes.Add(n);
                    int nn = n*n;
                    for (int k = nn; k <= max; k += nn)
                        isPrime[k] = false;
                }
            }

            for (int n = sqrt + 1; n <= max; n++)
                if (isPrime[n])
                    primes.Add(n);

            return primes.ToList();
        }

        public static bool IsPrime(this int n)
        {
            if (n <= 1) return false;
            if (n == 2) return true;
            if (n % 2 == 0) return false;
            if (n < 9) return true;
            if (n % 3 == 0) return false;

            long counter = 5;
            while ((counter * counter) <= n)
            {
                if (n % counter == 0) return false;
                if (n % (counter + 2) == 0) return false;
                counter += 6;
            }

            return true;
        }
    }
}
