using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace Shared
{
    public static class RomanNumeralsExtensions
    {
        private static readonly ReadOnlyDictionary<string, int> Values =
            new Dictionary<string, int> {{"I", 1}, {"V", 5}, {"X", 10}, {"L", 50}, {"C", 100}, {"D", 500}, {"M", 1000}}
                .AsReadOnly();

        private static readonly ReadOnlyDictionary<int, string> Lookup =
            Values.ToDictionary(k => k.Value, v => v.Key).AsReadOnly();

        //https://projecteuler.net/about=roman_numerals
        // Only one I, X, and C can be used as the leading numeral in part of a subtractive pair.
        // I can only be placed before V and X.
        // X can only be placed before L and C.
        // C can only be placed before D and M.
        private static readonly ReadOnlyDictionary<int, int> SubtractionRules =
            new Dictionary<int, int> {{1000, 100}, {500, 100}, {100, 10}, {50, 10}, {10, 1}, {5, 1}, {1, 0}}.AsReadOnly();

        public static int ParseRomanNumeral(this string numeral)
        {
            return BuildTokens(numeral)
                .Sum(x => x.NextValue <= x.CurrentValue ? x.CurrentValue : -x.CurrentValue);
        }

        public static string ToRomanNumeral(this int number)
        {
            return RomainNumeral(number, 1000, new StringBuilder());
        }

        private static string RomainNumeral(int number, int level, StringBuilder current)
        {
            if (number == 0) return current.ToString();

            current.Append(string.Join("", Enumerable.Repeat(Lookup[level], number / level)));

            //Look for subtractive combinations
            var rule = SubtractionRules[level];
            var subtraction = level - rule;
            var nextNumber = number % level;
            if (nextNumber / subtraction == 1)
            {
                current.Append(Lookup[rule]).Append(Lookup[level]);
                nextNumber = nextNumber % subtraction;
            }

            return RomainNumeral(nextNumber, GetNextLevel(level), current);
        }

        private static int GetNextLevel(int level)
        {
            return Values.Values.Cast<int?>().TakeWhile(x => x != level).LastOrDefault() ?? 1;
        }

        private static IEnumerable<Token> BuildTokens(string numeral)
        {
            return numeral.Select(x => x.ToString())
                .SlideWithPadding(2).Select(x => new Token
                {
                    Current = x.First(),
                    Next = x.Last()
                });
        }

        [DebuggerDisplay("Current: {Current}({CurrentValue}), Next: {Next}({NextValue})")]
        private class Token
        {
            public string Current { get; set; }
            public string Next { get; set; }

            public int CurrentValue => Values[Current];
            public int NextValue => Next != null ? Values[Next] : 0;
        }
    }
}