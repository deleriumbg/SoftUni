using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using FastFood.Data;
using FastFood.DataProcessor.Dto.Export;
using FastFood.Models.Enums;
using Newtonsoft.Json;
using Formatting = Newtonsoft.Json.Formatting;

namespace FastFood.DataProcessor
{
    public class Serializer
    {
        public static string ExportOrdersByEmployee(FastFoodDbContext context, string employeeName, string orderType)
        {
            var orderTypeEnum = Enum.Parse<OrderType>(orderType);
            var employee = context.Employees
                .ToArray()
                .Where(x => x.Name == employeeName)
                .Select(x => new
                {
                    Name = x.Name,
                    Orders = x.Orders.Where(o => o.Type == orderTypeEnum).Select(y => new
                        {
                            Customer = y.Customer,
                            Items = y.OrderItems.Select(z => new
                            {
                                Name = z.Item.Name,
                                Price = z.Item.Price,
                                Quantity = z.Quantity
                            }).ToArray(),
                            TotalPrice = y.TotalPrice
                        })
                        .OrderByDescending(or => or.TotalPrice)
                        .ThenByDescending(or => or.Items.Count())
                        .ToArray(),
                    TotalMade = x.Orders.Where(o => o.Type == orderTypeEnum).Sum(t => t.TotalPrice)
                })
                .FirstOrDefault();

            string serializedOrders = JsonConvert.SerializeObject(employee, Formatting.Indented);
            return serializedOrders;
        }

        public static string ExportCategoryStatistics(FastFoodDbContext context, string categoriesString)
        {
            var categoriesArray = categoriesString.Split(',');
            var categories = context.Categories
                .Where(x => categoriesArray.Any(c => c == x.Name))
                .Select(c => new CategoryDto
                {
                    Name = c.Name,
                    MostPopularItem = c.Items.Select(m => new MostPopularItemDto
                        {
                            Name = m.Name,
                            TimesSold = m.OrderItems.Sum(x => x.Quantity),
                            TotalMade = m.OrderItems.Sum(x => x.Item.Price * x.Quantity)
                        })
                        .OrderByDescending(x => x.TotalMade)
                        .ThenByDescending(x => x.TimesSold)
                        .FirstOrDefault()
                })
                .OrderByDescending(x => x.MostPopularItem.TotalMade)
                .ThenByDescending(x => x.MostPopularItem.TimesSold)
                .ToArray();

            StringBuilder sb = new StringBuilder();
            var xmlNamespaces = new XmlSerializerNamespaces(new []{XmlQualifiedName.Empty, });
            var serializer = new XmlSerializer(typeof(CategoryDto[]), new XmlRootAttribute("Categories"));
            serializer.Serialize(new StringWriter(sb), categories, xmlNamespaces);
            return sb.ToString().Trim();
        }
    }
}