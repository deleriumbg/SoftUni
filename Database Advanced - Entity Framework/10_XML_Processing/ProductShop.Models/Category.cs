using System.Collections.Generic;

namespace ProductShop.Models
{
    public class Category
    {
        //•	Categories have an id and name (from 3 to 15 characters)
        public Category()
        {
            this.CategoryProducts = new List<CategoryProduct>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<CategoryProduct> CategoryProducts { get; set; }
    }
}
