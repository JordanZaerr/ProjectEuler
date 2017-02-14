using System;
using System.Linq;
using Shared;

namespace SmallestMultiple
{
    //232,792,560
    class SmallestMultiple
    {
        static void Main()
        {
//            Timer.Record(FirstAttempt);
            Timer.Record(SecondAttempt);
            Console.ReadLine();
        }

        //~13 seconds
        private static void FirstAttempt()
        {
            int number = 1;
            var values = Enumerable.Range(1, 20).Reverse().ToList();
            while (values.Any(x => number % x != 0))
            {
                number++;
            }
            Console.WriteLine(number);
        }

        //~2ms
        private static void SecondAttempt()
        {
            var number = Enumerable.Range(1, 20).Aggregate(MathFunctions.LowestCommonMultiple);
            Console.WriteLine(number);
        }
    }
}
