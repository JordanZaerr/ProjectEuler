using System;
using System.Collections.Generic;
using System.Linq;
using Shared;

namespace ReciprocalCycles
{
    //983
    class ReciprocalCycles
    {
        static void Main()
        {
            Timer.Record(FirstAttempt);
            Console.ReadLine();
        }

        private static void FirstAttempt()
        {
            var chainIndex = 0;
            var foundChainLength = 0;
            for (int x = 1000 - 1; x >= 0; x--)
            {
                if (foundChainLength > x) break;

                var result = new List<int>();
                int input = x;
                int remainder = 1;
                for (int i = 0; i < 1000; i++)
                {
                    remainder = remainder*10;
                    result.Add(remainder/input);
                    remainder = remainder%input;
                }
                var chainLength = FindChainLength(result);
                if (chainLength > foundChainLength)
                {
                    foundChainLength = chainLength;
                    chainIndex = x;
                }
            }

            Console.WriteLine("Sequence {0} has a chain length of {1}", chainIndex, foundChainLength);

            //Not as fast of an implmentation....
//             var chain = Enumerable.Range(1, 999).Reverse().For((x, y) =>
//             {
//                var result = new List<int>();
//                int input = x;
//                int remainder = 1;
//                for (int i = 0; i < 1000; i++)
//                {
//                    remainder = remainder*10;
//                    result.Add(remainder/input);
//                    remainder = remainder%input;
//                }
//                var chainLength = FindChainLength(result);
//                if (chainLength > foundChainLength)
//                    foundChainLength = chainLength;
//                
//                return new {Input = x, ChainSize = FindChainLength(result)};
//            }).Where(x => x.ChainSize > 1).OrderByDescending(x => x.ChainSize).First();
//            Console.WriteLine(chain);
        }

        private static int FindChainLength(List<int> result)
        {
            if (!result.Any()) return 0;

            var total = result.Join();
            return result.Slide(15).Take(5).For((split, x) =>
            {
                var splitStr = split.Join();
                int firstIndex = total.IndexOf(splitStr);
                int secondIndex = total.IndexOf(splitStr, firstIndex + 1);
                return secondIndex != -1 ? secondIndex - firstIndex : 0;
            }).FirstOrderedBy(x => x);
        }
    }
}
