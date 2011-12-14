/*  
 
    Copyright (c) 2008-2010 by the President and Fellows of Harvard College. All rights reserved.  
    Profiles Research Networking Software was developed under the supervision of Griffin M Weber, MD, PhD.,
    and Harvard Catalyst: The Harvard Clinical and Translational Science Center, with support from the 
    National Center for Research Resources and Harvard University.


    Code licensed under a BSD License. 
    For details, see: LICENSE.txt 
  
*/
using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using Connects.Profiles.BusinessLogic;
using Connects.Profiles.Service.DataContracts;

public partial class CoAuthors : BasePage
{
    #region "LocalVars"

    private int _userID=0;

    #endregion

    #region Page Load Event
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
                hypBack.Attributes.Add("onclick", "Backward('" + hdnBack.ClientID + "')");

                if (Request["Person"] != null) //Check for Null values
                {
                    _userID = GetPersonFromQueryString();
                    ProfileRightSide1.ProfileId = _userID;

                    hypLnkViewProfile.Visible = true;
                    hypLnkViewProfile.NavigateUrl = "~/ProfileDetails.aspx?Person=" + Server.UrlEncode(_userID.ToString());

                    PersonList pList = new Connects.Profiles.Service.ServiceImplementation.ProfileService().GetPersonFromPersonId(_userID);
                    ltProfileName.Text = pList.Person[0].Name.FullName;
                    Page.Title = "Co-Authors of " + pList.Person[0].Name.FullName;
                    
                    rptCoAuthor.DataSource = pList.Person[0].PassiveNetworks.CoAuthorList.CoAuthor;
                    rptCoAuthor.DataBind();

                    lblSubTitle.Text = String.Format("Co-Authors ({0})", rptCoAuthor.Items.Count.ToString());

                }
            }

            catch (Exception Ex)
            {
                throw (Ex);
            }

            Page.Title = (string)Session["Fname"] + " " + (string)Session["Lname"] + " | " + Page.Title;
        }
    }
    #endregion   

}
