using System;
using System.Linq;
using Shared;

namespace DigitFactorials
{
    //40730
    class DigitFactorials
    {
        static void Main()
        {
            Timer.Record(FirstAttempt);
            Console.ReadLine();
        }

        private static void FirstAttempt()
        {
            var results = Enumerable.Range(3, 50000).Where(input =>
            {
                var str = input.ToString();
                var sum = str.Sum(x =>
                    ((int)Char.GetNumericValue(x)).Factorial());
                return input == sum;
            }).ToList();
            
            Console.WriteLine(results.Sum());
        }
    }
}
