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
using Connects.Profiles.DataAccess;
using Connects.Profiles.Utility;
using Microsoft.Practices.EnterpriseLibrary.Caching;
using Microsoft.Practices.EnterpriseLibrary.Caching.Expirations;

namespace Connects.Profiles.BusinessLogic
{
    public partial class FacultyBL: BaseBL
    {

        public DataTable GetFacultyRanks()
        {
            string key = "FacultyRankKey";
            DataTable rank = (DataTable)primitivesCache.GetData(key);

            if (rank == null)
            {
                FacultyDA da = new FacultyDA();
                rank = da.GetFacultyRanks();

                primitivesCache.Add(key, rank, CacheItemPriority.Normal, null,
                     new SlidingTime(TimeSpan.FromMinutes(System.Convert.ToInt32(ConfigUtil.GetConfigItem("StaticElementCacheDuration")))));
            }
            return rank;
        }

        /// <summary>
        /// Get a list of person types from the database.
        /// Logically reorganized to be in the correct format for the ComboTreeCheck control
        /// </summary>
        /// <returns>DataSet</returns>
        public DataSet GetPersonTypes()
        {
            string key = "PersonTypesKey";

            DataSet personTypesReturn = (DataSet)primitivesCache.GetData(key);

            if (personTypesReturn == null)
            {

                FacultyDA da = new FacultyDA();
                DataSet personTypes = da.GetPersonTypes();
                personTypesReturn = new DataSet();

                // New table for the master records
                personTypesReturn.Tables.Add("DataMasterName");
                personTypesReturn.Tables[0].Columns.Add("personTypeGroupId", Type.GetType("System.Int32"));
                personTypesReturn.Tables[0].Columns.Add("personTypeGroup", Type.GetType("System.String"));
                personTypesReturn.Tables[0].Columns.Add("Expanded", Type.GetType("System.Boolean"));

                // New table for the detail records
                personTypesReturn.Tables.Add("DataDetailName");
                personTypesReturn.Tables[1].Columns.Add("personTypeGroupId", Type.GetType("System.Int32"));
                personTypesReturn.Tables[1].Columns.Add("personTypeFlagId", Type.GetType("System.Int32"));
                personTypesReturn.Tables[1].Columns.Add("personTypeFlag", Type.GetType("System.String"));
                personTypesReturn.Tables[1].Columns.Add("Checked", Type.GetType("System.Boolean"));

                string lastParentTag="";
                string currentParentTag = "";
                string currentChildTag = "";
                int parentRowId = 0;
                int childRowId = 1;
                bool getChild = false;

                foreach (DataRow pRow in personTypes.Tables[0].Rows)
                {
                    currentParentTag = Convert.ToString(pRow["PersonFilterCategory"]);
                    currentChildTag = Convert.ToString(pRow["personfilter"]);
                    getChild = false;

                    if (currentParentTag != lastParentTag)
                    {
                        // We have a new parent
                        parentRowId++;
                        personTypesReturn.Tables[0].Rows.Add(parentRowId, currentParentTag);
                        lastParentTag = currentParentTag;

                        // Also get child
                        getChild = true;
                    }
                    else
                    {
                        // We only have child
                        getChild = true;
                    }

                    if (getChild)
                    {
                        personTypesReturn.Tables[1].Rows.Add(parentRowId, childRowId, currentChildTag);
                        childRowId++;
                    }
                }


                // Add to cache
                primitivesCache.Add(key, personTypesReturn, CacheItemPriority.Normal, null,
                     new SlidingTime(TimeSpan.FromMinutes(System.Convert.ToInt32(ConfigUtil.GetConfigItem("StaticElementCacheDuration")))));
            }

            return personTypesReturn;
        }

    }
}
