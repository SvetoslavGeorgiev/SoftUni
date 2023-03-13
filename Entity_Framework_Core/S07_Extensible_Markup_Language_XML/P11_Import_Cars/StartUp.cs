namespace CarDealer
{
    using CarDealer.Data;
    using CarDealer.Dtos.Import;
    using CarDealer.Models;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Xml.Serialization;

    public class StartUp
    {
        public static void Main(string[] args)
        {

            using CarDealerContext dbContext = new CarDealerContext();

            string xml = File.ReadAllText("../../../Datasets/cars.xml");

            string result = ImportCars(dbContext, xml);

            Console.WriteLine(result);

            //dbContext.Database.EnsureDeleted();
            //dbContext.Database.EnsureCreated();




        }


        public static string ImportSuppliers(CarDealerContext context, string inputXml)
        {

            XmlRootAttribute xmlRoot = new XmlRootAttribute("Suppliers");
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportSupplierDto[]), xmlRoot);

            using StringReader reader = new StringReader(inputXml);

            ImportSupplierDto[] importSupplierDtos = (ImportSupplierDto[])xmlSerializer.Deserialize(reader);

            Supplier[] suppliers = importSupplierDtos
                .Select(dto => new Supplier()
                {
                    Name = dto.Name,
                    IsImporter = dto.IsImporter
                })
                .ToArray();

            context.Suppliers.AddRange(suppliers);
            context.SaveChanges();


            return $"Successfully imported {suppliers.Length}";
        }

        public static string ImportParts(CarDealerContext context, string inputXml)
        {

            XmlRootAttribute xmlRoot = new XmlRootAttribute("Parts");
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<ImportPartDto>), xmlRoot);

            using StringReader reader = new StringReader(inputXml);

            List<ImportPartDto> partDtos = (List<ImportPartDto>)xmlSerializer.Deserialize(reader);

            ICollection<Part> parts = new List<Part>();


            foreach (var dto in partDtos)
            {

                if (!context.Suppliers.Any(s => s.Id == dto.SupplierId))
                {
                    continue;
                }

                Part part = new Part()
                {
                    Name = dto.Name,
                    Price = dto.Price,
                    Quantity = dto.Quantity,
                    SupplierId = dto.SupplierId
                };

                parts.Add(part);
            }

            context.Parts.AddRange(parts);
            context.SaveChanges();

            return $"Successfully imported {parts.Count}";
        }

        public static string ImportCars(CarDealerContext context, string inputXml)
        {
            XmlRootAttribute xmlRoot = new XmlRootAttribute("Cars");
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportCarDto[]), xmlRoot);

            using StringReader reader = new StringReader(inputXml);

            ImportCarDto[] carDtos = (ImportCarDto[])xmlSerializer.Deserialize(reader);

            ICollection<Car> cars = new List<Car>();

            foreach (var cDto in carDtos)
            {
                Car car = new Car()
                {
                    Make = cDto.Make,
                    Model = cDto.Model,
                    TravelledDistance = cDto.TraveledDistance
                };

                ICollection<PartCar> currentCarParts = new List<PartCar>();

                foreach (int partId in cDto.Parts.Select(p => p.Id).Distinct())
                {

                    if (!context.Parts.Any(p => p.Id == partId))
                    {
                        continue;
                    }

                    currentCarParts.Add(new PartCar()
                    {
                        PartId = partId,
                    });
                }

                car.PartCars = currentCarParts;

                cars.Add(car);
            }

            context.Cars.AddRange(cars);
            context.SaveChanges();


            return $"Successfully imported {cars.Count}";


        }
    }
}