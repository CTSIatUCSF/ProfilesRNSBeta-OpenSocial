using System;
using Connects.Profiles.DataAccess;
using Connects.Profiles.Utility;
using Microsoft.Practices.EnterpriseLibrary.Caching;
using Microsoft.Practices.EnterpriseLibrary.Caching.Expirations;

namespace Connects.Profiles.BusinessLogic
{
    public partial class SystemBL : BaseBL
    {
        public String GetNavHtml()
        {
            string key = "NavHTML";
            string navHTML = (string)primitivesCache.GetData(key);

            if (navHTML == null)
            {
                SystemDA da = new SystemDA();
                navHTML = da.GetNavHtml();

                primitivesCache.Add(key, navHTML, CacheItemPriority.Normal, null,
                     new SlidingTime(TimeSpan.FromMinutes(System.Convert.ToInt32(ConfigUtil.GetConfigItem("LongCacheDuration")))));
            }
            return navHTML;
        }
    }
}
