using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using Connects.Profiles.BusinessLogic;

public partial class UserControls_ucAuthors : BaseUserControl
{
    private int _profileId;
    public int ProfileId
    {
        get { return _profileId; }
        set {
                _profileId = value;
                BindGrdCoAuthors();
            }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        //if (!IsPostBack)
        //{
        //    //Bind Recent CoAuthors
        //    BindGrdCoAuthors();
        //}
    }

    #region Load Grid Recent CoAuthors: grdAuthors
    private void BindGrdCoAuthors()
    {
        int Count = 0;
        grdAuthors.DataSource = _userBL.GetUserCoAuthors(_profileId, "True", ref Count);
        grdAuthors.DataBind();
       
        if (!grdAuthors.Rows.Count.Equals(0))
        {
            HyperLink hl = (HyperLink)grdAuthors.FooterRow.FindControl("hypCoAuthors");
            hl.Text = "See all (" + Count + ") people";
            hl.NavigateUrl = "~/CoAuthors.aspx?Person=" + _profileId.ToString();

            HasData = true;
        }
    }
    #endregion

    #region grdAuthors OnRowCreated Event
    protected void grdAuthors_OnRowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            DataRowView drv = e.Row.DataItem as DataRowView;
            HyperLink hypLnk;

            if (drv != null)
            {
                if (drv["CoAuthors"].ToString() != string.Empty)
                {
                    hypLnk = new HyperLink();
                    hypLnk = (HyperLink)(e.Row.Cells[1].FindControl("hypLnkAuthors"));
                    hypLnk.NavigateUrl = "~\\ProfileDetails.aspx?From=Pinfo&Person=" + drv["PersonId"].ToString();
                }
            }
        }
    }
    #endregion


}
