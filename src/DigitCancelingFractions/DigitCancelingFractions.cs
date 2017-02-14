using System;
using System.Linq;
using Shared;

//This is a mess....
namespace DigitCancelingFractions
{
    //100
    class DigitCancelingFractions
    {
        static void Main()
        {
            Timer.Record(FirstAttempt);
            Console.ReadLine();
        }

        private static void FirstAttempt()
        {
            var range = Enumerable.Range(10, 90).ToList();
            var results = range
                .SelectMany(a => range
                    .Select(b => Figure(a, b)))
                    .Where(x => x != null).ToList();

            var top = (int)results.Select(x => (int)x.Item1).Product();
            var bottom = (int)results.Select(x => (int)x.Item2).Product();
            var gcf = MathFunctions.GreatestCommonFactor(top, bottom);
            Console.WriteLine(bottom / gcf);
        }

        private static Tuple<double,double> Figure(int a, int b)
        {
            double r = a/(double)b;
            if (r < 1)
            {
                var aStr = a.ToString();
                var a1 =  Char.GetNumericValue(aStr[0]);
                var a2 =  Char.GetNumericValue(aStr[1]);
                var bStr = b.ToString();
                var tb1 = bStr.Replace(aStr[0].ToString(), "");
                var tb2 = bStr.Replace(aStr[1].ToString(), "");

                if (tb1 == "" || tb2 == "") return null;
                var b1 = double.Parse(tb1);
                var b2 = double.Parse(tb2);                

                if(aStr.EndsWith("0") && bStr.EndsWith("0")) return null;

                if (b1 != 0 && b1 < 10 && a2/b1 == r) 
                    return Tuple.Create(a1, b1);
                if (b2 != 0 && b2 < 10 && a1/b2 == r)
                    return Tuple.Create(a1, b2);
            }
            return null;
        }
    }
}
