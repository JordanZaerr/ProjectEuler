using System;
using System.Linq;
using Shared;

namespace PermutedMultiples
{
    //142857
    class PermutedMultiples
    {
        static void Main()
        {
            //~400ms
            Timer.Record(FirstAttempt);
            Console.ReadLine();
        }

        private static void FirstAttempt()
        {
            var number = 1;
            while (true)
            {
                var results = Enumerable.Range(1, 6).Select(x => (number * x).ToString().OrderBy(y => y));
                var set = results.First();
                if (results.All(x => x.SequenceEqual(set)))
                {
                    Console.WriteLine(number);
                    return;
                }
                number++;
            }
        }
    }
}
