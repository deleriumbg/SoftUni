namespace SoftUniBabies.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Baby
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Gender{ get; set; }

        public DateTime Birthday { get; set; }
    }
}
