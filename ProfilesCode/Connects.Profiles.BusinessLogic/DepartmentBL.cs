using System;
using System.Data;
using Connects.Profiles.DataAccess;
using Connects.Profiles.Utility;
using Microsoft.Practices.EnterpriseLibrary.Caching;
using Microsoft.Practices.EnterpriseLibrary.Caching.Expirations;

namespace Connects.Profiles.BusinessLogic
{
    public partial class DepartmentBL : BaseBL
    {

        public DataTable GetDepartments()
        {
            string key = "DepartmentListKey";
            DataTable depts = (DataTable)primitivesCache.GetData(key);

            if (depts == null)
            {
                DepartmentDA da = new DepartmentDA();
                depts = da.GetDepartments();

                primitivesCache.Add(key, depts, CacheItemPriority.Normal, null,
                     new SlidingTime(TimeSpan.FromMinutes(System.Convert.ToInt32(ConfigUtil.GetConfigItem("StaticElementCacheDuration")))));
            }
            return depts;
        }
    }
}
