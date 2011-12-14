using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Web.Caching;
using System.Collections;

namespace Connects.Profiles.Utility
{
    public class CacheUtil<T>
    {
        public static void Insert(string key, T data, int duration, Cache ctx)
        {
            if (duration == 0)
                return;

            ctx.Insert(key, data, null, DateTime.Now.AddSeconds(duration), System.Web.Caching.Cache.NoSlidingExpiration);
        }

        public static void Insert(string key, T data, bool noExpiration, Cache ctx)
        {
            if (!noExpiration)
            {
                string item = ConfigUtil.GetConfigItem("ObjectCacheDuration");
                if (item == null)
                    throw new NullReferenceException("ObjectCacheDuration key is not defined in web.config");

                int duration = int.Parse(item);
                if (duration == 0)
                    return;
                //TimeSpan ts = TimeSpan.FromSeconds(duration);
                ctx.Insert(key, data, null, DateTime.Now.AddSeconds(duration), System.Web.Caching.Cache.NoSlidingExpiration);
            }
            else
            {
                ctx.Insert(key, data);
            }
        }

        public static T Get(string key, Cache ctx)
        {
            if (ctx.Get(key) is T)
            {
                return (T)ctx.Get(key);
            }
            else
            {
                return default(T);
            }
        }

        public static void Remove(string key, Cache ctx)
        {
            ctx.Remove(key);
        }

        public static int GetHashCode(object key, string additionalKey)
        {
            //serialize
            string xml = XmlUtilities.SerializeObject(key) + additionalKey;
            return xml.GetHashCode();

        }
    }
}
