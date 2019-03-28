﻿using System.ComponentModel.DataAnnotations;

namespace ProductShop.Models
{
    using System.Collections.Generic;

    public class Product
    {
        public Product()
        {
            this.CategoryProducts = new List<CategoryProduct>();
        }

        public int Id { get; set; }

        [MinLength(3)]
        public string Name { get; set; }

        [Range(typeof(decimal), "0.0", "79228162514264337593543950335")]
        public decimal Price { get; set; }

        public int SellerId { get; set; }
        public User Seller { get; set; }

        public int? BuyerId { get; set; }
        public User Buyer { get; set; }

        public ICollection<CategoryProduct> CategoryProducts { get; set; }
    }
}