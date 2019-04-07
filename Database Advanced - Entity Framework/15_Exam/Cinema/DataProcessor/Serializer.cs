using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using Cinema.DataProcessor.ExportDto;
using Newtonsoft.Json;
using Formatting = Newtonsoft.Json.Formatting;

namespace Cinema.DataProcessor
{
    using System;

    using Data;

    public class Serializer
    {
        public static string ExportTopMovies(CinemaContext context, int rating)
        {
            var movies = context.Movies
                .Where(x => x.Rating >= rating && x.Projections.Any(p => p.Tickets.Count > 0))
                .Select(x => new
                {
                    MovieName = x.Title,
                    Rating = x.Rating.ToString("F2"),
                    TotalIncomes = x.Projections.Sum(t => t.Tickets.Sum(p => p.Price)).ToString("F2"),
                    Customers = x.Projections.SelectMany(p => p.Tickets).Select(c => new
                    {
                        FirstName = c.Customer.FirstName,
                        LastName = c.Customer.LastName,
                        Balance = c.Customer.Balance.ToString("F2")
                    })
                        .OrderByDescending(c => c.Balance)
                        .ThenBy(c => c.FirstName)
                        .ThenBy(c => c.LastName)
                        .ToArray()
                })
                .OrderByDescending(x => double.Parse(x.Rating))
                .ThenByDescending(x => decimal.Parse(x.TotalIncomes))
                .Take(10)
                .ToArray();

            string serializedMovies = JsonConvert.SerializeObject(movies, Formatting.Indented);
            return serializedMovies;
        }

        public static string ExportTopCustomers(CinemaContext context, int age)
        {
            var customers = context.Customers
                .Where(x => x.Age >= age)
                .Select(x => new ExportTopCustomersDto
                {
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    SpentMoney = x.Tickets.Sum(t => t.Price).ToString("F2"),
                    SpentTime = new TimeSpan(x.Tickets.Sum(p => p.Projection.Movie.Duration.Ticks)).ToString("hh\\:mm\\:ss")
                })
                .OrderByDescending(z => decimal.Parse(z.SpentMoney))
                .Take(10)
                .ToArray();

            StringBuilder sb = new StringBuilder();
            var namespaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });
            var serializer = new XmlSerializer(typeof(ExportTopCustomersDto[]), new XmlRootAttribute("Customers"));
            serializer.Serialize(new StringWriter(sb), customers, namespaces);

            var result = sb.ToString().TrimEnd();
            return result;
        }
    }
}