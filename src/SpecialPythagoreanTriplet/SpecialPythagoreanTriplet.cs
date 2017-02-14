using System;
using System.Linq;
using Shared;

namespace SpecialPythagoreanTriplet
{
    //31875000, A=200, B=375, C=425
    class SpecialPythagoreanTriplet
    {
        static void Main()
        {
            Timer.Record(FirstAttempt);
            Console.ReadLine();
        }

        public static void FirstAttempt()
        {
            var range = Enumerable.Range(1, 500).ToList();

            var triangle = range
                .SelectMany(c => range
                    .SelectMany(b => range
                        .Where(a => a*a + b*b == c*c && a + b + c == 1000)
                        .Select(a => new {a,b,c} )))
                .Last();

            Console.WriteLine(triangle);
            Console.WriteLine(triangle.a * triangle.b * triangle.c);
            Console.WriteLine("Done");
        }
    }
}
