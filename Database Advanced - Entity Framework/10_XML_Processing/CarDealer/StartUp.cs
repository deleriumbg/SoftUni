using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using AutoMapper;
using CarDealer.Data;
using CarDealer.Dtos.Export;
using CarDealer.Dtos.Import;
using CarDealer.Models;

namespace CarDealer
{
    public class StartUp
    {
        private const string SuccessMessage = "Successfully imported {0}";
        private const string CarsXmlPath = @"../../../Datasets/cars.xml";
        private const string CustomersXmlPath = @"../../../Datasets/customers.xml";
        private const string PartsXmlPath = @"../../../Datasets/parts.xml";
        private const string SalesXmlPath = @"../../../Datasets/sales.xml";
        private const string SuppliersXmlPath = @"../../../Datasets/suppliers.xml";

        public static void Main(string[] args)
        {
            Mapper.Initialize(cfg => cfg.AddProfile(new CarDealerProfile()));
            var context = new CarDealerContext();

            //Import Data
            if (File.Exists(SalesXmlPath))
            {
                var importData = File.ReadAllText(SalesXmlPath);

                var output = ImportSales(context, importData);
                Console.WriteLine(output);
            }

            //Query and Export Data
            //Query 14. Cars With Distance
            Console.WriteLine(GetCarsWithDistance(context));

            //Query 15. Cars from make BMW
            Console.WriteLine(GetCarsFromMakeBmw(context));

            //Query 16. Local Suppliers
            Console.WriteLine(GetLocalSuppliers(context));

            //Query 17. Cars with Their List of Parts
            Console.WriteLine(GetCarsWithTheirListOfParts(context));

            //Query 18. Total Sales by Customer
            Console.WriteLine(GetTotalSalesByCustomer(context));

            //Query 19. Sales with Applied Discount
            Console.WriteLine(GetSalesWithAppliedDiscount(context));
        }

        public static string ImportSuppliers(CarDealerContext context, string inputXml)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(SuppliersDto[]), new XmlRootAttribute("Suppliers"));
            var suppliersDto = (SuppliersDto[])serializer.Deserialize(new StringReader(inputXml));
            var suppliers = new List<Supplier>();

            foreach (var supplierDto in suppliersDto)
            {
                var supplier = new Supplier
                {
                    Name = supplierDto.Name,
                    IsImporter = supplierDto.IsImporter
                };

                suppliers.Add(supplier);
            }

