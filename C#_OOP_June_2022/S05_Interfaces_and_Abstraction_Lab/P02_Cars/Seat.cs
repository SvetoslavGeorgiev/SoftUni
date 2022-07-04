namespace Cars
{
    public class Seat : ICar
    {
        private string model;
        private string color;

        

        public Seat(string model, string color)
        {
            Model = model;
            Color = color;
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
            return $"{Color} {GetType().Name} {Model}";
        }
    }
}