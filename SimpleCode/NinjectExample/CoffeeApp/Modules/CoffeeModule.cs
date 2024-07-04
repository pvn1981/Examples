using Ninject.Modules;

using Coffee.Core.Services;

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
