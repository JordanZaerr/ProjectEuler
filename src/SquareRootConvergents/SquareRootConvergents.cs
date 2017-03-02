using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using Shared;

namespace SquareRootConvergents
{
    //153
    class SquareRootConvergents
    {
        static void Main()
        {
            //Failure, or rather I just stopped since a pattern developed.
            //Timer.Record(FirstAttempt);

            //~25ms
            Timer.Record(SecondAttempt);
            Console.ReadLine();
        }

        private static void SecondAttempt()
        {
            var fractions = GetNext(3).Take(999).Zip(GetNext(2).Take(999), (num, den) => new { num, den });
            Console.WriteLine(fractions.Count(x => x.num.ToString().Length > x.den.ToString().Length));
        }

        private static IEnumerable<BigInteger> GetNext(int start)
        {
            var current = new BigInteger(start);
            var previous = new BigInteger(1);
            while (true)
            {
                // 2x the current value + the previous value generates 
                // the next value for both the numerator and denominators.
                var newCurrent = current * 2 + previous;
                previous = current;
                yield return newCurrent;
                current = newCurrent;
            }
        }

        private static void FirstAttempt()
        {
            Console.WriteLine("First");
            Console.WriteLine(2);
            Console.WriteLine(GetDenominator(1));
            Console.WriteLine();

            Console.WriteLine("Second");

            Console.WriteLine((2 + 1/2m));
            Console.WriteLine(GetDenominator(2));
            Console.WriteLine();

            Console.WriteLine("Third");
            Console.WriteLine((2 + 1/(2 + 1/2m)));

            Console.WriteLine(GetDenominator(3));
            Console.WriteLine();

            Console.WriteLine("Fourth");
            Console.WriteLine((2 + 1/(2 + 1/(2 + 1/2m))));
            Console.WriteLine(GetDenominator(4));
            Console.WriteLine();

            Console.WriteLine("Fifth");
            Console.WriteLine((2 + 1 / (2 + 1 / (2 + 1 / (2 + 1 / 2m)))));
            Console.WriteLine(GetDenominator(5));
            Console.WriteLine();

            Console.WriteLine("Sixth");
            Console.WriteLine((2 + 1 / (2 + 1 / (2 + 1 / (2 + 1 / (2 + 1 / 2m))))));
            Console.WriteLine(GetDenominator(6));
            Console.WriteLine();

            Console.WriteLine(GetDenominator(8));
        }

        private static decimal GetDenominator(int iteration)
        {
            iteration--;
            Func<Func<decimal>, decimal> funcGraph = x =>  x();
            while (iteration != 0)
            {
                var graph = funcGraph;
                funcGraph = x => 2 + 1 / graph(x);
                iteration--;
            }
            return funcGraph(() => 2);
        }
    }
}
