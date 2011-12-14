using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Connects.Profiles.BusinessLogic;
using Connects.Profiles.Service.DataContracts;

public partial class UserControls_ucSimilarPeopleMap : BaseUserControl
{
    private Boolean _showSimilarCoauthors = false;
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
    public void HideMapTab()
    {
        divMapView.Attributes.Add("style", "display:none");
    }

    protected void BindData()
    {
        if (_profileId != 0)
        {
            int count = 0;

            dlPeopleList.DataSource = _userBL.GetUserSimilarPeople(_profileId, "False", ref count);
            dlPeopleList.DataBind();
            ltsubHeader.Text = "Similar People (" + count + ")";
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
            }
        }
        if (e.Item.ItemType != ListItemType.Footer)
        {
            lbl = (Label)(e.Item.FindControl("LblRowNo"));
            lbl.Text = Convert.ToString(e.Item.ItemIndex + 1);
            lbl.Style.Add("Color", "#333");
            lbl.Visible = true;

            if (drv.Row["CoAuthor"] != null)
            {
                if (drv.Row["CoAuthor"].ToString().Length > 0)
                {
                    _showSimilarCoauthors = true;
                }
            }
        }
        else
        {
            PlaceHolder phSimilarCoauthors = (PlaceHolder)(e.Item.FindControl("phSimilarCoauthors"));
            phSimilarCoauthors.Visible = _showSimilarCoauthors;

            int personId = GetPersonFromQueryString();

            PersonList pList = new Connects.Profiles.Service.ServiceImplementation.ProfileService().GetPersonFromPersonId(personId);

            //if (pList.Person[0].Address.Latitude > 0)
            //{
            //    HyperLink hypLnkMap = (HyperLink)(e.Item.FindControl("hypNeighborMap"));
            //    hypLnkMap.NavigateUrl = "~/gpeople.aspx?person=" + personId.ToString();
            //}
            //else
            //{
            //    PlaceHolder ph = (PlaceHolder)(e.Item.FindControl("phGoogleMap"));
            //    ph.Visible = false;
            //}
        }
    }
    #endregion
}
