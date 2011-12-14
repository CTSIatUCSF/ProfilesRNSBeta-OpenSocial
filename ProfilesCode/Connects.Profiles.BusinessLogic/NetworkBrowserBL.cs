using System;
using System.Data;
using Connects.Profiles.DataAccess;
using Connects.Profiles.Utility;
using Microsoft.Practices.EnterpriseLibrary.Caching;
using Microsoft.Practices.EnterpriseLibrary.Caching.Expirations;

namespace Connects.Profiles.BusinessLogic
{
    public partial class NetworkBrowserBL : BaseBL 
    {
        public XmlReaderScope GetProfileNetworkForBrowser(int profileId)
        {
            try
            {
                return new NetworkBrowserDA().GetProfileNetworkForBrowser(profileId);
            }
            catch (Exception ex) { throw ex; }
        }
    }
}
