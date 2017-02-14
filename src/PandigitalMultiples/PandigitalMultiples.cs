using System;
using System.Linq;
using Shared;

namespace PandigitalMultiples
{
    //932718654
    class PandigitalMultiples
    {
        static void Main()
        {
            Timer.Record(FirstAttempt);
            Console.ReadLine();
        }

        private static void FirstAttempt()
        {
            var res = Enumerable.Range(1, 10000)
                .Select(x => CreateNumber(x, 9))
                .Where(x => x.IsPandigital())
                .FirstOrderedBy(x => x);

            Console.WriteLine(res);
        }

        private static string CreateNumber(int seed, int length, int count = 1, string str = "")
        {
            str += seed*count;
            return str.Length < length ? CreateNumber(seed, length, count + 1, str) : str;
        }
    }
}
