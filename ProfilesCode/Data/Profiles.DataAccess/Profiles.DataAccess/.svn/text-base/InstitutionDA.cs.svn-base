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

namespace Connects.Profiles.DataAccess
{
    public class InstitutionDA
    {

        public DataTable GetInstitutions()
        {
            DataSet ds = new DataSet();

            try
            {
                Database db = DatabaseFactory.CreateDatabase();

                string sqlCommand = "usp_GetInstitutions";
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
