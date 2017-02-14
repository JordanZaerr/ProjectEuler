using System;
using System.Collections.Generic;
using System.Linq;
using Shared;

namespace CoinSums
{
    //73682
    class CoinSums
    {
        static void Main()
        {
            //Super slow...<shrug>
            Timer.Record(FirstAttempt);
            Console.ReadLine();
        }

        //1p, 2p, 5p, 10p, 20p, 50p, £1 (100p) and £2 (200p).
        private static void FirstAttempt()
        {
            var p1l = Enumerable.Range(0, 201).ToList();
            var p2l = Enumerable.Range(0, 101).ToList();
            var p5l = Enumerable.Range(0, 41).ToList();
            var p10l = Enumerable.Range(0, 21).ToList();
            var p20l = Enumerable.Range(0, 11).ToList();
            var p50l = Enumerable.Range(0, 5).ToList();
            var e1l = Enumerable.Range(0, 3).ToList();
            var e2l = new List<int> {0, 1};

            var result = p1l.SelectMany(p1 =>
                p2l.SelectMany(p2 =>
                    p5l.SelectMany(p5 =>
                        p10l.SelectMany(p10 =>
                            p20l.SelectMany(p20 =>
                                p50l.SelectMany(p50 =>
                                    e1l.SelectMany(e1 =>
                                        e2l.Select(e2 => p1*1 + p2*2 + p5*5 + p10*10 + p20*20 + p50*50 + e1*100 + e2*200))))))))
                                        .Where(x => x == 200)
                                        .AsParallel();
            Console.WriteLine(result.Count());
        }
    }
}
