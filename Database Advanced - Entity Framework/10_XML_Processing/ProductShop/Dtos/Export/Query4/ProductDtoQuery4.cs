using System.Xml.Serialization;

namespace ProductShop.Dtos.Export.Query4
{
    [XmlType("Product")]
    public class ProductDtoQuery4
    {
        [XmlElement("name")]
        public string Name { get; set; }

        [XmlElement("price")]
        public decimal Price { get; set; }
    }
}
