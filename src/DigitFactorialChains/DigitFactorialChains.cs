using System;
using System.Collections.Generic;
using System.Linq;
using Shared;

namespace DigitFactorialChains
{
    //402
    class DigitFactorialChains
    {
        static void Main()
        {
            //8750ms
            Timer.Record(FirstAttempt);
            Console.ReadLine();
        }

        private static void FirstAttempt()
        {
            var result = Enumerable.Range(1, 1000000).AsParallel().Count(ChainLengthOf60);
            Console.WriteLine(result);
        }

        private static bool ChainLengthOf60(int num)
        {
            var pastNumbers = new HashSet<int>{num};
            var result = FactorialDigits(num);

            while (!pastNumbers.Contains(result))
            {
                pastNumbers.Add(result);
                result = FactorialDigits(result);
            }
            return pastNumbers.Count == 60;
        }

        private static int FactorialDigits(int num)
        {
            return (int)num
                .ToString()
                .ToCharArray()
                .Select(x => x - 48)
                .Sum(x => x.Factorial());
        }
    }
}
