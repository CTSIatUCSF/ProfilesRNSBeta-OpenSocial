﻿/*  
 
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
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using Connects.Profiles.Common;
using Connects.Profiles.Utility;
using Connects.Profiles.BusinessLogic;

public partial class ProfilesPage : System.Web.UI.MasterPage
{
    private UserBL _UserBL = new UserBL();
    private SystemBL _SystemBL = new SystemBL();
    private InstitutionBL _InstBL = new InstitutionBL();
    private String strRedirectURL = System.Configuration.ConfigurationManager.AppSettings["LoginURL"].ToString();
    private String _baseURL = System.Configuration.ConfigurationManager.AppSettings["URLBase"].ToString();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            this.ProcessPageLoad();
        }
        
    }

    private void ProcessPageLoad()
    {
        //Retrieve header menu links
        //litNavHtml.Text = _SystemBL.GetNavHtml();

        // Set the login URL
        hypLogMeIn.NavigateUrl = strRedirectURL;

        if (Profile.UserId != 0)
        {
            // We are logged in
            pnlNotLoggedIn.Visible = false;
            pnlLoggedIn.Visible = true;
            //pnlDisplayName.Visible = true;

            UserBL _userBL = new UserBL();

            //UserPreferences userPreference = new UserPreferences();
            //userPreference = _userBL.GetUserPreferences(Profile.UserId);

            //if (userPreference.ProfileExists)
            if (Profile.HasProfile == true)
            {
                hypViewMyProfile.Visible = true;
                hypViewMyProfile.NavigateUrl = "~/ProfileDetails.aspx?Person=" + Profile.ProfileId;

                hypManageProxies.Visible = true;
                hypManageProxies.NavigateUrl = "~/Proxy.aspx";


                    hypEditMyProfile.Visible = true;
                    hypEditMyProfile.NavigateUrl = "~/ProfileEdit.aspx?From=Self&Person=" + Profile.ProfileId;
               
                //lblDisplayName.Text = Profile.DisplayName;
            }
            else if (_UserBL.GetMyProxies(Profile.UserId).Length > 0)
            {
                hypManageProxies.Visible = true;
                hypManageProxies.NavigateUrl = "~/Proxy.aspx";
            }
        }
        else
        {
            // We are not logged in
            pnlNotLoggedIn.Visible = true;
            pnlLoggedIn.Visible = false;
            //pnlDisplayName.Visible = false;

            // Hide the mini search
            //upnlMinisearch.Visible = false;

            // Hide the whole network panel
            pnlMyNetwork.Visible = false;

            // Set the Edit Profile link when not logged in
            hypNotLoggedIn.NavigateUrl = strRedirectURL + "?EditMyProfile=true";
        }

        // Update the left panels
        upnlMinisearch.Update();
        pnlMyNetwork.Update();

    }
    public string CheckForSecureConnection()
    {
        string baseurl = ConfigurationManager.AppSettings["URLBase"].ToString().ToLower();

        if (Request.IsSecureConnection)
        {
            return baseurl.Replace("http://", "https://");
        }
        else
        {
            return baseurl;
        }
    }
    #region OnAsyncPostBackError
    protected void OnAsyncPostBackError(object sender, AsyncPostBackErrorEventArgs e)
    {
        scmPeople.AsyncPostBackErrorMessage = e.Exception.Message;

    }
    #endregion
}
