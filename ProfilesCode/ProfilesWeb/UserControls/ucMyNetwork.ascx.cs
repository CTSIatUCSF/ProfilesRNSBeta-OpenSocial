using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Connects.Profiles.BusinessLogic;

public partial class UserControls_ucMyNetwork : BaseUserControl
{
    private String strRedirectURL = System.Configuration.ConfigurationManager.AppSettings["LoginURL"].ToString();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Update();
        }
    }

    public void BindUserNetwork()
    {
        grdNetwork.DataSource = _userBL.GetUserNetwork(Profile.UserId);
        grdNetwork.DataBind();

        //Hide Link if Grid Networks returns no rows
        if (grdNetwork.Rows.Count == 0)
        {
            LnkNetwork.Visible = false;
        }
        else
        {
            LnkNetwork.Visible = true;
        }
    }

    #region Grid NetWork: OnRowCreated, OnRowDeleting

    protected void grdNetwork_OnRowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            DataRowView drv = e.Row.DataItem as DataRowView;
            HyperLink hypLnk;

            if (drv != null)
            {
                if (drv["MyNetwork"].ToString() != string.Empty)
                {
                    hypLnk = new HyperLink();
                    hypLnk = (HyperLink)(e.Row.Cells[1].FindControl("hypLnkNetwork"));
                    hypLnk.NavigateUrl = "~\\ProfileDetails.aspx?Person=" + drv["PersonId"].ToString();
                }
            }
        }
    }

    #region OnRowDeleting
    protected void grdNetwork_OnRowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            if (Profile.UserId != 0)
            {
                _userBL.UpdateUserNetwork(Profile.UserId, Convert.ToInt32(grdNetwork.DataKeys[e.RowIndex].Value), "Network");
                BindUserNetwork();

                Notify();
            }
            else
            {
                Response.Redirect(strRedirectURL);
            }
        }
        catch (Exception ex)
        {
            throw (ex);
        }
    }

    private void UpdateCompanionControls()
    {
        
    }

    #endregion
    #endregion

    public override void Update()
    {
        BindUserNetwork();
    }
}
