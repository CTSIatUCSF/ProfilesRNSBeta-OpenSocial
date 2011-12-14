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
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling; 

namespace Connects.Profiles.DataAccess
{
    public class SystemDA
    {

        public String GetAboutText()
        {
            DataSet ds = new DataSet();
            string result = "";

            try
            {
                Database db = DatabaseFactory.CreateDatabase();

                string sqlCommand = "usp_GetHtml";
                DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);

                db.AddInParameter(dbCommand, "PAGE", DbType.String, "About");

                ds = db.ExecuteDataSet(dbCommand);

                if (ds.Tables[0].Rows.Count > 0)
                    result = ds.Tables[0].Rows[0]["html"].ToString();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

            return result;
        }

        public String GetNavHtml()
        {
            DataSet ds = new DataSet();
            string result = "";

            try
            {
                Database db = DatabaseFactory.CreateDatabase();

                string sqlCommand = "usp_GetNavHtml";
                DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);

                ds = db.ExecuteDataSet(dbCommand);

                if (ds.Tables[0].Rows.Count > 0)
                    result = ds.Tables[0].Rows[0]["html"].ToString();
            }
            catch (Exception ex)
            {
                bool rethrow = ExceptionPolicy.HandleException(ex, "Log Only Policy");
                if (rethrow)
                    throw;
            }

            return result;
        }

        public String GetGoogleKey(string app, string url)
        {
            DataSet ds = new DataSet();
            string result = "";

            try
            {


                Database db = DatabaseFactory.CreateDatabase();

                string sqlCommand = "usp_GetGoogleKey";
                DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);

                db.AddInParameter(dbCommand, "app", DbType.String, app);
                db.AddInParameter(dbCommand, "url", DbType.String, url);

                ds = db.ExecuteDataSet(dbCommand);

                if (ds.Tables[0].Rows.Count > 0)
                    result = ds.Tables[0].Rows[0]["gkey"].ToString();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

            return result;
        }


        public DataSet GetGoogleMapZoomLinks()
        {
            DataSet ds = new DataSet();

            try
            {
                Database db = DatabaseFactory.CreateDatabase();

                string sqlCommand = "usp_GetGoogleMapPrefs";
                DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);

                ds = db.ExecuteDataSet(dbCommand);
              
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

            return ds;
        }

    }
}
