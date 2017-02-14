using System;
using System.Linq;

namespace MultiplesOf3And5
{
    //233168
    class MultiplesOf3And5
    {
        static void Main()
        {
            Console.WriteLine(Enumerable.Range(0,1000)
                .Where(x => x % 3 == 0 || x % 5 == 0)
                .Sum());
            Console.ReadLine();
        }
    }
}
