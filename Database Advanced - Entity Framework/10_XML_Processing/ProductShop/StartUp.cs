using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using AutoMapper;
using ProductShop.Data;
using ProductShop.Dtos.Export;
using ProductShop.Dtos.Export.Query4;
using ProductShop.Dtos.Import;
using ProductShop.Models;
using UserDto = ProductShop.Dtos.Export.UserDto;

namespace ProductShop
{
    public class StartUp
    {
        private const string SuccessMessage = "Successfully imported {0}";
        private const string UsersXmlPath = @"../../../Datasets/users.xml";
        private const string ProductsXmlPath = @"../../../Datasets/products.xml";
        private const string CategoriesXmlPath = @"../../../Datasets/categories.xml";
        private const string CategoriesProductsXmlPath = @"../../../Datasets/categories-products.xml";

        public static void Main(string[] args)
        {
            Mapper.Initialize(cfg => cfg.AddProfile(new ProductShopProfile()));
            var context = new ProductShopContext();

            //Import Data
            if (File.Exists(CategoriesProductsXmlPath))
            {
                var importData = File.ReadAllText(CategoriesProductsXmlPath);

                var output = ImportCategoryProducts(context, importData);
                Console.WriteLine(output);
            }

            //Query and Export Data
            //Query 5. Products In Range
            Console.WriteLine(GetProductsInRange(context));

            //Query 6. Sold Products
            Console.WriteLine(GetSoldProducts(context));

            //Query 7. Categories By Products Count
            Console.WriteLine(GetCategoriesByProductsCount(context));

            //Query 8. Users and Products
            Console.WriteLine(GetUsersWithProducts(context));
        }

        public static string ImportUsers(ProductShopContext context, string inputXml)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(UserDto[]), new XmlRootAttribute("Users"));
            var usersDto = (UserDto[])serializer.Deserialize(new StringReader(inputXml));
            var users = new List<User>();

            foreach (var userDto in usersDto)
            {
                var user = new User
                {
                    FirstName = userDto.FirstName,
                    LastName = userDto.LastName,
                    Age = userDto.Age
                };

                users.Add(user);
            }

