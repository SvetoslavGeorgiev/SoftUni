using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace SoftUniParking
{
    public class Parking
    {
        public Parking(int capacity)
        {
            Cars = new List<Car> ();
            Capacity = capacity;
        }

        private List<Car> cars;
        private int capacity;


        public int Count { get { return Cars.Count; } }

        public List<Car> Cars
        {
            get { return cars; }
            set { cars = value; }
        }

        public int Capacity
        {
            get { return capacity; }
            set { capacity = value; }
        }


        public string AddCar(Car car)
        {
            if (Cars.Any(x => x.RegistrationNumber == car.RegistrationNumber))
            {
                return "Car with that registration number, already exists";

            }
            else if (Capacity <= Cars.Count)
            {
                return "Parking is full!";
            }
            else
            {
                Cars.Add(car);
                return $"Successfully added new car {car.Make} {car.RegistrationNumber}";
            }

        }

        public Car GetCar(string registrationNumber)
        {

            return Cars.Find(x => x.RegistrationNumber == registrationNumber);

        }

        public string RemoveCar(string registrationNumber)
        {
            if (Cars.Find(x => x.RegistrationNumber == registrationNumber) == null)
            {

                return "Car with that registration number, doesn't exist!";

            }
            else
            {
                Cars.Remove(GetCar(registrationNumber));
                return $"Successfully removed {registrationNumber}";
            }
        }

        public void RemoveSetOfRegistrationNumber(List<string> registrationNumbers)
        {
            foreach (var reg in registrationNumbers)
            {
                RemoveCar(reg);
            }
        }
    }
}
