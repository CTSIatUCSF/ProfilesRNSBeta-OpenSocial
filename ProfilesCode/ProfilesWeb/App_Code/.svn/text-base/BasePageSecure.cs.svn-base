using System;
using System.Web;
using System.Web.UI;
using Connects.Profiles.Utility;

/// <summary>
/// Use this base page for all instance pages requiring authentication
/// </summary>
public class BasePageSecure : BasePage
{
    public BasePageSecure() { }

    protected override void OnLoad(EventArgs e)
    {
        base.OnLoad(e);
        //Response.AppendHeader("Cache-Control", "no-store");
    }

    override protected void OnInit(EventArgs e)
    {
        ////initialize our base class (System.Web,UI.Page)
        //base.OnInit(e);

        ////check to see if the Session is null (doesnt exist)
        //if (Context.Session != null)
        //{
        //    //check the IsNewSession value, this will tell us if the session has been reset. 
        //    //IsNewSession will also let us know if the users session has timed out
        //    if (Session.IsNewSession)
        //    {
        //        //now we know it's a new session, so we check to see if a cookie is present
        //        string cookie = Request.Headers["Cookie"];

        //        //now we determine if there is a cookie does it contains what we're looking for
        //        if ((null != cookie) && (cookie.IndexOf("ASP.NET_SessionId") >= 0))
        //        {
        //            //since it's a new session but a ASP.Net cookie exist we know
        //            //the session has expired so we need to redirect them
        //            Response.Redirect(ConfigUtil.GetConfigItem("LoginURL"));
        //        }
        //    }
        //}
    }

}
