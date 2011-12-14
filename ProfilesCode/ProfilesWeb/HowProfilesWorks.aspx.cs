using System;
using System.Web.UI;
using Connects.Profiles.BusinessLogic;

public partial class About : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Literal1.Text = ""; // Eric Meeks _systemBL.GetAboutText();

        ShowControl("pnlChkList", false);
        RefreshUpdatePanel("upnlMinisearch");

        // Make sure the right panel is hidden
        HideRightColumn();
    }
}
