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

public partial class UserControls_ucKeywords : BaseUserControl
{
    private int _profileId=0;

    public int ProfileId
    {
        get { return _profileId; }
        set
        {
            _profileId = value;
            BindGrdKeywords();
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        //if (!IsPostBack)
        //{
        //    //Bind Grid Keywords
        //    BindGrdKeywords();
        //}
    }

    #region Load Grid Keywords MeSH: grdKeywords
    /// <summary>
    /// To Bind data to MeSHkeywords
    /// </summary>
    /// <param name="UID"></param>
    private void BindGrdKeywords()
    {
        int Count = 0;
        grdKeywords.DataSource = _userBL.GetUserMESHkeywords(_profileId, "True", ref Count);
        grdKeywords.DataBind();

        if (!grdKeywords.Rows.Count.Equals(0))
        {
            HyperLink hl = (HyperLink)grdKeywords.FooterRow.FindControl("hypLnkAllKeywords");
            hl.Text = "See all (" + Count + ") keywords";
            hl.NavigateUrl = "~/Keywords.aspx?Person=" + _profileId.ToString();

            HasData = true;
        }
    }
    #endregion

    #region grdKeywords OnRowCreated Event
    protected void grdKeywords_OnRowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            DataRowView drv = e.Row.DataItem as DataRowView;
            HyperLink hypLnk;

            if (drv != null)
            {
                if (drv["MeSHKeywords"].ToString() != string.Empty)
                {
                    hypLnk = new HyperLink();
                    hypLnk = (HyperLink)(e.Row.Cells[0].FindControl("hypLnkKeywords"));
                    hypLnk.NavigateUrl = "~\\Search.aspx?From=MeSH&Word=" + Server.UrlEncode(drv["MeSHKeywords"].ToString());
                }
            }
        }
    }
    #endregion
}
