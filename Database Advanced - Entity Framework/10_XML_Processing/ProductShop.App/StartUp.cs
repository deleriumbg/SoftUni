using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using AutoMapper;
using ProductShop.App.DTO;
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

            ImportUsersFromXml(mapper);
            ImportProductsFromXml(mapper);
            ImportCategoriesFromXml(mapper);
            GenerateCategoriesForTheProducts();
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
            var xmlString = File.ReadAllText("XML/categories.xml");
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
            var xmlString = File.ReadAllText("XML/products.xml");
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
            var xmlString = File.ReadAllText("XML/users.xml");
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
