using System;
using System.Collections;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;


using Connects.Profiles.BusinessLogic;

public partial class Proxy : BasePageSecure
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // Make sure the right panel is hidden
        HideRightColumn();

        if (!IsPostBack)
        {
            ltHeader.Text = "Manage Proxies";

            if (_userBL.GetMyProxies(Profile.UserId).Length > 0)
            { 
                phProfilesICanEdit.Visible = true;
            }

            if (Profile.HasProfile == true)
            { phDesignatedProxies.Visible = true; }
            
            FillGrids();
        }
    }

    private void FillGrids()
    {
        IDataReader reader = null;
        try
        {
            // this needs to be refactored to use bool instead of "Y" "N"
            reader = _userBL.GetProxies(Profile.ProfileId, 0, "Y", "N", "Y", "Y");
            GridView1.DataSource = reader;
            GridView1.DataBind();

            reader.Close();

            // this needs to be refactored to use bool instead of "Y" "N"
            reader = _userBL.GetProxies(Profile.ProfileId, 0, "N", "Y", "Y", "Y");
            GridView2.DataSource = reader;
            GridView2.DataBind();
        }
        catch (Exception ex)
        {
            string err = ex.Message;
        }
        finally
        {
            if (reader != null)
            { if (!reader.IsClosed) { reader.Close(); } }
        }

    }

    protected void btnProfilesIEdit_OnClick(object sender, EventArgs e)
    {
        Response.Redirect("proxyedit.aspx");
    }

    protected void btnAddProxy_OnClick(object sender, EventArgs e)
    {
        Response.Redirect("proxyadd.aspx");
    }

    protected void GridView1_RowDataBound(Object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType != DataControlRowType.DataRow) return;

        System.Data.Common.DbDataRecord dbdr = e.Row.DataItem as System.Data.Common.DbDataRecord;
        HyperLink hyp = (HyperLink)e.Row.FindControl("HyperLink1");
        if (((string)dbdr["emailaddr"]).Length > 0)
        {
            hyp.ToolTip = (string)dbdr["emailaddr"];
            hyp.NavigateUrl = "mailto:" + (string)dbdr["emailaddr"];
        }
        else
        {
            hyp.ToolTip = "No email available";
        }
    }

    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        Response.Redirect("ProfileDetails.aspx?Person=" + GridView1.SelectedDataKey[0].ToString());
    }

    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        _userBL.DeleteProxy(Profile.ProfileId, Convert.ToInt32(GridView1.DataKeys[e.RowIndex]["UserId"]));
        FillGrids();
        //UpdateLeftNav();
    }

    private void UpdateLeftNav()
    {
        //Update Left Nav  Network List
        GridView grdNetwork = (GridView)this.Master.FindControl("grdNetwork");
        grdNetwork.DataSource = _userBL.GetUserNetwork(Profile.UserId);
        grdNetwork.DataBind();

        HyperLink LnkNetwork = (HyperLink)this.Master.FindControl("LnkNetwork");
        if (grdNetwork.Rows.Count == 0)
        { LnkNetwork.Visible = false; }
        else
        { LnkNetwork.Visible = true; }

        //Update Left Nav  Search List
        GridView grdSearchHistory = (GridView)this.Master.FindControl("grdSearchHistory");
        grdSearchHistory.DataSource = _userBL.GetUserSearchHistory(Profile.UserId);
        grdSearchHistory.DataBind();

        ((UpdatePanel)this.Master.FindControl("upnlNetwork")).Update();
    }

    protected void GridView2_RowDataBound(Object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType != DataControlRowType.DataRow) return;

        System.Data.Common.DbDataRecord dbdr = e.Row.DataItem as System.Data.Common.DbDataRecord;
        HyperLink hyp = (HyperLink)e.Row.FindControl("HyperLink2");
        if (((string)dbdr["emailaddr"]).Length > 0)
        {
            hyp.ToolTip = (string)dbdr["emailaddr"];
            hyp.NavigateUrl = "mailto:" + (string)dbdr["emailaddr"];
        }
        else
        {
            hyp.ToolTip = "No email available";
        }
    }

    protected void GridView2_SelectedIndexChanged(object sender, EventArgs e)
    {
        Response.Redirect("ProfileDetails.aspx?Person=" + GridView2.SelectedDataKey[0].ToString());
    }

}
