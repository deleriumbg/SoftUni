using System.Xml.Serialization;

namespace ProductShop.Dtos.Export.Query4
{
    [XmlType("User")]
    public class UserDtoQuery4
    {
        [XmlElement("firstName")]
        public string FirstName { get; set; }

        [XmlElement("lastName")]
        public string LastName { get; set; }

        [XmlElement("age")]
        public int? Age { get; set; }

        public SoldProductDtoQuery4 SoldProducts { get; set; }
    }
}
