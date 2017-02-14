using System;
using System.Linq;
using Shared;

namespace DoubleBasePalindromes
{
    //872187
    class DoubleBasePalindromes
    {
        static void Main()
        {
            Timer.Record(FirstAttempt);
            Console.ReadLine();
        }

        private static void FirstAttempt()
        {
            var sum = Enumerable.Range(1, 999999)
                .Where(IsPalindrome).Sum();
            Console.WriteLine(sum);
        }

        private static bool IsPalindrome(int i)
        {
            if (i == i.Reverse())
            {
                var binary = Convert.ToString(i, 2);
                return binary == binary.Reverse().Join();
            }
            return false;
        }
    }
}
