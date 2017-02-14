using System;
using System.Collections.Concurrent;
using System.Threading.Tasks;
using Shared;

namespace LongestCollatzSequence
{
    //837799
    class LongestCollatzSequence
    {
        public static ConcurrentBag<Tuple<int, long>> Counts = new ConcurrentBag<Tuple<int, long>>();

        static void Main()
        {
            Timer.Record(FirstAttempt);
            Console.ReadLine();
        }

        private static void FirstAttempt()
        {
            Parallel.For(1, 1000000, i => Counts.Add(Tuple.Create(i, GetSequenceCount(i))));
            var answer = Counts.FirstOrderedBy(x => x.Item2);
            Console.WriteLine("The number {0} has {1} numbers in it's sequence", answer.Item1, answer.Item2);
        }

        private static long GetSequenceCount(long start)
        {
            long count = 1;
            while (start != 1)
            {
                if (start%2 == 0)
                    start = start/2;
                else
                    start = 3*start + 1;
                count++;
            }
            return count;
        }
    }
}
