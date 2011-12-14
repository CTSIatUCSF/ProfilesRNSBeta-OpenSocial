using System;
using System.Web;

public partial class MasterPage : System.Web.UI.MasterPage
{
    public string GetProfileLink
    {
        get { return hlMyProf.NavigateUrl; }
    }

    public bool IsAuthenticatedUser
    {
        get { return HttpContext.Current.User.Identity.IsAuthenticated; }
    }

    public string CurrentPage
    {
        get { return Request.AppRelativeCurrentExecutionFilePath; }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        string l_redirectUrl = string.Format("http://{0}{1}", Request.Url.Authority, ResolveUrl("~/AllUsers.aspx"));
        if (IsAuthenticatedUser && CurrentPage == "~/Login.aspx")
            Response.Redirect(l_redirectUrl);

        loginStatus.Visible = CurrentPage != "~/Login.aspx";
        pLinks.Visible = IsAuthenticatedUser;
        hlMyProf.Visible = IsAuthenticatedUser;

        if (CurrentPage == "~/PasswordRecovery.aspx")
            pLinks.Visible = false;


        if (IsAuthenticatedUser && UserInfo.Current != null)
        {
            hlMyProf.Visible = true;
            hlMyProf.NavigateUrl = ResolveUrl("~/UserEdit.aspx");
        }
        else
        {
            hlMyProf.Visible = false;
        }

        //Show current page as bold link
        if ("~/" + hlRoles.HRef == CurrentPage)
        {
            hlRoles.Attributes.Add("style", "font-weight:bold");
        }
        if ("~/" + hlUsers.HRef == CurrentPage)
        {
            hlUsers.Attributes.Add("style", "font-weight:bold");
        }
    }

    protected void logout_clicked(object sender, EventArgs e)
    {
        if (UserInfo.Current != null)
        {
            UserInfo.Reset();
        }
    }
}
