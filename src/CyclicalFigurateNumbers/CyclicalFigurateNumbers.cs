using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Shared;

namespace CyclicalFigurateNumbers
{
    //28684
    class CyclicalFigurateNumbers
    {
        static void Main()
        {
            //150ms
            Timer.Record(FirstAttempt);
            Console.ReadLine();
        }

        private static void FirstAttempt()
        {
            var tri = NumberGenerators.GetTriangleNumbers().GetFourDigitNumbers().Select(x => new Token(x)).ToList();
            var quad = NumberGenerators.GetSquareNumbers().GetFourDigitNumbers().Select(x => new Token(x)).ToList();
            var pent = NumberGenerators.GetPentagonalNumbers().GetFourDigitNumbers().Select(x => new Token(x)).ToList();
            var hex = NumberGenerators.GetHexagonalNumbers().GetFourDigitNumbers().Select(x => new Token(x)).ToList();
            var hep = NumberGenerators.GetHeptagonalNumbers().GetFourDigitNumbers().Select(x => new Token(x)).ToList();
            var oct = NumberGenerators.GetOctagonalNumbers().GetFourDigitNumbers().Select(x => new Token(x)).ToList();

            var permutations = new List<List<Token>> {tri, quad, pent, hex, hep, oct}.Permutations().ToList();

            var chains = new List<Tuple<long, long, long, long, long, long>>();
            foreach (var set in permutations)
            {
                chains.AddRange(FindChain(set[0], set[1], set[2], set[3], set[4], set[5]));
            }
            var answer = chains.First();
            Console.WriteLine(answer.Item1 + answer.Item2 + answer.Item3 + answer.Item4 + answer.Item5 + answer.Item6);
        }


        private static IEnumerable<Tuple<long, long, long, long, long, long>> FindChain(
            IEnumerable<Token> l1,
            IEnumerable<Token> l2,
            IEnumerable<Token> l3,
            IEnumerable<Token> l4,
            IEnumerable<Token> l5,
            IEnumerable<Token> l6)
        {
            return (from n3 in l1.Where(x3 => l6.Any(x8 => x8.SecondHalf == x3.FirstHalf))
                    from n4 in l2.Where(x4 => n3.SecondHalf == x4.FirstHalf)
                    from n5 in l3.Where(x5 => n4.SecondHalf == x5.FirstHalf)
                    from n6 in l4.Where(x6 => n5.SecondHalf == x6.FirstHalf)
                    from n7 in l5.Where(x7 => n6.SecondHalf == x7.FirstHalf)
                    from n8 in l6.Where(x8 => n7.SecondHalf == x8.FirstHalf)
                    where n3.FirstHalf == n8.SecondHalf
                    select Tuple.Create(n3.Value, n4.Value, n5.Value, n6.Value, n7.Value, n8.Value))
                    .ToList();
        }
    }

    [DebuggerDisplay("{Value}")]
    public class Token
    {
        public Token(long number)
        {
            Value = number;
            var str = number.ToString();
            FirstHalf = str.Substring(0, 2);
            SecondHalf = str.Substring(2, 2);
        }

        public string FirstHalf { get; set; }
        public string SecondHalf { get; set; }
        public long Value { get; set; }
    }

    static class Extensions
    {
        public static IEnumerable<long> GetFourDigitNumbers(this IEnumerable<long> seq)
        {
            return seq.SkipWhile(x => x.ToString().Length < 4).TakeWhile(x => x.ToString().Length == 4);
        }
    }
}
