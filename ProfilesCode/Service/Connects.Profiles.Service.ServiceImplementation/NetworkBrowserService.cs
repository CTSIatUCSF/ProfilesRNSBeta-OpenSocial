using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.ServiceModel.Activation;
using Connects.Profiles.Service.DataContracts;
using Connects.Profiles.Service.ServiceContracts;
using Connects.Profiles.Utility;

using System.IO;

namespace Connects.Profiles.Service.ServiceImplementation
{
    [KnownType(typeof(Connects.Profiles.Service.DataContracts.LocalNetwork))]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
    public class NetworkBrowserService : INetworkBrowserService
    {
        #region INetworkBrowserService Members

        public LocalNetwork GetProfileNetworkForBrowser(string profileId)
        {
            try
            {
                return new NetworkBrowserServiceAdapter().GetProfileNetworkForBrowser(Convert.ToInt32(profileId));
            }
            catch (Exception ex) { // XmlUtilities.logit("message==>" + ex.Message + " stacktrace==>" + ex.StackTrace +  " source==" + ex.Source + " INNER: stack trace==> " + ex.InnerException.StackTrace + " message==>" + ex.InnerException.Message);
                throw ex; }
        }



        #endregion
    }
}
