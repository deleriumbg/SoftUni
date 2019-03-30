using System.Xml.Serialization;

namespace FastFood.DataProcessor.Dto.Export
{
    [XmlType("Category")]
    public class CategoryDto
    {
        public string Name { get; set; }

        public MostPopularItemDto MostPopularItem { get; set; }
    }
}
