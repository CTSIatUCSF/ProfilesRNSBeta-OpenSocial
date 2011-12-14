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

public partial class UserControls_ucSimilarPeople : BaseUserControl
{
    private int _profileId=0;
    public int ProfileId
    {
        get { return _profileId; }
        set {
                _profileId = value;
                BindGrdSimilarPeople();
            }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        //if (!IsPostBack)
        //{
        //    //Bind Similar People
        //    BindGrdSimilarPeople();
        //}
    }

    #region Load Grid similarPeople: grdSimilarPeople
    private void BindGrdSimilarPeople()
    {
        int Count = 0;
        grdSimilarPeople.DataSource = _userBL.GetUserSimilarPeople(_profileId, "True", ref Count);
        grdSimilarPeople.DataBind();

        if (!grdSimilarPeople.Rows.Count.Equals(0))
        {
            HyperLink hl = (HyperLink)grdSimilarPeople.FooterRow.FindControl("hypLnkSimiPeople");
            hl.Text = "See all (" + Count + ") people";
            hl.NavigateUrl = "~/SimilarPeople.aspx?Person=" + _profileId.ToString();

            HasData = true;
        }
    }
    #endregion

    #region grdSimilarPeople OnRowCreated Event
    protected void grdSimilarPeople_OnRowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            DataRowView drv = e.Row.DataItem as DataRowView;
            HyperLink hypLnk;

            if (drv != null)
            {
                if (drv["SimilarPeople"].ToString() != string.Empty)
                {
                    hypLnk = new HyperLink();
                    hypLnk = (HyperLink)(e.Row.Cells[1].FindControl("hypLnkSimilarPeople"));
                    hypLnk.NavigateUrl = "~\\ProfileDetails.aspx?From=Pinfo&Person=" + drv["PersonID"].ToString();
                }
            }
        }
    }
    #endregion


}
