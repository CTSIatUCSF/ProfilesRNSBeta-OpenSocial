using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using Connects.Profiles.Utility;

public partial class shiblogin : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // Make sure the right panel is hidden
        //        if (Request["devredirect"] != null)
        //        {
        //            Response.Redirect("http://dev.profiles.ucsf.edu/" + Request["devredirect"] + "/shiblogin.aspx");
        //        }

        HideRightColumn();

        Profile.PropertyValues.Clear();
        Profile.Save();

        Session.Clear();
        Session.Abandon();

        // added by Eric
        String employeeID = Request.Headers.Get("employeeNumber"); //"025693078";
        // new IDP
        if (employeeID == null || employeeID.Trim().Length == 0)
        {
            employeeID = Request.Headers.Get("uid"); //"025693078";
            if (employeeID != null && employeeID.Trim().Length > 9)
            {
                employeeID = employeeID.Substring(0, 9);
            }
        }
        if (employeeID != null && employeeID.Trim().Length > 0)
        {
            FormsAuthentication.SetAuthCookie(employeeID, false);
            Login l = new Login();
            l.UserName = employeeID;
            ProfilesMembershipUser user = getLoggedInUser(l);

            if (HttpContext.Current.Request.QueryString["EditMyProfile"] != null && user != null)
            {
                Response.Redirect("~/ProfileEdit.aspx?From=Self&Person=" + user.ProfileID.ToString());
            }
            else
            {
                Response.Redirect("~/Search.aspx");
            }
        }
    }

    private ProfilesMembershipUser getLoggedInUser(Login sender)
    {
        //Profile.UserName = ((Login)sender).UserName;

        //Profile.UserId = // GET USER ID FROM DB
        // Also set display name
        String userName = ((Login)sender).UserName;
        ProfilesMembershipUser user = (ProfilesMembershipUser)Membership.GetUser(userName);

        if (user == null)
        {
            // Not in the sytetm, try and add them now;
            MembershipCreateStatus status = new MembershipCreateStatus();
            Membership.CreateUser(userName, userName, null, null, null, true, null, out status);
            user = (ProfilesMembershipUser)Membership.GetUser(userName);
        }

        if (user != null)
        {
            // Get an instance of the ProfileCommon object
            ProfileCommon p = (ProfileCommon)ProfileCommon.Create(user.UserName, true);

            // Set our parameters from the custom authentication provider
            p.UserId = user.UserID;
            p.UserName = user.UserName;
            p.HasProfile = user.HasProfile;
            p.ProfileId = user.ProfileID;
            p.DisplayName = user.DisplayName;

            // Persist the profile data
            p.Save();

            // Refetch the profile data
            Profile.Initialize(user.UserName, true);
            //Profile.GetProfile(user.UserName);
        }

        return user;
    }
}