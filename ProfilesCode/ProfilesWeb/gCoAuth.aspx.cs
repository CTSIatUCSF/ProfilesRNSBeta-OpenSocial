using System;
using System.Data;
using Connects.Profiles.Utility;
using Connects.Profiles.Service.DataContracts;

public partial class gCoAuth : BasePage
{
    #region Local Variables
        private int _userID = 0;
        private string _displayname = string.Empty;
    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            hypBack.NavigateUrl = "ProfileDetails.aspx?Person=" + GetPersonFromQueryString();

            ProfileRightSide1.ProfileId = GetUserid();

            ltProfileName.Text = GetDisplayName();

            //linkPerson.NavigateUrl = "~/Profiles/default.aspx?redirect=ProfileDetails.aspx%3fPerson%3d" + GetPersonFromQueryString().ToString();
            //linkPerson.Text = Request.QueryString["displayname"];
            //litGoogleCode1.Text = "<script src=\"http://maps.google.com/maps?file=api&v=2&key=" + _systemBL.GetGoogleKey("maps", Request.Url.ToString()) + "\" type=\"text/javascript\"></script>";

            //dlGoogleMapLinks.DataSource = _systemBL.GetGoogleMapZoomLinks();
            //dlGoogleMapLinks.DataBind();

            //System.Web.UI.WebControls.Literal lt = (System.Web.UI.WebControls.Literal)FindControlRecursive(this.Master, "JavascriptLiteral");

            //IDataReader reader = _userBL.GetGMapUserCoAuthors(GetPersonFromQueryString(), 0);
            //IDataReader reader2 = _userBL.GetGMapUserCoAuthors(GetPersonFromQueryString(), 1);

            //lt.Text = new GoogleMapHelper().MapPlotPeople(GetPersonFromQueryString(), reader, reader2);
            
        }
    }
    public int GetUserid()
    {
        if (_userID == 0)
        {
            _userID = GetPersonFromQueryString();
        }
        return _userID;
    }
    public string GetDisplayName()
    {
        if (_displayname == string.Empty)
        {
            PersonList pList = new Connects.Profiles.Service.ServiceImplementation.ProfileService().GetPersonFromPersonId(GetUserid());
            lblSubTitle.Text = String.Format("Co-Authors ({0})", pList.Person[0].PassiveNetworks.CoAuthorList.TotalCoAuthorCount.ToString());
            _displayname = pList.Person[0].Name.FullName;
        }
        return _displayname;
    }

}
