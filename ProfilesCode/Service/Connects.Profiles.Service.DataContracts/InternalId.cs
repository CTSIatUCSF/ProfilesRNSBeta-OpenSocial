using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Connects.Profiles.Service.DataContracts
{
    [DataContract(Name = "InternalID")]
    public partial class InternalID
    {

        private string nameField;
        private string textField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute("Name")]
        [DataMember(IsRequired = false, Name = "Name", Order = 1)]
        public string Name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }

        [System.Xml.Serialization.XmlTextAttribute()]
        [DataMember(IsRequired = false, Name = "Text")]
        public string Text
        {
            get
            {
                return this.textField;
            }
            set
            {
                this.textField = value;
            }
        }
    }

    [System.Xml.Serialization.XmlTypeAttribute()]
    [DataContract(Name = "InternalIDList")]
    public partial class InternalIDList
    {

        private List<InternalID> internalIdField;

        [System.Xml.Serialization.XmlElementAttribute("InternalID")]
        [DataMember(IsRequired = false, Name = "InternalID", Order = 1)]
        public List<InternalID> InternalID
        {
            get
            {
                return this.internalIdField;
            }
            set
            {
                this.internalIdField = value;
            }
        }
    }
}
