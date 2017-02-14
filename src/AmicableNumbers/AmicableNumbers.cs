using System;
using System.Collections.Generic;
using System.Linq;
using Shared;

namespace AmicableNumbers
{
    //31626
    class AmicableNumbers
    {
        static void Main()
        {
            Timer.Record(FirstAttempt);
            Console.ReadLine();
        }

        private static void FirstAttempt()
        {
            Console.WriteLine(FindAmicableNumber(10000).Sum());
        }

        private static IEnumerable<long> FindAmicableNumber(int total)
        {
            for (int i = 2; i < total; i++)
            {
                var factorsI = FindProperDivisorsSum(i);
                var factorsOfFactors = FindProperDivisorsSum(factorsI);
                if (factorsI > i && factorsOfFactors == i)
                    yield return i + factorsI;
            }
        }

        private static long FindProperDivisorsSum(long number)
        {
            return number.GetFactors().Sum();
        }
    }
}
