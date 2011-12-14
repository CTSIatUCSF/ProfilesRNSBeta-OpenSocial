/*  
 
    Copyright (c) 2008-2010 by the President and Fellows of Harvard College. All rights reserved.  
    Profiles Research Networking Software was developed under the supervision of Griffin M Weber, MD, PhD.,
    and Harvard Catalyst: The Harvard Clinical and Translational Science Center, with support from the 
    National Center for Research Resources and Harvard University.


    Code licensed under a BSD License. 
    For details, see: LICENSE.txt 
  
*/
using System;
using System.Collections;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;


using Connects.Profiles.BusinessLogic;

public partial class ProxyEdit : BasePageSecure
{
    protected FullGridPager fullGridPager;
    protected int MaxVisible = 16;

    public DataSet MyDataSet
    {
        get
        {
            if (ViewState["MyDataSet"] == null)
                ViewState["MyDataSet"] = new DataSet();
            return (DataSet)ViewState["MyDataSet"];
        }
        set { ViewState["MyDataSet"] = value; }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            fullGridPager = new FullGridPager(gridProxies, MaxVisible, "Page", "of");
            fullGridPager.MaxVisiblePageNumbers = 16;
        }
            
        ltHeader.Text = "Profiles I can Edit";
        HideRightColumn();
        FillGrid();
    }

    private void FillGrid()
    {
        try
        {
            MyDataSet = _userBL.GetMyAssignedProxies(Profile.UserId);
            BindGrid(0);
        }
        catch (Exception ex)
        {
            string err = ex.Message;
        }
    }

    protected void gridProxies_RowDataBound(Object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType != DataControlRowType.DataRow) return;

        //set row hover 
        GridView gv = (GridView)sender;
        string className = (e.Row.RowState == DataControlRowState.Alternate) ? gv.AlternatingRowStyle.CssClass : gv.RowStyle.CssClass;
        e.Row.Attributes.Add("onmouseover", "this.className='gridHover';");
        e.Row.Attributes.Add("onmouseout", "this.className='" + className + "';");
        e.Row.Cells[1].Attributes.Add("onclick", Page.ClientScript.GetPostBackEventReference(gv, "Select$" + e.Row.RowIndex.ToString()));
        e.Row.Cells[2].Attributes.Add("onclick", Page.ClientScript.GetPostBackEventReference(gv, "Select$" + e.Row.RowIndex.ToString()));
    }

    protected void gridProxies_SelectedIndexChanged(object sender, EventArgs e)
    {
        Response.Redirect("ProfileEdit.aspx?From=Proxy&Person=" + gridProxies.SelectedDataKey[0].ToString());
    }

    protected void gridProxies_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        BindGrid(e.NewPageIndex);
    }

    protected void gridProxies_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        _userBL.DeleteProxy(Profile.UserId, Convert.ToInt32(gridProxies.SelectedDataKey[0]));
    }

    protected void gridProxies_PageIndexChanged(object sender, EventArgs e)
    {
        // Add page querystring variable to keep track of pagination in grid
        string uri = Request.Url.ToString();
        if (uri.IndexOf("page=") > -1)
        { uri = uri.Substring(0, uri.IndexOf("page=") - 1); }

        string pageValue = "";
        if (uri.IndexOf("?") > -1)
        { pageValue = "&page=" + ((GridView)sender).PageIndex.ToString(); }
        else
        { pageValue = "?page=" + ((GridView)sender).PageIndex.ToString(); }

        Session["BackPage"] = uri + pageValue;
    }

    protected void gridProxies_DataBound(object sender, EventArgs e)
    {
        if (fullGridPager == null)
        {
            fullGridPager = new FullGridPager(gridProxies, MaxVisible, "Page", "of");
        }

        fullGridPager.CreateCustomPager(gridProxies.BottomPagerRow);
    }

    protected void lnkPrevPageGroup_OnClick(object sender, EventArgs e)
    {
        int newIndex = fullGridPager.TheGrid.PageIndex - fullGridPager.MaxVisiblePageNumbers;

        if (newIndex >= 0)
            fullGridPager.TheGrid.PageIndex = newIndex;
    }

    protected void lnkNextPageGroup_OnClick(object sender, EventArgs e)
    {
        int newIndex = fullGridPager.TheGrid.PageIndex + fullGridPager.MaxVisiblePageNumbers;

        if (newIndex <= fullGridPager.TheGrid.PageCount)
        {
            fullGridPager.TheGrid.PageIndex = newIndex;
            BindGrid(newIndex);
        }

        //this.gridProxies.PageIndex = newIndex;
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

    private void BindGrid(int initialPage)
    {
        gridProxies.PageIndex = initialPage;
        gridProxies.DataSource = MyDataSet;
        gridProxies.DataBind();
    }

}
