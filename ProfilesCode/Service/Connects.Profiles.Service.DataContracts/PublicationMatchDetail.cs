using System.Xml.Serialization;
using System.Runtime.Serialization;
using System.Collections.Generic;

namespace Connects.Profiles.Service.DataContracts
{
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute()]
    [DataContract(Name = "PublicationMatchDetail")]
    public partial class PublicationMatchDetail
    {
        private PublicationPhraseDetailList phraseMeasurementsListField;
        private string searchPhraseField;

        [DataMember(IsRequired = false, Name = "PublicationPhraseDetailList", Order = 1)]
        public PublicationPhraseDetailList PublicationPhraseDetailList
        {
            get
            {
                return this.phraseMeasurementsListField;
            }
            set
            {
                this.phraseMeasurementsListField = value;
            }
        }

        [System.Xml.Serialization.XmlAttributeAttribute()]
        [DataMember(IsRequired = false, Name = "SearchPhrase", Order = 2, EmitDefaultValue = false)]
        public string SearchPhrase
        {
            get
            {
                return this.searchPhraseField;
            }
            set
            {
                this.searchPhraseField = value;
            }
        }

    }


    [System.Xml.Serialization.XmlTypeAttribute()]
    [CollectionDataContract(Name = "PublicationMatchDetailList")]
    public class PublicationMatchDetailList : List<PublicationMatchDetail>
    {
    }

}
