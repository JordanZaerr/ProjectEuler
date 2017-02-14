using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Threading.Tasks;
using Shared;

namespace DigitFifthPowers
{
    //443839
    class DigitFifthPowers
    {
        static void Main()
        {
            Timer.Record(FirstAttempt);
            Timer.Record(SecondAttempt);
            Console.ReadLine();
        }

        private static void FirstAttempt()
        {
            var list = new ConcurrentDictionary<int, int>();
            Parallel.For(2,
                1000000,
                num =>
                {
                    var sum = (int)num.ToString().Select(x => Math.Pow(Char.GetNumericValue(x), 5)).Sum();
                    if (num == sum) list[num] = 0;
                });
            Console.WriteLine(list.Keys.Sum());
        }

        private static void SecondAttempt()
        {
            var result = 
                Enumerable.Range(2, 999998)
                .Where(num => num == (int)num.ToString().Select(x => Math.Pow(Char.GetNumericValue(x), 5))
                .Sum()).Sum();

            Console.WriteLine(result);
        }
    }
}
