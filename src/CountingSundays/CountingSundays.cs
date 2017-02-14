using System;

namespace CountingSundays
{
    //171
    class CountingSundays
    {
        static void Main()
        {
            LazyAttempt();
            Console.ReadLine();
        }

        private static void LazyAttempt()
        {
            var start = new DateTime(1901, 1, 1);
            var end = new DateTime(2000, 12, 31);
            var count = 0;

            while (start != end)
            {
                if (start.DayOfWeek == DayOfWeek.Sunday && start.Day == 1)
                    count++;
                start = start.AddDays(1);
            }
            Console.WriteLine(count);
        }
    }
}
