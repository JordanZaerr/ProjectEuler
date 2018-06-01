using System;
using System.Linq;
using Shared;

namespace SquareDigitChain
{
    //8581146
    class SquareDigitChain
    {
        static void Main()
        {
            //9500ms
            Timer.Record(FirstAttempt);
            Console.ReadLine();
        }

        private static void FirstAttempt()
        {
            var result = Enumerable.Range(1, 10000000).AsParallel().Count(TerminatesWith89);
            Console.WriteLine(result);
        }

        private static bool TerminatesWith89(int num)
        {
            var result = SquareDigits(num);
            while (!(result == 1 || result == 89))
            {
                result = SquareDigits(result);
            }
            return result == 89;
        }

        private static int SquareDigits(int num)
        {
            return (int) num
                .ToString()
                .ToCharArray()
                .Select(x => x - 48)
                .Sum(x => Math.Pow(x, 2));
        }
    }
}
