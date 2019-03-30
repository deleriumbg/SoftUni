using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PetClinic.Models
{
    public class Animal
    {
        //-	Id – integer, Primary Key
        //-	Name – text with min length 3 and max length 20 (required)
        //-	Type – text with min length 3 and max length 20 (required)
        //-	Age – integer, cannot be negative or 0 (required)
        //-	PassportSerialNumber ¬– string, foreign key
        //-	Passport – the passport of the animal (required)
        //-	Procedures – the procedures, performed on the animal

        public Animal()
        {
            this.Procedures = new List<Procedure>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 3)]
        public string Name { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 3)]
        public string Type { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int Age { get; set; }

        [Required]
        public string PassportSerialNumber { get; set; }
        public Passport Passport { get; set; }

        public ICollection<Procedure> Procedures { get; set; }
    }
}
