using System;
using System.Collections.Generic;
using System.Linq;
using Shared;

namespace PentagonNumbers
{
    //5482660
    class PentagonNumbers
    {
        static void Main()
        {
            Timer.Record(FirstAttempt);
            Console.ReadLine();
        }

        private static void FirstAttempt()
        {
            var numbers = new HashSet<long>(NumberGenerators.GetPentagonalNumbers(2500));

            var absoluteValues = numbers.SelectMany(a => numbers.Select(b =>
            {
                var abs = Math.Abs(a - b);
                var plus = a + b;
                if (numbers.Contains(abs) && numbers.Contains(plus))
                    return abs;
                return int.MaxValue;
            }))
            .Where(x => x != int.MaxValue)
            .OrderBy(x => x);

            Console.WriteLine(absoluteValues.First());
        }
    }
}
