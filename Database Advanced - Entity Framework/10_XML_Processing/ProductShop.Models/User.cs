using System;
using System.Collections;
using System.Collections.Generic;

namespace ProductShop.Models
{
    public class User
    {
        //•	Users have an id, first name (optional) and last name (at least 3 characters) and age (optional).
        public User()
        {
            this.ProductsBought = new List<Product>();
            this.ProductsSold = new List<Product>();
        }

        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int? Age { get; set; }

        public ICollection<Product> ProductsBought { get; set; }

        public ICollection<Product> ProductsSold { get; set; }
    }
}
