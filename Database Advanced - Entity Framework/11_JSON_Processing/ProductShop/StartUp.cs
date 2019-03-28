using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using ProductShop.Data;
using ProductShop.Dto;
using ProductShop.Models;
using DataAnnotations = System.ComponentModel.DataAnnotations;


namespace ProductShop
{
    public class StartUp
    {
        private const string SuccessMessage = "Successfully imported {0}";
        private const string UsersJsonPath = @"../../../Datasets/users.json";
        private const string ProductsJsonPath = @"../../../Datasets/products.json";
        private const string CategoriesJsonPath = @"../../../Datasets/categories.json";
        private const string CategoriesProductsJsonPath = @"../../../Datasets/categories-products.json";

        public static void Main(string[] args)
        {
            Mapper.Initialize(cfg => cfg.AddProfile(new ProductShopProfile()));
            var context = new ProductShopContext();

            //Import Data
            if (File.Exists(CategoriesProductsJsonPath))
            {
                var importData = File.ReadAllText(CategoriesProductsJsonPath);

                var output = ImportCategoryProducts(context, importData);
                Console.WriteLine(output);
            }

            //Query and Export Data
            //Query 1. Products In Range
            Console.WriteLine(GetProductsInRange(context));

            //Query 2. Sold Products
            Console.WriteLine(GetSoldProducts(context));

            //Query 3. Categories By Products Count
            Console.WriteLine(GetCategoriesByProductsCount(context));

            //Query 4. Users and Products
            Console.WriteLine(GetUsersWithProducts(context));
        }

        public static string ImportUsers(ProductShopContext context, string inputJson)
        {
            
            var deserializedUsers = JsonConvert.DeserializeObject<User[]>(inputJson);

            var users = new List<User>();
            foreach (var user in deserializedUsers)
            {
                if (IsValid(user))
                {
                    users.Add(user);
                }
            }

            context.Users.AddRange(users);
            context.SaveChanges();
            return string.Format(SuccessMessage, users.Count);
        }

        public static string ImportProducts(ProductShopContext context, string inputJson)
        {
            var deserializedProducts = JsonConvert.DeserializeObject<Product[]>(inputJson);

            var products = new List<Product>();
            foreach (var product in deserializedProducts)
            {
                if (!IsValid(product))
                {
                    continue;
                }

                products.Add(product);
            }

            context.Products.AddRange(products);
            context.SaveChanges();
            return string.Format(SuccessMessage, products.Count);
        }

        public static string ImportCategories(ProductShopContext context, string inputJson)
        {
            var deserializedCategories = JsonConvert.DeserializeObject<Category[]>(inputJson);

            var categories = new List<Category>();
            foreach (var category in deserializedCategories)
            {
                if (!IsValid(category))
                {
                    continue;
                }

                categories.Add(category);
            }

            context.Categories.AddRange(categories);
            context.SaveChanges();
            return string.Format(SuccessMessage, categories.Count);
        }

        public static string ImportCategoryProducts(ProductShopContext context, string inputJson)
        {
            var categoryProducts = JsonConvert.DeserializeObject<CategoryProduct[]>(inputJson);
            context.CategoryProducts.AddRange(categoryProducts);
            context.SaveChanges();
            return string.Format(SuccessMessage, categoryProducts.Length);
        }

        public static string GetProductsInRange(ProductShopContext context)
        {
            var products = context.Products
                .Where(x => x.Price >= 500 && x.Price <= 1000)
                .OrderBy(x => x.Price)
                .Select(x => new
                {
                    name = x.Name,
                    price = x.Price,
                    seller = $"{x.Seller.FirstName} {x.Seller.LastName}"
                })
                .ToArray();

            var jsonProducts = JsonConvert.SerializeObject(products, Formatting.Indented);
            return jsonProducts;
        }

        public static string GetSoldProducts(ProductShopContext context)
        {
            var users = context.Users
                .Where(x => x.ProductsSold.Count > 0 && x.ProductsSold.Any(p => p.Buyer != null))
                .OrderBy(x => x.LastName)
                .ThenBy(x => x.FirstName)
                .Select(x => new
                {
                    firstName = x.FirstName,
                    lastName = x.LastName,
                    soldProducts = x.ProductsSold.Where(b => b.Buyer != null).Select(s => new
                    {
                        name = s.Name,
                        price = s.Price,
                        buyerFirstName = s.Buyer.FirstName,
                        buyerLastName = s.Buyer.LastName
                    }).ToArray()
                }).ToArray();

            var jsonUsers = JsonConvert.SerializeObject(users, new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
            });
            return jsonUsers;
        }

        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            var categories = context.Categories
                .OrderByDescending(c => c.CategoryProducts.Count)
                .Select(x => new
                {
                    category = x.Name,
                    productsCount = x.CategoryProducts.Count,
                    averagePrice = $"{x.CategoryProducts.Average(c => c.Product.Price):F2}",
                    totalRevenue = $"{x.CategoryProducts.Sum(c => c.Product.Price)}"
                })
                .ToArray();

            var jsonCategories = JsonConvert.SerializeObject(categories, Formatting.Indented);
            return jsonCategories;
        }

        public static string GetUsersWithProducts(ProductShopContext context)
        {
            var users = context.Users
                .Where(u => u.ProductsSold.Any(p => p.Buyer != null))
                .OrderByDescending(u => u.ProductsSold.Count(p => p.Buyer != null))
                .ProjectTo<UserDto>()
                .ToList();

            var objectToSerialize = Mapper.Map<UsersAndProductsDto>(users);

            string json = JsonConvert.SerializeObject(objectToSerialize, new JsonSerializerSettings()
            {
                ContractResolver = new DefaultContractResolver()
                {
                    NamingStrategy = new CamelCaseNamingStrategy(),                    
                },
                
                NullValueHandling = NullValueHandling.Ignore,
                Formatting = Formatting.Indented
            });

            return json;
        }

        public static bool IsValid(object obj)
        {
            var validationContext = new DataAnnotations.ValidationContext(obj);
            var validationResults = new List<DataAnnotations.ValidationResult>();

            return DataAnnotations.Validator.TryValidateObject(obj, validationContext, validationResults, true);
        }
    }
}
