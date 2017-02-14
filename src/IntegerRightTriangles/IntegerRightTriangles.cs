using System;
using System.Linq;
using Shared;

namespace IntegerRightTriangles
{
    //840
    class IntegerRightTriangles
    {
        static void Main()
        {
            Timer.Record(FirstAttempt);
            Console.ReadLine();
        }

        private static void FirstAttempt()
        {
            const int max = 1000;
            var result = Enumerable.Range(1, max/5)
                .SelectMany(a => Enumerable.Range(a, max - a)
                    .SelectMany(b => Enumerable.Range(b, max - b)
                        .Select(c => new Triangle(a, b, c))))
                .Where(x => x.Sum <= max && x.IsRight)
                .GroupBy(x => x.Sum)
                .OrderByDescending(x => x.Count())
                .First();

            Console.WriteLine("{0} has {1} right triangles", result.Key, result.Count());
        }

        public class Triangle
        {
            public int A { get; private set; }
            public int B { get; private set; }
            public int C { get; private set; }
            public int Sum { get; private set; }

            public Triangle(int a, int b, int c)
            {
                A = a;
                B = b;
                C = c;
                Sum = a + b + c;
            }

            public bool IsRight
            {
                get
                {
                    return A*A + B*B == C*C;
                }
            }
        }
    }
}
