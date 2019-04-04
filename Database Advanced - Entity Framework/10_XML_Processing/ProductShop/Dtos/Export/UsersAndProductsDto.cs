using System.Xml.Serialization;

namespace ProductShop.Dtos.Export
{
    //<Users>
        //<count>54</count>
        //<users>
            //<User>
            //<firstName>Cathee</firstName>
            //<lastName>Rallings</lastName>
            //<age>33</age>
            //<SoldProducts>
                //<count>9</count>
                //<products>
                    //<Product>
                        //<name>Fair Foundation SPF 15</name>
                        //<price>1394.24</price>
                    //</Product>
    //...
    //</Users>

    public class UsersAndProductsDto
    {
        [XmlElement("count")]
        public int Count { get; set; }


        [XmlArray("users")]
        public UserDto[] Users { get; set; }
    }

    [XmlType("User")]
    public class UserDto
    {
        [XmlElement("firstName")]
        public string FirstName { get; set; }

        [XmlElement("lastName")]
        public string LastName { get; set; }

        [XmlElement("age")]
        public int Age { get; set; }

        public SoldProductDto[] SoldProducts { get; set; }
    }


    [XmlType("SoldProducts")]
    public class SoldProductDto
    {
        [XmlElement("count")]
        public int Count { get; set; }

        [XmlArray("products")]
        public SoldProductsDto[] Products { get; set; }
    }
}
