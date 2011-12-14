using System;
using System.Data;
using System.Data.Common;
using System.Xml;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;

using System.IO;


namespace Connects.Profiles.DataAccess
{
    public class NetworkBrowserDA
    {
        public XmlReaderScope GetProfileNetworkForBrowser(int profileId)
        {
            string spName = "usp_GetFlashNetwork_XML";
            //This is a good debug tool.  You will need to add a flag to your web.config to enable it. See method for flag name.
            XmlDataUtility.logit("- line 1: NetworkBrowserDA.GetProfileNetworkForBrowser(" + profileId.ToString() + ")");
            XmlReaderScope scope = null;
            
            try
            {

                SqlDatabase db = DatabaseFactory.CreateDatabase() as SqlDatabase;
            

                DbCommand dbCommand = db.GetStoredProcCommand(spName);
            

                db.AddInParameter(dbCommand, "personid1", DbType.Int32, profileId);
            
                XmlReader reader = db.ExecuteXmlReader(dbCommand);
            
                scope = new XmlReaderScope(dbCommand.Connection, reader);
            
            }
            catch (Exception ex)
            {

                //this is a good debug tool.
                //XmlDataUtility.logit("- GetProfileNetworkForBrowser MESSAGE==> " + ex.Message + " STACKTRACE==>" + ex.StackTrace + " SOURCE==>" + ex.Source);

                bool rethrow = ExceptionPolicy.HandleException(ex, "Log Only Policy");
                if (rethrow)
                    throw ex;
            }

            return scope;
        }

    }
}
