using System;
using System.Linq;
using Shared;

namespace PandigitalProducts
{
    //45228
    class PandigitalProducts
    {
        private const string seq = "123456789";
        static void Main()
        {
            Timer.Record(FirstAttempt);
            Console.ReadLine();
        }

        private static void FirstAttempt()
        {
            var range = Enumerable.Range(1, 2000).ToList();

            var result = range.SelectMany(a => 
                range.Select(b => IsPandigital(a, b)))
                .Where(x => x != -1).Distinct().Sum();
            Console.WriteLine(result);
        }

        private static int IsPandigital(int a, int b)
        {
            var val = a*b;
            var str = a + b.ToString() + val;
            if (str.OrderBy(x => x).Join() == seq)
                return val;
            return -1;
        }
    }
}
