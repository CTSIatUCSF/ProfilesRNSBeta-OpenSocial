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
using Harvard.Hms.ResNavLoginUtilities;

public partial class HMS_Login : BasePage
{
    private TicketUtil ticketUtil = new TicketUtil();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (HttpContext.Current.Request.QueryString["ticket"] != null)
        {
            string ticket = HttpContext.Current.Request.QueryString["ticket"];

            string strCheckAuth = "";
            string[] TicketData;
            char[] splitter = { '|' };
            string loginUsername;

            strCheckAuth = ticketUtil.CheckTicket(ConfigUtil.GetConfigItem("TicketApp"), ticket, ConfigUtil.GetConfigItem("TicketKey"), ConfigUtil.GetConfigItem("TicketPostUrl"));

            if (strCheckAuth.Length > 8)
            {
                TicketData = strCheckAuth.Split(splitter);
                loginUsername = TicketData[0];

                ProfilesMembershipUser user = (ProfilesMembershipUser)Membership.GetUser(loginUsername);

                Profile.UserId = user.UserID;
                Profile.UserName = user.UserName;
                Profile.HasProfile = user.HasProfile;
                Profile.ProfileId = user.ProfileID;
                Profile.DisplayName = user.DisplayName;
            }

            Response.Redirect("~/");
        }
        else
        {
            Response.Redirect(ConfigUtil.GetConfigItem("ConnectsLoginURL"));
        }

    }
}
