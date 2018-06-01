using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Shared;

namespace PasscodeDerivation
{
    //73162890
    public class PasscodeDerivation
    {
        static void Main()
        {
            //20ms
            Timer.Record(FirstAttempt);
            Console.ReadLine();
        }

        private static void FirstAttempt()
        {
            var passcode = "";
            var keys = Keys.Distinct().OrderBy(x => x).Select(x => new Columns(x)).ToList();
            var distinctNumbers = keys
                .Select(x => x.First)
                .Concat(keys.Select(x => x.Second))
                .Concat(keys.Select(x => x.Third))
                .Distinct()
                .OrderBy(x => x)
                .ToList();

            var excluded = new List<int>();
            while (distinctNumbers.Any())
            {
                var num = distinctNumbers.First(x => HasNumbersBefore(keys, x, excluded));
                passcode += num;
                excluded.Add(num);
                distinctNumbers.Remove(num);
            }
            Console.WriteLine(passcode);
        }

        private static bool HasNumbersBefore(List<Columns> cols, int num, List<int> excludedNums)
        {
            return cols.All(x =>
            {
                if (x.Second == num && !excludedNums.Contains(x.First))
                    return false;
                if (x.Third == num && (!excludedNums.Contains(x.First) || !excludedNums.Contains(x.Second)))
                    return false;

                return true;
            });
        }

        [DebuggerDisplay("{First}{Second}{Third}")]
        public class Columns
        {
            private static int asciiOffset = 48;
            public Columns(string str)
            {
                
                First = Convert.ToInt32(str[0]- asciiOffset);
                Second = Convert.ToInt32(str[1]- asciiOffset);
                Third = Convert.ToInt32(str[2]- asciiOffset);
            }

            public int First { get; set; }
            public int Second { get; set; }
            public int Third { get; set; }
        }


        public static List<string> Keys = new List<string>
        {
            "319",
            "680",
            "180",
            "690",
            "129",
            "620",
            "762",
            "689",
            "762",
            "318",
            "368",
            "710",
            "720",
            "710",
            "629",
            "168",
            "160",
            "689",
            "716",
            "731",
            "736",
            "729",
            "316",
            "729",
            "729",
            "710",
            "769",
            "290",
            "719",
            "680",
            "318",
            "389",
            "162",
            "289",
            "162",
            "718",
            "729",
            "319",
            "790",
            "680",
            "890",
            "362",
            "319",
            "760",
            "316",
            "729",
            "380",
            "319",
            "728",
            "716"
        };
    }
}
