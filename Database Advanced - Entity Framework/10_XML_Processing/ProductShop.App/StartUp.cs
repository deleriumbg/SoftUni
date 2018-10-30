using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using AutoMapper;
using ProductShop.App.DTO;
using ProductShop.App.DTO.Export;
using ProductShop.Data;
using ProductShop.Models;
using DataAnnotations = System.ComponentModel.DataAnnotations;

namespace ProductShop.App
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var config = new MapperConfiguration(cfg => cfg.AddProfile<ProductShopProfile>());
            var mapper = config.CreateMapper();

            //Import Data
            ImportUsersFromXml(mapper);
            ImportProductsFromXml(mapper);
            ImportCategoriesFromXml(mapper);
            GenerateCategoriesForTheProducts();

            //Query and Export Data
            //Query 1. Products In Range
            GenerateXmlProductsInRange();

            //Query 2. Sold Products
            GenerateXmlSoldProducts();

            //Query 3. Categories By Products Count
            GenerateXmlCategoriesByProductsCount();

            //Query 4. Users and Products
            GenerateXmlUsersAndProducts();
        }

        private static void GenerateXmlUsersAndProducts()
        {
            var context = new ProductShopContext();

            var users = new UsersDtoQuery4
            {
                Count = context.Users.Count(),
                Users = context.Users.Where(x => x.ProductsSold.Count > 0).Select(x => new UserDtoQuery4
                {
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Age = x.Age.ToString(),
                    SoldProduct = new SoldProductDtoQuery4
                    {
                        Count = x.ProductsSold.Count(),
                        ProductDto = x.ProductsSold.Select(p => new ProductDtoQuery4
                        {
                            Name = p.Name,
                            Price = p.Price
                        })
                        .ToArray()   
                    }
                })
                .ToArray()
            };    

            StringBuilder sb = new StringBuilder();
            var xmlNamespaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });
            var serializer = new XmlSerializer(typeof(UsersDtoQuery4), new XmlRootAttribute("users"));
            serializer.Serialize(new StringWriter(sb), users, xmlNamespaces);

            File.WriteAllText("XML/Export/users-and-products.xml", sb.ToString());
        }

        private static void GenerateXmlCategoriesByProductsCount()
        {
            var context = new ProductShopContext();

            var categories = context.Categories
                .OrderByDescending(x => x.CategoryProducts.Count)
                .Select(x => new CategoryDtoExport
                {
                    Name = x.Name,
                    Count = x.CategoryProducts.Count,
                    AveragePrice = x.CategoryProducts.Average(c => c.Product.Price),
                    TotalRevenue = x.CategoryProducts.Sum(c => c.Product.Price)
                })
                .ToArray();
                

            StringBuilder sb = new StringBuilder();
            var xmlNamespaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });
            var serializer = new XmlSerializer(typeof(CategoryDtoExport[]), new XmlRootAttribute("categories"));
            serializer.Serialize(new StringWriter(sb), categories, xmlNamespaces);

            File.WriteAllText("XML/Export/categories-by-products.xml", sb.ToString());
        }

        private static void GenerateXmlSoldProducts()
        {
            var context = new ProductShopContext();

            var users = context.Users
                .Where(x => x.ProductsSold.Count > 0)
                .Select(x => new UserDtoExport
                {
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    SoldProducts = x.ProductsSold.Select(s => new SoldProductDto()
                    {
                        Name = s.Name,
                        Price = s.Price
                    })
                    .ToArray()
                })
                .OrderBy(x => x.LastName)
                .ThenBy(x => x.FirstName)
                .ToArray();

            StringBuilder sb = new StringBuilder();
            var xmlNamespaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });
            var serializer = new XmlSerializer(typeof(UserDtoExport[]), new XmlRootAttribute("users"));
            serializer.Serialize(new StringWriter(sb), users, xmlNamespaces);

            File.WriteAllText("XML/Export/users-sold-products.xml", sb.ToString());
        }

        private static void GenerateXmlProductsInRange()
        {
            var context = new ProductShopContext();

            var products = context.Products
                .Where(x => x.Price >= 1000 && x.Price <= 2000 && x.Buyer != null)
                .OrderByDescending(x => x.Price)
                .Select(x => new ProductDtoExport
                {
                    Name = x.Name,
                    Price = x.Price,
                    Buyer = $"{x.Buyer.FirstName} {x.Buyer.LastName}" ?? x.Buyer.LastName
                })
                .ToArray();

            StringBuilder sb = new StringBuilder();
            var xmlNamespaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });
            var serializer = new XmlSerializer(typeof(ProductDtoExport[]), new XmlRootAttribute("products"));
            serializer.Serialize(new StringWriter(sb), products, xmlNamespaces);

            File.WriteAllText("XML/Export/products-in-range.xml", sb.ToString());
        }

        private static void GenerateCategoriesForTheProducts()
        {
            var categoryProducts = new List<CategoryProduct>();

            for (int productId = 1; productId <= 200; productId++)
            {
                var categoryId = new Random().Next(1,12);

                var categoryProduct = new CategoryProduct()
                {
                    ProductId = productId,
                    CategoryId = categoryId
                };
                categoryProducts.Add(categoryProduct);
            }
            var context = new ProductShopContext();
            context.CategoryProducts.AddRange(categoryProducts);
            context.SaveChanges();
        }

        private static void ImportCategoriesFromXml(IMapper mapper)
        {
            var xmlString = File.ReadAllText("XML/Import/categories.xml");
            var serializer = new XmlSerializer(typeof(CategoryDto[]), new XmlRootAttribute("categories"));
            var deserializedCategories = (CategoryDto[])serializer.Deserialize(new StringReader(xmlString));

            var categories = new List<Category>();
            foreach (var categoryDto in deserializedCategories)
            {
                if (!IsValid(categoryDto))
                {
                    continue;
                }
                var category = mapper.Map<Category>(categoryDto);
                categories.Add(category);
            }

            var context = new ProductShopContext();
            context.Categories.AddRange(categories);
            context.SaveChanges();
        }

        private static void ImportProductsFromXml(IMapper mapper)
        {
            var xmlString = File.ReadAllText("XML/Import/products.xml");
            var serializer = new XmlSerializer(typeof(ProductDto[]), new XmlRootAttribute("products"));
            var deserializedProduct = (ProductDto[])serializer.Deserialize(new StringReader(xmlString));

            var products = new List<Product>();
            int productCounter = 1;
            foreach (var productDto in deserializedProduct)
            {
                if (!IsValid(productDto))
                {
                    continue;
                }

                var product = mapper.Map<Product>(productDto);

                var buyerId = new Random().Next(1, 30);
                var sellerId = new Random().Next(31, 56);

                product.BuyerId = buyerId;
                product.SellerId = sellerId;

                if (productCounter == 4)
                {
                    product.BuyerId = null;
                    productCounter = 1;
                }

                products.Add(product);
                productCounter++;
            }

            var context = new ProductShopContext();
            context.Products.AddRange(products);
            context.SaveChanges();
        }

        private static void ImportUsersFromXml(IMapper mapper)
        {
            var xmlString = File.ReadAllText("XML/Import/users.xml");
            var serializer = new XmlSerializer(typeof(UserDto[]), new XmlRootAttribute("users"));
            var deserializedUsers = (UserDto[])serializer.Deserialize(new StringReader(xmlString));

            var users = new List<User>();
            foreach (var userDto in deserializedUsers)
            {
                if (!IsValid(userDto))
                {
                    continue;
                }
                var user = mapper.Map<User>(userDto);
                users.Add(user);
            }

            var context = new ProductShopContext();
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
