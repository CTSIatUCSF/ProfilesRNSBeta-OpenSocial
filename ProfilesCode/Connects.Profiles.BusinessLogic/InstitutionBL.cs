using System;
using System.Data;
using Connects.Profiles.DataAccess;
using Connects.Profiles.Utility;
using Microsoft.Practices.EnterpriseLibrary.Caching;
using Microsoft.Practices.EnterpriseLibrary.Caching.Expirations;

namespace Connects.Profiles.BusinessLogic
{
    public partial class InstitutionBL : BaseBL
    {

        public DataTable GetInstitutions()
        {
            string key = "InstitutionListKey";
            DataTable inst = (DataTable)primitivesCache.GetData(key);

            if (inst == null)
            {
                InstitutionDA da = new InstitutionDA();
                inst = da.GetInstitutions();

                primitivesCache.Add(key, inst, CacheItemPriority.Normal, null,
                     new SlidingTime(TimeSpan.FromMinutes(System.Convert.ToInt32(ConfigUtil.GetConfigItem("StaticElementCacheDuration")))));
            }
            return inst;
        }

    }
}
