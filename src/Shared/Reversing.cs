using System.Linq;
using System.Numerics;

namespace Shared
{
    public static class Reversing
    {
        public static bool IsPalindrome(this int number)
        {
            return number == number.Reverse();
        }
        public static bool IsPalindrome(this BigInteger number)
        {
            return number == number.Reverse();
        }

        public static string ReverseString(this string str)
        {
            return new string(str.Reverse().ToArray());
        }

        public static int Reverse(this int remainder)
        {
            return ReverseInternal(remainder);
        }

        private static int ReverseInternal(this int remainder, int reversed = 0)
        {
            if (remainder == 0) return reversed;

            int rightmost = remainder%10;
            reversed = reversed*10 + rightmost;
            remainder = remainder/10;
            return ReverseInternal(remainder, reversed);
        }

        public static BigInteger Reverse(this BigInteger number)
        {
            return ReverseInternal(number, new BigInteger(0));
        }

        private static BigInteger ReverseInternal(this BigInteger remainder, BigInteger reversed)
        {
            if (remainder == 0) return reversed;
            var rightMost = remainder % 10;
            reversed = reversed * 10 + rightMost;
            remainder = remainder / 10;
            return ReverseInternal(remainder, reversed);
        }
    }
}