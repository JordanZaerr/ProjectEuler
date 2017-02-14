using System;
using System.Diagnostics;

namespace Shared
{
    public static class Timer
    {
        public static void Record(Action action)
        {
            var stopWatch = Stopwatch.StartNew();
            action();
            stopWatch.Stop();
            Console.WriteLine("Completed in {0}ms", stopWatch.ElapsedMilliseconds);
        }
    }
}