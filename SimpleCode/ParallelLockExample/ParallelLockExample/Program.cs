using System;
using System.Diagnostics;       // For Stopwatch
using System.Threading;         // For InterLock
using System.Threading.Tasks;

namespace ParallelLockExample
{
    class Program
    {
        static void BadCode()
        {
            var ValueWithoutInterlocked = 0;
            Parallel.For(0, 100000, _ =>
            {
                //Incrementing the value
                ValueWithoutInterlocked++;
            });
            //Console.WriteLine("Expected Result: 100000");
            //Console.WriteLine($"Actual Result: {ValueWithoutInterlocked}");
        }

        static void InterLockCode()
        {
            var ValueInterlocked = 0;
            Parallel.For(0, 100000, _ =>
            {
                //Incrementing the value
                Interlocked.Increment(ref ValueInterlocked);
            });
            //Console.WriteLine("Expected Result: 100000");
            //Console.WriteLine($"Actual Result: {ValueInterlocked}");
        }

        static object lockObject = new object();

        static void LockObjectCode()
        {
            
            var ValueWithLock = 0;
            Parallel.For(0, 100000, _ =>
            {
                lock (lockObject)
                {
                    //Incrementing the value
                    ValueWithLock++;
                }
            });
            //Console.WriteLine("Expected Result: 100000");
            //Console.WriteLine($"Actual Result: {ValueWithLock}");
        }

        static void Main(string[] args)
        {
            Stopwatch stopwatch = new Stopwatch();

            Console.WriteLine("--------------BAD CODE--------------");
            stopwatch.Reset();
            stopwatch.Start();
            for (int i = 0; i < 100; i++)
            {
                BadCode();
            }
            stopwatch.Stop();
            Console.WriteLine(stopwatch.ElapsedMilliseconds);
            Console.WriteLine("--------------BAD CODE--------------");

            Console.WriteLine("--------------InterLock CODE--------------");
            stopwatch.Reset();
            stopwatch.Start();
            for (int i = 0; i < 100; i++)
            {
                InterLockCode();
            }
            stopwatch.Stop();
            Console.WriteLine(stopwatch.ElapsedMilliseconds);
            Console.WriteLine("--------------InterLock CODE--------------");

            Console.WriteLine("--------------LockObject CODE--------------");
            stopwatch.Reset();
            stopwatch.Start();
            for (int i = 0; i < 100; i++)
            {
                LockObjectCode();
            }
            stopwatch.Stop();
            Console.WriteLine(stopwatch.ElapsedMilliseconds);
            Console.WriteLine("--------------LockObject CODE--------------");

            Console.ReadKey();
        }
    }
}
