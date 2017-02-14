using System;
using System.Numerics;
using Shared;

namespace LatticePaths
{
    //137846528820
    class LatticePaths
    {
        static void Main()
        {
            Timer.Record(() => FirstAttempt(20,20));
            Console.ReadLine();
        }

        //http://mathworld.wolfram.com/BinomialCoefficient.html
        //Latic path is how many paths are there from (0,0) to (a,b)
        //Binomial for Lattic Path is
        // (a + b)
        //----------
        //    b
        //Equation for Binomials is
        //     n!
        //------------
        //  (n - k)! * k!
        private static void FirstAttempt(int a, int b)
        {
            var ab = a + b;
            var numerator = ab.FactorialBig();
            var denominator =  BigInteger.Multiply((ab - b).FactorialBig(), b.FactorialBig());
            var answer = BigInteger.Divide(numerator, denominator);
            Console.WriteLine(answer);
        }
    }
}
