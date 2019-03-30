using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PetClinic.Models
{
    public class Passport
    {
        //-	SerialNumber – a string consisting of exactly 10 characters, starting with 7 letters and ending with 3 digits, Primary Key
        //-	Animal – the animal to which the passport is registered (required)
        //-	OwnerPhoneNumber – the phone number of the animal’s owner, required, make sure it matches one of the following requirements:
        //«	either starts with +359 and is followed by 9 digits
        //«	or consists of exactly 10 digits, starting with 0
        //-	OwnerName – the name of the animal’s owner; text with min length 3 and max length 30 (required)
        //-	RegistrationDate – the date and time on which the passport was registered (required)

        [Key]
        [RegularExpression("^[A-Za-z]{7}[0-9]{3}$")]
        public string SerialNumber { get; set; }

        [Required]
        public Animal Animal { get; set; }

        [RegularExpression("^0[0-9]{9}$|^\\+359[0-9]{9}$")]
        public string OwnerPhoneNumber { get; set; }

        [Required]
        [StringLength(30, MinimumLength = 3)]
        public string OwnerName { get; set; }

        [Required]
        public DateTime RegistrationDate { get; set; }
    }
}
