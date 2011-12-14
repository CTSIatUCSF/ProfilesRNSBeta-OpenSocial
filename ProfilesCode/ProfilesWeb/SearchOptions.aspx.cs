using System;
using System.Web.UI;
using Connects.Profiles.BusinessLogic;

public partial class SearchOptions : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ShowControl("pnlChkList", false);
        RefreshUpdatePanel("upnlMinisearch");

        // Make sure the right panel is hidden
        HideRightColumn();
    }
}
