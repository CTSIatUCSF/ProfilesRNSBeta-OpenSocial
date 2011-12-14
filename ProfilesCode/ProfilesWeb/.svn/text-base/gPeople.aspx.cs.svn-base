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
using Connects.Profiles.BusinessLogic;
using Connects.Profiles.Utility;
using Connects.Profiles.Service.DataContracts;

public partial class gPeople : BasePage
{
    #region Local Variables
    public string DisplayName
    {
        get
        {
            if (ViewState["DisplayName"] == null)
                ViewState["DisplayName"] = "";
            return (string)ViewState["DisplayName"];
        }
        set { ViewState["DisplayName"] = value; }
    }
    public int _userid = 0;
    private string _displayname = string.Empty;
    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {   
            hypBack.NavigateUrl = "ProfileDetails.aspx?Person=" + GetPersonFromQueryString().ToString();

            ProfileRightSide1.ProfileId = GetPersonFromQueryString();
            
                                   
            lblPerson.Text = GetDisplayName();
            int count = 0;
            DataTable td = _userBL.GetUserSimilarPeople(GetUserId(), "False", ref count);
            ltsubHeader.Text = "Similar People (" + count + ")";


            //lblPerson.Text = DisplayName;

            //lnkBack.NavigateUrl = "~/Profiles/default.aspx?redirect=ProfileDetails.aspx%3fPerson%3d" + GetPersonFromQueryString().ToString();
            //lnkBack.Text = Request.QueryString["displayname"];

            //litGoogleCode1.Text = "<script src=\"http://maps.google.com/maps?file=api&v=2&key=" +
            //        _systemBL.GetGoogleKey("maps", Request.Url.ToString()) + "\" type=\"text/javascript\"></script>";

            //dlGoogleMapLinks.DataSource = _systemBL.GetGoogleMapZoomLinks();
            //dlGoogleMapLinks.DataBind();

            //System.Web.UI.WebControls.Literal lt = (System.Web.UI.WebControls.Literal)FindControlRecursive(this.Master, "JavascriptLiteral");

            //IDataReader reader = _userBL.GetGMapUserSimilar(GetPersonFromQueryString(), false);
            //IDataReader reader2 = _userBL.GetGMapUserSimilar(GetPersonFromQueryString(), true);

            //lt.Text = new GoogleMapHelper().MapPlotPeople(GetPersonFromQueryString(), reader, reader2);
        }
    }
    public int GetUserId()
    {
        if (_userid == 0)
        {
            _userid = GetPersonFromQueryString();
        }
        return _userid;

    }
    public string GetDisplayName()
    {
        if (_displayname == string.Empty)
        {
            PersonList pList = new Connects.Profiles.Service.ServiceImplementation.ProfileService().GetPersonFromPersonId(GetUserId());
            _displayname = pList.Person[0].Name.FullName;
        }
        return _displayname;
    }

}
