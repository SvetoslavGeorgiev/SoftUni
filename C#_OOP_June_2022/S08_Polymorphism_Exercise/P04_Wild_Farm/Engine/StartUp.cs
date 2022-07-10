namespace WildFarm.Engine
{
    using System;
    using Models;
    using Models_Food;

    public class StartUp
    {
        static void Main()
        {

            var wildFarm = new WildFarm();
            var animalParser = new CommandParser();
            var foodParser = new CommandParser();
            var AnimalInfo = animalParser.AnimalParse(Console.ReadLine());

            while (AnimalInfo.End != Constants.End)
            {

                var animal = CreateAnimal(AnimalInfo);
                Console.WriteLine(animal.ProducingSound());
                wildFarm.AddAnimal(animal);

                var foodInfo = foodParser.FoodParse(Console.ReadLine());
                var food = GreateFood(foodInfo);

                try
                {
                    animal.Eat(food);
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }

                AnimalInfo = animalParser.AnimalParse(Console.ReadLine());
            }


            Console.WriteLine(wildFarm.PrintAnimals());


        }

        private static Food GreateFood(Command foodInfo)
        {
            switch (foodInfo.FoodType)
            {
                case Constants.Meat:
                    return new Meat(foodInfo.FoodQuantity);
                case Constants.Fruit:
                    return new Fruit(foodInfo.FoodQuantity);
                case Constants.Seeds:
                    return new Seeds(foodInfo.FoodQuantity);
                case Constants.Vegetable:
                    return new Vegetable(foodInfo.FoodQuantity);
                default:
                    return null;
            }
        }

        private static Animal CreateAnimal(Command AnimalInfo)
        {
            
            switch (AnimalInfo.AnimalType)
            {
                case Constants.Dog:
                    return new Dog(AnimalInfo.AnimalName, AnimalInfo.AnimalWeight, AnimalInfo.AnimalLivingRegion);
                case Constants.Cat:
                    return new Cat(AnimalInfo.AnimalName, AnimalInfo.AnimalWeight, AnimalInfo.AnimalLivingRegion, AnimalInfo.AnimalBreed);
                case Constants.Owl:
                    return new Owl(AnimalInfo.AnimalName, AnimalInfo.AnimalWeight, AnimalInfo.AnimalWingSize);
                case Constants.Hen:
                    return new Hen(AnimalInfo.AnimalName, AnimalInfo.AnimalWeight, AnimalInfo.AnimalWingSize);
                case Constants.Mouse:
                    return new Mouse(AnimalInfo.AnimalName, AnimalInfo.AnimalWeight, AnimalInfo.AnimalLivingRegion);
                case Constants.Tiger:
                    return new Tiger(AnimalInfo.AnimalName, AnimalInfo.AnimalWeight, AnimalInfo.AnimalLivingRegion, AnimalInfo.AnimalBreed);
                default:
                    return null;
            }
        }
    }
}
