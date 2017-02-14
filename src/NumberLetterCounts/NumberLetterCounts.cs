using System;
using System.Collections.Generic;
using System.Linq;
using Shared;

namespace NumberLetterCounts
{
    //21124
    class NumberLetterCounts
    {
        static readonly Dictionary<int, string> Lookup = new Dictionary<int, string>
        {
            #region values
            {1, "One"},
            {2, "Two"},
            {3, "Three"},
            {4, "Four"},
            {5, "Five"},
            {6, "Six"},
            {7, "Seven"},
            {8, "Eight"},
            {9, "Nine"},
            {10, "Ten"},
            {11, "Eleven"},
            {12, "Twelve"},
            {13, "Thirteen"},
            {14, "Fourteen"},
            {15, "Fifteen"},
            {16, "Sixteen"},
            {17, "Seventeen"},
            {18, "Eighteen"},
            {19, "Nineteen"},
            {20, "Twenty"},
            {30, "Thirty"},
            {40, "Forty"},
            {50, "Fifty"},
            {60, "Sixty"},
            {70, "Seventy"},
            {80, "Eighty"},
            {90, "Ninety"},
            {100, "OneHundred"},
            {200, "TwoHundred"},
            {300, "ThreeHundred"},
            {400, "FourHundred"},
            {500, "FiveHundred"},
            {600, "SixHundred"},
            {700, "SevenHundred"},
            {800, "EightHundred"},
            {900, "NineHundred"},
            {1000, "OneThousand"} 
            #endregion
        };

        static void Main()
        {
            Timer.Record(FirstAttempt);
            Console.ReadLine();
        }

        private static void FirstAttempt()
        {
            var output = new List<string>();

            Enumerable.Range(1, 1000).Each(i => output.Add(GetNumber(i, 10000)));

            output.Each(Console.WriteLine);
            Console.WriteLine(output.Sum(x => x.Length));
        }

        private static string GetNumber(int num, int position)
        {
            string result = "";
            if (position == 1)
                return result;

            var temp = num%position;
            if (Lookup.ContainsKey(temp) && num >= position/10)
                return Lookup[temp];

            temp = temp/(position/10);
            if (Lookup.ContainsKey(temp))
            {
                if (position == 1000)
                {
                    result = Lookup[temp] + "HundredAnd";
                }

                else if (position == 100)
                    result = Lookup[temp*10];
                else
                    result = Lookup[temp];
            }

            return result + GetNumber(num, position/10);
        }
    }
}
