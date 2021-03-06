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
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Connects.Profiles.Utility;
using Connects.Profiles.Common;
using Connects.Profiles.Service.DataContracts;

public partial class UserControls_ucProfileBaseInfo : BaseUserControl
{
    private int _personId = 0;
    private Random _myRandom = new Random();

    private bool _editMode = false;
    private bool _enabledHidingAddress = false;
    private bool _enabledHidingEmail = false;

    public bool EnabledHidingAddress
    {
        get { return System.Convert.ToBoolean(ConfigUtil.GetConfigItem("EnableHideAddressFunctionality")); }
    }

    public bool EnabledHidingEmail
    {
        get { return System.Convert.ToBoolean(ConfigUtil.GetConfigItem("EnableHideEmailFunctionality")); }
    }

    public bool EditMode
    {
        get { return _editMode; }

        set { _editMode = value; }
    }

    public int PersonId
    {
        get { return _personId; }
        set
        {
            _personId = value;
            LoadProfile();
        }
    }

    protected bool IsAddressVisibility()
    {
        UserPreferences userPreference = _userBL.GetUserPreferences(PersonId);
        if (Session["ProfileEdit"] != null &&
            (string)Session["ProfileEdit"] == "false" &&
                userPreference.Address.Equals("N"))
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    /// <summary>
    /// GetAddressVisibility -- This sets the value of the do not display address checkbox in the profile edit page
    /// </summary>
    /// <returns>boolean - false if the address is invisible</returns>
    protected bool GetAddressVisibility()
    {
        UserPreferences userPreference = _userBL.GetUserPreferences(PersonId);

        // To have an address invisible (i.e. visibility == false)
        // 2 conditions must exist
        // 1. Address preference is N
        // 2. Enable the hide functionality == true
        // Otherwise show the email
        if (userPreference.Address.Equals("N") == false && true == this.EnabledHidingAddress)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    protected bool IsEmailVisibility()
    {
        UserPreferences userPreference = _userBL.GetUserPreferences(PersonId);
        if (Session["ProfileEdit"] != null &&
            (string)Session["ProfileEdit"] == "false" &&
                userPreference.Email.Equals("N"))
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    /// <summary>
    /// GetEmailVisibility -- This sets the value of the do not display email checkbox in the profile edit page
    /// </summary>
    /// <returns>boolean - false if the address is invisible</returns>
    protected bool GetEmailVisibility()
    {
        UserPreferences userPreference = _userBL.GetUserPreferences(PersonId);

        // To have an email invisible (i.e. visibility == false)
        // 2 conditions must exist
        // 1. Email preference is N
        // 2. Enable the hide functionality == true
        // Otherwise show the email
        if (userPreference.Email.Equals("N") == false && true == EnabledHidingEmail)
        {
            return false;
        }
        else
        {
            return true;
        }
    }



    protected void Page_Load(object sender, EventArgs e)
    {

    }

    public void LoadProfile()
    {
        Connects.Profiles.Service.DataContracts.PersonList thisPerson = new Connects.Profiles.Service.ServiceImplementation.ProfileServiceAdapter().GetPersonFromPersonId(_personId);
        dlistProfileInfo.DataSource = thisPerson.Person;
        dlistProfileInfo.DataBind();

        rptrTitles.DataSource = _userBL.GetPersonAffiliations(_personId);
        rptrTitles.DataBind();

        // Hide the section if no "Other Positions"
        if (rptrTitles.Items.Count == 0)
            rptrTitles.Visible = false;
    }

    protected void dlistProfileInfo_ItemDataBound(object sender, DataListItemEventArgs e)
    {

        if (e.Item.ItemType == ListItemType.Item ||
            e.Item.ItemType == ListItemType.AlternatingItem)
        {
            UpdateEmailAddress(sender, e);
//            UpdateUserAddress(sender, e);
        }
    }

    private void UpdateUserAddress(object sender, DataListItemEventArgs e)
    {
        string address;

      //    string email;
      //    email = ((Connects.Profiles.Service.DataContracts.Person)e.Item.DataItem).EmailImageUrl.Text;
            string email;
            string phone;
            string fax;

            email = ((Connects.Profiles.Service.DataContracts.Person)e.Item.DataItem).EmailImageUrl.Text;
            phone = ((Connects.Profiles.Service.DataContracts.Person)e.Item.DataItem).Address.Telephone;
            fax = ((Connects.Profiles.Service.DataContracts.Person)e.Item.DataItem).Address.Fax;

            Image imgEmail = (Image)e.Item.FindControl("ImageEmail");
            Label lblEmail = (Label)e.Item.FindControl("lblReadEmail");
	        UserPreferences userPreference = _userBL.GetUserPreferences(PersonId);

            address = ((Connects.Profiles.Service.DataContracts.Person)e.Item.DataItem).Address.ToString();
        
    }

    private void UpdateEmailAddress(object sender, DataListItemEventArgs e)
    {
        string email;
        string phone;
        string fax;

        email = ((Connects.Profiles.Service.DataContracts.Person)e.Item.DataItem).EmailImageUrl.Text;
        phone = ((Connects.Profiles.Service.DataContracts.Person)e.Item.DataItem).Address.Telephone;
        fax = ((Connects.Profiles.Service.DataContracts.Person)e.Item.DataItem).Address.Fax;

        Image imgEmail = (Image)e.Item.FindControl("ImageEmail");
        Label lblEmail = (Label)e.Item.FindControl("lblReadEmail");
        Label lblEmailText = (Label)e.Item.FindControl("lblEmailText");
        Label lblTelePhoneText = (Label)e.Item.FindControl("lblTelePhoneText");
        Label lblTelePhone = (Label)e.Item.FindControl("lblTelePhone");
        Label lblFaxText = (Label)e.Item.FindControl("lblFaxText");
        Label lblFax = (Label)e.Item.FindControl("lblFax");

        UserPreferences userPreference = _userBL.GetUserPreferences(PersonId);


        if (email != null)
        {
            // Need this to pass over to the page that produces the image.  Old stuff - this should be refactored.
            Session["EmailImgText"] = email;

            imgEmail.ImageUrl = "../EmailImage.aspx?r=" + _myRandom.Next(99999).ToString();
            imgEmail.Visible = true;
            lblEmail.Visible = false;
            // Determine if we are in Edit mode or View mode
            // If we are in view mode and the user does not want to show the email.  make it invisible
            if (Session["ProfileEdit"] != null && (string)Session["ProfileEdit"] == "false" && userPreference.Email.Equals("N"))
            {
                imgEmail.AlternateText = "Email Address";
                imgEmail.Visible = false;
                lblEmail.Visible = false;
            }
        }
        else
        {
            Session["EmailImgText"] = "none";

            imgEmail.AlternateText = "Email Address";
            imgEmail.Visible = false;
            lblEmail.Visible = false;
        }

        if (phone == null)
        {
            lblTelePhone.Visible = false;
            lblTelePhone.Visible = false;
        }


        if (fax == null)
        {
            lblFaxText.Visible = false;
            lblFax.Visible = false;
        }

    }

    #region Grid Data Binding Helpers

    protected string GetInstitutionText(object affiliationList, int index)
    {
        string text = null;

        if ((((AffiliationListPerson)affiliationList).Affiliation != null) && (((AffiliationListPerson)affiliationList).Affiliation.Count > index))
            text = ((AffiliationListPerson)affiliationList).Affiliation[index] == null ? null : ((AffiliationListPerson)affiliationList).Affiliation[index].InstitutionName;

        return text;
    }

    protected string GetDepartmentText(object affiliationList, int index)
    {
        string text = null;

        if ((((AffiliationListPerson)affiliationList).Affiliation != null) && (((AffiliationListPerson)affiliationList).Affiliation.Count > index))
            text = ((AffiliationListPerson)affiliationList).Affiliation[index] == null ? null : ((AffiliationListPerson)affiliationList).Affiliation[index].DepartmentName;

        return text;
    }

    protected string GetDivisionText(object affiliationList, int index)
    {
        string text = null;

        if ((((AffiliationListPerson)affiliationList).Affiliation != null) && (((AffiliationListPerson)affiliationList).Affiliation.Count > index))
            text = ((AffiliationListPerson)affiliationList).Affiliation[index] == null ? null : ((AffiliationListPerson)affiliationList).Affiliation[index].DivisionName;

        return text;
    }

    protected string GetFacultyRank(object affiliationList, int index)
    {
        string text = null;

        if ((((AffiliationListPerson)affiliationList).Affiliation != null) && (((AffiliationListPerson)affiliationList).Affiliation.Count > index))
            text = ((AffiliationListPerson)affiliationList).Affiliation[index] == null ? null : ((AffiliationListPerson)affiliationList).Affiliation[index].FacultyType;

        return text;
    }

    protected string GetJobTitle(object affiliationList, int index)
    {
        string text = null;

        if ((((AffiliationListPerson)affiliationList).Affiliation != null) && (((AffiliationListPerson)affiliationList).Affiliation.Count > index))
            text = ((AffiliationListPerson)affiliationList).Affiliation[index] == null ? null : ((AffiliationListPerson)affiliationList).Affiliation[index].JobTitle;

        return text;
    }

    protected void UpdateAddressDisplaySetting(object objSender, EventArgs objArgs)
    {
        CheckBox cb = (CheckBox)objSender;
        if (cb.Checked)
        {
            _userBL.SetUserPreferences(Convert.ToInt32(Session["ProfileUsername"]), "Address", "N");
        }
        else
        {
            _userBL.SetUserPreferences(Convert.ToInt32(Session["ProfileUsername"]), "Address", "Y");
        }
    }

    protected void UpdateEmailDisplaySetting(object objSender, EventArgs objArgs)
    {
        CheckBox cb = (CheckBox)objSender;
        if (cb.Checked)
        {
            _userBL.SetUserPreferences(Convert.ToInt32(Session["ProfileUsername"]), "Email", "N");
        }
        else
        {
            _userBL.SetUserPreferences(Convert.ToInt32(Session["ProfileUsername"]), "Email", "Y");
        }
    }


    #endregion

}
