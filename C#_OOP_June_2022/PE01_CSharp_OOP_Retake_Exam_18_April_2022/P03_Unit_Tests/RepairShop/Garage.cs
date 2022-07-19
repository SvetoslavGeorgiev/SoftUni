using System;
using System.Collections.Generic;
using System.Linq;

namespace RepairShop
{
    public class Garage
    {
        private string name;
        private int mechanicsAvailable;
        private List<Car> cars;

        public Garage(string name, int mechanicsAvailable)
        {
            this.Name = name;
            this.MechanicsAvailable = mechanicsAvailable;
            this.cars = new List<Car>();
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException(nameof(value), "Invalid garage name.");
                }

                this.name = value;
            }
        }

        public int MechanicsAvailable
        {
            get
            {
                return this.mechanicsAvailable;
            }

            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("At least one mechanic must work in the garage.");
                }

                this.mechanicsAvailable = value;
            }
        }

        public int CarsInGarage => this.cars.Count;

        public void AddCar(Car car)
        {
            if (this.cars.Count == this.mechanicsAvailable)
            {
                throw new InvalidOperationException("No mechanic available.");
            }

            this.cars.Add(car);
        }

        public Car FixCar(string carModel)
        {
            Car carToFix = this.cars.FirstOrDefault(x => x.CarModel == carModel);

            if (carToFix == null)
            {
                throw new InvalidOperationException($"The car {carModel} doesn't exist.");
            }

            carToFix.NumberOfIssues = 0;

            return carToFix;
        }

        public int RemoveFixedCar()
        {
            var carsToRemove = this.cars.Where(x => x.IsFixed == true).ToList();

            if (carsToRemove.Count == 0)
            {
                throw new InvalidOperationException($"No fixed cars available.");
            }

            return this.cars.RemoveAll(x => x.IsFixed == true);
        }

        public string Report()
        {
            var reportCars = this.cars.Where(x => x.IsFixed == false).Select(f => f.CarModel).ToList();
            string carsNames = string.Join(", ", reportCars);
            string report = $"There are {reportCars.Count} which are not fixed: {carsNames}.";

            return report;
        }
    }
}
