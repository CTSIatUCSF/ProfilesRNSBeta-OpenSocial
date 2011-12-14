using System;
using System.Data;
using System.Collections.Generic;
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

                    // Profiles OpenSocial Extension by UCSF
                    OpenSocialHelper os = SetOpenSocialHelper(Profile.UserId, _userID, Page);
                    if (os.IsVisible() && os.HasGadgetListeningTo(OpenSocialHelper.JSON_PERSONID_CHANNEL))
                    {
                        List<Int32> OS_personIds = new List<Int32>();
                        foreach (CoAuthor coauthor in pList.Person[0].PassiveNetworks.CoAuthorList.CoAuthor)
                        {
                            OS_personIds.Add(Int32.Parse(coauthor.PersonID));
                        }
                        os.SetPubsubData(OpenSocialHelper.JSON_PERSONID_CHANNEL, OpenSocialHelper.BuildJSONPersonIds(OS_personIds, Page.Title));
                        GenerateOpensocialJavascipt();
                    }

                    //if (pList.Person[0].Address.Latitude == 0)
                     //   divMapView.Attributes.Add("style", "display:none");
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
