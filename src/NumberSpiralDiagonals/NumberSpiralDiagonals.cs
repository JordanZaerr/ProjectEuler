using System;
using System.Collections.Generic;
using System.Linq;
using Shared;

namespace NumberSpiralDiagonals
{
    //669171001
    class NumberSpiralDiagonals
    {
        static void Main()
        {
            Timer.Record(FirstAttempt);
            Console.ReadLine();
        }

        //43 44 45 46 47 48 49
        //42 21 22 23 24 25 26
        //41 20  7  8  9 10 27
        //40 19  6  1  2 11 28
        //39 18  5  4  3 12 29
        //38 17 16 15 14 13 30
        //37 36 35 34 33 32 31
        
        //1, 9, 25, 49 (3^2, 5^2, 7^2)
        //1, 5, 17, 37 (-4, -8, -12 from top row)
        //1, 7, 21, 43 (-2, -4, -6 from top row)
        //1, 3, 13, 31 (-6, -12, -18 from top row)
        private static void FirstAttempt()
        {
            var list = new List<int>{1};
            int row2 = 0, row3 = 0, row4 = 0;

            Enumerable.Range(2, 1001).Where(x => x%2 == 1)
                .Each(x =>
                {
                    var num = x*x;
                    list.Add(num);
                    list.Add(num - (row2 += 4));
                    list.Add(num - (row3 += 2));
                    list.Add(num - (row4 += 6));
                });
            Console.WriteLine(list.Sum());
        }
    }
}
