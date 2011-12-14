using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ErrorPage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["GLOBAL_ERROR"]!=null)
        {
            litError.Text = HttpContext.Current.Session["GLOBAL_ERROR"].ToString();
        }
        Session["GLOBAL_ERROR"] = null;
    }
}
