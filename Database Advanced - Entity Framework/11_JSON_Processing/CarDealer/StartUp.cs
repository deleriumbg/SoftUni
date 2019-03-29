using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AutoMapper;
using CarDealer.Data;
using CarDealer.DTO;
using CarDealer.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace CarDealer
{
    public class StartUp
    {
        private const string SuccessMessage = "Successfully imported {0}.";
        private const string CarsJsonPath = @"../../../Datasets/cars.json";
        private const string CustomersJsonPath = @"../../../Datasets/customers.json";
        private const string PartsJsonPath = @"../../../Datasets/parts.json";
        private const string SalesJsonPath = @"../../../Datasets/sales.json";
        private const string SuppliersJsonPath = @"../../../Datasets/suppliers.json";

        public static void Main(string[] args)
        {
            Mapper.Initialize(cfg => cfg.AddProfile(new CarDealerProfile()));
            var context = new CarDealerContext();

            //Import Data
            if (File.Exists(CarsJsonPath))
            {
                var importData = File.ReadAllText(SalesJsonPath);

                var output = ImportSales(context, importData);
                Console.WriteLine(output);
            }

            //Query and Export Data
            //Query 14. Export Ordered Customers
            Console.WriteLine(GetOrderedCustomers(context));

            //Query 15. Export Cars from make Toyota
            Console.WriteLine(GetCarsFromMakeToyota(context));

            //Query 16. Export Local Suppliers
            Console.WriteLine(GetLocalSuppliers(context));

            //Query 17. Export Cars with Their List of Parts
            Console.WriteLine(GetCarsWithTheirListOfParts(context));

            //Query 18. Export Total Sales by Customer
            Console.WriteLine(GetTotalSalesByCustomer(context));

            //Query 19. Export Sales with Applied Discount
            Console.WriteLine(GetSalesWithAppliedDiscount(context));
        }


        public static string ImportSuppliers(CarDealerContext context, string inputJson)
        {
            var deserializedSuppliers = JsonConvert.DeserializeObject<Supplier[]>(inputJson);
            context.Suppliers.AddRange(deserializedSuppliers);
            context.SaveChanges();
            return string.Format(SuccessMessage, deserializedSuppliers.Count());
        }

        public static string ImportParts(CarDealerContext context, string inputJson)
        {
            var existingSuppliers = context.Suppliers
                .Select(s => s.Id)
                .ToArray();

            var parts = JsonConvert.DeserializeObject<Part[]>(inputJson)
                .Where(p => existingSuppliers.Contains(p.SupplierId))
                .ToArray();

            context.Parts.AddRange(parts);
            context.SaveChanges();
            return string.Format(SuccessMessage, parts.Count());
        }

        public static string ImportCars(CarDealerContext context, string inputJson)
        {
            var cars = JsonConvert.DeserializeObject<CarInsertDto[]>(inputJson);
            var mappedCars = new List<Car>();

            foreach (var car in cars)
            {
                Car vehicle = Mapper.Map<CarInsertDto, Car>(car);
                mappedCars.Add(vehicle);

                var partIds = car
                    .PartsId
                    .Distinct()
                    .ToList();

                partIds.ForEach(pid =>
                    {
                        var currentPair = new PartCar()
                        {
                            Car = vehicle,
                            PartId = pid
                        };

                        vehicle.PartCars.Add(currentPair);
                    }
                );
            }

            context.Cars.AddRange(mappedCars);
            context.SaveChanges();
            return string.Format(SuccessMessage, context.Cars.Count());
        }

        public static string ImportCustomers(CarDealerContext context, string inputJson)
        {
            var deserializedCustomers = JsonConvert.DeserializeObject<Customer[]>(inputJson);
            context.Customers.AddRange(deserializedCustomers);
            context.SaveChanges();
            return string.Format(SuccessMessage, deserializedCustomers.Count());
        }

        public static string ImportSales(CarDealerContext context, string inputJson)
        {
            var deserializedSales = JsonConvert.DeserializeObject<Sale[]>(inputJson);
            context.Sales.AddRange(deserializedSales);
            context.SaveChanges();
            return string.Format(SuccessMessage, deserializedSales.Count());
        }

        public static string GetOrderedCustomers(CarDealerContext context)
        {
            var customers = context.Customers
                .OrderBy(x => x.BirthDate)
                .ThenBy(x => x.IsYoungDriver)
                .Select(x => new
                {
                    Name = x.Name,
                    BirthDate = x.BirthDate,
                    IsYoungDriver = x.IsYoungDriver
                })
                .ToArray();

            var jsonProducts = JsonConvert.SerializeObject(customers, new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
                NullValueHandling = NullValueHandling.Ignore,
                DateFormatString = "dd/MM/yyyy"
            });
            return jsonProducts;
        }

        public static string GetCarsFromMakeToyota(CarDealerContext context)
        {
            var cars = context.Cars
                .Where(x => x.Make == "Toyota")
                .OrderBy(x => x.Model)
                .ThenByDescending(x => x.TravelledDistance)
                .Select(x => new
                {
                    Id = x.Id,
                    Make = x.Make,
                    Model = x.Model,
                    TravelledDistance = x.TravelledDistance
                })
                .ToArray();

            var jsonCars = JsonConvert.SerializeObject(cars, Formatting.Indented);
            return jsonCars;
        }

        public static string GetLocalSuppliers(CarDealerContext context)
        {
            var suppliers = context.Suppliers
                .Where(x => x.IsImporter == false)
                .Select(x => new
                {
                    Id = x.Id,
                    Name = x.Name,
                    PartsCount = x.Parts.Count
                })
                .ToArray();

            var jsonSuppliers = JsonConvert.SerializeObject(suppliers, Formatting.Indented);
            return jsonSuppliers;
        }

        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            var cars = context.Cars
                .Include(x => x.PartCars)
                .ThenInclude(x => x.Part)
                .Select(x => new
                {
                    car = new
                    {
                        Make = x.Make,
                        Model = x.Model,
                        TravelledDistance = x.TravelledDistance
                    },
                    parts = x.PartCars.Select(p => new
                    {
                        Name = p.Part.Name,
                        Price = p.Part.Price.ToString("F2")
                    })
                    .ToArray()
                })
                .ToArray();

            var jsonCars = JsonConvert.SerializeObject(cars, new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
                NullValueHandling = NullValueHandling.Ignore,
            });
            return jsonCars;
        }

        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {
            var customers = context.Customers
                .Include(c => c.Sales)
                .ThenInclude(c => c.Car)
                .ThenInclude(c => c.PartCars)
                .ThenInclude(c => c.Part)
                .Where(c => c.Sales.Count >= 1)
                .Select(x => new
                {
                    FullName = x.Name,
                    BoughtCars = x.Sales.Count,
                    SpentMoney = x.Sales.Sum(y => y.Car.PartCars.Sum(z => z.Part.Price))
                })
                .ToArray()
                .OrderByDescending(x => x.SpentMoney)
                .ThenBy(x => x.BoughtCars)
                .ToArray();


            var jsonCustomers = JsonConvert.SerializeObject(customers, new JsonSerializerSettings()
            {
                NullValueHandling = NullValueHandling.Ignore,
                Formatting = Formatting.Indented,
                ContractResolver = new DefaultContractResolver()
                {
                    NamingStrategy = new CamelCaseNamingStrategy()
                }
            });

            return jsonCustomers;
        }

        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        {
            var sales = context.Sales
                .Take(10)
                .Select(x => new
                {
                    car = new
                    {
                        Make = x.Car.Make,
                        Model = x.Car.Model,
                        TravelledDistance = x.Car.TravelledDistance
                    },
                    customerName = x.Customer.Name,
                    Discount = $"{x.Discount:F2}",
                    price = $"{x.Car.PartCars.Sum(y => y.Part.Price):F2}",
                    priceWithDiscount =
                        $"{x.Car.PartCars.Sum(y => y.Part.Price) - (x.Car.PartCars.Sum(y => y.Part.Price) * (x.Discount / 100)):F2}"
                })
                .ToArray();

            var jsonSales = JsonConvert.SerializeObject(sales, new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
                NullValueHandling = NullValueHandling.Ignore,
            });
            return jsonSales;
        }
    }
}