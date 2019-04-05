using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using Newtonsoft.Json;
using VaporStore.Data.Models;
using VaporStore.Data.Models.Enums;
using VaporStore.DataProcessor.Dto.Import;

namespace VaporStore.DataProcessor
{
	using System;
	using Data;

	public static class Deserializer
	{
	    private const string ErrorMessage = "Invalid Data";

		public static string ImportGames(VaporStoreDbContext context, string jsonString)
		{
		    var deserializedGames = JsonConvert.DeserializeObject<GamesDto[]>(jsonString);
		    StringBuilder sb = new StringBuilder();
		    var games = new List<Game>();

		    foreach (var gameDto in deserializedGames)
		    {
		        if (!IsValid(gameDto) || gameDto.Tags.Count == 0)
		        {
		            sb.AppendLine(ErrorMessage);
		            continue;
		        }

		        var game = new Game
		        {
		            Name = gameDto.Name,
		            Price = gameDto.Price,
		            ReleaseDate = DateTime.ParseExact(gameDto.ReleaseDate, "yyyy-MM-dd", CultureInfo.InvariantCulture)
		        };

		        var developer = GetDeveloper(context, gameDto.Developer);
		        var genre = GetGenre(context, gameDto.Genre);

		        game.Developer = developer;
		        game.Genre = genre;

		        foreach (var currentTag in gameDto.Tags)
		        {
		            var tag = GetTag(context, currentTag);
                    game.GameTags.Add(new GameTag
                    {
                        Tag = tag
                    });
		        }

                games.Add(game);
		        sb.AppendLine($"Added {game.Name} ({game.Genre.Name}) with {game.GameTags.Count} tags");
		    }

            context.Games.AddRange(games);
		    context.SaveChanges();
		    var result = sb.ToString().TrimEnd();
		    return result;
		}

	    public static string ImportUsers(VaporStoreDbContext context, string jsonString)
		{
		    var deserializedUsers = JsonConvert.DeserializeObject<UsersDto[]>(jsonString);
		    StringBuilder sb = new StringBuilder();
		    var users = new List<User>();

		    foreach (var userDto in deserializedUsers)
		    {
		        if (!IsValid(userDto) || !userDto.Cards.All(IsValid))
		        {
		            sb.AppendLine(ErrorMessage);
		            continue;
		        }

		        var user = new User
		        {
		            FullName = userDto.FullName,
		            Username = userDto.Username,
		            Email = userDto.Email,
		            Age = userDto.Age
		        };

		        foreach (var cardDto in userDto.Cards)
		        {
		            user.Cards.Add(new Card
		            {
                        Number = cardDto.Number,
                        Cvc = cardDto.CVC,
                        Type = Enum.Parse<CardType>(cardDto.Type)
		            });
		        }

                users.Add(user);
		        sb.AppendLine($"Imported {user.Username} with {user.Cards.Count} cards");
		    }
		    context.Users.AddRange(users);
		    context.SaveChanges();
		    var result = sb.ToString().TrimEnd();
		    return result;
		}

		public static string ImportPurchases(VaporStoreDbContext context, string xmlString)
		{
		    var serializer = new XmlSerializer(typeof(PurchasesDto[]), new XmlRootAttribute("Purchases"));
		    var deserizlizedPurchases = (PurchasesDto[])serializer.Deserialize(new StringReader(xmlString));
		    var sb = new StringBuilder();
		    var purchases = new List<Purchase>();

		    foreach (var purchaseDto in deserizlizedPurchases)
		    {
		        if (!IsValid(purchaseDto))
		        {
		            sb.AppendLine(ErrorMessage);
		            continue;
		        }

		        var isValidEnum = Enum.TryParse<PurchaseType>(purchaseDto.Type, out PurchaseType purchaseType);
		        if (!isValidEnum)
		        {
		            sb.AppendLine(ErrorMessage);
		            continue;
		        }

		        var game = context.Games.FirstOrDefault(x => x.Name == purchaseDto.Title);
		        var card = context.Cards.FirstOrDefault(x => x.Number == purchaseDto.Card);

		        if (game == null || card == null)
		        {
		            sb.AppendLine(ErrorMessage);
		            continue;
		        }

		        var purchase = new Purchase
		        {
		            Type = purchaseType,
		            ProductKey = purchaseDto.Key,
		            Date = DateTime.ParseExact(purchaseDto.Date, "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture),
		            Card = card,
		            Game = game
		        };

                purchases.Add(purchase);
		        sb.AppendLine($"Imported {purchase.Game.Name} for {purchase.Card.User.Username}");
		    }

            context.Purchases.AddRange(purchases);
		    context.SaveChanges();
		    var result = sb.ToString().TrimEnd();
		    return result;
		}

	    private static Tag GetTag(VaporStoreDbContext context, string currentTag)
	    {
	        var tag = context.Tags.FirstOrDefault(x => x.Name == currentTag);

	        if (tag == null)
	        {
	            tag = new Tag
	            {
	                Name = currentTag
	            };

	            context.Tags.Add(tag);
	            context.SaveChanges();
	        }

	        return tag;
	    }

	    private static Genre GetGenre(VaporStoreDbContext context, string gameDtoGenre)
	    {
	        var genre = context.Genres.FirstOrDefault(x => x.Name == gameDtoGenre);

	        if (genre == null)
	        {
	            genre = new Genre
	            {
	                Name = gameDtoGenre
	            };

	            context.Genres.Add(genre);
	            context.SaveChanges();
	        }

	        return genre;
	    }

	    private static Developer GetDeveloper(VaporStoreDbContext context, string gameDtoDeveloper)
	    {
	        var developer = context.Developers.FirstOrDefault(x => x.Name == gameDtoDeveloper);

	        if (developer == null)
	        {
	            developer = new Developer
	            {
	                Name = gameDtoDeveloper
	            };

	            context.Developers.Add(developer);
	            context.SaveChanges();
	        }

	        return developer;
	    }

	    public static bool IsValid(object obj)
	    {
	        var validationContext = new ValidationContext(obj);
	        var validationResults = new List<ValidationResult>();

	        return Validator.TryValidateObject(obj, validationContext, validationResults, true);
	    }
	}
}