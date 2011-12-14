using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Text;
using System.Xml;


    //Copyright (c) 2008-2010 by the President and Fellows of Harvard College. All rights reserved.  
    //Profiles Research Networking Software was developed under the supervision of Griffin M Weber, MD, PhD.,
    //and Harvard Catalyst: The Harvard Clinical and Translational Science Center, with support from the 
    //National Center for Research Resources and Harvard University.


    //Code licensed under a BSD License. 
    //For details, see: LICENSE.txt 
 

public partial class Direct_Direct : System.Web.UI.Page
{
  
        string KeywordString = "";
        string directserviceURL = System.Configuration.ConfigurationSettings.AppSettings["DirectServiceURL"];
        string directwaitingimageURL = "images/yui-loading.gif";

        protected void Page_Load(object sender, EventArgs e)
        {
            GetResultXMLDocument();
            
            Int64 rnd = 0;
            Random r = new Random();
            rnd = r.Next();
        }

        #region <methods/>
        public string GetSearchPhrase()
        {
            return HttpUtility.HtmlEncode(KeywordString);
        }
        public string GetKeywordString()
        {
            KeywordString = Request.QueryString["SearchPhrase"].ToString();

            return KeywordString;
        }
        protected void GetResultXMLDocument()
        {
            string QueryID = Request["QueryID"];
            if (QueryID != "")
            {
                SqlDataReader dr;
                DataIO oDataIO = new DataIO();
                dr = oDataIO.GetApiQueryHistory(cs(QueryID));
                if (dr.Read())
                {
                    string QueryXML = dr["QueryXML"].ToString();
                    string OrigQueryXML = QueryXML;
                    QueryXML = QueryXML.Replace(" xmlns=\"http://connects.profiles.schema/profiles/query\"", "");
                    XmlDocument objDoc = new XmlDocument();
                    objDoc.LoadXml(QueryXML);
                    XmlElement SearchXML = objDoc.DocumentElement;
                    KeywordString = GetXMLText(SearchXML, "//KeywordString");
                }
                dr.Dispose();
            }

        }


        public string cs(string value)
        {
            if (value == null)
                return "null";
            else
                return "'" + value.Replace("'", "''") + "'";
        }

        public string GetXMLText(XmlElement tempXML, string tempPath)
        {
            string tempT = "";
            if (tempXML != null)
            {
                XmlNode tempX;
                tempX = tempXML.SelectSingleNode(tempPath);
                if (tempX != null)
                    tempT = tempX.InnerText;
            }
            return tempT;
        }

        public string DrawMyTable()
        {
            StringBuilder sb = new StringBuilder();
            StringBuilder jsAddSites = new StringBuilder();
            sb.Append(DrawListTableStart(6, 18, "Institution|Matches", "|", "|", "450|150", "l|c"));
            Int64 OddRow = 0;
           
            DataIO oDataIO = new DataIO();
            SqlDataReader dr = oDataIO.DirectResultset();
          
            while (dr.Read())
            {
                OddRow = 1 - OddRow;
                sb.Append(DrawListTableRow("doLocalPersonSearch('" + DirectServiceURL() + "'," + dr["SiteID"] + ");", "doSiteHoverOver(" + dr["SiteID"].ToString() + ");", "doSiteHoverOut(" + dr["SiteID"].ToString() + ");", OddRow,
                    dr["SiteName"].ToString() + "|" + "<div id='SITE_STATUS_" + dr["SiteID"].ToString() + "'><div class='siteresult' style='height:16px;'></div></div>",
                    "|",
                    "450|150",
                    "l|c"));
                jsAddSites.AppendLine("var t = {}; t.SiteID = " + dr["SiteID"] + "; t.ResultPopType = ''; t.ResultDetailsURL = ''; t.FSID = ''; fsObject.push(t);");
            }
            dr.Dispose();
            sb.Append(DrawListTableEnd());

            sb.Append("<script>");
            sb.Append(jsAddSites.ToString());
            sb.Append("</script>");

            return sb.ToString();            
        }

