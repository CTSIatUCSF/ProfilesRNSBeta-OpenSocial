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
using System.Collections.Generic;
using Connects.Profiles.DataAccess;
using Connects.Profiles.Utility;
using Microsoft.Practices.EnterpriseLibrary.Caching;
using Microsoft.Practices.EnterpriseLibrary.Caching.Expirations;

namespace Connects.Profiles.BusinessLogic
{
    public partial class SystemBL : BaseBL
    {
        public String GetGoogleKey(string app, string url)
        {
            //string key = "GoogleKey" + "_" + app;
            string appKey = string.Empty;// = (string)primitivesCache.GetData(key);
            
            
                SystemDA da = new SystemDA();
                appKey = da.GetGoogleKey(app, url);

               // primitivesCache.Add(key, appKey, CacheItemPriority.Normal, null,
                 //    new SlidingTime(TimeSpan.FromMinutes(System.Convert.ToInt32(ConfigUtil.GetConfigItem("SpotlightCacheDuration")))));
            
            return appKey;
        }

        public String GetAboutText()
        {
            string key = "AboutText";
            string aboutText = (string)primitivesCache.GetData(key);

            if (aboutText == null)
            {
                SystemDA da = new SystemDA();
                aboutText = da.GetAboutText();

                primitivesCache.Add(key, aboutText, CacheItemPriority.Normal, null,
                     new SlidingTime(TimeSpan.FromMinutes(System.Convert.ToInt32(ConfigUtil.GetConfigItem("LongCacheDuration")))));
            }
            return aboutText;
        }

        public DataSet GetGoogleMapZoomLinks()
        {
            string key = "GoogleMapZoomLinks";
            DataSet ds = (DataSet)primitivesCache.GetData(key);

            if (ds == null)
            {
                SystemDA da = new SystemDA();
                ds = da.GetGoogleMapZoomLinks();

                primitivesCache.Add(key, ds, CacheItemPriority.Normal, null,
                     new SlidingTime(TimeSpan.FromMinutes(System.Convert.ToInt32(ConfigUtil.GetConfigItem("LongCacheDuration")))));
            }

            return ds;
        }

        public List<String> GetGoogleMapDefaultLocation()
        {
            List<String> def = new List<String>();
            DataSet gmap;

            gmap = GetGoogleMapZoomLinks();

            for (int x = 0; x < gmap.Tables[0].Rows.Count; x++)
            {
                if (System.Convert.ToBoolean(gmap.Tables[0].Rows[x]["DefaultLevel"]))
                {
                    def.Add(System.Convert.ToString(gmap.Tables[0].Rows[x]["Latitude"]));
                    def.Add(System.Convert.ToString(gmap.Tables[0].Rows[x]["Longitude"]));
                    def.Add(System.Convert.ToString(gmap.Tables[0].Rows[x]["ZoomLevel"]));
                }
            }

            return def;
        }
    }
}
