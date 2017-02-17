using System;
using System.Linq;
using Shared;

namespace CombinatoricSelections
{
    //4075
    class CombinatoricSelections
    {
        static void Main()
        {
            //~130ms
            Timer.Record(FirstAttempt);
            Console.ReadLine();
        }

        private static void FirstAttempt()
        {
            var values = Enumerable.Range(1, 100)
                .SelectMany(n => Enumerable.Range(1, n)
                .Select(r => n.FactorialBig() / (r.FactorialBig() * (n - r).FactorialBig())))
                .Where(x => x > 1000000);

            Console.WriteLine(values.Count());
        }
    }
}
