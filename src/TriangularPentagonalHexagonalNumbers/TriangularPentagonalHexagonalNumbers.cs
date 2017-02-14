using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using Shared;

namespace TriangularPentagonalHexagonalNumbers
{
    //1533776805
    class TriangularPentagonalHexagonalNumbers
    {
        static void Main()
        {
            Timer.Record(FirstAttempt);
            Console.ReadLine();
        }

        private static void FirstAttempt()
        {
            const int count = 100000;
            var triangle = new HashSet<BigInteger>(NumberGenerators.GetTriangleNumbersBig(count));
            var pentagonal = new HashSet<BigInteger>(NumberGenerators.GetPentagonalNumbersBig(count));
            var hexagonal = new HashSet<BigInteger>(NumberGenerators.GetHexagonalNumbersBig(count));

            var number = triangle.Skip(285)
                .SkipWhile(x => !pentagonal.Contains(x) || !hexagonal.Contains(x)).First();
            Console.WriteLine(number);
        }
    }
}
