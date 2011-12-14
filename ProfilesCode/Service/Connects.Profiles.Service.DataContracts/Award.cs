﻿using System.Xml.Serialization;
using System.Runtime.Serialization;
using System.Collections.Generic;

namespace Connects.Profiles.Service.DataContracts
{
    [System.Xml.Serialization.XmlTypeAttribute()]
    [DataContract(Name = "Award")]
    public partial class Award
    {

        private string awardIDField;

        private string awardStartYearField;

        private string awardEndYearField;

        private string awardNameField;

        private string awardInstitutionField;

        [DataMember(IsRequired = false, Name = "AwardID", Order = 1)]
        public string AwardID
        {
            get
            {
                return this.awardIDField;
            }
            set
            {
                this.awardIDField = value;
            }
        }

        [DataMember(IsRequired = false, Name = "AwardStartYear", Order = 2)]
        public string AwardStartYear
        {
            get
            {
                return this.awardStartYearField;
            }
            set
            {
                this.awardStartYearField = value;
            }
        }

        [DataMember(IsRequired = false, Name = "AwardEndYear", Order = 3)]
        public string AwardEndYear
        {
            get
            {
                return this.awardEndYearField;
            }
            set
            {
                this.awardEndYearField = value;
            }
        }

        [DataMember(IsRequired = false, Name = "AwardName", Order = 4)]
        public string AwardName
        {
            get
            {
                return this.awardNameField;
            }
            set
            {
                this.awardNameField = value;
            }
        }

        [DataMember(IsRequired = false, Name = "AwardInstitution_Fullname", Order = 5)]
        public string AwardInstitution_Fullname
        {
            get
            {
                return this.awardInstitutionField;
            }
            set
            {
                this.awardInstitutionField = value;
            }
        }
    }

}
