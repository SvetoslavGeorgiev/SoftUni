namespace CarDealer
{
    using CarDealer.Data;
    using CarDealer.Dtos.Export;
    using CarDealer.Dtos.Import;
    using CarDealer.Models;
    using Castle.Core.Resource;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;

    public class StartUp
    {
        public static void Main(string[] args)
        {

            using CarDealerContext dbContext = new CarDealerContext();

            //string xml = File.ReadAllText("../../../Datasets/sales.xml");
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "../../../Results/sales-discounts.xml");

            string result = GetSalesWithAppliedDiscount(dbContext);

            File.WriteAllText(filePath, result);

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
                        Car = car,
                        PartId = partId
                    });
                }

                car.PartCars = currentCarParts;
                cars.Add(car);
            }

            context.Cars.AddRange(cars);
            context.SaveChanges();


            return $"Successfully imported {cars.Count}";


        }

        public static string ImportCustomers(CarDealerContext context, string inputXml)
        {
            XmlRootAttribute xmlRoot = new XmlRootAttribute("Customers");
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportCustumerDto[]), xmlRoot);

            using StringReader reader = new StringReader(inputXml);

            ImportCustumerDto[] custumerDtos = (ImportCustumerDto[])xmlSerializer.Deserialize(reader);

            ICollection<Customer> customers = new List<Customer>();

            foreach (var custumerDto in custumerDtos)
            {
                Customer custumer = new Customer()
                {
                    Name = custumerDto.Name,
                    BirthDate = custumerDto.BirthDate,
                    IsYoungDriver = custumerDto.IsYoungDriver,
                };

                customers.Add(custumer);
            }

            context.Customers.AddRange(customers);
            context.SaveChanges();

            return $"Successfully imported {customers.Count}";
        }

        public static string ImportSales(CarDealerContext context, string inputXml)
        {

            XmlRootAttribute xmlRoot = new XmlRootAttribute("Sales");
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportSaleDto[]), xmlRoot);

            using StringReader reader = new StringReader(inputXml);

            ImportSaleDto[] saleDtos = (ImportSaleDto[])xmlSerializer.Deserialize(reader);

            ICollection<Sale> sales = new List<Sale>();

            foreach (var sDto in saleDtos)
            {
                if (!context.Cars.Any(c => c.Id == sDto.CarId))
                {
                    continue;
                }

                Sale saleDto = new Sale()
                {
                    CarId = sDto.CarId,
                    CustomerId = sDto.CustomerId,
                    Discount = sDto.Discount
                };

                sales.Add(saleDto);

            }

            context.Sales.AddRange(sales);
            context.SaveChanges();  


            return $"Successfully imported {sales.Count}";

        }

        public static string GetCarsWithDistance(CarDealerContext context)
        {

            StringBuilder sb = new StringBuilder();

            ExportCarsWithDistanceDto[] carDtos = context
                .Cars
                .Where(c => c.TravelledDistance > 2_000_000)
                .OrderBy(c => c.Make)
                .ThenBy(c => c.Model)
                .Take(10)
                .Select(c => new ExportCarsWithDistanceDto
                {
                    Make = c.Make,
                    Model = c.Model,
                    TravelledDistance = c.TravelledDistance,
                })
                .ToArray();

            XmlRootAttribute rootAttribute = new XmlRootAttribute("cars");

            XmlSerializerNamespaces xmlns = new XmlSerializerNamespaces();
            xmlns.Add(string.Empty, string.Empty);

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ExportCarsWithDistanceDto[]), rootAttribute);

            using StringWriter stringWriter = new StringWriter(sb);

            xmlSerializer.Serialize(stringWriter, carDtos, xmlns);

            return stringWriter.ToString().TrimEnd();
        }

        public static string GetCarsFromMakeBmw(CarDealerContext context)
        {


            StringBuilder sb = new StringBuilder();


            ExportCarsFromMakeBMWDto[] carDtos = context
                .Cars
                .Where(c => c.Make == "BMW")
                .OrderBy(c => c.Model)
                .ThenByDescending(c => c.TravelledDistance)
                .Select(c => new ExportCarsFromMakeBMWDto
                {
                    Id = c.Id,
                    Model = c.Model,
                    TravelledDistance = c.TravelledDistance,
                })
                .ToArray();

            XmlRootAttribute rootAttribute = new XmlRootAttribute("cars");

            XmlSerializerNamespaces xmlns = new XmlSerializerNamespaces();
            xmlns.Add(string.Empty, string.Empty);

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ExportCarsFromMakeBMWDto[]), rootAttribute);

            using StringWriter stringWriter = new StringWriter(sb);

            xmlSerializer.Serialize(stringWriter, carDtos, xmlns);

            return stringWriter.ToString().TrimEnd();

        }

        public static string GetLocalSuppliers(CarDealerContext context)
        {
            StringBuilder sb = new StringBuilder();


            ExportLocalSuppliersDto[] carDtos = context
                .Suppliers
                .Where(s => s.IsImporter == false)
                .Select(s => new ExportLocalSuppliersDto
                {
                    Id = s.Id,
                    Name = s.Name,
                    PartsCount = s.Parts.Count()
                })
                .ToArray();

            XmlRootAttribute rootAttribute = new XmlRootAttribute("suppliers");

            XmlSerializerNamespaces xmlns = new XmlSerializerNamespaces();
            xmlns.Add(string.Empty, string.Empty);

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ExportLocalSuppliersDto[]), rootAttribute);

            using StringWriter stringWriter = new StringWriter(sb);

            xmlSerializer.Serialize(stringWriter, carDtos, xmlns);

            return stringWriter.ToString().TrimEnd();
        }


        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {

            StringBuilder sb = new StringBuilder();


            ExportCarsWithPartrsDto[] carDtos = context
                .Cars
                .Select(c => new ExportCarsWithPartrsDto
                {
                    Make = c.Make,
                    Model = c.Model,
                    TravelledDistance = c.TravelledDistance,
                    Parts = c.PartCars
                        .Select(p => new ExportPartsDto
                        {
                            Name = p.Part.Name,
                            Price = p.Part.Price
                        })
                        .OrderByDescending(p => p.Price)
                        .ToArray()
                })
                .OrderByDescending(c => c.TravelledDistance)
                .ThenBy(c => c.Model)
                .Take(5)
                .ToArray();

            XmlRootAttribute rootAttribute = new XmlRootAttribute("cars");

            XmlSerializerNamespaces xmlns = new XmlSerializerNamespaces();
            xmlns.Add(string.Empty, string.Empty);

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ExportCarsWithPartrsDto[]), rootAttribute);

            using StringWriter stringWriter = new StringWriter(sb);

            xmlSerializer.Serialize(stringWriter, carDtos, xmlns);

            return stringWriter.ToString().TrimEnd();

        }


        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {

            StringBuilder sb = new StringBuilder();


            ExportTotalSalesByCustomer[] carDtos = context
                .Customers
                .Where(c => c.Sales.Count() > 0)
                .Select(c => new ExportTotalSalesByCustomer
                {
                    FullName = c.Name,
                    BoughtCars = c.Sales.Count(),
                    SpentMoney = decimal.Parse(c.Sales.Sum(s => s.Car.PartCars.Sum(x => x.Part.Price)).ToString("F2"))
                })
                .OrderByDescending(c => c.SpentMoney)
                .ToArray();

            XmlRootAttribute rootAttribute = new XmlRootAttribute("customers");

            XmlSerializerNamespaces xmlns = new XmlSerializerNamespaces();
            xmlns.Add(string.Empty, string.Empty);

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ExportTotalSalesByCustomer[]), rootAttribute);

            using StringWriter stringWriter = new StringWriter(sb);

            xmlSerializer.Serialize(stringWriter, carDtos, xmlns);

            return stringWriter.ToString().TrimEnd();


        }

        //Problem 19
        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        {
            ExportSaleDto[] sales = context
                .Sales
                .Select(s => new ExportSaleDto()
                {
                    Car = new ExportSaleCarDto()
                    {
                        Make = s.Car.Make,
                        Model = s.Car.Model,
                        TraveledDistance = s.Car.TravelledDistance
                    },
                    CustomerName = s.Customer.Name,
                    Discount = s.Discount.ToString("f0"),
                    Price = s.Car.PartCars.Sum(cp => cp.Part.Price),
                    PriceWithDiscount = (s.Car.PartCars.Sum(cp => cp.Part.Price) -
                                        (s.Car.PartCars.Sum(cp => cp.Part.Price) * (s.Discount / 100)))
                })
                .ToArray();

            return Serialize(sales, "sales");
        }

        //Helper methods
        private static T Deserialize<T>(string inputXml, string rootName)
        {
            XmlRootAttribute xmlRoot = new XmlRootAttribute(rootName);
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(T), xmlRoot);

            using StringReader reader = new StringReader(inputXml);
            T dtos = (T)xmlSerializer
                .Deserialize(reader);

            return dtos;
        }

        private static string Serialize<T>(T dto, string rootName)
        {
            StringBuilder sb = new StringBuilder();

            XmlRootAttribute xmlRoot = new XmlRootAttribute(rootName);
            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(T), xmlRoot);

            using StringWriter writer = new StringWriter(sb);
            xmlSerializer.Serialize(writer, dto, namespaces);

            return sb.ToString().TrimEnd();
        }

    }
}