using System;
using System.Linq;
using System.Numerics;
using Shared;

namespace PowerDigitSum
{
    //1366
    class PowerDigitSum
    {
        static void Main()
        {
            Timer.Record(FirstAttempt);
            Console.ReadLine();
        }

        private static void FirstAttempt()
        {
            var exponent = BigInteger.Pow(new BigInteger(2), 1000);
            var sum = exponent.ToString().Select(char.GetNumericValue).Sum();
            Console.WriteLine(sum);
        }
    }
}
