using System;
using System.ComponentModel.DataAnnotations;

namespace PetClinic.DataProcessor.DTO.Import
{
    //{
    //    "Name":"Bella",
    //    "Type":"cat",
    //    "Age": 2,
    //    "Passport": {
    //      "SerialNumber": "etyhGgH678",
    //      "OwnerName": "Sheldon Cooper",
    //      "OwnerPhoneNumber": "0897556446",
    //      "RegistrationDate": "12-03-2014"
    //}

    public class AnimalsDto
    {
        [Required]
        [StringLength(20, MinimumLength = 3)]
        public string Name { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 3)]
        public string Type { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int Age { get; set; }

        public PassportDto Passport { get; set; }
    }

    public class PassportDto
    {
        [RegularExpression("^[A-Za-z]{7}[0-9]{3}$")]
        public string SerialNumber { get; set; }

        [Required]
        [StringLength(30, MinimumLength = 3)]
        public string OwnerName { get; set; }

        [RegularExpression("^0[0-9]{9}$|^\\+359[0-9]{9}$")]
        public string OwnerPhoneNumber { get; set; }

        [Required]
        public string RegistrationDate { get; set; }
    }
}
