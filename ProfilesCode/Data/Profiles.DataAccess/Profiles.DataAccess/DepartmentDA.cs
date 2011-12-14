using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace Connects.Profiles.DataAccess
{
    public class DepartmentDA
    {

        public DataTable GetDepartments()
        {
            DataSet ds = new DataSet();

            try
            {
                Database db = DatabaseFactory.CreateDatabase();

                string sqlCommand = "usp_GetDepartments";
                DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);

                ds = db.ExecuteDataSet(dbCommand);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

            return ds.Tables[0];
        }


    }
}
