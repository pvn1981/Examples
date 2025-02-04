using System;

namespace List_ConvertAll;
class Program
{
    static double TakeSquareRoot(int x)
    {
        return Math.Sqrt(x);
    }

    static void Main(string[] args)
    {
        List<int> integers = new List<int>();
        integers.Add(1);
        integers.Add(2);
        integers.Add(3);
        integers.Add(4);

        // Создание и заполнение списка целых чисел
        // Создание экземпляра делегата
        Converter<int, double> converter = TakeSquareRoot;
        List<double> doubles;

        // List<TOutput> ConvertAll<TOutput>(Converter<T, TOutput> converter);
        doubles = integers.ConvertAll<double>(converter);

        // Вызов обобщенного метода
        // для преобразования списка
        int i = 0;
        foreach (double d in doubles)
        {
            Console.WriteLine($"sqrt({integers[i]})={d}");
            i += 1;
        }
    }
}
