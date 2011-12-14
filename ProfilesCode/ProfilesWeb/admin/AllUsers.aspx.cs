using System;
using System.Collections.Generic;
using System.Configuration;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using Connects.Profiles.BusinessLogic;

public partial class AllUsers : Page
{
    private void RefreshCache()
    {
        Cache[dataSourceUsers.CacheKeyDependency] = String.Empty;
    }

    private void BindPageSize()
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["PageSize"] != null)
            {
                int pageSize;
                if (int.TryParse(Request.QueryString["PageSize"], out pageSize))
                {
                    ddlPageSizes.SelectedValue = pageSize.ToString();
                }
            }
        }
        gridUsers.PageSize = int.Parse(ddlPageSizes.SelectedValue);
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        BindPageSize();

        if (!IsPostBack)
        {
            if (!string.IsNullOrEmpty(Request.QueryString["ShowUser"]))
            {
                int l_UserID;
                if (int.TryParse(Request.QueryString["ShowUser"], out l_UserID))
                {
                    ProfilesMembershipUser l_user =
                        (ProfilesMembershipUser) new ProfilesDBMembershipProviderBL().GetUserByID(l_UserID);

                    if (l_user != null)
                    {
                        int userPosition = new ProfilesDBMembershipProviderBL().GetUserPosition(l_user.UserID);

                        int recordsAtPage = userPosition/gridUsers.PageSize;
                        gridUsers.PageIndex = recordsAtPage;
                    }
                }
            }

            if (Cache.Count == 0) RefreshCache();

        }
    }

    protected void lbNew_Click(object sender, EventArgs e)
    {
        Session[GlobalConst.PageSizeSessionKey] = ddlPageSizes.SelectedValue;
        Response.Redirect(string.Format("http://{0}{1}?IsAddNew=1",
                                        Request.Url.Authority,
                                        ResolveUrl("UserEdit.aspx")));
    }
    protected void imgBtnChangePass_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect(ResolveUrl("ChangePassword.aspx"));
    }

    protected void ddlPageSizes_SelectedIndexChanged(object sender, EventArgs e)
    {
        gridUsers.PageIndex = 0;
    }

    protected void gridUsers_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "DeleteUser")
        {
            string l_deletingUserName = e.CommandArgument.ToString();
            Membership.DeleteUser(l_deletingUserName);
            RefreshCache();
            gridUsers.DataBind();
            lSuccess.Visible = true;
            lSuccess.Text = "User was removed successfully.";
        }

        if (e.CommandName == "EditUser")
        {
            int userId = int.Parse(e.CommandArgument.ToString());
            Session[GlobalConst.PageSizeSessionKey] = ddlPageSizes.SelectedValue;
            Response.Redirect(string.Format("http://{0}{1}?UserID={2}",
                                            Request.Url.Authority,
                                            ResolveUrl("UserEdit.aspx"),
                                            userId));
        }
    }

    protected void lbSearch_Click(object sender, EventArgs e)
    {
//        if (!string.IsNullOrEmpty(tbSearch.Text))
//        {
//            gridUsers.DataBind();
//        }
    }

    protected void gridUsers_DataBound(object sender, EventArgs e)
    {
        bool needToRefreshColumns = true;

        if (lstColumns.Items.Count != 0)
        {
            foreach (ListItem l_Item in lstColumns.Items)
            {
                if (l_Item.Selected)
                {
                    needToRefreshColumns = false;
                    break;
                }
            }
        }

        //when selected column names count = 0  
        if (needToRefreshColumns)
        {
            //get Default selected columns from web.config in appSettings
            string l_defaultColumnsFromConfig = ConfigurationManager.AppSettings["ProfileSearchDefaultColumns"];
            string[] l_defaultColumnsArr = l_defaultColumnsFromConfig.Split(',');

            List<string> l_AllColumns = new List<string>();
            foreach (DataControlField l_GridColumn in gridUsers.Columns)
            {
                //using filtering only for not-Templated columns
                if (!string.IsNullOrEmpty(l_GridColumn.SortExpression))
                    l_AllColumns.Add(l_GridColumn.HeaderText);
            }

            //bind listBox
            lstColumns.Items.Clear();
            lstColumns.DataSource = l_AllColumns;
            lstColumns.DataBind();

            //check "default" listBoxItems 
            foreach (ListItem l_Item in lstColumns.Items)
            {
                foreach (string columnName in l_defaultColumnsArr)
                {
                    //after split operation <string.split(',')> the last element usually is space
                    //so we must validate each value
                    if (!string.IsNullOrEmpty(columnName))
                    {
                        if (columnName == l_Item.Value)
                        {
                            l_Item.Selected = true;
                        }
                    }
                }
            }
        }

        foreach (DataControlField l_Field in gridUsers.Columns)
        {
            //when current DataControlField is aspTemplateField(Edit or Delete) then break
            if (string.IsNullOrEmpty(l_Field.SortExpression)) break;

            bool l_isVisibleColumn = false;

            foreach (ListItem l_ListItem in lstColumns.Items)
            {
                if (l_ListItem.Selected)
                {
                    if (l_ListItem.Value == l_Field.SortExpression)
                    {
                        l_isVisibleColumn = true;
                        break;
                    }
                }
            }
            l_Field.Visible = l_isVisibleColumn;
        }
    }


    protected void bShowSelectedColumns_Click(object sender, EventArgs e)
    {
        gridUsers.DataBind();
    }
}
