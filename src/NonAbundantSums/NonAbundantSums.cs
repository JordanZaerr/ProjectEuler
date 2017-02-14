using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Threading.Tasks;
using Shared;

namespace NonAbundantSums
{
    //4179871
    class NonAbundantSums
    {
        static void Main()
        {
            Timer.Record(FirstAttempt);
            Console.ReadLine();
        }

        private static void FirstAttempt()
        {
            var range = Enumerable.Range(1, 28123).ToList();
            var abundants = range.Where(x => x.GetFactors().Sum() > x).ToList();

            //Ridiculous that I have to use a dictionary here but oh well, its much faster this way.
            var nonAbundantSums = new ConcurrentDictionary<int, int>(range.ToDictionary(k => k, v => 0));
            var halfAbundants = abundants.Take((int)Math.Ceiling(abundants.Count/2.0)).ToList();
            int _;
            Parallel.ForEach(abundants, x => 
                Parallel.ForEach(halfAbundants, y => nonAbundantSums.TryRemove((x + y), out _)));
            Console.WriteLine(nonAbundantSums.Keys.Sum());
        }
    }
}
