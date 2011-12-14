using System;
using System.Web.UI;
using System.Text;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Web.UI.WebControls;
using Connects.Profiles.Common;
using Connects.Profiles.Service.DataContracts;
using Connects.Profiles.Utility;
using System.Web.UI.HtmlControls;

public partial class OpenSocialTest : BasePage
{
    #region "LocalVars"

    //public DataSet PubMedResults
    //{
    //    get
    //    {
    //        if (ViewState["PubMedResults"] == null)
    //        { ViewState["PubMedResults"] = new DataSet(); }
    //        return (DataSet)ViewState["PubMedResults"];
    //    }
    //    set
    //    {
    //        ViewState["PubMedResults"] = value;
    //    }
    //}

    public int EditUserId
    {
        get
        {
            if (ViewState["EditUsername"] == null)
                ViewState["EditUsername"] = "";
            return (int)ViewState["EditUsername"];
        }
        set { ViewState["EditUsername"] = value; }
    }

    private int _personId=0;
    private PersonList personProfileList;
    private Person personProfile;
    private bool _isVisibleProfile;
    private OpenSocialHelper osHelper;

    #endregion

    #region Page Load Event
    protected void Page_Load(object sender, EventArgs e)
    {
        int UserId = Profile.UserId;
        if (Request["viewer"] != null) 
        {
            UserId = Int32.Parse(Request["viewer"]);
        }
        
        osHelper = new OpenSocialHelper(UserId, GetPersonFromQueryString(), Page);

        Session["EmailImgText"] = "none";

        // Get the profile ID from the query string
        _personId = GetPersonFromQueryString();

        if (!IsPostBack)
        {
            if (_personId > 0)
            {
                personProfileList = new Connects.Profiles.Service.ServiceImplementation.ProfileService().GetPersonFromPersonId(_personId);
                personProfile = personProfileList.Person[0];

                if (personProfile != null)
                {
                    // check to see if profile is hidden
                    _isVisibleProfile = personProfile.Visible;


                    this.EditUserId = Profile.UserId;
                    
                    // Handle situation where it's the logged-in user viewing their own page
                    ProcessSelfProxyAndHidden();

                    //Save Search History
                    if (Profile.UserId != 0)
                        SaveUserSearchHistory(_personId);

                    hypBack.NavigateUrl = (string)Session["BackPage"];
                    if ((string)Request["From"] == "SE")
                    {
                        hypBack.Visible = true;
                    }

                    // Set the page titles 
                    Page.Title = personProfile.Name.FirstName + " " + personProfile.Name.LastName + " | " + Page.Title;
                    ltProfileName.Text = personProfile.Name.FullName;
                }
            }
        }

        InitializeUserControlEvents();

    }

    #endregion

    #region OpenSocial Helpers

    protected OpenSocialHelper OpenSocial()
    {
        return osHelper;
    }

    protected String GetGadgetContent()
    {
        return ""; // turn off for now
        StreamReader SR;
        string S;
        string xml = "";
        SR=File.OpenText("Z:\\gadgets\\Mentor.xml");
        S=SR.ReadLine();
        while(S!=null)
        {
            xml += S;
            S=SR.ReadLine();
        }
        SR.Close();
        return xml;
    }

    #endregion

    #region InitPage Helpers

    private void ProcessSelfProxyAndHidden()
    {
        if (_personId == Profile.ProfileId)
        {
            imgReach.ImageUrl = "images/reachyou.gif";
            imgReach.Visible = true;
            ShowControl("pnlChkList", false);

            ReadOnlySection(_personId);
        }
        else if (_userBL.IsProxyFor(Profile.UserId, _personId))
        {
            //Find Control in Masterpage and Make it Visible
            Control o = FindControlRecursive(this.Master, "hypEditAsProxy");
            HyperLink hl = new HyperLink();
            hl = (HyperLink)o;
            hl.Visible = true;
            hl.NavigateUrl = "ProfileEdit.aspx?From=Proxy&Person=" + _personId.ToString();

            ReadOnlySection(_personId);
        }
        else
        {
            // You don't own the profile and you're not a proxy so check the "hidden profile" condition
            ProcessHiddenCondition();
        }
    }

