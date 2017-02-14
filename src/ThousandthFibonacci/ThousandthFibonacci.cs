using System;
using System.Numerics;
using Shared;

namespace ThousandthFibonacci
{
    //4782
    class ThousandthFibonacci
    {
        static void Main()
        {
            Timer.Record(FirstAttempt);
            Timer.Record(SecondAttempt);
            Console.ReadLine();
        }

        private static void FirstAttempt()
        {
            int total = 3;
            var last = new BigInteger(1);
            var current = new BigInteger(2);
            while (current.ToString().Length < 1000)
            {
                var temp = current + last;
               last = current;
               current = temp;
               total++;
            }
            Console.WriteLine(total);
        }

        private static void SecondAttempt()
        {
            Console.WriteLine(Fib(new BigInteger(1), new BigInteger(2), 3, 1000));
        }

        private static int Fib(BigInteger first, BigInteger second, int total, int stopAtLength)
        {
            var next = first + second;
            var newTotal = total+1;
            return next.ToString().Length >= stopAtLength ? newTotal : Fib(second, next, newTotal, stopAtLength);
        }
    }
}
