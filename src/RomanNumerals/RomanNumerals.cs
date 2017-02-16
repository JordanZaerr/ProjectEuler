using System;
using System.IO;
using System.Linq;
using Shared;

namespace RomanNumerals
{
    //743
    class RomanNumerals
    {
        static void Main()
        {
            //~50ms
            Timer.Record(FirstAttempt);
            Console.ReadLine();
        }

        private static void FirstAttempt()
        {
            var verboseNumerals = File.ReadAllLines("numerals.txt")
                .SelectMany(x => x.Split('\n'))
                .ToList();

            Console.WriteLine(verboseNumerals
                .Sum(x => x.Length - x.ParseRomanNumeral().ToRomanNumeral().Length));
        }
    }
}
