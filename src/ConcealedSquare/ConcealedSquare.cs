using System;
using System.Text.RegularExpressions;
using Shared;

namespace ConcealedSquare
{
    //1389019170
    class ConcealedSquare
    {
        private static readonly Regex RegexFunc = new Regex(@"1\d2\d3\d4\d5\d6\d7\d8\d9\d0", RegexOptions.Compiled);

        static void Main()
        {
            //9ms
            Timer.Record(FirstAttempt);
            Console.ReadLine();
        }

        private static void FirstAttempt()
        {
            var root = (long)Math.Floor(Math.Sqrt(1929394959697989900d)); //Maximum value
            while (root > 1)
            {
                if (RegexFunc.IsMatch((root * root).ToString()))
                {
                    Console.WriteLine(root);
                    return;
                }
                root--;
            }
        }
    }
}
