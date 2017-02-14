using System;
using System.Collections.Generic;
using System.Linq;

namespace SumSquareDifference
{
    //25164150
    class SumSquareDifference
    {
        static void Main()
        {
            FirstAttempt();
            Console.ReadLine();
        }

        private static void FirstAttempt()
        {
            var values = Enumerable.Range(1, 100).ToList();
            Console.WriteLine(Math.Pow(values.Sum(), 2) - values.Sum(x => Math.Pow(x, 2)));
            Console.ReadLine();
        }
    }
}
