﻿using System;
using System.Data;
using System.Data.Common;
using System.Globalization;
using System.Text;
using Connects.Profiles.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace Connects.Profiles.DataAccess
{
    public class UserDA
    {
        #region Profile

        public DataTable GetUserInformation(int personId)
        {
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();

            try
            {
                Database db = DatabaseFactory.CreateDatabase();

                string sqlCommand = "usp_GetProfileInfo";
                DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);

                db.AddInParameter(dbCommand, "PersonID", DbType.Int32, personId);

                ds = db.ExecuteDataSet(dbCommand);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

            if (ds.Tables.Count > 0)
                dt = ds.Tables[0];

            return dt;
        }

        public DataTable GetPersonAffiliations(int personId)
        {
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();

            try
            {
                Database db = DatabaseFactory.CreateDatabase();

                string sqlCommand = "usp_GetPersonAffiliations";
                DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);

                db.AddInParameter(dbCommand, "PersonID", DbType.Int32, personId);

                ds = db.ExecuteDataSet(dbCommand);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

            if (ds.Tables.Count > 0)
                dt = ds.Tables[0];

            return dt;
        }

        // PRG: Refactor or get rid of this
        public String GetUserName(string LDAPusername)
        {
            string UserName;

            try
            {
                Database db = DatabaseFactory.CreateDatabase();

                string sqlCommand = "usp_GetUserName";
                DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);

                db.AddInParameter(dbCommand, "LdapUserName", DbType.String, LDAPusername);
                db.AddOutParameter(dbCommand, "UserName", DbType.String, 10);

                db.ExecuteNonQuery(dbCommand);
                UserName = string.Format(CultureInfo.CurrentCulture, "{0}", db.GetParameterValue(dbCommand, "@UserName"));
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

            return UserName;
        }

        // PRG: New authentication methods return this.  Evaluate for removal.
        public bool HasProfile(int userId)
        {
            bool hasProfile;

            try
            {
                Database db = DatabaseFactory.CreateDatabase();

                string sqlCommand = "usp_CheckProfile";
                DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);

                db.AddInParameter(dbCommand, "UserID", DbType.String, userId);
                db.AddOutParameter(dbCommand, "exists", DbType.Boolean, 1);

                db.ExecuteNonQuery(dbCommand);
                hasProfile = (bool)db.GetParameterValue(dbCommand, "exists");
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

            return hasProfile;
        }

        // PRG: Not sure if we need this - evaluate for removal
        public String GetDisplayName(string ldapUsername)
        {
            DataSet ds = new DataSet();
            string result = "";

            try
            {
                Database db = DatabaseFactory.CreateDatabase();

                string sqlCommand = "usp_GetPersonDisplayName";
                DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);

                db.AddInParameter(dbCommand, "LDAP_USERNAME", DbType.String, ldapUsername);

                ds = db.ExecuteDataSet(dbCommand);

                if (ds.Tables[0].Rows.Count > 0)
                    result = ds.Tables[0].Rows[0]["display_name"].ToString();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

            return result;
        }

        #endregion

        #region Preferences

        // PRG: Need to check on parameter to be passed
        public UserPreferences GetUserPreferences(int userId)
        {
            DataSet ds = new DataSet();
            UserPreferences userPref = new UserPreferences();

            try
            {
                Database db = DatabaseFactory.CreateDatabase();

                string sqlCommand = "usp_GetUserPreference";
                DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);

                db.AddInParameter(dbCommand, "PersonID", DbType.Int32, userId);

                ds = db.ExecuteDataSet(dbCommand);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    DataRow dr = ds.Tables[0].Rows[0];

                    userPref.AwardsHonors = dr["AwardsHonors"].ToString();
                    userPref.Narrative = dr["Narrative"].ToString();
                    userPref.Photo = dr["Photo"].ToString();
                    userPref.Publications = dr["Publications"].ToString();
                    userPref.PhotoPref = Int32.Parse((dr["PhotoPreference"].ToString()));
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

            return userPref;
        }

        // PRG: Need to check on parameter to be passed
        public void SetUserPreferences(int userId, string Type, string Flag)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase();

                string sqlCommand = "usp_SetUserPreference";
                DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);

                // Input parameters can specify the input value
                db.AddInParameter(dbCommand, "PersonId", DbType.Int32, userId);
                db.AddInParameter(dbCommand, "Type", DbType.String, Type);
                db.AddInParameter(dbCommand, "Flag", DbType.String, Flag);
                // Output parameters specify results
                db.AddOutParameter(dbCommand, "Return", DbType.Int32, 4);

                db.ExecuteNonQuery(dbCommand);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        #endregion

        #region Proxies

        /// <summary>
        /// Performs both insert and update operations on proxy
        /// </summary>
        /// <param name="userName">Username</param>
        /// <param name="proxy">Proxy</param>
        public void InsertProxy(int userId, int proxy)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase();

                string sqlCommand = "usp_AddProxyDesignated ";
                DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);

                db.AddInParameter(dbCommand, "UserID", DbType.Int32, userId);
                db.AddInParameter(dbCommand, "proxy", DbType.Int32, proxy);

                db.ExecuteNonQuery(dbCommand);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void DeleteProxy(int personId, int proxy)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase();

                string sqlCommand = "usp_DeleteProxyDesignated";
                DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);

                db.AddInParameter(dbCommand, "PersonId", DbType.String, personId);
                db.AddInParameter(dbCommand, "proxy", DbType.String, proxy);

                db.ExecuteNonQuery(dbCommand);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public string GetMyProxies(int proxy)
        {
            DataSet ds = new DataSet();
            StringBuilder sb = new StringBuilder();

            try
            {
                Database db = DatabaseFactory.CreateDatabase();
                    
                string sqlCommand = "usp_GetProxies";
                DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);

                db.AddInParameter(dbCommand, "proxy", DbType.Int32, proxy);

                ds = db.ExecuteDataSet(dbCommand);

                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    sb.Append(dr["PersonID"].ToString());
                    sb.Append(",");
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

            return sb.ToString();
        }



        public IDataReader GetProxies(int personId, int proxy, string designated, string showDefault, string showAll, string showHiddenDefaults)
        {
            IDataReader reader = null;
            //string designatedProxy = "Y";
            //string defaultProxy = "N";
            //string showallProxy = "Y";

            try
            {
                Database db = DatabaseFactory.CreateDatabase();

                string sqlCommand = "usp_GetProxies";
                DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);

                if (personId != 0)
                    db.AddInParameter(dbCommand, "PersonId", DbType.Int32, personId);

                if (proxy != 0)
                    db.AddInParameter(dbCommand, "proxy", DbType.Int32, proxy);

                db.AddInParameter(dbCommand, "designated", DbType.String, designated);
                db.AddInParameter(dbCommand, "default", DbType.String, showDefault);
                db.AddInParameter(dbCommand, "showall", DbType.String, showAll);

                reader = db.ExecuteReader(dbCommand);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

            return reader;
        }

        public DataSet GetMyAssignedProxies(int proxy)
        {
            DataSet ds = new DataSet();

            try
            {
                Database db = DatabaseFactory.CreateDatabase();

                string sqlCommand = "usp_GetProxies";
                DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);

                db.AddInParameter(dbCommand, "proxy", DbType.Int32, proxy);
                db.AddInParameter(dbCommand, "designated", DbType.String, "Y");
                db.AddInParameter(dbCommand, "default", DbType.String, "N");
                db.AddInParameter(dbCommand, "showall", DbType.String, "Y");


                ds = db.ExecuteDataSet(dbCommand);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

            return ds;
        }

        // PRG: looks ok
        public DataSet GetProxySearch(string lastName, string firstName, string department, string institution)
        {
            DataSet ds = new DataSet();

            try
            {
                Database db = DatabaseFactory.CreateDatabase();

                string sqlCommand = "usp_ProxySearch";
                DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);

                db.AddInParameter(dbCommand, "Lastname", DbType.String, lastName);
                db.AddInParameter(dbCommand, "Firstname", DbType.String, firstName);
                db.AddInParameter(dbCommand, "Department", DbType.String, department);
                db.AddInParameter(dbCommand, "Institution", DbType.String, institution);

                ds = db.ExecuteDataSet(dbCommand);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

            return ds;
        }

        #endregion

        #region User Checklist

        // PRG: fixed - need to adjust params through stack
        public DataTable GetCheckListForUID(int userId, int personId)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase();
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();

                string sqlCommand = "usp_GetCheckListAll";
                DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);

                // Input parameters can specify the input value
                db.AddInParameter(dbCommand, "UserID", DbType.Int32, userId);
                db.AddInParameter(dbCommand, "PersonID", DbType.Int32, personId);

                ds = db.ExecuteDataSet(dbCommand);

                if (ds.Tables.Count > 0)
                    dt = ds.Tables[0];

                return dt;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void UpdateUserCheckList(int userId, int personId, string RelationShipType)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase();

                string sqlCommand = "usp_UpdateCheckList";
                DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);

                // Input parameters can specify the input value
                db.AddInParameter(dbCommand, "UserID", DbType.Int32, userId);
                db.AddInParameter(dbCommand, "PersonID", DbType.Int32, personId);
                db.AddInParameter(dbCommand, "RelationShipType", DbType.String, RelationShipType);
                // Output parameters specify results
                db.AddOutParameter(dbCommand, "Return", DbType.Int32, 4);

                db.ExecuteNonQuery(dbCommand);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void DeleteUserCheckListItem(int userId, int personId, string RelationShipType)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase();

                string sqlCommand = "usp_DeleteCheckListItem";
                DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);

                // Input parameters can specify the input value
                db.AddInParameter(dbCommand, "UserID", DbType.Int32, userId);
                db.AddInParameter(dbCommand, "PersonID", DbType.Int32, personId);
                db.AddInParameter(dbCommand, "RelationShipType", DbType.String, RelationShipType);
                // Output parameters specify results
                db.AddOutParameter(dbCommand, "Return", DbType.Int32, 4);

                db.ExecuteNonQuery(dbCommand);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        #endregion

        #region Network

        public DataTable GetUserNetwork(int userId)
        {
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();

            try
            {
                Database db = DatabaseFactory.CreateDatabase();

                string sqlCommand = "usp_GetUserNetwork";
                DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);

                db.AddInParameter(dbCommand, "UserID", DbType.Int32, userId);

                ds = db.ExecuteDataSet(dbCommand);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

            if (ds.Tables.Count > 0)
                dt = ds.Tables[0];

            return dt;
        }

        // PRG: Fixed - need to convert params for entire stack
        public void UpdateUserNetwork(int userId, int personId, string RelationShipType)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase();

                string sqlCommand = "usp_DeleteUserNetwork";
                DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);

                // Input parameters can specify the input value
                db.AddInParameter(dbCommand, "UserID", DbType.Int32, userId);
                db.AddInParameter(dbCommand, "PersonID", DbType.Int32, personId);
                db.AddInParameter(dbCommand, "RelationShipType", DbType.String, RelationShipType);
                // Output parameters specify results
                db.AddOutParameter(dbCommand, "Return", DbType.Int32, 4);

                db.ExecuteNonQuery(dbCommand);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        #endregion

        #region Search History

        public DataTable GetUserSearchHistory(int userId)
        {
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();

            try
            {
                Database db = DatabaseFactory.CreateDatabase();

                string sqlCommand = "usp_GetUserSearchHistory";
                DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);

                db.AddInParameter(dbCommand, "UserID", DbType.Int32, userId);

                ds = db.ExecuteDataSet(dbCommand);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

            if (ds.Tables.Count > 0)
                dt = ds.Tables[0];

            return dt;
        }

        public void InsertUserSearchHistory(int userId, int personId, string ProfileName)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase();

                string sqlCommand = "usp_InsertSearchHistory";
                DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);

                // Input parameters can specify the input value
                db.AddInParameter(dbCommand, "UserID", DbType.Int32, userId);
                db.AddInParameter(dbCommand, "PersonID", DbType.Int32, personId);
                // Output parameters specify results
                db.AddOutParameter(dbCommand, "Return", DbType.Int32, 4);

                db.ExecuteNonQuery(dbCommand);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void ClearSearchHistory(int userId)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase();

                string sqlCommand = "usp_ClearSearchHistory";
                DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);

                // Input parameters can specify the input value
                db.AddInParameter(dbCommand, "UserID", DbType.Int32, userId);
                db.ExecuteNonQuery(dbCommand);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        #endregion

        #region Publications

        public DataTable GetUserPublications(int userId)
        {
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();

            try
            {
                Database db = DatabaseFactory.CreateDatabase();

                string sqlCommand = "usp_GetUserPublications";
                DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);

                db.AddInParameter(dbCommand, "UserID", DbType.Int32, userId);

                ds = db.ExecuteDataSet(dbCommand);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

            if (ds.Tables.Count > 0)
                dt = ds.Tables[0];

            return dt;
        }

        #endregion

        #region Awards and Honors

        public DataTable GetUserAwardsHonors(int personId)
        {
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();

            try
            {
                Database db = DatabaseFactory.CreateDatabase();

                string sqlCommand = "usp_GetUserAwardsHonors";
                DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);

                db.AddInParameter(dbCommand, "PersonID", DbType.Int32, personId);

                ds = db.ExecuteDataSet(dbCommand);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

            if (ds.Tables.Count > 0)
                dt = ds.Tables[0];

            return dt;
        }

        #endregion

        #region Narratives

        public String GetUserNarratives(int personId)
        {
            DataSet ds = new DataSet();
            string returnStr = "";

            try
            {
                Database db = DatabaseFactory.CreateDatabase();

                string sqlCommand = "usp_GetUserNarratives";
                DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);

                db.AddInParameter(dbCommand, "PersonID", DbType.Int32, personId);

                ds = db.ExecuteDataSet(dbCommand);

                if (ds.Tables[0].Rows.Count > 0)
                    returnStr = ds.Tables[0].Rows[0]["Narratives"].ToString();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

            return returnStr;
        }

        public void UpdateUserNarratives(int userId, string narrative)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase();

                string sqlCommand = "usp_AddNarrative";
                DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);

                db.AddInParameter(dbCommand, "PersonId", DbType.Int32, userId);
                db.AddInParameter(dbCommand, "NarrativeMain", DbType.String, narrative);

                db.ExecuteNonQuery(dbCommand);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        #endregion

        #region Neighbors

        public DataTable GetUserNeighbors(int personId)
        {
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();

            try
            {
                Database db = DatabaseFactory.CreateDatabase();

                string sqlCommand = "usp_GetUserNeighbors";
                DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);

                db.AddInParameter(dbCommand, "PersonID", DbType.Int32, personId);

                ds = db.ExecuteDataSet(dbCommand);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

            if (ds.Tables.Count > 0)
                dt = ds.Tables[0];

            return dt;
        }

        #endregion

        #region MeSH Keywords

        public DataTable GetUserMESHkeywords(int personId, string RowNum, ref int TotalCount)
        {
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();

            try
            {
                Database db = DatabaseFactory.CreateDatabase();

                string sqlCommand = "usp_GetMeSHkeywords";
                DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);

                db.AddInParameter(dbCommand, "PersonID", DbType.Int32, personId);
                db.AddInParameter(dbCommand, "RowNum", DbType.String, RowNum);
                db.AddOutParameter(dbCommand, "TotalCount", DbType.Int32, TotalCount);

                ds = db.ExecuteDataSet(dbCommand);

                Int32 int32Val;
                bool result = Int32.TryParse(db.GetParameterValue(dbCommand, "@TotalCount").ToString(), out int32Val);
                TotalCount = int32Val;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

            if (ds.Tables.Count > 0)
                dt = ds.Tables[0];

            return dt;
        }


        public DataTable GetUserMESHCategories(int personId, ref int TotalCount)
        {
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();

            try
            {
                Database db = DatabaseFactory.CreateDatabase();
                System.Text.StringBuilder sql = new StringBuilder();

                sql.Append(" with ReturnData as (  select * from ( select m.*, g.semanticgroupname,row_number() ");
				sql.Append("		over (	partition by g.semanticgroupname order by m.weight desc, m.mesh_header desc) as [Rank] ");
				sql.Append("		from (select meshheader mesh_header, sum(meshweight) as weight  ");
				sql.Append("				from cache_pub_mesh where personid = " + personId.ToString());
				sql.Append("				group by meshheader) as m, ");
				sql.Append("		mesh_descriptors as d, mesh_semantic_groups as g  ");
				sql.Append("		where m.mesh_header = d.descriptorname and d.descriptorui = g.descriptorui	) ");
		        sql.Append("    x where Rank <= 10 ), ");
		        sql.Append("    v as ( select semanticgroupname, max(weight) w, count(*) n  ");
				sql.Append("    from ReturnData  ");
				sql.Append("    group by semanticgroupname )  ");
			    sql.Append("    select ReturnData.*,(ReturnData.weight/v.w) as weight, n, (select sum(n) from v) Total ");
			    sql.Append("    from ReturnData, v  ");
			    sql.Append("    where ReturnData.semanticgroupname = v.semanticgroupname  ");
			    sql.Append("    order by semanticgroupname, w desc, mesh_header  ");

                DbCommand dbCommand = db.GetSqlStringCommand(sql.ToString());


                ds = db.ExecuteDataSet(dbCommand);

                Int32 int32Val = ds.Tables[0].Rows.Count;
              
                TotalCount = int32Val;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

            if (ds.Tables.Count > 0)
                dt = ds.Tables[0];

            return dt;
        }



        #endregion

        #region Co-Authors

        public DataTable GetUserCoAuthors(int personId, string RowNum, ref int TotalCount)
        {
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();

            try
            {
                Database db = DatabaseFactory.CreateDatabase();

                string sqlCommand = "usp_GetUserCoAuthors";
                DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);

                db.AddInParameter(dbCommand, "PersonID", DbType.Int32, personId);
                db.AddInParameter(dbCommand, "RowNum", DbType.String, RowNum);
                db.AddOutParameter(dbCommand, "TotalCount", DbType.Int32, TotalCount);

                ds = db.ExecuteDataSet(dbCommand);

                Int32 int32Val;
                bool result = Int32.TryParse(db.GetParameterValue(dbCommand, "@TotalCount").ToString(), out int32Val);
                TotalCount = int32Val;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

            if (ds.Tables.Count > 0)
                dt = ds.Tables[0];

            return dt;
        }

        #endregion

        #region Similar People

        public DataTable GetUserSimilarPeople(int userId, string RowNum, ref int TotalCount)
        {
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();

            try
            {
                Database db = DatabaseFactory.CreateDatabase();

                string sqlCommand = "usp_GetUserSimilarPeople";
                DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);

                db.AddInParameter(dbCommand, "UserID", DbType.Int32, userId);
                db.AddInParameter(dbCommand, "RowNum", DbType.String, RowNum);
                db.AddOutParameter(dbCommand, "TotalCount", DbType.Int32, TotalCount);

                ds = db.ExecuteDataSet(dbCommand);

                Int32 int32Val;
                bool result = Int32.TryParse(db.GetParameterValue(dbCommand, "@TotalCount").ToString(), out int32Val);
                TotalCount = int32Val;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

            if (ds.Tables.Count > 0)
                dt = ds.Tables[0];

            return dt;
        }

        #endregion

        #region Same Department

        public DataTable GetUserDepartmentPeople(int personId, string RowNum, ref int TotalCount)
        {
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();

            try
            {
                Database db = DatabaseFactory.CreateDatabase();

                string sqlCommand = "usp_GetUserDepartmentPeople";
                DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);

                db.AddInParameter(dbCommand, "PersonID", DbType.Int32, personId);
                db.AddInParameter(dbCommand, "RowNum", DbType.String, RowNum);
                db.AddOutParameter(dbCommand, "TotalCount", DbType.Int32, TotalCount);

                ds = db.ExecuteDataSet(dbCommand);

                Int32 int32Val;
                bool result = Int32.TryParse(db.GetParameterValue(dbCommand, "@TotalCount").ToString(), out int32Val);
                TotalCount = int32Val;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

            if (ds.Tables.Count > 0)
                dt = ds.Tables[0];

            return dt;
        }

        #endregion

        #region Spotlight Area

        public DataTable GetSpotlight(int personId, string spotlightType)
        {
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();

            try
            {
                Database db = DatabaseFactory.CreateDatabase();

                string sqlCommand = "usp_GetSpotlight";
                DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);

                db.AddInParameter(dbCommand, "PersonID", DbType.Int32, personId);
                db.AddInParameter(dbCommand, "spotlightType", DbType.String, spotlightType);

                ds = db.ExecuteDataSet(dbCommand);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

            if (ds.Tables.Count > 0)
                dt = ds.Tables[0];

            return dt;
        }


        #endregion

        #region Advisors

        public DataTable GetUserAdvisors(int userId, string relationShipType)
        {
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();

            try
            {
                Database db = DatabaseFactory.CreateDatabase();

                string sqlCommand = "usp_GetCheckList";
                DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);

                db.AddInParameter(dbCommand, "UserID", DbType.Int32, userId);
                db.AddInParameter(dbCommand, "RelationShipType", DbType.String, relationShipType);

                ds = db.ExecuteDataSet(dbCommand);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

            if (ds.Tables.Count > 0)
                dt = ds.Tables[0];

            return dt;
        }

        #endregion

        #region Google Map

        public IDataReader GetGMapUserSimilar(int personId, bool showConnections)
        {
            IDataReader reader = null;

            try
            {
                Database db = DatabaseFactory.CreateDatabase();

                string sqlCommand = "usp_GetGMapUserSimilar";
                DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);

                db.AddInParameter(dbCommand, "PersonID", DbType.Int32, personId);
                db.AddInParameter(dbCommand, "show_connections", DbType.Boolean, showConnections);

                reader = db.ExecuteReader(dbCommand);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

            return reader;
        }

        public IDataReader GetGMapUserCoAuthors(int personId, int which)
        {
            IDataReader reader = null;

            try
            {
                Database db = DatabaseFactory.CreateDatabase();

                string sqlCommand = "usp_GetGMapUserCoAuthors";
                DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);

                db.AddInParameter(dbCommand, "PersonID", DbType.Int32, personId);
                // Not sure of the purpose of this parameter
                db.AddInParameter(dbCommand, "which", DbType.Int32, which);

                reader = db.ExecuteReader(dbCommand);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

            return reader;
        }

        #endregion

        #region Help Text on Profile

        public String GetUserSupportHtml(int personId, int editMode)
        {
            DataSet ds = new DataSet();
            string returnStr = "";

            try
            {
                Database db = DatabaseFactory.CreateDatabase();

                string sqlCommand = "usp_GetUserSupportHtml";
                DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);

                db.AddInParameter(dbCommand, "PersonID", DbType.Int32, personId);
                db.AddInParameter(dbCommand, "editMode", DbType.Int32, editMode);

                ds = db.ExecuteDataSet(dbCommand);

                if (ds.Tables[0].Rows.Count > 0)
                    returnStr = ds.Tables[0].Rows[0]["html"].ToString();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

            return returnStr;
        }

        #endregion
    }
}
