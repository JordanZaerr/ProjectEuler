using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using Shared;

namespace PowerfulDigitCounts
{
    //49
    class PowerfulDigitCounts
    {
        static void Main()
        {
            //10ms
            Timer.Record(FirstAttempt);
            //15ms
            Timer.Record(SecondAttempt);
            Console.ReadLine();
        }

        private static void FirstAttempt()
        {
            var list = new List<Tuple<int, int>>();
            for (int i = 1; i < 10; i++)
            {
                for (int x = 0; x < 25; x++)
                {
                    var length = BigInteger.Pow(new BigInteger(i), x).ToString().Length;
                    if(length == x)
                        list.Add(Tuple.Create(i,x));
                }
            }

            Console.WriteLine(list.Count);
        }

        private static void SecondAttempt()
        {
            var list = from num in Enumerable.Range(1, 10)
                from exp in Enumerable.Range(1, 25)
                where BigInteger.Pow(new BigInteger(num), exp).ToString().Length == exp
                select Tuple.Create(num, exp);

            Console.WriteLine(list.Count());
        }
    }
}
