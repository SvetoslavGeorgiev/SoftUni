namespace Zoo
{
    public class Animal
    {
        public Animal()
        {

        }
        public Animal(string species, string diet, double weight, double length)
        {
            Species = species;
            Diet = diet;
            Weight = weight;
            Length = length;


        }

        private string species;
        private string diet;
        private double weight;
        private double length;


        public string Species { get; set; }
        public string Diet { get; set; }
        public double Weight { get; set; }
        public double Length { get; set; }


        public override string ToString()
        {
            var result = $"The {Species} is a {Diet} and weighs {Weight} kg.";

            return result.ToString();
        }
    }
}
