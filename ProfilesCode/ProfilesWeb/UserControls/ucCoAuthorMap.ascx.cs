using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Connects.Profiles.BusinessLogic;

public partial class UserControls_ucCoAuthorMap : BaseUserControl
{
    private int _profileId=0;
    public int ProfileId
    {
        get { return _profileId; }
        set { _profileId = value; }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        BindData();
    }

    protected void BindData()
    {
        if (_profileId != 0)
        {
            int count = 0;

            dlPeopleList.DataSource = _userBL.GetUserCoAuthors(_profileId, "False", ref count);
            dlPeopleList.DataBind();
            ltsubHeader.Text = "Co-Authors (" + count + ")";
        }
    }

    #region dlPeopleList OnItemDataBound
    protected void dlPeopleList_OnItemDataBound(Object sender, DataListItemEventArgs e)
    {
        DataRowView drv = (DataRowView)e.Item.DataItem;
        HyperLink hypLnk;
        Label lbl;

        if ((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem))
        {                                                                                 //To check if the BirthDate has null values
            if (drv.Row["PersonId"].ToString() != DBNull.Value.ToString())
            {

                hypLnk = (HyperLink)(e.Item.FindControl("hypLnkPeopleList"));
                //
                hypLnk.NavigateUrl = "~\\ProfileDetails.aspx?From=SE&Person=" + drv["PersonId"].ToString();

                lbl = (Label)(e.Item.FindControl("LblRowNo"));
                lbl.Text = Convert.ToString(e.Item.ItemIndex + 1);
                lbl.Style.Add("Color", "#333");
                lbl.Visible = true;

            }
        }
        else if (e.Item.ItemType == ListItemType.Footer)
        {
            //PlaceHolder phSimilarCoauthors = (PlaceHolder)(e.Item.FindControl("phSimilarCoauthors"));
            //phSimilarCoauthors.Visible = showSimilarCoauthors;

            if (_profileId != 0)
            {
                HyperLink hypLnkMap = (HyperLink)(e.Item.FindControl("hypNeighborMap"));
                if (Profile.UserName.Length == 0)
                {
                    hypLnkMap.NavigateUrl = "~/gCoAuth.aspx?person=" + _profileId.ToString();
                }
                else
                {
                    hypLnkMap.NavigateUrl = "~/gCoAuth.aspx?person=" + _profileId.ToString() + "&sso=Y";
                }
            }
            else
            {
                PlaceHolder ph = (PlaceHolder)(e.Item.FindControl("phGoogleMap"));
                ph.Visible = false;
            }
        }

    }
    #endregion
}
