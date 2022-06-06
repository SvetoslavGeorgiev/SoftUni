using System;

namespace Zoo
{
    public class StartUp
    {
        static void Main()
        {
            var zoo = new Zoo("Zoo Time", 20);
            var animaleOne = new Animal("elephant", "herbivore", 4000, 4);
            var animalTwo = new Animal("elephant", "herbivore", 3421.25, 3.7);
            var animalThree = new Animal("zebra", "herbivore", 380.52, 1.9);
            var animalFour = new Animal("cheetah", "carnivore", 59.52, 1.4);
            var animalFive = new Animal("wolf", "carnivore", 65.25, 1.5);

            Console.WriteLine(zoo.AddAnimal(animaleOne));  // Successfully added elephant to the zoo.
            Console.WriteLine(zoo.AddAnimal(animalTwo));   // Successfully added elephant to the zoo.
            Console.WriteLine(zoo.AddAnimal(animalThree)); // Successfully added zebra to the zoo.
            Console.WriteLine(zoo.AddAnimal(animalFour));  // Successfully added cheetah to the zoo.
            Console.WriteLine(zoo.AddAnimal(animalFive));  // Successfully added wolf to the zoo.

            var animalByDiet = zoo.GetAnimalsByDiet("herbivore");
            foreach (var animal in animalByDiet)
            {
                Console.WriteLine(animal.ToString());
            }
            // The elephant is a herbivore and weighs 4000 kg.
            // The elephant is a herbivore and weighs 3421.25 kg.
            // The zebra is a herbivore and weighs 380.52 kg.

            var getAnimalByWeight = zoo.GetAnimalByWeight(4000);
            Console.WriteLine(getAnimalByWeight.ToString());
            // The elephant is a herbivore and weighs 4000 kg.

            var animalSix = new Animal("wolf", "carnivore", 80.25, 1.8);
            var animalSeven = new Animal("moose", "stake", 250.25, 2.5);
            Console.WriteLine(zoo.AddAnimal(animalSix));   // Successfully added wolf to the zoo.
            Console.WriteLine(zoo.AddAnimal(animalSeven)); // Invalid animal diet.

            Console.WriteLine(zoo.GetAnimalCountByLength(1.4, 3));
            // There are 4 animals with a length between 1.4 and 3 meters.

            Console.WriteLine($"Animals living in the zoo: {zoo.Animals.Count}.");
            // Animals living in the zoo: 6.

            Console.WriteLine(zoo.RemoveAnimals("elephant")); // 2
            Console.WriteLine($"There are {zoo.Animals.Count} animals living in the zoo.");
            // Animals living in the zoo: 4.


        }
    }
}
