using System;
using System.Linq;
using System.Numerics;
using Shared;

namespace PowerfulDigitSums
{
    //972
    class PowerfulDigitSums
    {
        static void Main()
        {
            //~150ms
            Timer.Record(FirstAttempt);
            Console.ReadLine();
        }

        private static void FirstAttempt()
        {
            // You can move the start number up to make it 
            // significantly faster (95 is the highest).
            var start = 1;
            var count = 100 - start;
            var results = Enumerable.Range(start, count)
                .Select(a => new BigInteger(a))
                .SelectMany(a => Enumerable.Range(start, count)
                    .Select(b => BigInteger.Pow(a, b)))
                .Select(SumDigits)
                .Max();

            Console.WriteLine(results);
        }

        private static int SumDigits(BigInteger number)
        {
            return number.ToString().Select(x => x.ToString()).Select(int.Parse).Sum();
        }
    }
}
