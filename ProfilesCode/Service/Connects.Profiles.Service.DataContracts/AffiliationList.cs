﻿using System;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using System.Collections;
using System.Collections.Generic;

namespace Connects.Profiles.Service.DataContracts
{
    [System.Xml.Serialization.XmlTypeAttribute()]
    [System.SerializableAttribute()]
    public class AffiliationList
    {
        private List<Affiliation> affiliationField;

        [System.Xml.Serialization.XmlElementAttribute("Affiliation")]
        public List<Affiliation> Affiliation
        {
            get
            {
                return this.affiliationField;
            }
            set
            {
                this.affiliationField = value;
            }
        }


    }
}
