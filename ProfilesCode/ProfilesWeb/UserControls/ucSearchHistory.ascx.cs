using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Connects.Profiles.BusinessLogic;

public partial class UserControls_ucSearchHistory : BaseUserControl
{

    protected void Page_Load(object sender, EventArgs e)
    {
        BindSearchHistory();
        //if (Request["Person"] != null && Profile.UserId != null)
        //{
        //    if (Request["Person"] != null)
        //    {
        //        BindSearchHistory();
        //    }
        //}
    }

    private void BindSearchHistory()
    {
        grdSearchHistory.DataSource = _userBL.GetUserSearchHistory(Profile.UserId);
        grdSearchHistory.DataBind();

        //Hide Link Clear if Search History returns no rows
        if (grdSearchHistory.Rows.Count == 0)
        {
            LnkClearHistory.Visible = false;
        }
        else
        {
            LnkClearHistory.Visible = true;
        }
    }    

    protected void LnkClearHistory_Click(object sender, EventArgs e)
    {
        if (Profile.UserId != null)
        {
            _userBL.ClearSearchHistory(Profile.UserId);
            BindSearchHistory(); ;
        }
    }

    #region Grid Search History: OnRowCreated
    #region OnRowCreated

    protected void grdSearchHistory_OnRowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            DataRowView drv = e.Row.DataItem as DataRowView;
            HyperLink hypLnk;

            if (drv != null)
            {
                if (drv["ProfileName"].ToString() != string.Empty)
                {
                    hypLnk = new HyperLink();
                    hypLnk = (HyperLink)(e.Row.Cells[1].FindControl("hypLnkSearchHistory"));
                    hypLnk.NavigateUrl = "~\\ProfileDetails.aspx?Person=" + drv["PersonId"].ToString();
                }
            }
        }
    }
    #endregion
    #endregion
}
