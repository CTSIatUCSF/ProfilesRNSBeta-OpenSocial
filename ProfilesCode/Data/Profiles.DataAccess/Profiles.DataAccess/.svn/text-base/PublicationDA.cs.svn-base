/*  
 
    Copyright (c) 2008-2010 by the President and Fellows of Harvard College. All rights reserved.  
    Profiles Research Networking Software was developed under the supervision of Griffin M Weber, MD, PhD.,
    and Harvard Catalyst: The Harvard Clinical and Translational Science Center, with support from the 
    National Center for Research Resources and Harvard University.


    Code licensed under a BSD License. 
    For details, see: LICENSE.txt 
  
*/
using System;
using System.Collections;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace Connects.Profiles.DataAccess
{
    public class PublicationDA
    {
        #region Publications

        public void DeletePublications(int personId, bool deletePMID, bool deleteMPID)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase();

                string sqlCommand = "usp_DeleteAllPublications";
                DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);

                db.AddInParameter(dbCommand, "PersonID", DbType.Int32, personId);
                db.AddInParameter(dbCommand, "deletePMID", DbType.Boolean, deletePMID);
                db.AddInParameter(dbCommand, "deleteMPID", DbType.Boolean, deleteMPID);

                db.ExecuteNonQuery(dbCommand);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void AddUserPublication(int userId, int pmId)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase();

                string sqlCommand = "usp_AddPublicationPM";
                DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);

                db.AddInParameter(dbCommand, "UserID", DbType.Int32, userId);
                db.AddInParameter(dbCommand, "pmid", DbType.Int32, Convert.ToInt32(pmId));

                db.ExecuteNonQuery(dbCommand);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void AddCustomPublication(Hashtable parameters)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase();

                string sqlCommand = "usp_AddPublicationMY";
                DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);

                foreach (object key in parameters.Keys)
                {
                    db.AddInParameter(dbCommand, Convert.ToString(key), DbType.String, Convert.ToString(parameters[key]));
                }

                db.ExecuteNonQuery(dbCommand);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void EditCustomPublication(Hashtable parameters)
        {

            string skey = string.Empty;
            string sparam = string.Empty;


            try
            {
                Database db = DatabaseFactory.CreateDatabase();

                string sqlCommand = "usp_UpdatePublicationMY";
                DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);

                foreach (object key in parameters.Keys)
                {
                    skey = (string)key;
                    sparam = (string)parameters[skey].ToString();

                    db.AddInParameter(dbCommand, skey, DbType.String, sparam);
                }

                db.ExecuteNonQuery(dbCommand);
            }
            catch (Exception e)
            {

                skey = skey;
                sparam = sparam;

                throw new Exception(e.Message);
            }
        }

        public IDataReader GetCustomPublication(string mpid)
        {
            IDataReader reader = null;

            try
            {
                Database db = DatabaseFactory.CreateDatabase();

                string sqlCommand = "usp_GetCustomPublication ";
                DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);

                db.AddInParameter(dbCommand, "mpid", DbType.String, mpid);

                reader = db.ExecuteReader(dbCommand);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

            return reader;
        }

        #endregion

        #region PubMed Publications

        public bool CheckPublicationExists(string pmid)
        {
            bool exists = false;

            try
            {
                Database db = DatabaseFactory.CreateDatabase();

                string sqlCommand = "usp_CheckPublication";
                DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);

                db.AddInParameter(dbCommand, "pmid", DbType.String, pmid);
                db.AddOutParameter(dbCommand, "exists", DbType.Boolean, 1);

                db.ExecuteNonQuery(dbCommand);

                exists = Convert.ToBoolean(db.GetParameterValue(dbCommand, "exists"));
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

            return exists;

        }

        public void InsertPublication(string pmid, string xml)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase();

                string sqlCommand = "usp_InsertPublication ";
                DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);

                db.AddInParameter(dbCommand, "pmid", DbType.String, pmid);
                db.AddInParameter(dbCommand, "xml", DbType.Xml, xml);

                db.ExecuteNonQuery(dbCommand);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        #endregion

    }
}
