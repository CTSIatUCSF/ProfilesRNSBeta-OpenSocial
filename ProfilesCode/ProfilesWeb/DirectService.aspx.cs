using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using System.Data.SqlClient;
using System.Text;
using System.Net;
using System.IO;
using System.Net.Cache;
using System.Configuration;


    //Copyright (c) 2008-2010 by the President and Fellows of Harvard College. All rights reserved.  
    //Profiles Research Networking Software was developed under the supervision of Griffin M Weber, MD, PhD.,
    //and Harvard Catalyst: The Harvard Clinical and Translational Science Center, with support from the 
    //National Center for Research Resources and Harvard University.


    //Code licensed under a BSD License. 
    //For details, see: LICENSE.txt 
 
public partial class Direct_DirectService : System.Web.UI.Page
{    
    

    DataIO oDataIO;
    SqlCommand sqlCmd;    
    
    int[] SiteIDs;
    string[] URLs;
    string[] FSIDs;
    Int64 sites = 0;

    List<Site> ListOfSites;

    protected void Page_Load(object sender, EventArgs e)
    {
        DrawUIOnLoad();
    }

   protected void DrawUIOnLoad()
        {
            string DirectServiceURL = ConfigurationSettings.AppSettings["DirectServiceURL"];
            string ProfilesURL = ConfigurationSettings.AppSettings["URLBASE"]; ;
            string PopulationTypeText = ConfigurationSettings.AppSettings["DirectPopulationType"];
            int QueryTimeout = 15;

            try
            {
                QueryTimeout = Convert.ToInt16(ConfigurationSettings.AppSettings["DirectQueryTimeout"]);
            }
            catch { }




            string sql = string.Empty;
            string ResultDetailsURL = string.Empty;
            string strResult = "";
            XmlElement ResultXML = null;
            oDataIO = new DataIO();
            SqlConnection Conn = new SqlConnection();
            Conn = oDataIO.GetDBConnection("ProfilesDB");
            //Conn.Open();
            sqlCmd = new SqlCommand();
            sqlCmd.Connection = Conn;

            if (Request["Request"] == null) { return; }

            string task = Request["Request"].ToLower();
            switch (task)
            {
                case "getsites":
                    string ResultStr = "<?xml version=\"1.0\" encoding=\"UTF-8\" ?>" + "<site-list>";

                    SqlDataReader dr;
                    dr = oDataIO.GetSitesOrderBySortOrder();
                    while (dr.Read())
                    {
                        Int64 SiteID = Convert.ToInt64(dr["SiteID"]);
                        string SiteName = dr["SiteName"].ToString();
                        string QueryURL = dr["QueryURL"].ToString();
                        if (SiteName == null) SiteName = "";
                        if (QueryURL == null) QueryURL = "";
                        ResultStr = ResultStr + "<site-description><site-id>" + SiteID + "</site-id><name>" + cx(SiteName) + "</name><aggregate-query>" + cx(QueryURL) + "</aggregate-query></site-description>";
                    }
                    dr.Dispose();
                    ResultStr += "</site-list>";
                    Response.ContentType = "text/xml";
                    Response.AddHeader("Content-Type", "text/xml;charset=UTF-8");
                    //Response.ContentEncoding.CodePage = 65001;
                    Response.Charset = "UTF-8";

                    Response.Write(ResultStr);
                    break;
                case "incomingcount":
                    string q = Request["SearchPhrase"].Trim();
                    // Enter log record
                    sql = "insert into FSLogIncoming(Details,ReceivedDate,RequestIP,QueryString) " +
                         " values (0,GetDate()," + cs(Request.ServerVariables["REMOTE_ADDR"]) + "," + cs(q) + ")";
                    sqlCmd.CommandText = sql;
                    sqlCmd.CommandType = System.Data.CommandType.Text;
                    // Execute query
                    string QueryXML = "<Profiles Operation=\"GetPersonList\" Version=\"2\" xmlns=\"http://connects.profiles.schema/profiles/query\"><QueryDefinition><Name><LastName></LastName><FirstName></FirstName></Name><FacultyTypeList></FacultyTypeList><FacultyRankList></FacultyRankList><Affiliations><AffiliationList><Affiliation><InstitutionName></InstitutionName><DepartmentName></DepartmentName></Affiliation></AffiliationList></Affiliations><PersonFilterList></PersonFilterList><Keywords><KeywordString>" + cx(q) + "</KeywordString></Keywords></QueryDefinition><OutputOptions StartRecord=\"1\" MaxRecords=\"1\"></OutputOptions></Profiles>";
                    dr = oDataIO.GetPersonList_xml(cs(QueryXML));
                    if (dr.Read())
                    {
                        strResult = dr[0].ToString();
                    }
                    dr.Dispose();

                    // Parse results
                    strResult = strResult.Replace(" xmlns=\"http://connects.profiles.schema/profiles/personlist\"", "");
                    XmlDocument objDoc = new XmlDocument();
                    objDoc.LoadXml(strResult);
                    ResultXML = objDoc.DocumentElement;
                    string QueryID = ResultXML.GetAttribute("QueryID");
                    string ResultCount = ResultXML.GetAttribute("TotalCount");

                    // Form result message
                    ResultStr = "<?xml version=\"1.0\" encoding=\"UTF-8\" ?>";
                    ResultStr += "<aggregation-result>";
                    ResultStr += "<count>" + ResultCount + "</count>";
                    ResultStr += "<population-type>" + PopulationTypeText + "</population-type>";
                    ResultStr += "<preview-URL>" + DirectServiceURL + "?Request=IncomingPreview&amp;SearchPhrase=" + cx(q) + "</preview-URL>";
                    ResultStr += "<search-results-URL>" + DirectServiceURL + "?Request=IncomingDetails&amp;SearchPhrase=" + cx(q) + "</search-results-URL>";
                    ResultStr += "</aggregation-result>";

                    // Send result
                    Response.ContentType = "text/xml";
                    Response.AddHeader("Content-Type", "text/xml;charset=UTF-8");
                    //Response.ContentEncoding.CodePage = 65001;
                    Response.Charset = "UTF-8";
                    Response.Write(ResultStr);
                    break;
                case "incomingdetails":
                    q = Request["SearchPhrase"].Trim();

                    // Enter log record
                    sql = "insert into FSLogIncoming(Details,ReceivedDate,RequestIP,QueryString) ";
                    sql += " values (1,GetDate()," + cs(Request.ServerVariables["REMOTE_ADDR"]) + "," +
                            cs(q) + ")";
                    sqlCmd.CommandType = System.Data.CommandType.Text;
                    sqlCmd.CommandText = sql;
                    int iResult = sqlCmd.ExecuteNonQuery();

                    // Execute queryA
                    QueryXML = "<Profiles Operation=\"GetPersonList\" Version=\"2\" xmlns=\"http://connects.profiles.schema/profiles/query\"><QueryDefinition><Name><LastName></LastName><FirstName></FirstName></Name><FacultyTypeList></FacultyTypeList><FacultyRankList></FacultyRankList><Affiliations><AffiliationList><Affiliation><InstitutionName></InstitutionName><DepartmentName></DepartmentName></Affiliation></AffiliationList></Affiliations><PersonFilterList></PersonFilterList><Keywords><KeywordString>" + cx(q) + "</KeywordString></Keywords></QueryDefinition><OutputOptions StartRecord=\"1\" MaxRecords=\"1\"></OutputOptions></Profiles>";
                    dr = oDataIO.GetPersonList_xml(cs(QueryXML));
                    if (dr.Read())
                        strResult = dr[0].ToString();

                    dr.Dispose();

                    // Parse results
                    strResult = strResult.Replace(" xmlns=\"http://connects.profiles.schema/profiles/personlist\"", "");
                    objDoc = new XmlDocument();
                    objDoc.LoadXml(strResult);
                    ResultXML = objDoc.DocumentElement;
                    QueryID = ResultXML.GetAttribute("QueryID");
                    ResultCount = ResultXML.GetAttribute("TotalCount");

                    // Redirect user to the results
                    //Response.Redirect(ProfilesURL + "/search/people/results/" + QueryID);
                    Response.Redirect(ProfilesURL + "Search.aspx?From=SP&Keyword=" + q);
                    break;
                case "incomingpreview":
                    q = Request["SearchPhrase"].Trim();

                    Response.Write(DisplayPageHeader());

                    // Execute query
                    QueryXML = "<Profiles Operation=\"GetPersonList\" Version=\"2\" xmlns=\"http://connects.profiles.schema/profiles/query\"><QueryDefinition><Name><LastName></LastName><FirstName></FirstName></Name><FacultyTypeList></FacultyTypeList><FacultyRankList></FacultyRankList><Affiliations><AffiliationList><Affiliation><InstitutionName></InstitutionName><DepartmentName></DepartmentName></Affiliation></AffiliationList></Affiliations><PersonFilterList></PersonFilterList><Keywords><KeywordString>" + cx(q) + "</KeywordString></Keywords></QueryDefinition><OutputOptions StartRecord=\"1\" MaxRecords=\"1\"></OutputOptions></Profiles>";
                    dr = oDataIO.GetPersonList_xml(cs(QueryXML));
                    if (dr.Read())
                    {
                        strResult = dr[0].ToString();
                    }
                    dr.Dispose();

                    // Parse results
                    strResult = strResult.Replace(" xmlns=\"http://connects.profiles.schema/profiles/personlist\"", "");

                    XmlDocument objDocincomepreview = new XmlDocument();
                    objDocincomepreview.LoadXml(strResult);
                    ResultXML = objDocincomepreview.DocumentElement;
                    QueryID = ResultXML.GetAttribute("QueryID");
                    ResultCount = ResultXML.GetAttribute("TotalCount");

                    Response.Write("<div style=\"width:260px;text-align:center;\"><b>");
                    if (Convert.ToInt64(ResultCount) == 0)
                        Response.Write("no people were found");

                    if (Convert.ToInt64(ResultCount) == 1)
                        Response.Write("one person was found");

                    if (Convert.ToInt64(ResultCount) > 1)
                        Response.Write(ResultCount + " people were found");

                    Response.Write("</b></div>");

                    if (Convert.ToInt64(ResultCount) > 0)
                    {
                        Response.Write("<div style=\"border-top:1px solid #999;width:260px;height:1px;overflow:hidden;margin:3px 0 3px 0;\"></div>");
                        Response.Write("<div style=\"width:290px;\">");
                        dr = oDataIO.GetFacultyRank(QueryID);
                        Int64 wz = 0;
                        while (dr.Read())
                        {
                            if (Convert.ToInt64(dr["n"]) > wz) wz = Convert.ToInt64(dr["n"]);
                        }

                        dr = oDataIO.GetFacultyRank(QueryID);

                        while (dr.Read())
                        {
                            Int64 w = 1 + Convert.ToInt64(100 * Convert.ToInt64(dr["n"]) / (wz * 1.000000));
                            Response.Write("<table cellpadding=\"0\" cellspacing=\"0\">");
                            Response.Write("<tr>");
                            Response.Write("<td style=\"width:120px; text-align:right; border-right:1px solid #000; padding-right:3px;\">" + dr["facultyrank"] + "</td>");
                            Response.Write("<td style=\"width:" + w.ToString() + "px; background-color:#900; \"></td>");
                            Response.Write("<td style=\"\">" + dr["n"] + "</td>");
                            Response.Write("<tr>");
                            Response.Write("</tr>");
                            Response.Write("</table>");
                        }
                    }
                    Response.Write("<div style=\"border-top:1px solid #999;width:260px;height:1px;overflow:hidden;margin:3px 0 3px 0;\"></div>");
                    Response.Write("<div style=\"width:260px;text-align:center;font-size:10px;\">Powered by Harvard Catalyst Profiles</div>");
                    Response.Write("</div>");
                    Response.Write("</body>");
                    Response.Write("</html>");
                    break;
                case "outgoingcount":
                    if (Request["blank"] == "y")
                    {
                        Response.Write("<html><body></body></html>");
                        Response.End();
                    }


                    string SearchPhrase = Request["SearchPhrase"];


                    Response.Write("<script>parent.dsLoading=1;</script>" + Environment.NewLine);

                    SqlConnection sqlConn_FS = new SqlConnection();
                    sqlConn_FS = new SqlConnection();

                    oDataIO = new DataIO();
                    sqlConn_FS = oDataIO.GetDBConnection("ProfilesDB");
                    sqlCmd = new SqlCommand();
                    sqlCmd.Connection = sqlConn_FS;
                    
                    dr = oDataIO.GetSitesOrderBySiteID();

                    SiteIDs = new int[1000];
                    URLs = new string[1000];
                    FSIDs = new string[1000];

                    Site site;
                    ListOfSites = new List<Site>();

                    List<AsyncProcessing> ListOfThreads = new List<AsyncProcessing>();
                    AsyncProcessing async;
                    while (dr.Read())
                    {
                        SiteIDs[sites] = Convert.ToInt32(dr["SiteID"].ToString());
                        URLs[sites] = dr["QueryURL"] + SearchPhrase;
                        FSIDs[sites] = dr["FSID"].ToString();
                        site = new Site(URLs[sites], SiteIDs[sites], FSIDs[sites], SearchPhrase, HttpContext.Current);
                        ListOfSites.Add(site);
                        async = new AsyncProcessing();
                        async.BeginProcessRequest(site);
                        ListOfThreads.Add(async);
                    }

                    dr.Close();
                    dr.Dispose();


                    //eat up the CPU for x number of seconds :) so all the requests can come back.  This is set in the web.config file
                    DateTime end = DateTime.Now.AddSeconds(QueryTimeout);
                    while (DateTime.Now < end)
                    { }

                    //close out anything that did not complete in 5 seconds
                    for (int loop = 0; loop < ListOfThreads.Count; loop++)
                    {
                        if (!ListOfThreads[loop].Site.IsDone)
                        {
                            sql = "update FSLogOutgoing set ResponseTime = datediff(ms,SentDate,GetDate()), "
                                    + " ResponseState = " + 1
                                    + " where FSID = " + cs(ListOfThreads[loop].Site.FSID);

                            sqlCmd.CommandText = sql;
                            sqlCmd.CommandType = System.Data.CommandType.Text;
                            iResult = sqlCmd.ExecuteNonQuery();
                            Response.Write("<script>parent.siteResult(" + ListOfThreads[loop].Site.SiteID + ",1,0,'','','','');</script>");
                            ListOfThreads.Remove(ListOfThreads[loop]);
                        }
                    }

                    try
                    {
                        Response.Flush();
                    }
                    catch { }

                    break;
                case "outgoingdetails":
                    string FSID = Request["fsid"].Trim();
                    string SiteId = string.Empty;
                    if (FSID != "")
                    {

                        dr = oDataIO.GetFsID(cs(FSID));

                        if (dr.Read())
                        {
                            SiteId = dr["SiteID"].ToString();
                            ResultDetailsURL = dr["ResultDetailsURL"].ToString().Replace("\n\t", "");
                        }
                        dr.Dispose();
                    }
                    if ((FSID != "") && (SiteId != "") && (ResultDetailsURL != ""))
                    {
                        // Enter log record
                        sql = "insert into FSLogOutgoing(FSID,SiteID,Details,SentDate) "
                            + " values (" + cs(FSID) + "," + cs(SiteId) + ",1,GetDate())";
                        sqlCmd.CommandText = sql;
                        sqlCmd.CommandType = System.Data.CommandType.Text;
                        iResult = sqlCmd.ExecuteNonQuery();
                        Response.Redirect(ResultDetailsURL);
                    }
                    else
                        Response.Redirect(ProfilesURL);
                    break;
            }

            Response.End();
        }

