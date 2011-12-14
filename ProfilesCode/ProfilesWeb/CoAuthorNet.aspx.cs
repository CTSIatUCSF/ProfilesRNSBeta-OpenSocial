using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Connects.Profiles.Service.DataContracts;

public partial class CoAuthorNet : BasePage
{
    public string _NetworkBrowserService;
    #region "LocalVars"

    private int _userID = 0;

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

                    
                    lblSubTitle.Text = String.Format("Co-Authors ({0})", pList.Person[0].PassiveNetworks.CoAuthorList.TotalCoAuthorCount.ToString());

                    if (pList.Person[0].Address.Latitude == 0)
                        divMapView.Attributes.Add("style", "display:none");
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
