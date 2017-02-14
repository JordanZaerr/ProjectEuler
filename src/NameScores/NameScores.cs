using System;
using System.IO;
using System.Linq;
using Shared;

namespace NameScores
{
    //871198282
    class NameScores
    {
        static void Main()
        {
            Timer.Record(FirstAttempt); 
            Console.ReadLine();
        }

        static void FirstAttempt()
        {
            var names = File.ReadAllText("names.txt").Split(',')
                            .Select(x => x.Trim('"')).OrderBy(x => x);

            var result = names.For((name, i) => name.Aggregate(0, (t, c) => t + (c - 64))*(++i)).Sum();
            Console.WriteLine(result);
        }
    }
}
