using System;
using System.Reactive.Linq;

namespace Range;
class Program
{
    static void Main(string[] args)
    {
        var input = Observable.Range(1, 15);
        input.Subscribe(x => Console.WriteLine("The number is {0}", x));
    }
}
