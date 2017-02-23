using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using Shared;

namespace LychrelNumber
{
    //249
    class LychrelNumber
    {
        static void Main()
        {
            //~280ms
            Timer.Record(FirstAttempt);
            Timer.Record(SecondAttempt);
            Console.ReadLine();
        }

        private static void FirstAttempt()
        {
            var lychrelNumbers = new List<BigInteger>();

            var iteration = 10;
            while (iteration <= 10000)
            {
                var num = new BigInteger(iteration);
                var lychrel = true;
                for (int i = 0; i < 50; i++)
                {
                    num = num + num.Reverse();
                    if (num.IsPalindrome())
                    {
                        lychrel = false;
                        break;
                    }
                }
                if(lychrel)
                    lychrelNumbers.Add(iteration);
                iteration++;
            }

            Console.WriteLine(lychrelNumbers.Count());
        }

        private static void SecondAttempt()
        {
            var total = Enumerable.Range(10, 9990)
                .Aggregate(0, (tot, cur) =>
                {
                    var num = new BigInteger(cur);
                    return Enumerable.Range(0, 50).EachBreakable(x =>
                    {
                        num += num.Reverse();
                        return !num.IsPalindrome();
                    }) ? tot : tot + 1;
                });
            Console.WriteLine(total);
        }
    }
}
