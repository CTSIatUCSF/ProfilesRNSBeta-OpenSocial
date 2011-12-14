using System;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using System.Collections;
using System.Collections.Generic;

namespace Connects.Profiles.Service.DataContracts
{
    [XmlInclude(typeof(VisibleType))]
    public class VisibleType
    {
        public string Visible;
    }
}
