
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace StaticFucTemplate
{
    public class PetAnimal
    {
        private readonly string PetName;
        private readonly PetColor PetColor;

        private int _hunger;

        protected PetAnimal(string petName, PetColor petColor)
        {
            PetName = petName;
            PetColor = petColor;

            Console.WriteLine("+ PetAnimal: {0}", PetName);
        }

        ~PetAnimal()
        {
            Console.WriteLine("- ~PetAnimal: {0}", PetName);
        }

        public virtual void Feed(IPetFood food)
        {
            Eat(food);
        }

        protected void Eat(IPetFood food)
        {
            _hunger -= food.Energy;
        }

        public string MyPet() => $"My pet is {PetName} and its color is {PetColor.Color}.";
    }

    public class PetDog : PetAnimal
    {
        public PetDog(string petName, PetColor petColor) : base(petName, petColor)
        {
            Console.WriteLine("++ PetDog: {0}", petName);
        }

        ~PetDog()
        {
            Console.WriteLine("-- ~PetDog: {0}", MyPet());
        }

        public string Bark()
        {
            return "Woof!";
        }        

    }

    public class PetCat : PetAnimal
    {
        public PetCat(string petName, PetColor petColor) : base(petName, petColor)
        {
            Console.WriteLine("+++ PetCat: {0}", petName);
        }

        ~PetCat()
        {
            Console.WriteLine("--- ~PetCat: {0}", MyPet());
        }

        public string Meow()
        {
            return "Meow!";
        }

        public override void Feed(IPetFood food)
        {
            if (food is Fish)
            {
                Eat(food);
            }
            else
            {
                Meow();
            }
        }
    }
}
