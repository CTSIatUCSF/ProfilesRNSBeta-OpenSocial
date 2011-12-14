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
using Connects.Profiles.Service.DataContracts;

public partial class SimilarPeople : BasePage
{
    #region "LocalVars"

    public int userId = 0;

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
                    // Read the userId from the querystring
                    userId = GetPersonFromQueryString();

                    // Set the UserId on the user controls
                    ProfileRightSide1.ProfileId = userId;
                    SimilarPeopleMap.ProfileId = userId;

                    hypLnkViewProfile.Visible = true;
                    hypLnkViewProfile.NavigateUrl = "~/ProfileDetails.aspx?Person=" + userId.ToString();

                    //DataRow dro = _userBL.GetUserInformation(userId).Rows[0];
                    PersonList pList = new Connects.Profiles.Service.ServiceImplementation.ProfileService().GetPersonFromPersonId(userId);

                    //Session["PersonIsMy"] = (string)dro["Lastname"] + ", " + ((string)dro["Firstname"]).Substring(0, 1);
                    ltProfileName.Text = String.Format("{0} {1}", pList.Person[0].Name.FirstName, pList.Person[0].Name.LastName);

                    // PRG: Refactor needed
                    //Persist names into viewstate
                    Session["Lname"] = pList.Person[0].Name.LastName;
                    Session["Fname"] = pList.Person[0].Name.FirstName;

                   // if (pList.Person[0].Address.Latitude == 0)
                     //   SimilarPeopleMap.HideMapTab();
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
