/*  
 
    Copyright (c) 2008-2010 by the President and Fellows of Harvard College. All rights reserved.  
    Profiles Research Networking Software was developed under the supervision of Griffin M Weber, MD, PhD.,
    and Harvard Catalyst: The Harvard Clinical and Translational Science Center, with support from the 
    National Center for Research Resources and Harvard University.


    Code licensed under a BSD License. 
    For details, see: LICENSE.txt 
  
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using Connects.Profiles.Utility;

public partial class login : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // Make sure the right panel is hidden
        HideRightColumn();
    }

    protected void loginControl_LoggedIn(object sender, EventArgs e)
    {
        ProfilesMembershipUser user = (ProfilesMembershipUser)Membership.GetUser(((Login)sender).UserName);
        
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

        if (HttpContext.Current.Request.QueryString["EditMyProfile"] != null)
            Response.Redirect("~/ProfileEdit.aspx?From=Self&Person=" + user.ProfileID.ToString());
    }

}
