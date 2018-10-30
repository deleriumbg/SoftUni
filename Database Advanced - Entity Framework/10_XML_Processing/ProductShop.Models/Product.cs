using System.Collections.Generic;

namespace ProductShop.Models
{
    public class Product
    {
        //•	Products have an id, name (at least 3 characters), price, buyerId (optional) and sellerId as IDs of users.
        public Product()
        {
            this.CategoryProducts = new List<CategoryProduct>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public int? BuyerId { get; set; }
        public User Buyer { get; set; }

        public int? SellerId { get; set; }
        public User Seller { get; set; }

        public ICollection<CategoryProduct> CategoryProducts { get; set; }
    }
}
