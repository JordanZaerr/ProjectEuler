using System;
using System.Collections.Generic;
using Shared;

namespace HighlyDivisibleTriangularNumber
{
    //76576500
    class HighlyDivisibleTriangularNumber
    {
        static void Main()
        {
            Timer.Record(FirstAttempt);
            Console.ReadLine();
        }

        public static void FirstAttempt()
        {
            long count = 0;
            long answer = 0;
            foreach (var number in Generator.GetTriangleNumbers())
            {
                count = number.GetNumberOfFactors();
                if (count > 500)
                {
                    answer = number;
                    break;
                }
            }
            Console.WriteLine("Number {0} has {1} factors", answer, count);
        }
    }

    internal static class Generator
    {
        public static IEnumerable<long> GetTriangleNumbers()
        {
            int start = 1;
            long total = 0;
            while (true)
            {
                yield return total += start;
                start++;
            }
        }
    }
}
