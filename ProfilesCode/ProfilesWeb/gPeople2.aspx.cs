﻿/*  
 
    Copyright (c) 2008-2010 by the President and Fellows of Harvard College. All rights reserved.  
    Profiles Research Networking Software was developed under the supervision of Griffin M Weber, MD, PhD.,
    and Harvard Catalyst: The Harvard Clinical and Translational Science Center, with support from the 
    National Center for Research Resources and Harvard University.


    Code licensed under a BSD License. 
    For details, see: LICENSE.txt 
  
*/
using System;
using System.Data;
using Connects.Profiles.Utility;
using Connects.Profiles.Service.DataContracts;
using Connects.Profiles.BusinessLogic;

public partial class gPeople2 : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {            
            lblPerson.Text = Request.QueryString["displayname"];

            litGoogleCode1.Text = "<script src=\"http://maps.google.com/maps?file=api&v=2&key=" +
                    _systemBL.GetGoogleKey("maps", Request.Url.ToString()) + "\" type=\"text/javascript\"></script>";

            dlGoogleMapLinks.DataSource = _systemBL.GetGoogleMapZoomLinks();
            dlGoogleMapLinks.DataBind();
            
            IDataReader reader = _userBL.GetGMapUserSimilar(Convert.ToInt32(Request.QueryString["Person"]), false);
            IDataReader reader2 = _userBL.GetGMapUserSimilar(Convert.ToInt32(Request.QueryString["Person"]), true);

            litGoogleCode2.Text = new GoogleMapHelper().MapPlotPeople2(Convert.ToInt32(Request.QueryString["Person"]), reader, reader2);
        }
    }
}
