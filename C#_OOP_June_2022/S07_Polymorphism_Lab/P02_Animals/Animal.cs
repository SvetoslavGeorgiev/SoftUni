namespace Animals
{
    public abstract class Animal
    {

        private string name;
        private string favouriteFood;

        public Animal(string name, string favouriteFood)
        {
            Name = name;
            FavouriteFood = favouriteFood;
        }

        public string FavouriteFood
        {
            get => favouriteFood;
            private set 
            { 
                favouriteFood = value; 
            }
        }

        public string Name
        {
            get => name;
            private set 
            { 
                name = value; 
            }
        }


        public virtual string ExplainSelf()
        {
            return string.Empty;
        }

    }
}