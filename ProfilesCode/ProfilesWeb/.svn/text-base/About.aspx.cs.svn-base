/*  
 
    Copyright (c) 2008-2010 by the President and Fellows of Harvard College. All rights reserved.  
    Profiles Research Networking Software was developed under the supervision of Griffin M Weber, MD, PhD.,
    and Harvard Catalyst: The Harvard Clinical and Translational Science Center, with support from the 
    National Center for Research Resources and Harvard University.


    Code licensed under a BSD License. 
    For details, see: LICENSE.txt 
  
*/

using System;
using System.Web.UI;
using Connects.Profiles.BusinessLogic;

public partial class About : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Literal1.Text = _systemBL.GetAboutText();

        ShowControl("pnlChkList", false);
        RefreshUpdatePanel("upnlMinisearch");

        // Make sure the right panel is hidden
        HideRightColumn();
    }
}