        #region <Methods/>

        private double Timer()
        {

            TimeSpan sinceMidnight = DateTime.Now - DateTime.Today;
            return sinceMidnight.TotalSeconds;

        }

        string DisplayPageHeader()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<!DOCTYPE html PUBLIC \"-//W3C//DTD XHTML 1.0 Transitional//EN\" \"http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd\">");
            sb.AppendLine("<html xmlns=\"http://www.w3.org/1999/xhtml\">");
            sb.AppendLine("<head>");
            sb.AppendLine("<title>Harvard Catalyst Profiles - Federated Search Preview</title>");
            sb.AppendLine("<style>");
            sb.AppendLine("body, td, th, textarea, select, h2, h3, h4, h5, h6 {");
            sb.AppendLine("font-family: arial, sans-serif;");
            sb.AppendLine("font-size:12px;");
            sb.AppendLine("padding:2px;");
            sb.AppendLine("margin:0px;");
            sb.AppendLine("}");
            sb.AppendLine("table {");
            sb.AppendLine("border-collapse:collapse;");
            sb.AppendLine("}");
            sb.AppendLine("td {");
            sb.AppendLine("border-bottom:1px solid #FFF;");
            sb.AppendLine("}");
            sb.AppendLine("</style>");
            sb.AppendLine("</head>");
            sb.AppendLine("<body>");
            return sb.ToString();
        }

        private string cs(string temp)
        {
            if (temp == null)
            {
                return "";
            }
            else
            {
                return "'" + temp.Replace("'", "''") + "'";
            }
        }

        string cx(string temp)
        {
            return temp.Replace("&", "&amp;").Replace("<", "&lt;").Replace(">", "&gt;").Replace("\"", "&quot;").Replace("'", "&apos;");
        }

        string ch(string temp)
        {
            return "'" + temp.Replace(@"\", @"\\").Replace("'", "\'") + "'";
        }



        public string GetXMLText(XmlElement tempXML, string tempPath)
        {
            string tempT = string.Empty;
            XmlNode tempX = null;

            if (tempXML != null)
            {
                tempX = tempXML.SelectSingleNode(tempPath);
                if (tempX != null)
                {
                    tempT = tempX.InnerText;
                }
            }
            return tempT;
        }

        private Int32 ConvertReponseTextToCode(string ResponseStatus)
        {
            switch (ResponseStatus)
            {
                case "Continue": return 100;
                case "Switching protocols": return 101;
                case "OK": return 200;
                case "Created": return 201;
                case "Accepted": return 202;
                case "Non-Authoritative Information": return 203;
                case "No Content": return 204;
                case "Reset Content": return 205;
                case "Partial Content": return 206;
                case "Multiple Choices": return 300;

                case "Moved Permanently": return 301;
                case "Found": return 302;
                case "See Other": return 303;
                case "Not Modified": return 304;
                case "Use Proxy": return 305;
                case "Temporary Redirect": return 307;
                case "Bad Request": return 400;
                case "Unauthorized": return 401;
                case "Payment Required": return 402;
                case "Forbidden": return 403;
                case "Not Found": return 404;
                case "Method Not Allowed": return 405;
                case "Not Acceptable": return 406;
                case "Proxy Authentication Required": return 407;
                case "Request Timeout": return 408;
                case "Conflict": return 409;
                case "Gone": return 410;
                case "Length Required": return 411;
                case "Precondition Failed": return 412;
                case "Request Entity Too Large": return 413;
                case "Request-URI Too Long": return 414;
                case "Unsupported Media Type": return 415;
                case "Requested Range Not Suitable": return 416;
                case "Expectation Failed": return 417;
                case "Internal Server Error": return 500;
                case "Not Implemented": return 501;
                case "Bad Gateway": return 502;
                case "Service Unavailable": return 503;
                case "Gateway Timeout": return 504;
                case "HTTP Version Not Supported": return 505;
                default: return 0;
            }

        }
        #endregion
    }


    public class Site
    {
        public Site(string url, int siteid, string fsid, string searchphrase, HttpContext context)
        {
            this.URL = url;
            this.SiteID = siteid;
            this.FSID = fsid;
            this.SearchPhrase = searchphrase;
            this.Context = context;
        }
        public bool Completed { get; set; }
        public string URL { get; set; }
        public int SiteID { get; set; }
        public string FSID { get; set; }
        public string SearchPhrase { get; set; }
        public string JavaScript { get; set; }
        public bool IsDone { get; set; }
        public HttpContext Context { get; set; }

    }

    public class AsyncProcessing
    {

        DataIO oDataIO;
        SqlCommand sqlCmd;
        SqlConnection Conn;


        private WebRequest _request;


        public AsyncProcessing()
        {
            oDataIO = new DataIO();
            SqlConnection Conn = new SqlConnection();
            Conn = oDataIO.GetDBConnection("ProfilesDB");
            sqlCmd = new SqlCommand();
            sqlCmd.Connection = Conn;
        }

        public void BeginProcessRequest(Site site)
        {
            string sql = "";
            int iResult = 0;
            this.Site = site;
            site.IsDone = false;
            _request = WebRequest.Create(site.URL);

            // Enter log record
            sql = "insert into FSLogOutgoing(FSID,SiteID,Details,SentDate,QueryString) "
                 + " values ('" + site.FSID.ToString() + "'," + site.SiteID.ToString() + ",0,GetDate()," + cs(site.SearchPhrase) + ")";
            sqlCmd.CommandText = sql;
            sqlCmd.CommandType = System.Data.CommandType.Text;            
            iResult = sqlCmd.ExecuteNonQuery();
            _request.BeginGetResponse(new AsyncCallback(EndProcessRequest), site);

        }

        public void EndProcessRequest(IAsyncResult result)
        {

            string resultdata = String.Empty;
            Site site = (Site)result.AsyncState;
            XmlElement ResultXML;
            XmlDocument outgoingcount;
            WebResponse response = null;

            try
            {
                response = _request.EndGetResponse(result);
            }
            catch
            {
                return;
            }

            string ResultCount = string.Empty;
            string ResultDetailsURL = string.Empty;
            string ResultPopulationType = string.Empty;
            string ResultPreviewURL = string.Empty;
            string ResultText = string.Empty;
            string sql = string.Empty;

            using (response)
            {
                StreamReader reader = new StreamReader(response.GetResponseStream());
                resultdata = reader.ReadToEnd();

                outgoingcount = new XmlDocument();

                if (resultdata != "ERROR")
                {
                    outgoingcount.LoadXml(resultdata);

                    ResultText = resultdata;
                    ResultXML = outgoingcount.DocumentElement;
                    ResultCount = GetXMLText(ResultXML, "//count");
                    ResultDetailsURL = GetXMLText(ResultXML, "//search-results-URL");
                    ResultPopulationType = GetXMLText(ResultXML, "//population-type");
                    ResultPreviewURL = GetXMLText(ResultXML, "//preview-URL");
                }
                else
                {
                    ResultText = resultdata;
                }
                sql = "update FSLogOutgoing set ResponseTime = datediff(ms,SentDate,GetDate()), "
                    + " ResponseState = 4, "
                    + " ResponseStatus = 200, " //+ HttpContext.Current.Response.StatusCode.ToString() + ", "
                    + " ResultText = " + cs(ResultText) + ", "
                    + " ResultCount = " + cs(ResultCount) + ", "
                    + " ResultDetailsURL = " + cs(ResultDetailsURL)
                    + " where FSID = " + cs(site.FSID);
                sqlCmd.CommandText = sql;
                sqlCmd.CommandType = System.Data.CommandType.Text;

                int iResult = sqlCmd.ExecuteNonQuery();

                site.JavaScript = "<script language=\"javascript\" type=\"text/javascript\">parent.siteResult(" + site.SiteID + ",0," + ch(ResultCount) + "," + ch(ResultDetailsURL) + "," + ch(ResultPopulationType) + "," + ch(ResultPreviewURL) + ",'" + site.FSID + "');</script>" + Environment.NewLine;
                site.Context.Response.Write(site.JavaScript);
                try
                {
                    site.Context.Response.Flush();
                }
                catch { }
                site.IsDone = true;
                this.Site = site;
                response.Close();
            }

        }



        public Site Site { get; set; }


        #region <Methods/>

        private string cs(string temp)
        {
            if (temp == null)
            {
                return "";
            }
            else
            {
                return "'" + temp.Replace("'", "''") + "'";
            }
        }

        string cx(string temp)
        {
            return temp.Replace("&", "&amp;").Replace("<", "&lt;").Replace(">", "&gt;").Replace("\"", "&quot;").Replace("'", "&apos;");
        }

        string ch(string temp)
        {
            temp = temp.Replace(@"\", "\\");
            temp = temp.Replace("'", "\'") + "'";
            temp = temp.Replace("\n", "");

            return "'" + temp;
        }


        public string GetXMLText(XmlElement tempXML, string tempPath)
        {
            

            string tempT = string.Empty;
            XmlNode tempX = null;

            if (tempXML != null)
            {
                tempX = tempXML.SelectSingleNode(tempPath);
                if (tempX != null)
                {
                    tempT = tempX.InnerText;
                }
            }
            return tempT;
        }


        #endregion




    }


