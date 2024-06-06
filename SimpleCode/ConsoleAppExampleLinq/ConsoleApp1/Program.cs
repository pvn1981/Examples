using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace ConsoleAppExample1
{
    class Program
    {
        static void IntersectExample()
        {
            ObservableCollection<double> values = new ObservableCollection<double>() { 0, 1, 2, 3, 4 };
            int countAll = values.Count();

            ObservableCollection<double> readValuesOld = values;
            ObservableCollection<double> readValuesNew1 = new ObservableCollection<double>() { 0, 1, 2, 3, -1 };
            ObservableCollection<double> readValuesNew2 = new ObservableCollection<double>() { 0, 1, 2, -1, 4 };

            if (values.Intersect(readValuesOld).Count() == countAll)
            {
                Console.WriteLine("values = readValuesOld");
            }
            else
            {
                Console.WriteLine("values != readValuesOld");
            }

            if (values.Intersect(readValuesNew1).Count() == countAll)
            {
                Console.WriteLine("values = readValuesNew1");
            }
            else
            {
                Console.WriteLine("values != readValuesNew1");
            }

            if (values.Intersect(readValuesNew2).Count() == countAll)
            {
                Console.WriteLine("values = readValuesNew2");
            }
            else
            {
                Console.WriteLine("values != readValuesNew2");
            }
        }

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

            // Intersect example for collection double 
            IntersectExample();
        }
    }
}
