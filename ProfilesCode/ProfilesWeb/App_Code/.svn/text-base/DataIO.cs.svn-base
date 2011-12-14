using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Xml;
using System.Configuration;
using System.Web;
using System.Web.Caching;


    //Copyright (c) 2008-2010 by the President and Fellows of Harvard College. All rights reserved.  
    //Profiles Research Networking Software was developed under the supervision of Griffin M Weber, MD, PhD.,
    //and Harvard Catalyst: The Harvard Clinical and Translational Science Center, with support from the 
    //National Center for Research Resources and Harvard University.


    //Code licensed under a BSD License. 
    //For details, see: LICENSE.txt 
 

    /// <summary>
    ///     This class is used for all database IO of the web data layer of profiles.  
    ///     Plus contains generic data base IO methods for building Command Objects, Data Readers ect...
    /// 
    /// </summary>

    public class DataIO
    {
        public string _ErrorMsg = "";
        public string _ErrorNumber = "";

        #region <Methods/>

        public SqlDataReader DirectResultset()
        { //ref List<T> ResultSet
            string sql = "select * from FSSites with (NOLOCK) where isactive = 1 order by SortOrder";
            SqlDataReader sqldr = this.GetSQLDataReader("ProfilesDB", sql, CommandType.Text, CommandBehavior.CloseConnection, null);
            return sqldr;
        
        }

        public SqlDataReader GetApiQueryHistory(string QueryID)
        {
            string sql = "select top 1 * from api_query_history with (nolock) where QueryID = " + QueryID;
            SqlDataReader sqldr = this.GetSQLDataReader("ProfilesDB", sql, CommandType.Text, CommandBehavior.CloseConnection, null);
            return sqldr;
        }

        public SqlDataReader GetSitesOrderBySortOrder()
        {
            string sql = "select * from FSSites with (NOLOCK) where isactive = 1 order by sortorder";
            SqlDataReader sqldr = this.GetSQLDataReader("ProfilesDB", sql, CommandType.Text, CommandBehavior.CloseConnection, null);
            return sqldr;
        }

        public SqlDataReader GetSitesOrderBySiteID()
        {
            string sql = "select SiteID, QueryURL, newid() FSID from FSSites with (NOLOCK) where isactive = 1 order by SiteID; select count(siteid) from FSSites with (NOLOCK);";
            SqlDataReader sqldr = this.GetSQLDataReader("ProfilesDB", sql, CommandType.Text, CommandBehavior.CloseConnection, null);
            return sqldr;
        }

        public SqlDataReader GetPersonList_xml(string QueryXML)
        {
            string sql = "usp_GetPersonList_xml @xMessage = " + QueryXML;
            SqlDataReader sqldr = this.GetSQLDataReader("ProfilesDB", sql, CommandType.Text, CommandBehavior.CloseConnection, null);
            return sqldr;
        }

        public SqlDataReader GetFsID(string FsID)
        {
            string sql = "select siteid, resultdetailsurl from FSLogOutgoing with (NOLOCK) where details = 0 and fsid = " + FsID;
            SqlDataReader sqldr = this.GetSQLDataReader("ProfilesDB", sql, CommandType.Text, CommandBehavior.CloseConnection, null);
            return sqldr;
        }

        public SqlDataReader GetFacultyRank(string QueryID)
        {
            string sql = "select facultyranksort, max(facultyrank) facultyrank, sum(n) n from ( select facultyranksort, facultyrank, count(*) n  from api_query_results r with (NOLOCK), cache_person p with (NOLOCK) where r.personid = p.personid and r.queryid = '" + QueryID + "' group by facultyranksort, facultyrank ) t group by facultyranksort order by facultyranksort";
            SqlDataReader sqldr = this.GetSQLDataReader("ProfilesDB", sql, CommandType.Text, CommandBehavior.CloseConnection, null);
            return sqldr;
        }

        /// <summary>
        /// returns sqlconnection object
        /// </summary>
        /// <param name="Connectionstring"></param>
        /// <returns></returns>
        public SqlConnection GetDBConnection(string Connectionstring)
        {
            if (Connectionstring == "")
                Connectionstring = ConfigurationManager.ConnectionStrings["ProfilesDB"].ConnectionString;
            else
            {
                if (Connectionstring.Length < 50)
                    Connectionstring = ConfigurationManager.ConnectionStrings[Connectionstring].ConnectionString;
            }
            SqlConnection dbsqlconnection = new SqlConnection(Connectionstring);
            try
            {
                dbsqlconnection.Open();
            }
            catch { }
            return dbsqlconnection;
        }

        public SqlCommand GetDBCommand(SqlConnection sqlcn, String CmdText, CommandType CmdType, CommandBehavior CmdBehavior, SqlParameter[] sqlParam)
        {
            SqlCommand sqlcmd = new SqlCommand(CmdText, sqlcn);
            sqlcmd.CommandType = CmdType;

            AddSQLParameters(sqlcmd, sqlParam);
            return sqlcmd;
        }

        public SqlCommand GetDBCommand(string SqlConnectionString, String CmdText, CommandType CmdType, CommandBehavior CmdBehavior, SqlParameter[] sqlParam)
        {
            SqlCommand sqlcmd = new SqlCommand(CmdText, GetDBConnection(SqlConnectionString));
            sqlcmd.CommandType = CmdType;
            if (sqlParam != null)
                AddSQLParameters(sqlcmd, sqlParam);
            return sqlcmd;
        }

        public void AddSQLParameters(SqlCommand sqlcmd, SqlParameter[] sqlParam)
        {
            for (int i = 0; i < sqlParam.GetLength(0); i++)
            {
                sqlcmd.Parameters.Add(sqlParam[i]);
            }
        }

        public SqlDataReader GetSQLDataReader(SqlCommand sqlcmd)
        {
            SqlDataReader sqldr;
            try
            {
                sqldr = sqlcmd.ExecuteReader(CommandBehavior.CloseConnection);
                return sqldr;
            }
            catch (SqlException e)
            {
                ErrorMessage = e.Message;
                ErrorNumber = e.Number.ToString();
                return null;
            }
            finally
            {
                sqlcmd.Dispose();
            }

        }

        public SqlDataReader GetSQLDataReader(string ConnectionString, String CmdText, CommandType CmdType, CommandBehavior CmdBehavior, SqlParameter[] sqlParam)
        {
            return this.GetSQLDataReader(this.GetDBCommand(ConnectionString, CmdText, CmdType, CmdBehavior, sqlParam));
        }

        public void ExecuteSQLDataCommand(SqlCommand sqlcmd)
        {

            sqlcmd.ExecuteNonQuery();
            sqlcmd.Dispose();

        }


        /*public xmlReader GetXMLReader(SqlCommand sqlcmd)
        {
            XmlReader xmlr;
            xmlr = sqlcmd.ExecuteXmlReader();
            return xmlr;
        }
        */


        #endregion

        #region <Properties/>

        /// <summary>
        /// Property: error message
        /// </summary>
        public string ErrorMessage
        {
            get { return _ErrorMsg; }
            set { _ErrorMsg = value; }
        }

        public string ErrorNumber
        {
            get { return _ErrorNumber; }
            set { _ErrorNumber = value; }
        }

        #endregion
    }
