using System.Xml.Serialization;

namespace ProductShop.Dtos.Export
{
    //<User>
        //<firstName>Almire</firstName>
        //<lastName>Ainslee</lastName>
        //<soldProducts>
            //<Product>
                //<name>olio activ mouthwash</name>
                //<price>206.06</price>
            //</Product>
    //</User>

    [XmlType("User")]
    public class UsersSoldProductsDto
    {
        [XmlElement("firstName")]
        public string FirstName { get; set; }

        [XmlElement("lastName")]
        public string LastName { get; set; }

        [XmlArray("soldProducts")]
        public SoldProductsDto[] SoldProducts { get; set; }
    }

    [XmlType("Product")]
    public class SoldProductsDto
    {
        [XmlElement("name")]
        public string Name { get; set; }

        [XmlElement("price")]
        public decimal Price { get; set; }
    }
}
