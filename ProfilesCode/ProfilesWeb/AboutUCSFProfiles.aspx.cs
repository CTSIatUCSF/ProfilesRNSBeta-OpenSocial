using System;
using System.Web.UI;
using Connects.Profiles.BusinessLogic;

public partial class AboutUCSFProfiles : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ShowControl("pnlChkList", false);
        RefreshUpdatePanel("upnlMinisearch");
        hypLogMeIn.NavigateUrl = System.Configuration.ConfigurationManager.AppSettings["LoginURL"].ToString() + "?EditMyProfile=true";
        // Make sure the right panel is hidden
        HideRightColumn();
    }
}
