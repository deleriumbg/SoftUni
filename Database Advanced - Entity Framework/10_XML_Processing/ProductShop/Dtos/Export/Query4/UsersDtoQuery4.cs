using System.Xml.Serialization;

namespace ProductShop.Dtos.Export.Query4
{
    [XmlRoot("users")]
    public class UsersDtoQuery4
    {
        [XmlElement("count")]
        public int Count { get; set; }

        [XmlArray("users")]
        public UserDtoQuery4[] Users { get; set; }
    }
}
