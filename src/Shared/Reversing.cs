using System.Linq;

namespace Shared
{
    public static class Reversing
    {
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
    }
}