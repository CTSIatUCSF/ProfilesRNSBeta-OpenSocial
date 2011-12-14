using System;
using System.Data;
using Connects.Profiles.Utility;
using Connects.Profiles.Service.DataContracts;
using Connects.Profiles.BusinessLogic;

public partial class gPeople2 : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {            
            lblPerson.Text = Request.QueryString["displayname"];

            litGoogleCode1.Text = "<script src=\"http://maps.google.com/maps?file=api&v=2&key=" +
                    _systemBL.GetGoogleKey("maps", Request.Url.ToString()) + "\" type=\"text/javascript\"></script>";

            dlGoogleMapLinks.DataSource = _systemBL.GetGoogleMapZoomLinks();
            dlGoogleMapLinks.DataBind();
            
            IDataReader reader = _userBL.GetGMapUserSimilar(Convert.ToInt32(Request.QueryString["Person"]), false);
            IDataReader reader2 = _userBL.GetGMapUserSimilar(Convert.ToInt32(Request.QueryString["Person"]), true);

            litGoogleCode2.Text = new GoogleMapHelper().MapPlotPeople(Convert.ToInt32(Request.QueryString["Person"]), reader, reader2);
        }
    }
}
