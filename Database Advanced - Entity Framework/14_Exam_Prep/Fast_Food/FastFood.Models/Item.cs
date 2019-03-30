using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FastFood.Models
{
    public class Item
    {
        //•	Id – integer, Primary Key
        //•	Name – text with min length 3 and max length 30 (required, unique)
        //•	CategoryId – integer, foreign key
        //•	Category – the item’s category (required)
        //•	Price – decimal (non-negative, minimum value: 0.01, required)
        //•	OrderItems – collection of type OrderItem

        public Item()
        {
            this.OrderItems = new List<OrderItem>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(30, MinimumLength = 3)]
        public string Name { get; set; }

        [Required]
        public int CategoryId { get; set; }
        public Category Category { get; set; }

        [Required]
        [Range(typeof(decimal), "0.01", "79228162514264337593543950335")]
        public decimal Price { get; set; }

        public ICollection<OrderItem> OrderItems { get; set; }
    }
}
