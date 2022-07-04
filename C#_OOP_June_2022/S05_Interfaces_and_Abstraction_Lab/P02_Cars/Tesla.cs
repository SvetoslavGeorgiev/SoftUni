namespace Cars
{
    public class Tesla : ICar, IElectricCar
    {
        private string color;
        private string model;
        private int battery;

        public Tesla(string model,string color, int battery)
        {
            Model = model;
            Color = color;
            Battery = battery;
        }

        public string Model
        {
            get => model;
            set
            {
                model = value;
            }
        }
        public string Color
        {
            get => color;
            set
            {
                color = value;
            }
        }
        public int Battery 
        {
            get => battery;
            set
            {
                battery = value;
            }
        }

        public string Start()
        {
            return $"Engine Start";
        }

        public string Stop()
        {
            return $"Breaaak!";
        }

        public override string ToString()
        {
            var batteriesString = Battery == 1
                ? $"{Battery} Battery"
                : $"{Battery} Batteries";

            return $"{Color} {GetType().Name} {Model} with {batteriesString}";
        }
    }
}