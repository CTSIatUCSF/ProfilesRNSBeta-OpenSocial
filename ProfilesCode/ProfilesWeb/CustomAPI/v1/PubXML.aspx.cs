using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.Common;
using Connects.Profiles.Common;
using Connects.Profiles.Service.DataContracts;
using Connects.Profiles.Utility;
using Connects.Profiles.BusinessLogic;
using Microsoft.Practices.EnterpriseLibrary.Data;

public partial class PubXML : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            string PMID = Request["PMID"];

            if (PMID != null && PMID.Length > 0)
            {
                ProcessPMID(PMID);
            }
        }
        catch (Exception ex)
        {
            Response.Write("ERROR" + Environment.NewLine + ex.Message + Environment.NewLine);
        }
    }

    private void ProcessPMID(string PMID)
    {
        string sql = "select cast(x as varchar(max)) from pm_all_xml where pmid = '" + PMID + "';";
        Database db = DatabaseFactory.CreateDatabase();
        DbCommand dbCommand = db.GetSqlStringCommand(sql);
        Response.ContentType = "text/xml";
        Response.Write((string)db.ExecuteScalar(dbCommand));
    }
}
