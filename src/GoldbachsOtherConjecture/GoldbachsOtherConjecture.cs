using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Shared;

namespace GoldbachsOtherConjecture
{
    //5777
    class GoldbachsOtherConjecture
    {
        static void Main()
        {
            Timer.Record(FirstAttempt);
            Timer.Record(SecondAttempt);
            Console.ReadLine();
        }

        //Way uglier but faster
        private static void FirstAttempt()
        {
            const int length = 10000;
            var primes = Primes.FindPrimesBySieveOfAtkins(length);
            var composites = Enumerable.Range(2, length).Except(primes).Where(x => x%2==1).ToList();

            var results = new List<Conjecture>();
            foreach (var comp in  composites)
            {
                var badResult = false;
                foreach (var prime in primes)
                {
                    if (prime >= comp)
                    {
                        badResult = true;
                        results.Add(new Conjecture(comp, -1, -1));
                        break;
                    }
                    var foundResult = false;
                    for (int i = 0; i < (int)Math.Sqrt(comp); i++)
                    {
                        if (comp == (prime + (2*(i*i))))
                        {
                            foundResult = true;
                            results.Add(new Conjecture(comp, prime, i));
                            break;
                        }
                    }
                    if (foundResult)
                        break;
                }
                if (badResult)
                    break;
            }

            var result = results.FirstOrDefault(x => x.Prime == -1);
            Console.WriteLine(result.Composite);
        }

        //Cleaner but 3-4X slower
        private static void SecondAttempt()
        {
            const int length = 10000;
            var primes = Primes.FindPrimesBySieveOfAtkins(length);
            var composites = Enumerable.Range(2, length).Except(primes).Where(x => x % 2 == 1).ToList();

            var results = composites
                .Select(c => FindPrime(c, primes.Where(pr => pr < c)))
                .First(x => x.Prime == -1);
            Console.WriteLine(results.Composite);
        }

        private static Conjecture FindPrime(int comp, IEnumerable<int> primes)
        {
            var result = primes.Select(p => FindSquare(comp, p)).FirstOrDefault(x => x != null);
            return result ?? new Conjecture(comp, -1, -1);
        }

        private static Conjecture FindSquare(int comp, int prime)
        {
            return Enumerable.Range(1, (int)Math.Sqrt(comp))
                .Select(x => comp == (prime + (2*(x*x))) ? new Conjecture(comp, prime, x) : null)
                .FirstOrDefault(x => x != null);
        }
    }

    [DebuggerDisplay("Composite: {Composite} = {Prime} + 2({Square})^2")]
    internal class Conjecture
    {
        public int Composite { get; set; }
        public int Prime { get; set; }
        public int Square { get; set; }

        public Conjecture(int composite, int prime, int square)
        {
            Composite = composite;
            Prime = prime;
            Square = square;
        }
    }
}
