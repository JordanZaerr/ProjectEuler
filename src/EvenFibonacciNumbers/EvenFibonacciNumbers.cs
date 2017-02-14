using System;
using System.Collections.Generic;
using System.Linq;

namespace EvenFibonacciNumbers
{
    class EvenFibonacciNumbers
    {
        //4613732
        static void Main()
        {
//******Attempt One******
//            int total = 2;
//            int last = 1;
//            int current = 2;
//
//            while (current < 4000000)
//            {
//                var temp = current + last;
//               last = current;
//               current = temp;
//                if (current%2 == 0)
//                    total += current;
//            }


//******Attempt Two******
//            var total = FibGen().Aggregate((t, c) => c % 2 == 0 ? t + c : t);


//******Attempt Three******
            var total = Fib(1, 2, 2, 4000000);



            Console.WriteLine(total);
            Console.ReadLine();
        }

        //******Attempt Two******
        private static IEnumerable<int> FibGen()
        {
            int current = 1;
            int last = 1;
            while (current < 4000000)
            {
                var newCurrent = current + last;
                last = current;
                yield return newCurrent;
                current = newCurrent;
            }
        }

        //******Attempt Three******
        private static int Fib(int first, int second, int total, int stopAt)
        {
            var next = first + second;
            if (next%2 == 0)
                total += next;
            return next >= stopAt ? total : Fib(second, next, total, stopAt);
        }
    }
}
