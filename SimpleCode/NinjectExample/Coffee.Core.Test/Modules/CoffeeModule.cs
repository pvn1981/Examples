using Coffee.Core.Services;
using Ninject.Modules;

namespace Coffee.Core.Test.Modules
{
    public class CoffeeModule : NinjectModule
    {
        public override void Load()
        {
            Bind<ICoffeeService>().To<CoffeeService>().WhenInjectedInto<CreamCoffeeService>();
        }
    }
}
