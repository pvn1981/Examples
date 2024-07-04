using System;

using Coffee.Core.Services;
using CoffeeApp.Modules;

using Ninject;


namespace CoffeeApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // load a module into kernel instance 
            IKernel kernel = new StandardKernel(new CoffeeModule());

            Console.WriteLine("Coffee :");
            var coffee = kernel.Get<CoffeeService>();
            var coffeeBeverage = new Beverage(coffee);
            coffeeBeverage.GetIngredients();
            Console.WriteLine();

            Console.WriteLine("Coffee With Cream :");
            var creamCoffee = kernel.Get<CreamCoffeeService>();
            var creamCoffeeBeverage = new Beverage(creamCoffee);
            creamCoffeeBeverage.GetIngredients();
            Console.ReadKey();
        }
    }
}
