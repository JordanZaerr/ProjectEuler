using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Shared;

namespace CodedTriangleNumbers
{
    //162
    class CodedTriangleNumbers
    {
        static void Main()
        {
            Timer.Record(FirstAttempt);
            Console.ReadLine();
        }

        private static void FirstAttempt()
        {
            var triangleNums = new HashSet<long>(NumberGenerators.GetTriangleNumbers(100));
            var input = Parse();
            var count = input.Count(x => triangleNums.Contains(x.Sum()));
            Console.WriteLine(count);
        }

        private static IEnumerable<IEnumerable<int>> Parse()
        {
            var input = File.ReadAllText("words.txt");
            return input.Split(',')
                .Select(x => x.Trim('"')
                    .Select(y => y -64));
        }
    }
}
