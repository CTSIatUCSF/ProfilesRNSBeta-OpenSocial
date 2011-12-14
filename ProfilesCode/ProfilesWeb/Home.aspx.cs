using System;

public partial class Home : System.Web.UI.Page
{
    
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Redirect("Search.aspx");
    }
}
