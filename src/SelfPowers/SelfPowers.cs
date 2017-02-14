using System;
using System.Linq;
using System.Numerics;
using Shared;

namespace SelfPowers
{
    //9110846700
    class SelfPowers
    {
        static void Main()
        {
            Timer.Record(FirstAttempt);
            Console.ReadLine();
        }

        private static void FirstAttempt()
        {
            var range = Enumerable.Range(1, 1000).ToList();
            var sum = range
                .Select(x => BigInteger.Pow(x, x))
                .Aggregate(BigInteger.Add)
                .ToString();
            Console.WriteLine(sum.ReverseString().Substring(0, 10).ReverseString());
        }
    }
}
