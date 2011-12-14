using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UCSFErrorPage : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ShowControl("left", false);

        // Make sure the right panel is hidden
        HideRightColumn();

        // clear the error
        litError.Text = "<h2>We’re sorry for the inconvenience, an error has occurred</h2><p>An unexpected error occurred on our website. The website administrator has been notified.</p>";
    }
}
