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
using System.Data.Common;
using System.Globalization;
using System.Text;
using Connects.Profiles.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace Connects.Profiles.DataAccess
{
    public class PhotoDA
    {

        public DataSet GetUserPhotoList(int personId, int photousagetypeid)
        {
            DataSet ds = new DataSet();

            try
            {
                Database db = DatabaseFactory.CreateDatabase();

                string sqlCommand = "usp_GetUserPhotoList";
                DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);

                db.AddInParameter(dbCommand, "PersonID", DbType.Int32, personId);
                db.AddInParameter(dbCommand, "photousagetypeID", DbType.Int32, photousagetypeid);

                ds = db.ExecuteDataSet(dbCommand);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

            return ds;
        }
        
        public Byte[] GetUserPhoto(int personId)
        {
            byte[] binaryData=null;
            DataSet ds = new DataSet();

            try
            {
                Database db = DatabaseFactory.CreateDatabase();

                string sqlCommand = "usp_GetUserPhotoList";
                DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);

                db.AddInParameter(dbCommand, "PersonID", DbType.Int32, personId);
                db.AddInParameter(dbCommand, "photousagetypeID", DbType.Int32, 1);

                ds = db.ExecuteDataSet(dbCommand);

                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    if (Convert.ToInt32(ds.Tables[0].Rows[i]["photousagetypeid"]) == 1)
                        // Read the data from varbinary(max) column
                        binaryData = (byte[])ds.Tables[0].Rows[i]["photo"];
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

            return binaryData;
        }

        public void SaveUserPhoto(int personId, byte[] photoData)
        {
            int photoId=0;

            try
            {

                Database db = DatabaseFactory.CreateDatabase();

                string sqlCommand = "usp_AddUserPhoto";
                DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);

                db.AddInParameter(dbCommand, "PersonID", DbType.Int32, personId);
                db.AddInParameter(dbCommand, "Photo", DbType.Binary, photoData);

                // Default this to personal photos
                db.AddInParameter(dbCommand, "PhotoUsageTypeID", DbType.Int32, GetUsageCode());

                db.AddOutParameter(dbCommand, "PhotoID", DbType.Int32, photoId);

                db.ExecuteNonQuery(dbCommand);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

        }
         public int GetUsageCode()
        {
            int rtn = 0;
            try
            {
                Database db = DatabaseFactory.CreateDatabase();
                System.Data.IDataReader reader;

                string sqlCommand = "usp_getphotousage";
                DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);

                reader = db.ExecuteReader(dbCommand);


                while (reader.Read())
                {

                    if (reader[1].ToString().ToLower() == "custom")
                    {
                        rtn = Convert.ToInt32(reader[0]);
                    }


                }

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

            return rtn;

        }        

        public void SetUserPhotoPreference(int personId, int preference)
        {
            int returnCode = 0;

            try
            {
                Database db = DatabaseFactory.CreateDatabase();

                string sqlCommand = "usp_SetUserPreference";
                DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);

                db.AddInParameter(dbCommand, "PersonID", DbType.Int32, personId);
                db.AddInParameter(dbCommand, "Type", DbType.String, "PhotoPreference");
                db.AddInParameter(dbCommand, "Flag", DbType.String, preference.ToString());

                db.AddOutParameter(dbCommand, "Return", DbType.Int32, returnCode);

                db.ExecuteNonQuery(dbCommand);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

        }
    }
}
