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
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using Connects.Profiles.BusinessLogic;

public partial class ucSearchList : BaseUserControl
{
    private Boolean showSimilarCoauthors = false;

    private int _profileId=0;

    public int ProfileId
    {
        get { return _profileId; }
        set { _profileId = value; }
    }

    private string queryType;
    public string QueryType
    {
        get { return queryType; }
        set { queryType = value; }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (queryType.Length>0)
            {
                BindListpeople();
            }
        }
    }

    #region Datalist Bind Data
    private void BindListpeople()
    {
        int count = 0;
        switch (QueryType)
        {
            case "MeSH":
                dlMeSH.Visible = true;
                dlPeopleList.Visible = false;
                dlMeSH.DataSource = _userBL.GetUserMESHkeywords(_profileId, "False", ref count);
                dlMeSH.DataBind();
                ltsubHeader.Text = "Keywords-MeSH (" + count + ")";// +count;
                break;
            case "CoAuthors":
                dlMeSH.Visible = false;
                dlPeopleList.Visible = true;
                dlPeopleList.DataSource = _userBL.GetUserCoAuthors(_profileId, "False", ref count);
                dlPeopleList.DataBind();
                ltsubHeader.Text = "Co-Authors (" + count + ")";
                break;
            case "SimilarPeople":
                dlMeSH.Visible = false;
                dlPeopleList.Visible = true;
                dlPeopleList.DataSource = _userBL.GetUserSimilarPeople(_profileId, "False", ref count);
                dlPeopleList.DataBind();
                ltsubHeader.Text = "Similar People (" + count + ")";
                break;
            case "MyDept":
                dlMeSH.Visible = false;
                dlPeopleList.Visible = true;
                dlPeopleList.DataSource = _userBL.GetUserDepartmentPeople(_profileId, "False", ref count);
                dlPeopleList.DataBind();
                ltsubHeader.Text = "In My Department (" + count + ")"; ;
                break;
        }

    }
    #endregion

    #region dlMeSH OnItemDataBound
    protected void dlMeSH_OnItemDataBound(Object sender, DataListItemEventArgs e)
    {
        int userID = GetPersonFromQueryString();

        DataRowView drv = (DataRowView)e.Item.DataItem;
        HyperLink hypLnk;
        if ((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem))
        {
            if (drv.Row["MeSHKeywords"].ToString() != DBNull.Value.ToString())
            {
                hypLnk = (HyperLink)(e.Item.FindControl("hypLnkMeSHlist"));
                hypLnk.NavigateUrl = "~\\Search.aspx?From=MeSH&Word=" + Server.UrlEncode(drv["MeSHKeywords"].ToString());
            }
        }
    }
    #endregion

    #region dlPeopleList OnItemDataBound
    protected void dlPeopleList_OnItemDataBound(Object sender, DataListItemEventArgs e)
    {
        DataRowView drv = (DataRowView)e.Item.DataItem;
        HyperLink hypLnk;
        Label lbl;
        if ((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem))
        {                                                                                 //To check if the BirthDate has null values
            if (drv.Row["username"].ToString() != DBNull.Value.ToString())
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
                    showSimilarCoauthors = true;
                }
            }
        }
        else
        {
            PlaceHolder phSimilarCoauthors = (PlaceHolder)(e.Item.FindControl("phSimilarCoauthors"));
            phSimilarCoauthors.Visible = showSimilarCoauthors;

            int userID = GetPersonFromQueryString();

            if (userID != 0)
            {
                HyperLink hypLnkMap = (HyperLink)(e.Item.FindControl("hypNeighborMap"));
                if (QueryType == "CoAuthors")
                {
                    if (Profile.UserName.Length == 0)
                    {
                        hypLnkMap.NavigateUrl = "~/gcoauth.aspx?person=" + userID.ToString();
                    }
                    else
                    {
                        hypLnkMap.NavigateUrl = "~/gcoauth.aspx?person=" + userID.ToString() + "&sso=Y";
                    }
                }
                else
                {
                    if (Profile.UserName.Length == 0)
                    {
                        hypLnkMap.NavigateUrl = "~/gpeople.aspx?person=" + userID.ToString();
                    }
                    else
                    {
                        hypLnkMap.NavigateUrl = "~/gpeople.aspx?person=" + userID.ToString() + "&sso=Y";
                    }
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
