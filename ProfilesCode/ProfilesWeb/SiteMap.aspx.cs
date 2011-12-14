using System;
using System.Web.UI;
using System.Data;
using System.Data.Common;
using Connects.Profiles.Utility;
using Microsoft.Practices.EnterpriseLibrary.Data;

public partial class SiteMap : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string URLBase = ConfigUtil.GetConfigItem("URLBase");
        Response.Write("<?xml version=\"1.0\" encoding=\"UTF-8\"?>" + Environment.NewLine +
                                "<urlset xmlns=\"http://www.sitemaps.org/schemas/sitemap/0.9\"" + Environment.NewLine +
                                "xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\"" + Environment.NewLine +
                                "xsi:schemaLocation=\"http://www.sitemaps.org/schemas/sitemap/0.9 http://www.sitemaps.org/schemas/sitemap/0.9/sitemap.xsd\">" + Environment.NewLine +
                                "<url><loc>" + URLBase + "</loc></url>" + Environment.NewLine +
                                "<url><loc>" + URLBase + "SearchOptions.aspx</loc></url>" + Environment.NewLine +
                                "<url><loc>" + URLBase + "HowProfilesWorks.aspx</loc></url>" + Environment.NewLine +
                                "<url><loc>" + URLBase + "AboutUCSFProfiles.aspx</loc></url>" + Environment.NewLine +
                                "<url><loc>" + URLBase + "UCSF_Profiles_Introduction.pptx</loc></url>" + Environment.NewLine);
        IDataReader reader = null;
        try
        {
            Database db = DatabaseFactory.CreateDatabase();

            string sqlCommand = "select '<url><loc>" + URLBase + "ProfileDetails.aspx?Person=' + cast(personId as varchar) + '</loc></url>' from person where IsActive = 1;";
            DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
            reader = db.ExecuteReader(dbCommand);
            while (reader.Read())
            {
                Response.Write(reader[0].ToString() + Environment.NewLine);
            }
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
        finally
        {
            Response.Write("</urlset>");
            if (reader != null)
            {
                reader.Close();
            }
        }
    }

}
