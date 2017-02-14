using System;
using System.Linq;
using Shared;

namespace LexicographicPermutations
{
    //2783915460
    class LexicographicPermutations
    {
        static void Main()
        {
            Timer.Record(FirstAttempt);
            Console.ReadLine();
        }

        private static void FirstAttempt()
        {
            Console.WriteLine(Enumerable.Range(0,10).Join().GetPermutations().ElementAt(999999));
        }
    }
}
