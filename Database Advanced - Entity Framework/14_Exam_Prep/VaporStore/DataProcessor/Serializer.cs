using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using Castle.DynamicProxy.Generators.Emitters.SimpleAST;
using Newtonsoft.Json;
using VaporStore.Data.Models.Enums;
using VaporStore.DataProcessor.Dto.Export;
using Formatting = Newtonsoft.Json.Formatting;

namespace VaporStore.DataProcessor
{
	using System;
	using Data;

	public static class Serializer
	{
		public static string ExportGamesByGenres(VaporStoreDbContext context, string[] genreNames)
		{
		    var genres = context.Genres
		        .Where(x => genreNames.Contains(x.Name))
		        .Select(x => new
		        {
		            Id = x.Id,
		            Genre = x.Name,
		            Games = x.Games.Where(g => g.Purchases.Any()).Select(g => new
		                {
		                    Id = g.Id,
		                    Title = g.Name,
		                    Developer = g.Developer.Name,
		                    Tags = string.Join(", ", g.GameTags.Select(t => t.Tag.Name)),
		                    Players = g.Purchases.Count
		                })
		                .OrderByDescending(g => g.Players)
		                .ThenBy(g => g.Id)
		                .ToArray(),
                    TotalPlayers = x.Games.Sum(y => y.Purchases.Count)
		        })
		        .OrderByDescending(x => x.TotalPlayers)
		        .ThenBy(x => x.Id)
		        .ToArray();

		    string serializedGenres = JsonConvert.SerializeObject(genres, Formatting.Indented);
		    return serializedGenres;
		}

		public static string ExportUserPurchasesByType(VaporStoreDbContext context, string storeType)
		{
		    var purchaseType = Enum.Parse<PurchaseType>(storeType);

		    var users = context.Users
		        .Select(x => new UserPurchasesByTypeDto
		        {
		            Username = x.Username,
		            Purchases = x.Cards
		                .SelectMany(p => p.Purchases)
		                .Where(t => t.Type == purchaseType)
		                .Select(p => new PurchaseDto
		                {
                            Card = p.Card.Number,
                            Cvc = p.Card.Cvc,
                            Date = p.Date.ToString("yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture),
                            Game = new GameDto
                            {
                                Title = p.Game.Name,
                                Genre = p.Game.Genre.Name,
                                Price = p.Game.Price
                            }
		                })
		                .OrderBy(p => p.Date)
		                .ToArray(),
                    TotalSpent = x.Cards
                        .SelectMany(p => p.Purchases)
                        .Where(t => t.Type == purchaseType)
                        .Sum(p => p.Game.Price)
		        })
		        .Where(x => x.Purchases.Any())
		        .OrderByDescending(x => x.TotalSpent)
		        .ThenBy(x => x.Username)
		        .ToArray();

		    StringBuilder sb = new StringBuilder();
		    var namespaces = new XmlSerializerNamespaces(new []{XmlQualifiedName.Empty });
		    var serializer = new XmlSerializer(typeof(UserPurchasesByTypeDto[]), new XmlRootAttribute("Users"));
		    serializer.Serialize(new StringWriter(sb), users, namespaces);

            var result = sb.ToString().TrimEnd();
		    return result;
		}
	}
}