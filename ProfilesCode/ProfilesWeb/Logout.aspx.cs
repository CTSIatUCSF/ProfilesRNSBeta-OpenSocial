﻿using System;
using System.Web.Security;
using Connects.Profiles.Utility;

public partial class Logout : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        for (int i=0; i < Session.Count; i++)
        {
            Session[i] = null;
        }

        Session.Clear();
        Session.Abandon();

        Profile.ProfileId = 0;
        Profile.HasProfile = false;
        Profile.UserId = 0;
        Profile.UserName = null;
        Profile.DisplayName = null;

        Response.Expires = 1;
        Response.ExpiresAbsolute = DateTime.Now.AddMinutes(-1);
        Response.AddHeader("pragma", "no-cache");
        Response.AddHeader("cache-control", "private");
        Response.CacheControl = "no-cache";

        Response.Redirect(ConfigUtil.GetConfigItem("AfterLogoutURL"));
    }
}
