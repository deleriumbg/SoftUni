using System.Xml.Serialization;

namespace ProductShop.App.DTO.Export
{
    [XmlType("user")]
    public class UserDtoExport
    {
        [XmlAttribute("first-name")]
        public string FirstName { get; set; }

        [XmlAttribute("last-name")]
        public string LastName { get; set; }

        [XmlArray("sold-products")]
        public SoldProductDto[] SoldProducts { get; set; }
    }
}
