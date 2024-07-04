using Coffee.Core.Services;
using Coffee.Core.Test.Modules;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using Ninject;

namespace Coffee.Core.Test
{
    [TestClass]
    public class CreamCoffeeServiceTest
    {
        private static IKernel _kernel;

        [ClassInitialize]
        public static void TearUp(TestContext testContext)
        {
            _kernel = new StandardKernel(new CoffeeModule());
        }

        [ClassCleanup]
        public static void TearDown()
        {
            // The test framework will call this method once -AFTER- each test run.
        }

        [TestMethod]
        public void CreamCoffeeService_GetCoffee_MustReturnTheCupWithTheIngredientsOfCoffeePowderAndHotWaterAndCream()
        {
            // Initialize DI
            ICoffeeService coffeeService = _kernel.Get<CreamCoffeeService>();

            // Act
            Cup cup = coffeeService.GetCoffee();

            // Assert
            Assert.IsTrue(cup.ingredients.Contains("Coffee Powder"));
            Assert.IsTrue(cup.ingredients.Contains("Hot Water"));
            Assert.IsTrue(cup.ingredients.Contains("Cream"));
        }
    }
}
