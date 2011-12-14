/*  
 
    Copyright (c) 2008-2010 by the President and Fellows of Harvard College. All rights reserved.  
    Profiles Research Networking Software was developed under the supervision of Griffin M Weber, MD, PhD.,
    and Harvard Catalyst: The Harvard Clinical and Translational Science Center, with support from the 
    National Center for Research Resources and Harvard University.


    Code licensed under a BSD License. 
    For details, see: LICENSE.txt 
  
*/
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



