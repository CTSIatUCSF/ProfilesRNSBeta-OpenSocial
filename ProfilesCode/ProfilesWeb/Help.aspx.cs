using System;
using System.Web.UI;
using Connects.Profiles.BusinessLogic;

public partial class Help : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ShowControl("pnlChkList", false);
        RefreshUpdatePanel("upnlMinisearch");

        // Make sure the right panel is hidden
        HideRightColumn();

        hypLogMeIn2.NavigateUrl = System.Configuration.ConfigurationManager.AppSettings["LoginURL"].ToString() + "?EditMyProfile=true";
        hypLogMeIn3.NavigateUrl = System.Configuration.ConfigurationManager.AppSettings["LoginURL"].ToString() + "?EditMyProfile=true";
    }
}
