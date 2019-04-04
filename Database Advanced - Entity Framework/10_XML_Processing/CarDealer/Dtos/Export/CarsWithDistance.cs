using System.Xml.Serialization;

namespace CarDealer.Dtos.Export
{
    //<car>
        //<make>BMW</make>
        //<model>1M Coupe</model>
        //<travelled-distance>39826890</travelled-distance>
    //</car>

    [XmlType("car")]
    public class CarsWithDistance
    {
        [XmlElement("make")]
        public string Make { get; set; }

        [XmlElement("model")]
        public string Model { get; set; }

        [XmlElement("travelled-distance")]
        public long TravelledDistance { get; set; }
    }
}
