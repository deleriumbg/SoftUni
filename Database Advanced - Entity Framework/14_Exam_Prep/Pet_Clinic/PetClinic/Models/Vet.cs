using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PetClinic.Models
{
    public class Vet
    {
        //-	Id – integer, Primary Key
        //-	Name – text with min length 3 and max length 40 (required)
        //-	Profession – text with min length 3 and max length 50 (required)
        //-	Age – integer number, minimum value of 22 years and maximum 65 (required)
        //-	PhoneNumber – required, unique, make sure it matches one of the following requirements:
        //«	either starts with +359 and is followed by 9 digits
        //«	or consists of exactly 10 digits, starting with 0
        //-	Procedures – the procedures, performed by the vet

        public Vet()
        {
            this.Procedures = new List<Procedure>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(40, MinimumLength = 3)]
        public string Name { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Profession { get; set; }

        [Required]
        [Range(22, 65)]
        public int Age { get; set; }

        [RegularExpression("^0[0-9]{9}$|^\\+359[0-9]{9}$")]
        public string PhoneNumber { get; set; }

        public ICollection<Procedure> Procedures { get; set; }
    }
}
