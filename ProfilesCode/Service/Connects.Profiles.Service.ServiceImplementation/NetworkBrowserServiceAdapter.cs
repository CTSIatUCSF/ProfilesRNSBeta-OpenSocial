using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Activation;
using Connects.Profiles.BusinessLogic;
using Connects.Profiles.DataAccess;
using Connects.Profiles.Service.DataContracts;
using Connects.Profiles.Utility;

using System.IO;



namespace Connects.Profiles.Service.ServiceImplementation
{
    public class NetworkBrowserServiceAdapter
    {
        public LocalNetwork GetProfileNetworkForBrowser(int profileId)
        {
            //Debug logging
           XmlUtilities.logit("Line1: profileid:" + profileId);

            NetworkBrowserBL nb = new NetworkBrowserBL();
        

            try
            {
                using (XmlReaderScope scope = nb.GetProfileNetworkForBrowser(profileId))
                {
                
                    Type type = typeof(LocalNetwork);
                
                    string responseXML;

                    scope.Reader.Read();
                
                    responseXML = scope.Reader.ReadOuterXml();
                

                    LocalNetwork ln = XmlUtilities.DeserializeObject(responseXML, type) as LocalNetwork;

                    return ln;
                }
            }
            catch (Exception ex)
            {
                 XmlUtilities.logit("ERROR: " + ex.Message + " " + ex.StackTrace + " ,,,, INNER EXCEPTION: " + ex.InnerException.Message + ex.InnerException.StackTrace);
                throw ex;
            }


        }

    }

}
