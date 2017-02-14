using System;
using System.Linq;
using Shared;

namespace FactorialDigitSum
{
    //648
    class FactorialDigitSum
    {
        static void Main()
        {
            Timer.Record(FirstAttempt);
            Console.ReadLine();
        }

        private static void FirstAttempt()
        {
            Console.WriteLine(100.FactorialBig()
                .ToString().Select(char.GetNumericValue).Sum());
        }
    }
}
