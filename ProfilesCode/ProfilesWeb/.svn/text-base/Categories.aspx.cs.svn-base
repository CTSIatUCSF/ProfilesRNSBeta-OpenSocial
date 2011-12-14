/*  
 
    Copyright (c) 2008-2010 by the President and Fellows of Harvard College. All rights reserved.  
    Profiles Research Networking Software was developed under the supervision of Griffin M Weber, MD, PhD.,
    and Harvard Catalyst: The Harvard Clinical and Translational Science Center, with support from the 
    National Center for Research Resources and Harvard University.


    Code licensed under a BSD License. 
    For details, see: LICENSE.txt 
  
*/
using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using Connects.Profiles.BusinessLogic;

public partial class Categories : BasePage
{
    private int _personId;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {

                if (Request.QueryString["Person"] != null) //Check for Null values
                {
                    _personId = GetPersonFromQueryString();
                    hypBack.Attributes.Add("onclick", "Backward('" + _personId.ToString() + "')");
                    this.ProfileRightSide1.ProfileId = _personId;

                    hypLnkViewProfile.Visible = true;
                    hypLnkViewProfile.NavigateUrl = "~/ProfileDetails.aspx?Person=" + Server.UrlEncode(_personId.ToString());

                    DataRow dro = _userBL.GetUserInformation(_personId).Rows[0];

                    Session["PersonIsMy"] = (string)dro["Lastname"] + ", " + ((string)dro["Firstname"]).Substring(0, 1);

                    ltProfileName.Text = (string)dro["DisplayName"];

                    //Persist names into viewstate
                    Session["Lname"] = dro["Lastname"].ToString();
                    Session["Fname"] = dro["Firstname"].ToString();
                }
            }

            catch (Exception Ex)
            {
                throw (Ex);
            }

            Page.Title = (string)Session["Fname"] + " " + (string)Session["Lname"] + " | " + Page.Title;
            LoadCategories();
        }
    }

    protected void LoadCategories()
    {

        int count = 0;
        DataTable dt = _userBL.GetUserMESHCategories(_personId, ref count);

        string sg = "";
        int totkw = Convert.ToInt32(dt.Rows[0]["Total"]);  //Total Keywords
        int nkw = 0;
        int col = 1;
     
        int groupcount = 0;

        System.Text.StringBuilder HTML = new System.Text.StringBuilder();

        HTML.Append("<div class=\"keywordCategories\">");
        HTML.Append("<div class=\"tabInfoText\">Keywords are listed here are grouped according to their &quot;semantic&quot; categories. Within each category,<br>up to ten keywords are shown, in decreasing order of relevance.</div>");
        HTML.Append("<table>");
        HTML.Append("<tr>");
        HTML.Append("<td valign=\"top\">");

        for (int loop = 0; loop < dt.Rows.Count; loop++)
        {
            if (dt.Rows[loop]["semanticgroupname"].ToString() != sg)
            {
                if (sg != "")
                {
                    HTML.Append("</div>");
                }
                if ((col < 3) && (nkw > (totkw / 3) * col))
                {
                    HTML.Append("</td><td valign=\"top\">");
                    col = col + 1;
                }
                sg = dt.Rows[loop]["semanticgroupname"].ToString();
                nkw = nkw + Convert.ToInt32(dt.Rows[loop]["n"]);
                HTML.Append("<div class=\"kwsg\">" + sg + "</div>");
                HTML.Append("<div class=\"kwsgbox\">");
                groupcount += 1;
            }           


            HTML.Append("<a href=\"Search.aspx?From=MeSH&amp;Word=" + Server.UrlEncode(dt.Rows[loop]["mesh_header"].ToString()) + "\">" + dt.Rows[loop]["mesh_header"].ToString() + "</a><br/>");
            //w = 150 * Convert.ToInt32(dt.Rows[loop]["Weight"]);
            HTML.Append("<div class=\"kwbar\"></div>");

        }

        HTML.Append("</td>");
        HTML.Append("</tr>");
        HTML.Append("</table>");
        HTML.Append("</div>");


        ltsubHeader.Text = "Categories (" + groupcount + ")";// +count;

        ltCategories.Text = HTML.ToString();

    }





}
