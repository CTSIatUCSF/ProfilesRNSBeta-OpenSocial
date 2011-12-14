/*  
 
    Copyright (c) 2008-2010 by the President and Fellows of Harvard College. All rights reserved.  
    Profiles Research Networking Software was developed under the supervision of Griffin M Weber, MD, PhD.,
    and Harvard Catalyst: The Harvard Clinical and Translational Science Center, with support from the 
    National Center for Research Resources and Harvard University.


    Code licensed under a BSD License. 
    For details, see: LICENSE.txt 
  
*/
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
