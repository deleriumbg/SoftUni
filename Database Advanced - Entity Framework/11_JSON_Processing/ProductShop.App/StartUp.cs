using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using DataAnnotations = System.ComponentModel.DataAnnotations;

namespace ProductShop.App
{
    using AutoMapper;

    using Data;
    using Models;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<ProductShopProfile>();
            });
            var mapper = config.CreateMapper();

            var context = new ProductShopContext();

            //Import Data
            ImportUsersFromJson(context);
            ImportProductsFromJson(context);
            ImportCategoriesFromJson(context);
            GenerateCategoriesForTheProducts(context);

            //Query and Export Data
            //Query 1. Products In Range
            GenerateJsonProductsInRange(context);

            //Query 2. Sold Products
            GenerateJsonSoldProducts(context);

            //Query 3. Categories By Products Count
            GenerateJsonCategoriesByProductsCount(context);

            //Query 4. Users and Products
            GenerateJsonUsersAndProducts(context);
        }

        private static void GenerateJsonUsersAndProducts(ProductShopContext context)
        {
            var users = new 
            {
                usersCount = context.Users.Count(),
                users = context.Users.Where(x => x.ProductsSold.Count > 0).Select(x => new 
                    {
                        firstName = x.FirstName,
                        lastName = x.LastName,
                        age = x.Age.ToString(),
                        soldProduct = new 
                        {
                            count = x.ProductsSold.Count,
                            products = x.ProductsSold.Select(p => new 
                                {
                                    name = p.Name,
                                    price = p.Price
                                })
                                .ToArray()   
                        }
                    })
                    .ToArray()
            }; 

            var jsonUsers = JsonConvert.SerializeObject(users, new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
                NullValueHandling = NullValueHandling.Ignore
            });
            File.WriteAllText("Json/users-and-products.json", jsonUsers);
        }

        private static void GenerateJsonCategoriesByProductsCount(ProductShopContext context)
        {
            var categories = context.Categories
                .Select(x => new 
                {
                    category = x.Name,
                    productsCount = x.CategoryProducts.Count,
                    averagePrice = x.CategoryProducts.Sum(c => c.Product.Price) / x.CategoryProducts.Count,
                    totalRevenue = x.CategoryProducts.Sum(c => c.Product.Price)
                })
                .OrderByDescending(x => x.productsCount)
                .ToArray();

            var jsonCategories = JsonConvert.SerializeObject(categories, Formatting.Indented);
            File.WriteAllText("Json/categories-by-products.json", jsonCategories);
        }

        private static void GenerateJsonSoldProducts(ProductShopContext context)
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
                        })
                        .ToArray()
                })
                .ToArray();

            var jsonUsers = JsonConvert.SerializeObject(users, new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
                NullValueHandling = NullValueHandling.Ignore
            });
            File.WriteAllText("Json/users-sold-products.json", jsonUsers);
        }

        private static void GenerateJsonProductsInRange(ProductShopContext context)
        {
            var products = context.Products
                .Where(x => x.Price >= 1000 && x.Price <= 2000 && x.Buyer != null)
                .OrderBy(x => x.Price)
                .Select(x => new 
                {
                    name = x.Name,
                    price = x.Price,
                    seller = x.Seller.FirstName + " " + x.Seller.LastName ?? x.Seller.LastName
                })
                .ToArray();

            var jsonProducts = JsonConvert.SerializeObject(products, Formatting.Indented);
            File.WriteAllText("Json/products-in-range.json", jsonProducts);
        }

        private static void GenerateCategoriesForTheProducts(ProductShopContext context)
        {
            var categoryProducts = new List<CategoryProduct>();

            for (int productId = 1; productId <= 200; productId++)
            {
                var categoryId = new Random().Next(1, 12);

                var categoryProduct = new CategoryProduct()
                {
                    ProductId = productId,
                    CategoryId = categoryId
                };
                categoryProducts.Add(categoryProduct);
            }

            context.CategoryProducts.AddRange(categoryProducts);
            context.SaveChanges();
        }

        private static void ImportCategoriesFromJson(ProductShopContext context)
        {
            var jsonString = File.ReadAllText("Json/categories.json");
            var deserializedCategories = JsonConvert.DeserializeObject<Category[]>(jsonString);

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
        }

        private static void ImportProductsFromJson(ProductShopContext context)
        {
            var jsonString = File.ReadAllText("Json/products.json");
            var deserializedProducts = JsonConvert.DeserializeObject<Product[]>(jsonString);

            var products = new List<Product>();
            foreach (var product in deserializedProducts)
            {
                if (!IsValid(product))
                {
                    continue;
                }

                var buyerId = new Random().Next(1, 30);
                var sellerId = new Random().Next(31, 57);
                var randomProductWithoutBuyer = new Random().Next(1, 4);

                product.BuyerId = buyerId;
                product.SellerId = sellerId;

                if (randomProductWithoutBuyer == 3)
                {
                    product.BuyerId = null;
                }

                products.Add(product);
            }
            
            context.Products.AddRange(products);
            context.SaveChanges();
        }


        private static void ImportUsersFromJson(ProductShopContext context)
        {
            var jsonString = File.ReadAllText("Json/users.json");
            var deserializedUsers = JsonConvert.DeserializeObject<User[]>(jsonString);

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
        }

        public static bool IsValid(object obj)
        {
            var validationContext = new DataAnnotations.ValidationContext(obj);
            var validationResults = new List<DataAnnotations.ValidationResult>();

            return DataAnnotations.Validator.TryValidateObject(obj, validationContext, validationResults, true);
        }
    }
}