        string DrawListTableStart(Int64 marginTop, Int64 marginBottom, string tempColName, string tempColUrl, string tempColIcon, string tempColWidth, string tempColJustify)
        {
            Int64 i = 0;
            string BasePath = System.Configuration.ConfigurationSettings.AppSettings["DirectBaseURL"];  
            string[] ColNames = tempColName.Split('|');
            string[] ColUrls = tempColUrl.Split('|');
            string[] ColIcons = tempColIcon.Split('|');
            string[] ColWidths = tempColWidth.Split('|');
            string[] ColJustifys = tempColJustify.Split('|');
            //if (ColIcons.LongLength < 0) 

            //if (marginTop == null) marginTop = 0;
            //if (marginBottom == null) marginBottom = 0;
            StringBuilder sb = new StringBuilder("");
            sb.Append("<div class='listTable' style='margin-top:" + marginTop + "px;margin-bottom:" + marginBottom + "px;'>");
            sb.Append("<table>");
            sb.Append("<tr style='font-weight:bold;background-color:#F0F4F6'>");
            for (i = 0; i < ColNames.Length; i++)
            {
                sb.Append("<td ");
                if (ColWidths[i] != "")
                    sb.Append(" style='width:" + ColWidths[i] + "px;");
                else
                {
                    sb.Append(" style='");
                }

                if (ColJustifys[i] == "l")
                    sb.Append("text-align:left;'");
                else
                    sb.Append("text-align:center;'");

                sb.Append(">");
                if (ColUrls[i] != "")
                    sb.Append("<a href='" + ColUrls[i] + "'>");

                sb.Append(ColNames[i]);

                if (ColIcons[i] == "1")
                    sb.Append("<img src='" + BasePath + "images/sort_asc.gif' alt='Sort Descending'/>");

                if (ColIcons[i] == "2")
                    sb.Append("<img src='" + BasePath + "images/sort_desc.gif' alt='Sort Ascending'/>");
                sb.Append("</a>");
                sb.Append("</td>");

                
            }
            sb.Append("</tr>");
            return sb.ToString();
        }

        public string DrawListTableRow(string tempRowClick, string tempRowMouseOver, string tempRowMouseOut,
                        Int64 tempRowOdd, string tempColText, string tempColURL, string tempColWidth,
                            string tempColJustify)
        {
            StringBuilder sb = new StringBuilder();
            string[] ColTexts = tempColText.Split('|');
            string[] ColURLs = tempColURL.Split('|');
            string[] ColWidths = tempColWidth.Split('|');
            string[] ColJustifys = tempColJustify.Split('|');

            sb.Append("<tr");
            if (tempRowOdd == 1)
                sb.Append(" style='cursor:pointer;background-color:#FFFFFF'");
            else
                sb.Append(" style='cursor:pointer;background-color:#F0F4F6'");

            

            sb.Append(" onMouseOver=\"doListTableRowOver(this);");
            if (tempRowMouseOver != "")
                sb.Append(tempRowMouseOver);

            sb.Append("\"");
            sb.Append(" onMouseOut=\"doListTableRowOut(this," + tempRowOdd + ");");
            if (tempRowMouseOut != "")
                sb.Append(tempRowMouseOut);

            sb.Append("\"");
            if (tempRowClick != "")
                sb.Append(" onClick=\"" + tempRowClick + "\"");

            sb.Append(">");
            string StyleStr = "", ClassName = "";
            for (int i = 0; i < ColTexts.Length 
                ; i++)
            {
                sb.Append("<td");
                if (ColJustifys[i] == "l")
                {
                    sb.Append(" style='text-align:left;'");
                }
                else
                {
                    sb.Append(" style='text-align:center;'");
                }

                StyleStr = "";
                if (ColWidths[i] != "")
                    StyleStr = " style='width:" + (Convert.ToInt64(ColWidths[i]) - 12).ToString() + "px;'";

                ClassName = "";
                if (ColURLs[i] != "")
                {
                    sb.Append(" onMouseOver='doListTableCellOver(this);'");
                    sb.Append(" onMouseOut='doListTableCellOut(this);'");
                    sb.Append(" onClick='doListTableCellClick(this);" + ColURLs[i] + "'");
                    ClassName = "class='listTableLink'";
                }
                sb.Append(">");
                sb.Append("<div" + StyleStr + ClassName + ">" + ColTexts[i] + "</div>");
                sb.Append("</td>");
            }
            sb.Append("</tr>");
            return sb.ToString();
        }

        public string DrawListTableEnd()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("</table>");
            sb.Append("</div>");
            return sb.ToString();
        }


        public string DirectServiceURL()
        {
            return directserviceURL;

        }
        public string DirectWaitingImageURL()
        {
            return directwaitingimageURL;
        }

        #endregion

    }
