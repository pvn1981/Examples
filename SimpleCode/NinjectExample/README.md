# Description
This example get from https://github.com/rickseven/dotnet-ninject-sample

CoffeeApp is an example of a simple console application that applies Dependency Injection using [Ninject](http://www.ninject.org/).

Before continuing, I hope you know what [Dependency Injection](https://en.wikipedia.org/wiki/Dependency_injection) is.

#### There are three projects in this solution :

#### 1. Coffee.Core
Coffee.Core is a core library that provides coffee service.

#### 2. Coffee.Core.Test
Coffee.Core.Test is a unit test for Coffee.Core library that uses [NUnit](https://nunit.org/).

#### 3. CoffeeApp
CoffeeApp is an application that uses the Coffee.Core library.

## Usage
We will apply Coffee.Core to our application, say we have a simple application called CoffeeApp.

Ok, to call the service provided by Coffee.Core we will use Ninject.

Let's say we have a Beverage class that is dependent on the Coffee.Core service. The code is as follows :
```
using Coffee.Core.Services;
using System;

namespace CoffeeApp
{
    public class Beverage
    {
        private readonly ICoffeeService _coffeeService;

        public Beverage(ICoffeeService coffeeService) {
            _coffeeService = coffeeService;
        }

        public void GetIngredients() {
            var cup = _coffeeService.GetCoffee();
            foreach (string ingredient in cup.ingredients)
            {
                Console.WriteLine("- " + ingredient);
            }
        }
    }
}

```
To apply it, create a module called CoffeeModule that extends to NinjectModule. Then in the Load method, service bindings will be injected.
```
using Coffee.Core.Services;
using Ninject.Modules;

namespace CoffeeApp.Modules
{
    public class CoffeeModule : NinjectModule
    {
        public override void Load()
        {
            Bind<ICoffeeService>().To<CoffeeService>().WhenInjectedInto<CreamCoffeeService>();
        }
    }
}

```
We can call the service, as in the following code snippet :
```
IKernel kernel = new StandardKernel(new CoffeeModule());
ICoffeeService coffeeService = kernel.Get<CoffeeService>();
var coffeeBeverage = new Beverage(coffeeService);
```

## Requirments

##### Coffee.Core
- NET Framework (v4.5)

##### Coffee.Core.Test 
- NET Framework (v4.5)
- Ninject (v3.3.4)
- NUnit (v3.11.0)

##### CoffeeApp 
- NET Framework (v4.7.2)
- Ninject (v3.3.4)
- Coffee.Core
