using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Shared;

namespace ConsecutivePrimeSum
{
    //997651
    internal class ConsecutivePrimeSum
    {
        private static void Main()
        {
            //Timer.Record(FirstAttempt);
            Timer.Record(SecondAttempt);
            Console.ReadLine();
        }

        //Slow and produces the wrong answer.
        private static void FirstAttempt()
        {
            const int length = 1000000;
            var primes = new HashSet<int>(Primes.FindPrimesBySieveOfAtkins(length));
            var range = primes.Take(length).ToList();
            var list = new List<PrimeHolder>();
            var index = 0;

            range.Each(x =>
            {
                var sum = 0;
                var count = 0;
                range.Skip(index).Each(y =>
                {
                    count++;
                    sum += y;
                    if(primes.Contains(sum))
                        list.Add(new PrimeHolder(sum, count));
                });
                index++;
            });

            var top = list.FirstOrderedBy(x => x.Count);
            Console.WriteLine(top.Prime);
        }

        //Fast and is right.
        private static void SecondAttempt()
        {
            const int length = 1000000;
            var primes = new HashSet<int>(Primes.FindPrimesBySieveOfAtkins(length));
            var range = primes.Take(length).ToList();
            var list = new List<PrimeHolder>();

            for (int i = 0; i < range.Count; i++)
            {
                var sum = 0;
                var count = 0;
                for (int x = i; x < range.Count; x++)
                {
                    count++;
                    sum += range[x];
                    if (sum > length) 
                        break;
                    if (primes.Contains(sum))
                        list.Add(new PrimeHolder(sum, count));
                }
            }
            Console.WriteLine(list.FirstOrderedBy(x => x.Count).Prime);
        }
    }


    [DebuggerDisplay("Prime: {Prime}, Count: {Count}")]
    internal class PrimeHolder
    {
        public int Prime { get; set; }
        public int Count { get; set; }

        public PrimeHolder(int prime, int count)
        {
            Prime = prime;
            Count = count;
        }
    }

    class Holder
    {
        public int Num { get; set; }
        public int Total { get; set; }
        public int Count { get; set; }
    }
}
