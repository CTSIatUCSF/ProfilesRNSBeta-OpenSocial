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

public partial class UserControls_ucNeighbors : BaseUserControl
{
    private int _profileId=0;

    public int ProfileId
    {
        get { return _profileId; }
        set
        {
            _profileId = value;
            BindGrdNeighbors();
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
    }

    #region Loag Grid Neighbor: grdSameDepartment
    private void BindGrdNeighbors()
    {
        grdNeighbors.DataSource = _userBL.GetUserNeighbors(_profileId);
        grdNeighbors.DataBind();

        if (!grdNeighbors.Rows.Count.Equals(0))
            HasData = true;
    }
    #endregion

    #region grdNeighbors OnRowCreated Event
    protected void grdNeighbors_OnRowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            DataRowView drv = e.Row.DataItem as DataRowView;
            HyperLink hypLnk;

            if (drv != null)
            {
                if (drv["MyNeighbors"].ToString() != string.Empty)
                {
                    hypLnk = new HyperLink();
                    hypLnk = (HyperLink)(e.Row.Cells[1].FindControl("hypLnkNeighbors"));
                    hypLnk.NavigateUrl = "~\\ProfileDetails.aspx?From=Pinfo&Person=" + drv["PersonId"].ToString();
                }
            }
        }
    }
    #endregion

}
