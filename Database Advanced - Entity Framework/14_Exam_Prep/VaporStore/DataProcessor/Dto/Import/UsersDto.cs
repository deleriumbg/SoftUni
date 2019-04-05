using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace VaporStore.DataProcessor.Dto.Import
{
    //    "FullName": "Lorrie Silbert",
    //    "Username": "lsilbert",
    //    "Email": "lsilbert@yahoo.com",
    //    "Age": 33,
    //    "Cards": [
    //{
    //    "Number": "1833 5024 0553 6211",
    //    "CVC": "903",
    //    "Type": "Debit"
    //},
    //{
    //"Number": "5625 0434 5999 6254",
    //"CVC": "570",
    //"Type": "Credit"
    //},
    //{
    //"Number": "4902 6975 5076 5316",
    //"CVC": "091",
    //"Type": "Debit"
    //}
    //]

    public class UsersDto
    {
        [Required]
        [RegularExpression("^[A-Z][a-z]+ [A-Z][a-z]+$")]

        public string FullName { get; set; }
        [Required]
        [StringLength(20), MinLength(3)]
        public string Username { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        [Range(3, 103)]
        public int Age { get; set; }

        public List<CardsDto> Cards { get; set; }
    }

    public class CardsDto
    {
        [Required]
        [RegularExpression("^[0-9]{4} [0-9]{4} [0-9]{4} [0-9]{4}$")]
        public string Number { get; set; }

        [Required]
        [RegularExpression("^[0-9]{3}$")]
        public string CVC { get; set; }

        [Required]
        public string Type { get; set; }
    }
}