            context.Suppliers.AddRange(suppliers);
            context.SaveChanges();
            return string.Format(SuccessMessage, suppliers.Count);
        }

        public static string ImportParts(CarDealerContext context, string inputXml)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(PartsDto[]), new XmlRootAttribute("Parts"));
            var partsDto = (PartsDto[])serializer.Deserialize(new StringReader(inputXml));
            var parts = new List<Part>();

            var supplierIds = context.Suppliers
                .Select(x => x.Id)
                .ToList();

            foreach (var partDto in partsDto)
            {
                if (supplierIds.Contains(partDto.SupplierId))
                {
                    var part = new Part
                    {
                        Name = partDto.Name,
                        Price = partDto.Price,
                        Quantity = partDto.Quantity,
                        SupplierId = partDto.SupplierId
                    };
                    parts.Add(part);
                }
            }

            context.Parts.AddRange(parts);
            context.SaveChanges();
            return string.Format(SuccessMessage, parts.Count);
        }

        public static string ImportCars(CarDealerContext context, string inputXml)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(CarsDto[]), new XmlRootAttribute("Cars"));
            var carDtos = (CarsDto[])xmlSerializer.Deserialize(new StringReader(inputXml));
            var cars = new List<Car>();

            var validPartIds = context.Parts.Select(x => x.Id).ToList();

            foreach (var carDto in carDtos)
            {
                var car = new Car()
                {
                    Make = carDto.Make,
                    Model = carDto.Model,
                    TravelledDistance = carDto.TravelledDistance
                };

                var uniquePartIds = carDto.PartCars.Select(x => x.Id).Distinct();
                var partCars = new List<PartCar>();

                foreach (var partId in uniquePartIds)
                {
                    if (!validPartIds.Contains(partId))
                    {
                        continue;
                    }

                    partCars.Add(new PartCar
                    {
                        PartId = partId,
                        Car = car
                    });
                }

                car.PartCars = partCars;
                cars.Add(car);
            }

            context.Cars.AddRange(cars);
            context.SaveChanges();

            return string.Format(SuccessMessage, cars.Count);
        }

        public static string ImportCustomers(CarDealerContext context, string inputXml)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(CustomersDto[]), new XmlRootAttribute("Customers"));
            var customersDto = (CustomersDto[])serializer.Deserialize(new StringReader(inputXml));
            var customers = new List<Customer>();

            foreach (var customerDto in customersDto)
            {
                var customer = new Customer
                {
                    Name = customerDto.Name,
                    BirthDate = customerDto.BirthDate,
                    IsYoungDriver = customerDto.IsYoungDriver
                };
                customers.Add(customer);
            }

            context.Customers.AddRange(customers);
            context.SaveChanges();
            return string.Format(SuccessMessage, customers.Count);
        }

        public static string ImportSales(CarDealerContext context, string inputXml)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(SalesDto[]), new XmlRootAttribute("Sales"));
            var salesDto = (SalesDto[])serializer.Deserialize(new StringReader(inputXml));
            var sales = new List<Sale>();
            var carIds = context.Cars
                .Select(x => x.Id)
                .ToList();

            foreach (var saleDto in salesDto)
            {
                if (carIds.Contains(saleDto.CarId))
                {
                    var sale = new Sale
                    {
                        CarId = saleDto.CarId,
                        CustomerId = saleDto.CustomerId,
                        Discount = saleDto.Discount
                    };
                    sales.Add(sale);
                }
            }

            context.Sales.AddRange(sales);
            context.SaveChanges();
            return string.Format(SuccessMessage, sales.Count);
        }

        public static string GetCarsWithDistance(CarDealerContext context)
        {
            var cars = context.Cars
                .Where(x => x.TravelledDistance > 2_000_000)
                .Select(x => new CarsWithDistance
                {
                    Make = x.Make,
                    Model = x.Model,
                    TravelledDistance = x.TravelledDistance
                })
                .OrderBy(x => x.Make)
                .ThenBy(x => x.Model)
                .Take(10)
                .ToArray();

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(CarsWithDistance[]), new XmlRootAttribute("cars"));
            StringBuilder sb = new StringBuilder();
            var namespaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });
            xmlSerializer.Serialize(new StringWriter(sb), cars, namespaces);

            return sb.ToString().TrimEnd();
        }

        public static string GetCarsFromMakeBmw(CarDealerContext context)
        {
            var cars = context.Cars
                .Where(x => x.Make == "BMW")
                .Select(x => new CarsFromMakeBmw
                {
                    Id = x.Id,
                    Model = x.Model,
                    TravelledDistance = x.TravelledDistance
                })
                .OrderBy(x => x.Model)
                .ThenByDescending(x => x.TravelledDistance)
                .ToArray();

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(CarsFromMakeBmw[]), new XmlRootAttribute("cars"));
            StringBuilder sb = new StringBuilder();
            var namespaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });
            xmlSerializer.Serialize(new StringWriter(sb), cars, namespaces);

            return sb.ToString().TrimEnd();
        }

        public static string GetLocalSuppliers(CarDealerContext context)
        {
            var suppliers = context.Suppliers
                .Where(x => x.IsImporter == false)
                .Select(x => new LocalSuppliers
                {
                    Id = x.Id,
                    Name = x.Name,
                    PartsCount = x.Parts.Count
                })
                .ToArray();

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(LocalSuppliers[]), new XmlRootAttribute("suppliers"));
            StringBuilder sb = new StringBuilder();
            var namespaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });
            xmlSerializer.Serialize(new StringWriter(sb), suppliers, namespaces);

            return sb.ToString().TrimEnd();
        }

        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            var cars = context.Cars
                .Select(c => new CarsWithListOfParts
                {
                    Make = c.Make,
                    Model = c.Model,
                    TravelledDistance = c.TravelledDistance,
                    Parts = c.PartCars.Select(p => new PartDto
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

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(CarsWithListOfParts[]), new XmlRootAttribute("cars"));
            StringBuilder sb = new StringBuilder();
            var namespaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });
            xmlSerializer.Serialize(new StringWriter(sb), cars, namespaces);

            return sb.ToString().TrimEnd();
        }

        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {
            var customers = context.Customers
                .Where(x => x.Sales.Any())
                .Select(x => new TotalSalesByCustomer
                {
                    FullName = x.Name,
                    BoughtCars = x.Sales.Count,
                    SpentMoney = x.Sales.Sum(y => y.Car.PartCars.Sum(z => z.Part.Price))
                })
                .OrderByDescending(x => x.SpentMoney)
                .ToArray();

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(TotalSalesByCustomer[]), new XmlRootAttribute("customers"));
            StringBuilder sb = new StringBuilder();
            var namespaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });
            xmlSerializer.Serialize(new StringWriter(sb), customers, namespaces);

            return sb.ToString().TrimEnd();
        }

        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        {
            var sales = context.Sales
                .Select(x => new SalesWithAppliedDiscount
                {
                    Car = new ExportCarForSaleDto()
                    {
                        Make = x.Car.Make,
                        Model = x.Car.Model,
                        TravelledDistance = x.Car.TravelledDistance
                    },
                    Discount = x.Discount,
                    CustomerName = x.Customer.Name,
                    Price = x.Car.PartCars.Sum(y => y.Part.Price),
                    PriceWithDiscount = (x.Car.PartCars.Sum(y => y.Part.Price) - x.Car.PartCars.Sum(y => y.Part.Price) * x.Discount / 100)
                })
                .ToArray();

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(SalesWithAppliedDiscount[]), new XmlRootAttribute("sales"));
            StringBuilder sb = new StringBuilder();
            var namespaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });
            xmlSerializer.Serialize(new StringWriter(sb), sales, namespaces);

            return sb.ToString().TrimEnd();
        }
    }
}