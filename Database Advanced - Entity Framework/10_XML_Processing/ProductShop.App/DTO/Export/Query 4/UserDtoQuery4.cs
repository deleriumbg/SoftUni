using System.Xml.Serialization;

namespace ProductShop.App.DTO.Export
{
    [XmlType("user")]
    public class UserDtoQuery4
    {
        [XmlAttribute("first-name")]
        public string FirstName { get; set; }

        [XmlAttribute("last-name")]
        public string LastName { get; set; }

        [XmlAttribute("age")]
        public string Age { get; set; }

        [XmlElement("sold-products")]
        public SoldProductDtoQuery4 SoldProduct { get; set; }
    }
}
