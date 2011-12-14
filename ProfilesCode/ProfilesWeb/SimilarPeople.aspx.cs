using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections.Generic;
using Connects.Profiles.BusinessLogic;
using Connects.Profiles.Service.DataContracts;

public partial class SimilarPeople : BasePage
{
    #region "LocalVars"

    public int userId = 0;
    private UserBL _userBL = new UserBL();

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

                    // Profiles OpenSocial Extension by UCSF
                    OpenSocialHelper os = SetOpenSocialHelper(Profile.UserId, userId, Page);
                    if (os.IsVisible() && os.HasGadgetListeningTo(OpenSocialHelper.JSON_PERSONID_CHANNEL))
                    {
                        int count = 0;
                        List<Int32> OS_personIds = new List<Int32>();
                        foreach (DataRow row in _userBL.GetUserSimilarPeople(userId, "False", ref count).Rows)
                        {
                            OS_personIds.Add((Int32)row.ItemArray[0]);
                        }
                        os.SetPubsubData(OpenSocialHelper.JSON_PERSONID_CHANNEL, OpenSocialHelper.BuildJSONPersonIds(OS_personIds, "Similar people to " + pList.Person[0].Name.FullName));
                        GenerateOpensocialJavascipt();
                    }
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
