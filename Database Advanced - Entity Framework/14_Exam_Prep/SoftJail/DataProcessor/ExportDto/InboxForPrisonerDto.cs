using System.Xml.Serialization;

namespace SoftJail.DataProcessor.ExportDto
{
    //<Prisoner>
        //<Id>3</Id>
        //<Name>Binni Cornhill</Name>
        //<IncarcerationDate>1967-04-29</IncarcerationDate>
        //<EncryptedMessages>
            //<Message>
                //<Description>!?sdnasuoht evif-ytnewt rof deksa uoy ro orez artxe na ereht sI</Description>
            //</Message>
        //</EncryptedMessages>
    //</Prisoner>

    [XmlType("Prisoner")]
    public class InboxForPrisonerDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string IncarcerationDate { get; set; }

        [XmlArray("EncryptedMessages")]
        public MessagesDto[] EncryptedMessages { get; set; }
    }

    [XmlType("Message")]
    public class MessagesDto
    {
        public string Description { get; set; }
    }
}
