using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ChangePassword : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void ChangePassword1_Cancel(object sender, EventArgs e)
    {

        Response.Redirect(((MasterPage)Master).GetProfileLink);
    }

    protected void ChangePassword1_ContinueButtonClick(object sender, EventArgs e)
    {
        Response.Redirect(((MasterPage)Master).GetProfileLink);
    }
}
