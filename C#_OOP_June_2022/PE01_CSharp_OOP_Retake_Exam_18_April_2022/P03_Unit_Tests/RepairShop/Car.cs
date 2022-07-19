namespace RepairShop
{
    public class Car
    {
        public Car(string carModel, int numberOfIssues)
        {
            CarModel = carModel;
            NumberOfIssues = numberOfIssues;
        }

        public string CarModel { get; set; }
        public int NumberOfIssues { get; set; }
        public bool IsFixed => NumberOfIssues == 0;
    }
}
