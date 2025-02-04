using System;
using System.Reactive.Concurrency;
using System.Reactive.Linq;
using LINQPad;

namespace SimpleExample;
class Program
{
    static void Example1()
    {
        /* Return 1:
         *
         * Can't get any simpler than this
         */

        var input = Observable.Return(42);
        input.Subscribe(x => Console.WriteLine("The number is {0}", x));
    }

    static void Example2()
    {
        /* Return 2:
         *
         * Show that Return Completes after returning its one value
         */

        // Materialize lets us see the OnComplete, which normally isn't part of the
        // values returned in the stream.
        var input = Observable.Return(42).Materialize();

        input.Dump();
    }

    static void Example3()
    {
        /* Return 3:
         *
         * Demonstrate that Return is a Cold Observable (i.e. that it produces a new
         * stream of events every time someone subscribes to it)
         */

        var input = Observable.Return(42);
        input.Subscribe(x => Console.WriteLine("Subscription 1: {0}", x));
        input.Subscribe(x => Console.WriteLine("Subscription 2: {0}", x));
    }

    static void Example4()
    {
        /* Range 1
         *
         * Nothing particularly exciting here
         */

        var input = Observable.Range(1, 100);

        input.Sum().Subscribe(x => Console.WriteLine("The Sum is {0}", x));
    }

    static void Example5()
    {
        /* Timer 1
         *
         * Demonstrate a simple use of Observable.Timer 
         */

        // We've specified that we want the timer to start *immediately*, that it should
        // tick every second, and that we want the ticks to appear as Task<T>'s on other
        // threads
        var timer = Observable.Timer(TimeSpan.Zero, TimeSpan.FromSeconds(1.0), Scheduler.CurrentThread);

        timer.Take(5).Subscribe(x => Console.WriteLine(x % 2 == 0 ? "Tick" : "Tock"));

        // Linqpad needs to wait while the tasks are running
        
        // Block for 5.5 seconds
        // Thread.Sleep(5500); 
        
        // Nonblock for 5.5 seconds
        Task.Delay(5500);
        
        // Linqpad needs to wait while the tasks are running
    }

    static async void Example6()
    {
        /* Start 1:
         *
         * Run an Action in the background and give us an Observable that represents the
         * background task. Equivalent to (new Task(() => {...})).Start()
         *
         * This sample also demonstrates how to use First() to block on an Observable.
         */

        var task = Observable.Start(() => {
            Console.WriteLine("Hello World!");

            // Do something very time-consuming here
            Thread.Sleep(1000);
            return;
        });

        // Wait until the task is completed
        await task;

        Console.WriteLine("We're Finished!");

        // vim: ts=4 sw=4 tw=80 et :
    }

    static void Main(string[] args)
    {
        // 'Q' = 81
        const int qBigLitheral = 81;

        // 'q' == 113
        const int qSmallLitheral = 113;

        // 'q' == 13
        const int qEenter = 13;

        // 'q' == 10 -- Возврат каретки
        const int qLineFeed = 10;

        // '1' == 49
        const int digit_1 = 49;

        // '2' == 50
        const int digit_2 = 50;

        // '3' == 51
        const int digit_3 = 51;

        // '4' == 52
        const int digit_4 = 52;

        // '5' == 53
        const int digit_5 = 53;

        // '6' == 54
        const int digit_6 = 54;

        int k = 0;
        Console.WriteLine(@"Enter number example, for exit type 'q': ");
        while (!(k == qBigLitheral || k == qSmallLitheral))
        {
            k = Console.Read();
            if(k == qEenter || k == qLineFeed)
            {
                continue;
            }

            switch(k)
            {
                case digit_1:
                    Example1();
                    break;
                case digit_2:
                    Example2();
                    break;
                case digit_3:
                    Example3();
                    break;
                case digit_4:
                    Example4();
                    break;
                case digit_5:
                    Example5();
                    break;
                case digit_6:
                    Example6();
                    break;
                default:
                    break;
            }

            Console.WriteLine(@"Task ended choose another number or type 'q' for exit: ");
        }
    }
}
