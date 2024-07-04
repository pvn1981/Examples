using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coffee.Core.Services
{
    public class CoffeeService : ICoffeeService
    {
        public Cup GetCoffee()
        {
            Cup cup = new Cup();
            cup.ingredients.Add("Coffee Powder");
            cup.ingredients.Add("Hot Water");
            return cup;
        }
    }
}
