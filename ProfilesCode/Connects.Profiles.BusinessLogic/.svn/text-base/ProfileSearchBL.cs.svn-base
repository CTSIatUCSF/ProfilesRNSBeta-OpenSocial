/*  
 
    Copyright (c) 2008-2010 by the President and Fellows of Harvard College. All rights reserved.  
    Profiles Research Networking Software was developed under the supervision of Griffin M Weber, MD, PhD.,
    and Harvard Catalyst: The Harvard Clinical and Translational Science Center, with support from the 
    National Center for Research Resources and Harvard University.


    Code licensed under a BSD License. 
    For details, see: LICENSE.txt 
  
*/
using System;
using System.Collections.Generic;
using System.Data;
using Connects.Profiles.DataAccess;
using Connects.Profiles.Utility;
using Microsoft.Practices.EnterpriseLibrary.Caching;
using Microsoft.Practices.EnterpriseLibrary.Caching.Expirations;

namespace Connects.Profiles.BusinessLogic
{
    public class ProfileSearchBL : BaseBL
    {
        public XmlReaderScope ProfileSearch(string qd, bool isSecure)
        {
            try
            {
                return new ProfileSearchDA().ProfileSearch(qd, isSecure);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public int GetProfileSearchTotalRowCount(string queryId, int initialRowCount)
        {
            string key = "ProfileSearchRows" + queryId;
            int cacheRowCount = Convert.ToInt32(primitivesCache.GetData(key));

            if (cacheRowCount == 0)
            {
                cacheRowCount = initialRowCount;

                primitivesCache.Add(key, cacheRowCount, CacheItemPriority.Normal, null,
                     new SlidingTime(TimeSpan.FromMinutes(System.Convert.ToInt32(ConfigUtil.GetConfigItem("StaticElementCacheDuration")))));
            }

            return cacheRowCount;
        }

        public XmlReaderScope GetMatchingKeywords(string keyword, string queryID, bool exactKeyword)
        {
            return new ProfileSearchDA().GetMatchingKeywords(keyword, queryID, exactKeyword);
        }

        public string[] GetAutoCompleteKeywords(string prefixText, int count)
        {
            bool orderByRelevance = false;
            IDataReader l_KWReader = new ProfileSearchDA().GetAutoCompleteKeywords(prefixText, count, orderByRelevance);

            List<string> l_Keywords = new List<string>();
            if (l_KWReader != null)
            {
                if (((System.Data.SqlClient.SqlDataReader)l_KWReader).HasRows)
                {
                    while (l_KWReader.Read())
                    {
                        l_Keywords.Add(l_KWReader.GetString(0));
                    }

                    if (!l_KWReader.IsClosed)
                    {
                        l_KWReader.Close();
                    }
                }
            }

            return l_Keywords.ToArray();


        }

    }
}
