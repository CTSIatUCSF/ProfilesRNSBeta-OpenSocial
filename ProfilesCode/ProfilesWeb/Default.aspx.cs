using System;
using System.Configuration;
using System.Web;

public partial class DefaultAuth : BasePage
{
    private String _strHomePageUrl = ConfigurationManager.AppSettings["HomePageUrl"].ToString();

    protected void Page_Load(object sender, EventArgs e)
    {
        //get the redirect URL
        string strRedirectPage = (string)Request.QueryString["redirect"];

        //If theres a querystring with redirect URL 
        if (strRedirectPage != null)
        {
            //redirect to the url requested
            HttpContext.Current.Response.Redirect(strRedirectPage, false);
        }
        else
        {
            if ((string)Request["Edit"] == "Y" && Profile.UserName.Length > 0)
            {
                if (Profile.HasProfile == true)
                {
                    
                    Response.Redirect("ProfileEdit.aspx?From=Self&Person=" + Profile.ProfileId);
                }
                else
                { Response.Redirect("about.aspx?page=NoProfile"); }
            }
            else
            {
                Response.Redirect(_strHomePageUrl, false);
            }
        }
    }


}



