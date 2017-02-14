using System;
using System.Linq;
using Shared;

namespace SubStringDivisibility
{
    //16695334890
    class SubStringDivisibility
    {
        static void Main()
        {
            Timer.Record(FirstAttempt);
            Console.ReadLine();
        }

        private static void FirstAttempt()
        {
            //~18 seconds
            var sum = 
                Enumerable.Range(0, 10)
                          .Join()
                          .GetPermutations()
                          .Where(IsOddlyDivisible)
                          .Sum(x => long.Parse(x));
            Console.WriteLine(sum);

            //~14 seconds
//            var results = new ConcurrentBag<long>();
//            var permutations = Enumerable.Range(0, 10).Join().GetPermutations().ToList();
//            Parallel.For(0, permutations.Count, x =>
//            {
//                var val = permutations[x];
//                if(IsOddlyDivisible(val))
//                    results.Add(long.Parse(val));
//            });
//            Console.WriteLine(results.Sum());
        }

        //Let d1 be the 1st digit, d2 be the 2nd digit, and so on. In this way, we note the following:
        //d2d3d4=406 is divisible by 2
        //d3d4d5=063 is divisible by 3
        //d4d5d6=635 is divisible by 5
        //d5d6d7=357 is divisible by 7
        //d6d7d8=572 is divisible by 11
        //d7d8d9=728 is divisible by 13
        //d8d9d10=289 is divisible by 17
        private static bool IsOddlyDivisible(string number)
        {
            var divisors = new[] {2,3,5,7,11,13,17};
            return number.Slide(3).Skip(1).Zip(divisors, (c3, d) => int.Parse(c3.Join())%d == 0).All(x => x);
        }
    }
}
