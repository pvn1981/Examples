using System;
using System.Linq;

namespace ConsoleAppExample1
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] words = { "bot", "apple", "apricot" };

            int minimalLength = words.Where(w => w.StartsWith("a")).Min(w => w.Length);

            // output: 5
            Console.WriteLine(minimalLength);

            int[] numbers = { 4, 7, 10 };

            int product = numbers.Aggregate(1, (interim, next) => interim * next);

            // output: 280
            Console.WriteLine(product);
        }
    }
}
