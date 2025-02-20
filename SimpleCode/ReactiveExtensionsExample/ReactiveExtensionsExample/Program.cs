using System.Reactive;
using System.Reactive.Linq;

namespace ReactiveExtensionsExample
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Create an observable sequence from a range of numbers
            var observable = Enumerable.Range(1, 4).ToObservable();

            // Subscribe to the observable
            observable.Subscribe(
                onNext: x => Console.WriteLine($"Received: {x}"),
                onError: ex => Console.WriteLine($"Error: {ex.Message}"),
                onCompleted: () => Console.WriteLine("Sequence completed.")
            );

            observable.Select(i => i * i).Subscribe(
                i => Console.WriteLine($"Received i^2: {i}"),
                e => Console.WriteLine(e),
                () => Console.WriteLine("Taking squares: complete"));

            observable.Take(2).Subscribe(Observer.Create<int>(
                i => Console.WriteLine($"Received count=2 elements: {i}"),
                e => Console.WriteLine(e),
                () => Console.WriteLine("Taking two items: complete")));

            observable.Where(i => i % 2 != 0).Subscribe(
                i => Console.WriteLine($"Received only odd elements: {i}"),
                e => Console.WriteLine(e),
                () => Console.WriteLine("Taking odd numbers: complete"));

            // Keep the console open
            Console.ReadLine();
        }
    }
}
