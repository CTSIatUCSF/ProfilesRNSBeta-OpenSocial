/*  
 
    Copyright (c) 2008-2010 by the President and Fellows of Harvard College. All rights reserved.  
    Profiles Research Networking Software was developed under the supervision of Griffin M Weber, MD, PhD.,
    and Harvard Catalyst: The Harvard Clinical and Translational Science Center, with support from the 
    National Center for Research Resources and Harvard University.


    Code licensed under a BSD License. 
    For details, see: LICENSE.txt 
  
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Connects.Profiles.BusinessLogic;

public partial class UserControls_ucKeywordMap : BaseUserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        this.BindData();
    }

    private int _profileId;
    public int ProfileId
    {
        get { return _profileId; }
        set { _profileId = value; }
    }


    private void BindData()
    {
        int count = 0;

        if (_profileId != 0)
        {
            dlMeSH.DataSource = _userBL.GetUserMESHkeywords(_profileId, "False", ref count);
            dlMeSH.DataBind();
            ltsubHeader.Text = "Keywords (" + count + ")";// +count;
           
        }
    }

    #region dlMeSH OnItemDataBound
    protected void dlMeSH_OnItemDataBound(Object sender, DataListItemEventArgs e)
    {
        int userId = GetPersonFromQueryString();

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


}
