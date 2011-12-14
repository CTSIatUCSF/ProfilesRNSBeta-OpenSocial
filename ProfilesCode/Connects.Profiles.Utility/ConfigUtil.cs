using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace Connects.Profiles.Utility
{
    public static class ConfigUtil
    {

        public static string GetConfigItem(string key)
        {
            object o = ConfigurationManager.AppSettings[key];
            return (o == null) ? null : o.ToString();
        }

        public static string GetConfigItem(string section, string key)
        {
            System.Collections.Specialized.NameValueCollection nvsh =
                (System.Collections.Specialized.NameValueCollection)
                System.Configuration.ConfigurationManager.GetSection(section);

            if (nvsh == null)
                throw new ConfigurationErrorsException("can't read section " + section + " in web.config.");

            return nvsh[key];

        }

    }
}
