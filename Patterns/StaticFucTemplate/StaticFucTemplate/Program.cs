using System;

namespace StaticFucTemplate
{
    internal class Program
    {
        class Worker
        {
            public void Show()
            {
                var owner = new PetOwner("Diego Jones");
                owner.AddPet(new PetDog("Ruffy", new PetColor("Brown with white spots and pink nose.")));
                owner.AddPet(new PetCat("Precious", new PetColor("Calico with a large white patch on the right side of her face.")));

                Console.Write(owner.MyPets());

                var ownerNew = new PetOwner("Vlad");

                PetAnimal animal;

                animal = new PetDog("Black german shepherd", new PetColor("black"));
                IPetFood food = new Kibble();

                ownerNew.AddPet(animal);

                PetFeeder.FeedPet(animal, food);

                animal = new PetCat("Bart", new PetColor("black"));
                food = new Fish();

                PetFeeder.FeedPet(animal, food);
                ownerNew.AddPet(animal);

                Console.Write(ownerNew.MyPets());
            }
        }

        static void Main(string[] args)
        {
            RunWorker();

            // For clean memory in this point of code
            GC.Collect();

            Console.Read();
        }

        static void RunWorker()
        {
            Worker spec = new Worker();
            spec.Show();
        }
    }
}
