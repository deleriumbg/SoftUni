using System.ComponentModel.DataAnnotations;

namespace ProductShop.Models
{
    using System.Collections.Generic;

    public class Category
    {
        public Category()
        {
            this.CategoryProducts = new List<CategoryProduct>();
        }

        public int Id { get; set; }

        [Required(AllowEmptyStrings=false)]
        [DisplayFormat(ConvertEmptyStringToNull=false)]
        [MinLength(3), MaxLength(15)]
        public string Name { get; set; }

        public ICollection<CategoryProduct> CategoryProducts { get; set; }
    }
}
