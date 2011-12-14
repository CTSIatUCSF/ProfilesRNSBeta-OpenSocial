using System.Xml.Serialization;
using System.Runtime.Serialization;
using System.Collections.Generic;

namespace Connects.Profiles.Service.DataContracts
{
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute()]
    [DataContract(Name = "PublicationMatchSummary")]
    public partial class PublicationMatchSummary : PublicationMatchDetailList
    {
        private PublicationList publicationListField;

        [DataMember(IsRequired = false, Name = "PublicationList", Order = 1)]
        public PublicationList PublicationList
        {
            get
            {
                return this.publicationListField;
            }
            set
            {
                this.publicationListField = value;
            }
        }

    }
}