            context.Users.AddRange(users);
            context.SaveChanges();
            return string.Format(SuccessMessage, users.Count);
        }

        public static string ImportProducts(ProductShopContext context, string inputXml)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(ProductDto[]), new XmlRootAttribute("Products"));
            var productsDto = (ProductDto[])serializer.Deserialize(new StringReader(inputXml));
            var products = new List<Product>();

            foreach (var productDto in productsDto)
            {
                var product = new Product
                {
                    Name = productDto.Name,
                    Price = productDto.Price,
                    SellerId = productDto.SellerId,
                    BuyerId = productDto.BuyerId
                };
                products.Add(product);
            }

            context.Products.AddRange(products);
            context.SaveChanges();
            return string.Format(SuccessMessage, products.Count);
        }

        public static string ImportCategories(ProductShopContext context, string inputXml)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(CategoryDto[]), new XmlRootAttribute("Categories"));
            var categoriesDto = (CategoryDto[])serializer.Deserialize(new StringReader(inputXml));
            var categories = new List<Category>();

            foreach (var categoryDto in categoriesDto)
            {
                if (categoryDto.Name != null)
                {
                    var category = new Category
                    {
                        Name = categoryDto.Name
                    };

                    categories.Add(category);
                }
            }

            context.Categories.AddRange(categories);
            context.SaveChanges();
            return string.Format(SuccessMessage, categories.Count);
        }

        public static string ImportCategoryProducts(ProductShopContext context, string inputXml)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(CategoryProductDto[]), new XmlRootAttribute("CategoryProducts"));
            var categoryProductsDto = (CategoryProductDto[])serializer.Deserialize(new StringReader(inputXml));
            var categoryProducts = new List<CategoryProduct>();

            foreach (var categoryProductDto in categoryProductsDto)
            {
                var categoryIdExists = context.CategoryProducts.Any(x => x.CategoryId == categoryProductDto.CategoryId);
                var productIdExists = context.CategoryProducts.Any(x => x.ProductId == categoryProductDto.ProductId);

                if (!categoryIdExists && !productIdExists)
                {
                    var categoryProduct = new CategoryProduct
                    {
                        CategoryId = categoryProductDto.CategoryId,
                        ProductId = categoryProductDto.ProductId
                    };
                    categoryProducts.Add(categoryProduct);
                }
            }

            context.CategoryProducts.AddRange(categoryProducts);
            context.SaveChanges();
            return string.Format(SuccessMessage, categoryProducts.Count);
        }

        public static string GetProductsInRange(ProductShopContext context)
        {
            var products = context.Products
                .Where(x => x.Price >= 500 && x.Price <= 1000)
                .Select(x => new ProductsInRangeDto
                {
                    Name = x.Name,
                    Price = x.Price,
                    Buyer = x.Buyer.FirstName + " " + x.Buyer.LastName
                })
                .OrderBy(x => x.Price)
                .Take(10)
                .ToArray();

            StringBuilder sb = new StringBuilder();
            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces(new []{ XmlQualifiedName.Empty });
            XmlSerializer serializer = new XmlSerializer(typeof(ProductsInRangeDto[]), new XmlRootAttribute("Products"));
            serializer.Serialize(new StringWriter(sb), products, namespaces);

            return sb.ToString().TrimEnd();
        }

        public static string GetSoldProducts(ProductShopContext context)
        {
            var users = context.Users
                .Where(x => x.ProductsSold.Any())
                .Select(x => new UsersSoldProductsDto
                {
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    SoldProducts = x.ProductsSold.Select(p => new SoldProductsDto
                    {
                        Name = p.Name,
                        Price = p.Price
                    })
                    .ToArray()
                })
                .OrderBy(x => x.LastName)
                .ThenBy(x => x.FirstName)
                .Take(5)
                .ToArray();

            StringBuilder sb = new StringBuilder();
            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces(new []{ XmlQualifiedName.Empty });
            XmlSerializer serializer = new XmlSerializer(typeof(UsersSoldProductsDto[]), new XmlRootAttribute("Users"));
            serializer.Serialize(new StringWriter(sb), users, namespaces);

            return sb.ToString().TrimEnd();
        }

        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            var categories = context.Categories
                .Select(x => new CategoriesByProductsCountDto
                {
                    Name = x.Name,
                    Count = x.CategoryProducts.Count,
                    AveragePrice = x.CategoryProducts.Average(c => c.Product.Price),
                    TotalRevenue = x.CategoryProducts.Sum(c => c.Product.Price)
                })
                .OrderByDescending(x => x.Count)
                .ThenBy(x => x.TotalRevenue)
                .ToArray();

            StringBuilder sb = new StringBuilder();
            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces(new []{ XmlQualifiedName.Empty });
            XmlSerializer serializer = new XmlSerializer(typeof(CategoriesByProductsCountDto[]), new XmlRootAttribute("Categories"));
            serializer.Serialize(new StringWriter(sb), categories, namespaces);

            return sb.ToString().TrimEnd();
        }

        public static string GetUsersWithProducts(ProductShopContext context)
        {
            var users = new UsersDtoQuery4
            {
                Count = context.Users.Count(x => x.ProductsSold.Any()),
                Users = context.Users.Where(x => x.ProductsSold.Any()).Select(x => new UserDtoQuery4
                    {
                        FirstName = x.FirstName,
                        LastName = x.LastName,
                        Age = x.Age,
                        SoldProducts = new SoldProductDtoQuery4
                        {
                            Count = x.ProductsSold.Count(),
                            ProductDto = x.ProductsSold.Select(p => new ProductDtoQuery4
                                {
                                    Name = p.Name,
                                    Price = p.Price
                                })
                                .OrderByDescending(p => p.Price)
                                .ToArray()   
                        }
                    })
                    .OrderByDescending(x => x.SoldProducts.Count)
                    .Take(10)
                    .ToArray()
            };    
            
            StringBuilder sb = new StringBuilder();
            var xmlNamespaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });
            var serializer = new XmlSerializer(typeof(UsersDtoQuery4), new XmlRootAttribute("Users"));
            serializer.Serialize(new StringWriter(sb), users, xmlNamespaces);

            return sb.ToString().TrimEnd();
        }
    }
}