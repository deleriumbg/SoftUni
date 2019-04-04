using System.Xml.Serialization;

namespace ProductShop.Dtos.Export
{
    //<Product>
        //<name>Parsley</name>
        //<price>519.06</price>
        //<buyer>Brendin Predohl</buyer>
    //</Product>

    [XmlType("Product")]
    public class ProductsInRangeDto
    {
        [XmlElement("name")]
        public string Name { get; set; }

        [XmlElement("price")]
        public decimal Price { get; set; }

        [XmlElement("buyer")]
        public string Buyer { get; set; }
    }
}