    private void ProcessHiddenCondition()
    {
        if (!_isVisibleProfile)
        {
            this.pnlReadOnlySection.Visible = false;
            this.txtProfileProblem.Text = "This profile is under construction and will be available soon.";
        }
        else
            ReadOnlySection(_personId);
    }

    #endregion


    #region User ReadOnly Section
    private void ReadOnlySection(int personId)
    {
        try
        {            

            #region Basic Information

                ucProfileBaseInfo.PersonId = _personId;

            #endregion

            #region Awards&Honors

            //RptrReadAwardsHonors.DataSource = _userBL.GetUserAwardsHonors(personId);

            RptrReadAwardsHonors.DataSource = personProfile.AwardList.Award;
            RptrReadAwardsHonors.DataBind();

            if (RptrReadAwardsHonors.Items.Count.Equals(0))
            {
                pnlReadoOnlyAwardsHonors.Visible = false;
            }
            #endregion

            #region Narrative

            lblReadOnlyNarrative.Text = Server.HtmlEncode(_userBL.GetUserNarratives(personId)).Replace("\n", "<br />");
            if (lblReadOnlyNarrative.Text.Length == 0)
            {
                pnlReadOnlyNarrative.Visible = false;
            }

            #endregion

            #region Prepare to display ProfileUser

            UserPreferences userPreference = new UserPreferences();
            userPreference = _userBL.GetUserPreferences(personId);
            //IF "Y" then Show 
            //IF "N" then Hide
            #region Hide/Show Photo

            if (userPreference.Photo.Equals("Y"))
            {
                imgReadPhoto.ImageUrl = _userBL.GetUserPhotoURL(personId);
            }
            else
            {
                //Hide Photo
                imgReadPhoto.Visible = false;
            }

            #endregion

            #region Hide/Show Awards & Honors

            if (userPreference.AwardsHonors.Equals("N"))
            {
                pnlReadoOnlyAwardsHonors.Visible = false;
            }

            #endregion

            #region Hide/Show Narrative

            if (userPreference.Narrative.Equals("N"))
            {
                pnlReadOnlyNarrative.Visible = false;
            }
            #endregion

            #region Hide/Show Publications

            if (userPreference.Publications.Equals("N"))
            {
                pnlReadOnlyPublications.Visible = false;
            }

            #endregion

            #endregion

            #region Right Side Controls 

            ProfileRightSide1.ProfileId = _personId;

            #endregion

            this.txtProfileProblem.Text = ""; // Eric Meeks _userBL.GetProfileSupportHtml(_personId, true);

        }
        catch (Exception Ex)
        {
            throw (Ex);
        }

    }
    #endregion

    #region Save User Search History

    private void SaveUserSearchHistory(int profileID)
    {
        string[] split = ltProfileName.Text.Split(Convert.ToChar(44));
        _userBL.InsertUserSearchHistory(Profile.UserId, profileID, split[0]);
    }
    
    #endregion

    #region Control Events

    public void lnkPubLoc_DataBinding(object sender, EventArgs e)
    {
        if (((HyperLink)sender).Text == "Custom")
        {
            ((HyperLink)sender).Text = "External Web Site";
        }
    }

    public void rptPubSource_ItemDataBound(object sender, EventArgs e)
    {
        if ((((Connects.Profiles.Service.DataContracts.PublicationSourceList)(((Repeater)(sender)).DataSource)))[0].Name == "Custom")
        {
            if (String.IsNullOrEmpty(((((Connects.Profiles.Service.DataContracts.PublicationSourceList)(((Repeater)(sender)).DataSource)))[0].URL)))
            {
                // Use the DIV to hide the entire row
                ((Repeater)(sender)).Parent.Visible = false;
            }
        }
    }

    #endregion

    #region User Control Events

    private void InitializeUserControlEvents()
    {
        IProfileUserControlPublisher pub = null;
        IProfileUserControlSubscriber sub = null;

        // Make the Modify Network a publisher and the My Network control a subscriber
        pub = FindControlRecursive(Page, "ucModifyNetwork") as IProfileUserControlPublisher;
        sub = FindControlRecursive(Master, "ucMyNetwork") as IProfileUserControlSubscriber;
        pub.SubscribeBiDirectional(sub);
    }

    #endregion

}
