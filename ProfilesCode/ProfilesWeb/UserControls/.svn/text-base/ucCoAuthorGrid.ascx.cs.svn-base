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
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using Connects.Profiles.BusinessLogic;
using Connects.Profiles.Service.DataContracts;
using System.Collections.Generic;

public partial class UserControls_ucCoAuthorGrid : BaseUserControl
{

    private int _profileId;
    public int ProfileId
    {
        get { return _profileId; }
        set
        {
            _profileId = value;
            BindGrdCoAuthors();
        }
    }
    
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    #region Load Grid Recent CoAuthors: grdAuthors
    private void BindGrdCoAuthors()
    {
        Profiles searchReq = ProfileHelper.GetNewProfilesDefinition();

        searchReq.QueryDefinition.PersonID = System.Convert.ToString(ProfileId);

        //searchReq.OutputOptions.OutputFilterList = new OutputFilterList();

        OutputFilterList reqOutputFilterList = new OutputFilterList();
        List<OutputFilter> reqFilterList = new List<OutputFilter>(1);

        OutputFilter reqFilter = new OutputFilter() { Summary = false, Text = "CoAuthorList" };
        reqFilterList.Add(reqFilter);
        reqOutputFilterList.OutputFilter = reqFilterList;

        searchReq.OutputOptions.OutputFilterList = reqOutputFilterList;
                
        grdAuthors.DataSource = new Connects.Profiles.Service.ServiceImplementation.ProfileService().ProfileSearch(searchReq).Person[0].PassiveNetworks.CoAuthorList.CoAuthor;
        grdAuthors.DataBind();

    }
    #endregion

    #region grdAuthors OnRowCreated Event
    protected void grdAuthors_OnRowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            DataRowView drv = e.Row.DataItem as DataRowView;
            HyperLink hypLnk;

            if (drv != null)
            {
                if (drv["CoAuthors"].ToString() != string.Empty)
                {
                    hypLnk = new HyperLink();
                    hypLnk = (HyperLink)(e.Row.Cells[1].FindControl("hypLnkAuthors"));
                    hypLnk.NavigateUrl = "~\\ProfileDetails.aspx?From=Pinfo&Person=" + drv["PersonId"].ToString();
                }
            }
        }
    }
    #endregion
}
