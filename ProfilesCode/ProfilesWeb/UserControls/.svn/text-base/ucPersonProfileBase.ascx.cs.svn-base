
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
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Connects.Profiles.BusinessLogic;

public partial class UserControls_ucPersonProfileBase : BaseUserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        BindData();
    }

    private string profileId;
    public string ProfileId
    {
        get { return profileId; }
        set { profileId = value; }
    }

    protected virtual void BindData() {}
 
}
