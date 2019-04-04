using System.Xml.Serialization;

namespace ProductShop.Dtos.Import
{
    //<CategoryProduct>
        //<CategoryId>4</CategoryId>
        //<ProductId>1</ProductId>
    //</CategoryProduct>

    [XmlType("CategoryProduct")]
    public class CategoryProductDto
    {
        public int CategoryId { get; set; }

        public int ProductId { get; set; }
    }
}
