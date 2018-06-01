using System;
using System.Numerics;
using Shared;

namespace LargeNonMersennePrime
{
    //8739992577
    class LargeNonMersennePrime
    {
        static void Main()
        {
            //411703ms, Super slow...
            Timer.Record(FirstAttempt);
            Console.ReadLine();
        }

        private static void FirstAttempt()
        {
            var i = new BigInteger(2);
            i = BigInteger.Pow(i, 7830457);
            i = BigInteger.Multiply(i, 28433);
            i = BigInteger.Add(i, 1);

            //Should be: 2,357,207
            var numberOfDigits = (int)Math.Ceiling(BigInteger.Log10(i));
            Console.WriteLine("{0:N0}", numberOfDigits);

            var str = i.ToString();
            Console.WriteLine(str.Substring(str.Length - 10));
        }
    }
}
