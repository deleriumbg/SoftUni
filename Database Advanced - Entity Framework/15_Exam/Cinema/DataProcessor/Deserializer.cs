using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using Cinema.Data.Models;
using Cinema.Data.Models.Enums;
using Cinema.DataProcessor.ImportDto;
using Newtonsoft.Json;

namespace Cinema.DataProcessor
{
    using System;

    using Data;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";
        private const string SuccessfulImportMovie 
            = "Successfully imported {0} with genre {1} and rating {2}!";
        private const string SuccessfulImportHallSeat 
            = "Successfully imported {0}({1}) with {2} seats!";
        private const string SuccessfulImportProjection 
            = "Successfully imported projection {0} on {1}!";
        private const string SuccessfulImportCustomerTicket 
            = "Successfully imported customer {0} {1} with bought tickets: {2}!";

        public static string ImportMovies(CinemaContext context, string jsonString)
        {
            var deserializedMovies = JsonConvert.DeserializeObject<Movie[]>(jsonString);
            StringBuilder sb = new StringBuilder();
            var movies = new List<Movie>();

            foreach (var currentMovie in deserializedMovies)
            {
                if (!IsValid(currentMovie))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var validGenre = Enum.TryParse(currentMovie.Genre.ToString(), out Genre genre);
                if (!validGenre)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var movie = new Movie
                {
                    Title = currentMovie.Title,
                    Genre = genre,
                    Duration = currentMovie.Duration,
                    Rating = currentMovie.Rating,
                    Director = currentMovie.Director
                };

                movies.Add(movie);
                sb.AppendLine(string.Format(SuccessfulImportMovie, movie.Title, movie.Genre, movie.Rating.ToString("F2")));
            }

            context.Movies.AddRange(movies);
            context.SaveChanges();

            var result = sb.ToString().TrimEnd();
            return result;
        }

        public static string ImportHallSeats(CinemaContext context, string jsonString)
        {
            var deserializedHalls = JsonConvert.DeserializeObject<HallsAndSeatsDto[]>(jsonString);
            StringBuilder sb = new StringBuilder();
            var halls = new List<Hall>();

            foreach (var hallDto in deserializedHalls)
            {
                if (!IsValid(hallDto) || hallDto.Seats <= 0)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var hall = new Hall
                {
                    Name = hallDto.Name,
                    Is4Dx = hallDto.Is4Dx,
                    Is3D = hallDto.Is3D
                };

                for (int i = 0; i < hallDto.Seats; i++)
                {
                    hall.Seats.Add(new Seat());
                }

                halls.Add(hall);

                string movieType = "Normal";
                if (hall.Is4Dx && hall.Is3D)
                {
                    movieType = "4Dx/3D";
                }
                else if (hall.Is4Dx)
                {
                    movieType = "4Dx";
                }
                else if (hall.Is3D)
                {
                    movieType = "3D";
                }

                sb.AppendLine(string.Format(SuccessfulImportHallSeat, hall.Name, movieType, hall.Seats.Count));
            }

            context.Halls.AddRange(halls);
            context.SaveChanges();

            var result = sb.ToString().TrimEnd();
            return result;
        }

        public static string ImportProjections(CinemaContext context, string xmlString)
        {
            var serializer = new XmlSerializer(typeof(ImportProjectionsDto[]), new XmlRootAttribute("Projections"));
            var deserizlizedProjections = (ImportProjectionsDto[])serializer.Deserialize(new StringReader(xmlString));
            var sb = new StringBuilder();
            var projections = new List<Projection>();

            foreach (var projectionDto in deserizlizedProjections)
            {
                if (!IsValid(projectionDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var movie = context.Movies.FirstOrDefault(x => x.Id == projectionDto.MovieId);
                var hall = context.Halls.FirstOrDefault(x => x.Id == projectionDto.HallId);

                if (movie == null || hall == null)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var projection = new Projection
                {
                    MovieId = movie.Id,
                    HallId = hall.Id,
                    DateTime = DateTime.ParseExact(projectionDto.DateTime, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture)
                };

                projections.Add(projection);
                sb.AppendLine(string.Format(SuccessfulImportProjection, movie.Title, projection.DateTime.ToString("MM/dd/yyyy")));
            }

            context.Projections.AddRange(projections);
            context.SaveChanges();
            var result = sb.ToString().TrimEnd();
            return result;
        }

        public static string ImportCustomerTickets(CinemaContext context, string xmlString)
        {
            var serializer = new XmlSerializer(typeof(CustomersTicketsDto[]), new XmlRootAttribute("Customers"));
            var deserizlizedCustomers = (CustomersTicketsDto[])serializer.Deserialize(new StringReader(xmlString));
            var sb = new StringBuilder();
            var customers = new List<Customer>();

            foreach (var customerDto in deserizlizedCustomers)
            {
                if (!IsValid(customerDto) || !customerDto.Tickets.All(IsValid))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var validProjectionIds = context.Projections.Select(x => x.Id).ToArray();
                bool allProjectionIdsAreValid = true;

                foreach (var currentTicket in customerDto.Tickets)
                {
                    if (!validProjectionIds.Contains(currentTicket.ProjectionId))
                    {
                        allProjectionIdsAreValid = false;
                        break;
                    }
                }

                if (!allProjectionIdsAreValid)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var customer = new Customer
                {
                    FirstName = customerDto.FirstName,
                    LastName = customerDto.LastName,
                    Age = customerDto.Age,
                    Balance = customerDto.Balance,
                    Tickets = customerDto.Tickets.Select(t => new Ticket
                    {
                        ProjectionId = t.ProjectionId,
                        Price = t.Price
                    }).ToArray()
                };

                customers.Add(customer);
                sb.AppendLine(string.Format(SuccessfulImportCustomerTicket, customer.FirstName, customer.LastName, customer.Tickets.Count));
            }

            context.Customers.AddRange(customers);
            context.SaveChanges();
            var result = sb.ToString().TrimEnd();
            return result;
        }

        public static bool IsValid(object obj)
        {
            var validationContext = new ValidationContext(obj);
            var validationResults = new List<ValidationResult>();

            return Validator.TryValidateObject(obj, validationContext, validationResults, true);
        }
    }
}