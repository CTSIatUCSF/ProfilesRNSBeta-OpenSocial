using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

using Connects.Profiles.BusinessLogic;

public partial class Keywords : BasePage
{
    #region "LocalVars"

    private Random _random = new Random();
    private int _personId;

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
                    _personId = GetPersonFromQueryString();

                    this.ProfileRightSide1.ProfileId = _personId;
                    this.KeywordMap.ProfileId = _personId;

                    hypLnkViewProfile.Visible = true;
                    hypLnkViewProfile.NavigateUrl = "~/ProfileDetails.aspx?Person=" + _personId.ToString();

                    DataRow dro = _userBL.GetUserInformation(_personId).Rows[0];

                    Session["PersonIsMy"] = (string)dro["Lastname"] + ", " + ((string)dro["Firstname"]).Substring(0, 1);

                    ltProfileName.Text = (string)dro["DisplayName"];

                    //Persist names into viewstate
                    Session["Lname"] = dro["Lastname"].ToString();
                    Session["Fname"] = dro["Firstname"].ToString();
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

    #region Save User Search History

    private void SaveUserSearchHistory(string profileID)
    {
        string[] split = ltProfileName.Text.Split(Convert.ToChar(44));
        _userBL.InsertUserSearchHistory(Profile.UserId, _personId, split[0]);
    }
    #endregion

    

}
