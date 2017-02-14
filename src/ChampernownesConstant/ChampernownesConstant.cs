using System;
using System.Linq;
using Shared;

namespace ChampernownesConstant
{
    //210
    class ChampernownesConstant
    {
        static void Main()
        {
            Timer.Record(FirstAttempt);
            Console.ReadLine();
        }

        private static void FirstAttempt()
        {
            var constant = Enumerable.Range(1, 1000000).Join();
            var result = Enumerable.Range(0, 7)
                .Select(x => (int)Char.GetNumericValue(constant[(int)Math.Pow(10, x) - 1]))
                .Product();

            Console.WriteLine(result);
        }
    }
}
