using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleLambdaExample
{
    class Program
    {
        class FooClass
        {
            int _a;

            public FooClass(int a)
            {
                _a = a;
            }

            public int A => _a;
        }
        static void Main(string[] args)
        {
            FooClass fooClass = new FooClass(4); ;
            Console.WriteLine($"fooClass.A: {fooClass.A}");

            Console.WriteLine("Press any key!");
            Console.ReadKey();
        }
    }
}
