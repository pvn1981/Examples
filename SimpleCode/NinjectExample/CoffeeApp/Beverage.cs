using System;

using Coffee.Core.Services;

namespace CoffeeApp
{
    public class Beverage
    {
        private readonly ICoffeeService _coffeeService;
        public Beverage(ICoffeeService coffeeService)
        {
            _coffeeService = coffeeService;
        }

        public void GetIngredients()
        {
            var cup = _coffeeService.GetCoffee();
            foreach (string ingredient in cup.ingredients)
            {
                Console.WriteLine("- " + ingredient);
            }
        }
    }
}
