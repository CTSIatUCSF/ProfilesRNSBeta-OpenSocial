using System.Xml.Serialization;
using System.Runtime.Serialization;
using System.Collections.Generic;

namespace Connects.Profiles.Service.DataContracts
{
    [System.Xml.Serialization.XmlTypeAttribute()]
    [CollectionDataContract(Name = "PublicationList")]
    public class PublicationList : List<Publication>
    {
    }
}
