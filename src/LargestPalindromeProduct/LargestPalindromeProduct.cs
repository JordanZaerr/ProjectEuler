using System;
using System.Linq;
using Shared;

namespace LargestPalindromeProduct
{
    class LargestPalindromeProduct
    {
        //906609
        private static void Main()
        {
            Timer.Record(WithJustProducts);
            //Timer.Record(WithFactors);
            Console.ReadLine();
        }

        private static void WithJustProducts()
        {
            var range = Enumerable.Range(100, 900).ToList();
            var largestPalindrome = range.SelectMany(x => range.Select(y => x*y))
                .Where(IsPalindrome)
                .Max();

            Console.WriteLine(largestPalindrome);
        }

        private static void WithFactors()
        {
            var range = Enumerable.Range(100, 900).ToList();
            var largestPalindrome = range.SelectMany(x => range.Select(y => new Product(x, y)))
                .Where(x => IsPalindrome(x.Value))
                .Max(x => x.Value);

            Console.WriteLine(largestPalindrome);
        }

        private static bool IsPalindrome(int number)
        {
            return number == number.Reverse();
        }

        private class Product
        {
            private readonly int _x;
            private readonly int _y;
            public int Value { get; private set; }

            public Product(int x, int y)
            {
                _x = x;
                _y = y;
                Value = x*y;
            }

            public override string ToString()
            {
                return string.Format("{0} * {1} = {2}", _x, _y, Value);
            }
        }
    }
}
