using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using static System.Console;

namespace LinqInParallel
{
    class Program
    {
        static void Main(string[] args)
        {
            var watch = new Stopwatch();
            Write("Press enter to start: ");
            ReadLine();
            watch.Start();

            IEnumerable<int> numbers = Enumerable.Range(1, 2_000_000_000);

            var squares = numbers.Select(number => number * number).ToArray();

            watch.Stop();
            WriteLine($" {watch.ElapsedMilliseconds:#,##0} elapsed milliseconds.");
        }
    }
}
