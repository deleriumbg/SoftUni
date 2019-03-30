using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FastFood.Models
{
    public class Category
    {
        //•	Id – integer, Primary Key
        //•	Name – text with min length 3 and max length 30 (required)
        //•	Items – collection of type Item

        public Category()
        {
            this.Items = new List<Item>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(30, MinimumLength = 3)]
        public string Name { get; set; }

        public ICollection<Item> Items { get; set; }
    }
}
