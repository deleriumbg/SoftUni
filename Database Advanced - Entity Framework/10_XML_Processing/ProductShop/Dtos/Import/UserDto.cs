using System.Xml.Serialization;

namespace ProductShop.Dtos.Import
{
    //<User>
        //<firstName>Chrissy</firstName>
        //<lastName>Falconbridge</lastName>
        //<age>50</age>
    //</User>

    [XmlType("User")]
    public class UserDto
    {
        [XmlElement("firstName")]
        public string FirstName { get; set; }

        [XmlElement("lastName")]
        public string LastName { get; set; }

        [XmlElement("age")]
        public int? Age { get; set; }
    }
}
