using System.Xml.Serialization;

namespace ProductShop.Dtos.Export.Query4
{
    [XmlType("SoldProducts")]
    public class SoldProductDtoQuery4
    {
        [XmlElement("count")] 
        public int Count { get; set; }

        [XmlArray("products")] 
        public ProductDtoQuery4[] ProductDto { get; set; }
    }
}
