using System.Xml.Serialization;

namespace ProductShop.App.DTO.Export
{
    [XmlRoot("users")]
    public class UsersDtoQuery4
    {
        [XmlAttribute("count")]
        public int Count { get; set; }

        [XmlElement("user")]
        public UserDtoQuery4[] Users { get; set; }
    }
}
