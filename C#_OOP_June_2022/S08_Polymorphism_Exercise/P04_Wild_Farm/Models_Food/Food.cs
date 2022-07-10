namespace WildFarm.Models_Food
{
    public abstract class Food
    {
        private int quantity;

        public Food(int quantity)
        {
            Quantity = quantity;
        }

        public int Quantity 
        {
            get => quantity; 
            private set
            {
                quantity = value;
            }
        }

    }
}
