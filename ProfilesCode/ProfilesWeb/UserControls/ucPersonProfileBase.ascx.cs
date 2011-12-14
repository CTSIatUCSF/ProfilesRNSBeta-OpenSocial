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
