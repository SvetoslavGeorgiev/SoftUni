using System.Collections.Generic;
using System.Linq;

namespace Zoo
{
    public class Zoo
    {
        public Zoo()
        {

        }
        public Zoo(string name, int capacity)
        {
            Animals = new List<Animal>();
            Name = name;
            Capacity = capacity;
        }


        private List<Animal> animals;
        private string name;
        private int capacity;



        public List<Animal> Animals { get; set; }
        public string Name { get; set; }
        public int Capacity { get; set; }


        public string AddAnimal(Animal animal)
        {
            if (Animals.Count < Capacity)
            {
                if (string.IsNullOrWhiteSpace(animal.Species))
                {
                    return "Invalid animal species.";
                }
                else if (animal.Diet != "herbivore" && animal.Diet != "carnivore")
                {
                    return "Invalid animal diet.";
                }
                else
                {
                    Animals.Add(animal);
                    return $"Successfully added {animal.Species} to the zoo.";
                }

            }
            else
            {
                return "The zoo is full.";
            }
        }

        public int RemoveAnimals(string specie)
        {
            int count = 0;

            var animalStartCount = Animals.Count;

            Animals.RemoveAll(x => x.Species == specie);

            count = animalStartCount - Animals.Count;

            return count;
        }

        public List<Animal> GetAnimalsByDiet(string diet)
        {
            var animalsByDiet = new List<Animal>();

            animalsByDiet = Animals.Where(x => x.Diet == diet).ToList();

            return animalsByDiet;


        }

        public Animal GetAnimalByWeight(double weight)
        {

            var animal = Animals.FirstOrDefault(x => x.Weight == weight);

            return animal;
        }

        public string GetAnimalCountByLength(double minimumLength, double maximumLength)
        {
            

            var count = Animals.FindAll(x => x.Length >= minimumLength && x.Length <= maximumLength).Count();
            

            return $"There are {count} animals with a length between {minimumLength} and {maximumLength} meters.";
        }
    }
}
