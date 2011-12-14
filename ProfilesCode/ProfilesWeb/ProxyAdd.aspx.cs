using System;
using System.Collections;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;


using Connects.Profiles.BusinessLogic;

public partial class ProxyAdd : BasePageSecure
{
    private DepartmentBL _deptBL = new DepartmentBL();
    private InstitutionBL _instBL = new InstitutionBL();

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
            ltHeader.Text = "Add a Proxy";

            drpDepartment.DataSource = _deptBL.GetDepartments(); //Srch.GetDepartment();
            drpDepartment.DataTextField = "Department";
            drpDepartment.DataBind();
            drpDepartment.Items.Insert(0, new ListItem("--Select--"));
            drpDepartment.Items[0].Selected = true;

            drpInstitution.DataSource = _instBL.GetInstitutions(); //Srch.GetInstitutions();
            drpInstitution.DataTextField = "InstitutionName";
            drpInstitution.DataBind();
            drpInstitution.Items.Insert(0, new ListItem("--Select--"));
            drpInstitution.Items[0].Selected = true;

            HideRightColumn();
        }
    }

    protected void btnProxySearch_Click(object sender, EventArgs e)
    {
        try
        {
            string dept = "";
            string inst = "";

            if (drpDepartment.SelectedValue != "--Select--")
                dept = drpDepartment.SelectedValue;

            if (drpInstitution.SelectedValue != "--Select--")
                inst = drpInstitution.SelectedValue;


            MyDataSet = _userBL.GetProxySearch(txtLastName.Text, txtFirstName.Text, dept, inst);
            gridSearchResults.PageIndex = 0;
            gridSearchResults.DataSource = MyDataSet;
            gridSearchResults.DataBind();

            litGridHeader.Text = "Search Results (" + gridSearchResults.Rows.Count.ToString() +")";

            pnlProxySearchResults.Visible = true;
        }
        catch (Exception ex)
        {
            string err = ex.Message;
        }
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

    protected void btnSearchReset_Click(object sender, EventArgs e)
    {
        txtLastName.Text = "";
        txtFirstName.Text = "";
        drpInstitution.SelectedIndex = -1;
        drpDepartment.SelectedIndex = -1;
        gridSearchResults.DataBind();
        litGridHeader.Text = "";
        pnlProxySearchResults.Visible = false;
    }

    protected void btnSearchCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("proxy.aspx");
    }

    protected void gridSearchResults_RowDataBound(Object sender, GridViewRowEventArgs e)
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

    protected void gridSearchResults_SelectedIndexChanged(object sender, EventArgs e)
    {
        _userBL.InsertProxy(Profile.ProfileId, Convert.ToInt32(gridSearchResults.DataKeys[gridSearchResults.SelectedIndex]["UID"]));
        Response.Redirect("proxy.aspx");
    }

    protected void gridSearchResults_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gridSearchResults.PageIndex = e.NewPageIndex;
        gridSearchResults.DataSource = MyDataSet;
        gridSearchResults.DataBind();
    }
}
