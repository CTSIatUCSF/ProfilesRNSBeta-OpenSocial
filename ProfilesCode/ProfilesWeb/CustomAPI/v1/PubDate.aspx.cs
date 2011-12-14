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

public partial class PubDate : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            string PMID = Request["PMID"];
            string MPID = Request["MPID"];

            if (PMID != null && PMID.Length > 0)
            {
                ProcessPMID(PMID);
            }
            else if (MPID != null && MPID.Length > 0)
            {
                ProcessMPID(MPID);
            }
        }
        catch (Exception ex)
        {
            Response.Write("ERROR" + Environment.NewLine + ex.Message + Environment.NewLine);
        }
    }

    private void ProcessPMID(string PMID)
    {
        ProcessDateSQL("select PubDate from pm_pubs_general where PMID = '" + PMID + "';");
    }

    private void ProcessMPID(string MPID)
    {
        ProcessDateSQL("select publicationdt from my_pubs_general where mpid = '" + MPID + "';");
    }

    private void ProcessDateSQL(string dateSQL)
    {
        Database db = DatabaseFactory.CreateDatabase();
        DbCommand dbCommand = db.GetSqlStringCommand(dateSQL);
        DateTime pubdate = (DateTime)db.ExecuteScalar(dbCommand);

        if (pubdate != null && pubdate.ToString().Length > 0)
        {
            Response.Write(pubdate.ToShortDateString() + Environment.NewLine);
        }
    }
}
