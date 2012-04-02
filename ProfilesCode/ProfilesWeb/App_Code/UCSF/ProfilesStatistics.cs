using System;
using System.Data;
using System.Data.Common;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Web.Script.Serialization;

/// <summary>
/// Summary description for EditedCount
/// </summary>
public static class ProfilesStatistics
{
    public static string GetAllAsJSON()
    {
        Dictionary<string, int> stats = new Dictionary<string, int>();
        stats.Add("profiles", GetProfilesCount());
        stats.Add("publications", GetPublicationsCount());
        stats.Add("edited", GetEditedCount());
        stats.Add("links", GetLinksCount());
        JavaScriptSerializer serializer = new JavaScriptSerializer();
        return serializer.Serialize(stats);
    }

    public static int GetEditedCount()
    {
        Int32 editedCount = 0;

        try
        {
            Database db = DatabaseFactory.CreateDatabase();

            string sqlCommand = "select count(*) from (" +
                "select distinct personid from photo union " +
                "select distinct personid from narratives union " +
                "select distinct personid from awards union " +
                "select distinct personid from my_pubs_general union " +
                "select distinct personid from publications_add union " +
                "select distinct personid from publications_exclude) as u;";
            DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
            editedCount = (Int32)db.ExecuteScalar(dbCommand);
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }

        return (int)editedCount;
    }

    public static int GetProfilesCount()
    {
        Int32 profilesCount = 0;

        try
        {
            Database db = DatabaseFactory.CreateDatabase();

            string sqlCommand = "select count(*) from person where isactive = 1;";
            DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
            profilesCount = (Int32)db.ExecuteScalar(dbCommand);
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }

        return (int)profilesCount;
    }

    public static int GetPublicationsCount()
    {
        Int32 publicationsCount = 0;

        try
        {
            Database db = DatabaseFactory.CreateDatabase();

            string sqlCommand = "select (select count(distinct(PMID)) from publications_include i join person p on p.personid = i.personid where PMID is not null and isactive = 1) + " +
                                "(select count(distinct(MPID)) from publications_include i join person p on p.personid = i.personid where MPID is not null and isactive = 1);";
            DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
            publicationsCount = (Int32)db.ExecuteScalar(dbCommand);
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }

        return (int)publicationsCount;
    }

    public static int GetLinksCount()
    {
        return GetAppRegistryCount(103);
    }

    private static int GetAppRegistryCount(int appId)
    {
        Int32 registryCount = 0;

        try
        {
            Database db = DatabaseFactory.CreateDatabase();

            string sqlCommand = "select count(*) from shindig_app_registry where appId = " + appId + ";";
            DbCommand dbCommand = db.GetSqlStringCommand(sqlCommand);
            registryCount = (Int32)db.ExecuteScalar(dbCommand);
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }

        return (int)registryCount;
    }
}
