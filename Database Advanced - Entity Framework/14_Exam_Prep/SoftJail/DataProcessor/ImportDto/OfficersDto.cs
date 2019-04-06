using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Xml.Serialization;

namespace SoftJail.DataProcessor.ImportDto
{
    //<Officer>
        //<Name>Minerva Kitchingman</Name>
        //<Money>2582</Money>
        //<Position>Invalid</Position>
        //<Weapon>ChainRifle</Weapon>
        //<DepartmentId>2</DepartmentId>
        //<Prisoners>
            //<Prisoner id="15" />
        //</Prisoners>
    //</Officer>

    [XmlType("Officer")]
    public class OfficersDto
    {
        [Required]
        [StringLength(30, MinimumLength = 3)]
        public string Name { get; set; }

        [Required]
        [Range(typeof(decimal), "0", "79228162514264337593543950335")]
        public decimal Money { get; set; }

        [Required]
        public string Position{ get; set; }

        [Required]
        public string Weapon { get; set; }

        [Required]
        public int DepartmentId { get; set; }

        [XmlArray("Prisoners")]
        public PrisonerIdDto[] Prisoners { get; set; }
    }

    [XmlType("Prisoner")]
    public class PrisonerIdDto
    {
        [XmlAttribute("id")]
        public int Id { get; set; }
    }
}
