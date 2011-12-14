using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

public partial class ForDevelopers : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ShowControl("pnlChkList", false);
        RefreshUpdatePanel("upnlMinisearch");
        // Make sure the right panel is hidden
        HideRightColumn();
    }
}
