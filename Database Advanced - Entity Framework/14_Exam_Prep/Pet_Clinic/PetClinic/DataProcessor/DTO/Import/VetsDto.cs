using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace PetClinic.DataProcessor.DTO.Import
{
    //<Vet>
        //<Name>Michael Jordan</Name>
        //<Profession>Emergency and Critical Care</Profession>
        //<Age>45</Age>
        //<PhoneNumber>0897665544</PhoneNumber>
    //</Vet>

    [XmlType("Vet")]
    public class VetsDto
    {
        [Required]
        [StringLength(40, MinimumLength = 3)]
        public string Name { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Profession { get; set; }

        [Required]
        [Range(22, 65)]
        public int Age { get; set; }

        [Required]
        [RegularExpression("^0[0-9]{9}$|^\\+359[0-9]{9}$")]
        public string PhoneNumber { get; set; }
    }
}
