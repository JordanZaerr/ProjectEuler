using System;
using System.Collections.Generic;
using System.Linq;

namespace Shared
{
    public static class Factors
    {
        public static long GetNumberOfFactors(this long number)
        {
            return number.GetFactors().Count();
        }

        public static IEnumerable<long> GetFactors(this int number)
        {
            return GetFactors((long)number);
        }

        public static IEnumerable<long> GetFactors(this long number)
        {
            var root = (long)Math.Ceiling(Math.Sqrt(number));

            for (int i = 1; i < root; i++)
            {
                if (number%i == 0)
                {
                    yield return i;
                    if(i != 1)
                        yield return number/i;
                }
            }
            if (root*root == number)
                yield return root;
        }
    }
}
