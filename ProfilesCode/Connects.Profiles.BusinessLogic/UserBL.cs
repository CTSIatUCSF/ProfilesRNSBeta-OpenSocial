using System;
using System.Data;
using Connects.Profiles.Common;
using Connects.Profiles.DataAccess;
using Connects.Profiles.Utility;
using Microsoft.Practices.EnterpriseLibrary.Caching;
using Microsoft.Practices.EnterpriseLibrary.Caching.Expirations;

namespace Connects.Profiles.BusinessLogic
{
    public partial class UserBL: BaseBL
    {
        #region Profile

        public DataTable GetUserInformation(int personID)
        {
            string key = "userInformation" + "_" + personID.ToString();
            DataTable userInfo;//= (DataTable)primitivesCache.GetData(key);

            //if (userInfo == null)
            //{
                UserDA da = new UserDA();
                userInfo = da.GetUserInformation(personID);

            //    primitivesCache.Add(key, userInfo, CacheItemPriority.Normal, null,
            //         new SlidingTime(TimeSpan.FromMinutes(System.Convert.ToInt32(ConfigUtil.GetConfigItem("SpotlightCacheDuration")))));
            //}
            return userInfo;
        }

        public DataTable GetPersonAffiliations(int personID)
        {
            //string key = "personAffiliation" + "_" + personID.ToString();
            DataTable userInfo;// = (DataTable)primitivesCache.GetData(key);

            //if (userInfo == null)
            //{
                UserDA da = new UserDA();
                userInfo = da.GetPersonAffiliations(personID);

            //    primitivesCache.Add(key, userInfo, CacheItemPriority.Normal, null,
            //         new SlidingTime(TimeSpan.FromMinutes(System.Convert.ToInt32(ConfigUtil.GetConfigItem("SpotlightCacheDuration")))));
            //}
            return userInfo;
        }

        public bool HasProfile(int userId)
        {
            return new UserDA().HasProfile(userId);
        }

        public String GetDisplayName(string ldapUsername)
        {
            //string key = "DisplayName" + "_" + ldapUsername;
            string displayName;// = (string)primitivesCache.GetData(key);

            //if (displayName == null)
            //{
                UserDA da = new UserDA();
                displayName = da.GetDisplayName(ldapUsername);

            //    primitivesCache.Add(key, displayName, CacheItemPriority.Normal, null,
            //         new SlidingTime(TimeSpan.FromMinutes(System.Convert.ToInt32(ConfigUtil.GetConfigItem("LongCacheDuration")))));
            //}
            return displayName;
        }
        #endregion

        #region Preferences

        public UserPreferences GetUserPreferences(int userId)
        {
            //string key = "userPreferences" + "_" + userId.ToString();
            UserPreferences userPref;// = (UserPreferences)primitivesCache.GetData(key);

            //if (userPref == null)
           // {
                UserDA da = new UserDA();
                userPref = da.GetUserPreferences(userId);

              //  primitivesCache.Add(key, userPref, CacheItemPriority.Normal, null,
             //        new SlidingTime(TimeSpan.FromMinutes(System.Convert.ToInt32(ConfigUtil.GetConfigItem("SpotlightCacheDuration")))));
            //}
            return userPref;
        }

        public void SetUserPreferences(int userId, string Type, string Flag)
        {
            UserDA da = new UserDA();

            string key = "userPreferences" + "_" + userId.ToString();
            // Throw out any potential caching
            primitivesCache.Remove(key);

            da.SetUserPreferences(userId, Type, Flag);
        }


        #endregion

        #region Proxies

        public void InsertProxy(int userId, int proxy)
        {
            new UserDA().InsertProxy(userId, proxy);
        }

        public void DeleteProxy(int personId, int proxy)
        {
            new UserDA().DeleteProxy(personId, proxy);
        }

        public string GetMyProxies(int proxy)
        {
            //string key = "MyProxies" + "_" + proxy.ToString();
            string myProxies = string.Empty;// (string)primitivesCache.GetData(key);

            //if (myProxies == null)
            //{
                myProxies = new UserDA().GetMyProxies(proxy);

            //    primitivesCache.Add(key, myProxies, CacheItemPriority.Normal, null,
            //         new SlidingTime(TimeSpan.FromMinutes(System.Convert.ToInt32(ConfigUtil.GetConfigItem("SpotlightCacheDuration")))));
            //}

            return myProxies;
        }

        public bool IsProxyFor(int userId, int proxy)
        {
            bool isProxy = false;

            if (GetMyProxies(userId).Contains(proxy.ToString()))
                isProxy = true;

            return isProxy;
        }

        public IDataReader GetProxies(int personId, int proxy, string designated, string showDefault, string showAll, string showHiddenDefaults)
        {
            return new UserDA().GetProxies(personId, proxy, designated, showDefault, showAll, showHiddenDefaults);
        }

        public DataSet GetMyAssignedProxies(int proxy)
        {
            return new UserDA().GetMyAssignedProxies(proxy);
        }

        public DataSet GetProxySearch(string lastName, string firstName, string department, string institution)
        {
            return new UserDA().GetProxySearch(lastName, firstName, department, institution);
        }



        #endregion

        #region Network

        public DataTable GetUserNetwork(int userId)
        {
            //string key = "userNetwork" + "_" + UID;
            //DataTable network = (DataTable)primitivesCache.GetData(key);
            DataTable network;

            //if (network == null)
            //{
                UserDA da = new UserDA();
                network = da.GetUserNetwork(userId);

            //    primitivesCache.Add(key, network, CacheItemPriority.Normal, null,
            //         new SlidingTime(TimeSpan.FromMinutes(System.Convert.ToInt32(ConfigUtil.GetConfigItem("SpotlightCacheDuration")))));
            //}
            return network;
        }

        public void UpdateUserNetwork(int userId, int personId, string RelationShipType)
        {
            //string key = RelationShipType + "_" + UID;
            //// Preemtively clear this relationship type from the cache
            //FlushRelationshipCache(UID);

            //// Also clear the cache holding data on the user and relationships to other profiles
            //string checklistKey = "userCheckList" + "_" + UID + "_" + ProfileUID;
            //primitivesCache.Remove(checklistKey);

            new UserDA().UpdateUserNetwork(userId, personId, RelationShipType);
        }

        #endregion

        #region User Checklist

        public DataTable GetCheckListForUID(int userId, int personId)
        {
            //string key = "userCheckList" + "_" + ViewerID + "_" + ProfileID;
            //DataTable checkList = (DataTable)primitivesCache.GetData(key);
            DataTable checkList;

            //if (checkList == null)
            //{
                UserDA da = new UserDA();
                checkList = da.GetCheckListForUID(userId, personId);

            //    primitivesCache.Add(key, checkList, CacheItemPriority.Normal, null,
            //         new SlidingTime(TimeSpan.FromMinutes(System.Convert.ToInt32(ConfigUtil.GetConfigItem("SpotlightCacheDuration")))));
            //}

            return checkList;
        }

        public void UpdateUserCheckList(int userId, int personId, string RelationShipType)
        {
            //FlushRelationshipCache(viewerUID);

            new UserDA().UpdateUserCheckList(userId, personId, RelationShipType);
        }

        public void DeleteUserCheckListItem(int userId, int personId, string RelationShipType)
        {
            //FlushRelationshipCache(viewerUID);

            new UserDA().DeleteUserCheckListItem(userId, personId, RelationShipType);
        }

        #endregion

        #region Search History

        public DataTable GetUserSearchHistory(int userID)
        {
           // string key = "userSearchHistory" + "_" + userID.ToString();
            DataTable searchHistory;// = (DataTable)primitivesCache.GetData(key);
              UserDA da = new UserDA();
                searchHistory = da.GetUserSearchHistory(userID);

            //    primitivesCache.Add(key, searchHistory, CacheItemPriority.Normal, null,
            //         new SlidingTime(TimeSpan.FromMinutes(System.Convert.ToInt32(ConfigUtil.GetConfigItem("SpotlightCacheDuration")))));
            //}

            return searchHistory;
        }

        public void InsertUserSearchHistory(int userId, int personId, string ProfileName)
        {
            // Clear the cache containing the user's search history
            primitivesCache.Remove("userSearchHistory" + "_" + userId.ToString());

            new UserDA().InsertUserSearchHistory(userId, personId, ProfileName);
        }

        public void ClearSearchHistory(int userID)
        {
            // Clear the cache containing the user's search history
            primitivesCache.Remove("userSearchHistory" + "_" + userID.ToString());

            new UserDA().ClearSearchHistory(userID);
        }

        #endregion

        #region Publications

        public DataTable GetUserPublications(int userID)
        {
           // string key = "userPublications" + "_" + userID.ToString();
            DataTable pubs;// = (DataTable)primitivesCache.GetData(key);

            //if (pubs == null)
            //{
                UserDA da = new UserDA();
                pubs = da.GetUserPublications(userID);

            //    primitivesCache.Add(key, pubs, CacheItemPriority.Normal, null,
            //         new SlidingTime(TimeSpan.FromMinutes(System.Convert.ToInt32(ConfigUtil.GetConfigItem("SpotlightCacheDuration")))));
            //}
            return pubs;
        }

        #endregion

        #region Awards and Honors

        public DataTable GetUserAwardsHonors(int personId)
        {
            string key = "userAwardsHonors" + "_" + personId.ToString();
            DataTable awardsHonors;// = (DataTable)primitivesCache.GetData(key);

            //if (awardsHonors == null)
            //{
                UserDA da = new UserDA();
                awardsHonors = da.GetUserAwardsHonors(personId);

               // primitivesCache.Add(key, awardsHonors, CacheItemPriority.Normal, null,
               //      new SlidingTime(TimeSpan.FromMinutes(System.Convert.ToInt32(ConfigUtil.GetConfigItem("SpotlightCacheDuration")))));
           // }
            return awardsHonors;
        }

        #endregion

        #region Narrations

        public String GetUserNarratives(int personID)
        {
            string key = "userNarratives" + "_" + personID.ToString();
            string narratives;// = (string)primitivesCache.GetData(key);

          //  if (narratives == null)
           // {
                UserDA da = new UserDA();
                narratives = da.GetUserNarratives(personID);

              //  primitivesCache.Add(key, narratives, CacheItemPriority.Normal, null,
             //        new SlidingTime(TimeSpan.FromMinutes(System.Convert.ToInt32(ConfigUtil.GetConfigItem("SpotlightCacheDuration")))));
          //  }
            return narratives;
        }

        public void UpdateUserNarratives(int userId, string narrative)
        {
            string key = "userNarratives" + "_" + userId.ToString();
            // Wipe the narritive cache for this user
            primitivesCache.Remove(key);

            new UserDA().UpdateUserNarratives(userId, narrative);
        }

        #endregion

        #region Neighbors

        public DataTable GetUserNeighbors(int personID)
        {
            string key = "userNeighbors" + "_" + personID.ToString();
            DataTable neighbors;// = (DataTable)primitivesCache.GetData(key);

           // if (neighbors == null)
           // {
                UserDA da = new UserDA();
                neighbors = da.GetUserNeighbors(personID);

             //   primitivesCache.Add(key, neighbors, CacheItemPriority.Normal, null,
             //        new SlidingTime(TimeSpan.FromMinutes(System.Convert.ToInt32(ConfigUtil.GetConfigItem("SpotlightCacheDuration")))));
           // }
            return neighbors;
        }

        #endregion

        #region MeSH Keywords

        public DataTable GetUserMESHkeywords(int personID, string RowNum, ref int TotalCount)
        {
            string key = "userMeshKeywords" + "_" + personID.ToString();
            //DataTable mkw = (DataTable)primitivesCache.GetData(key);
            DataTable mkw=null;

            if (mkw == null)
            {
                UserDA da = new UserDA();
                mkw = da.GetUserMESHkeywords(personID, RowNum, ref TotalCount);

                //primitivesCache.Add(key, mkw, CacheItemPriority.Normal, null,
                 //    new SlidingTime(TimeSpan.FromMinutes(System.Convert.ToInt32(ConfigUtil.GetConfigItem("SpotlightCacheDuration")))));
            }
            return mkw;
        }


        public DataTable GetUserMESHCategories(int personID,ref int TotalCount)
        {
            string key = "userMeshKeywords" + "_" + personID.ToString();
            //DataTable mkw = (DataTable)primitivesCache.GetData(key);
            DataTable mkw = null;

            if (mkw == null)
            {
                UserDA da = new UserDA();
                mkw = da.GetUserMESHCategories(personID, ref TotalCount);
              
            }
            return mkw;
        }

        
        #endregion

        #region Co-Authors

        public DataTable GetUserCoAuthors(int personId, string RowNum, ref int TotalCount)
        {
            string key = "userCoAuthors" + "_" + personId.ToString();
            //DataTable dt = (DataTable)primitivesCache.GetData(key);
            DataTable dt = null;

            if (dt == null)
            {
                UserDA da = new UserDA();
                dt = da.GetUserCoAuthors(personId, RowNum, ref TotalCount);

               // primitivesCache.Add(key, dt, CacheItemPriority.Normal, null,
               //      new SlidingTime(TimeSpan.FromMinutes(System.Convert.ToInt32(ConfigUtil.GetConfigItem("SpotlightCacheDuration")))));
            }
            return dt;
        }

        #endregion

        #region  Similar People

        public DataTable GetUserSimilarPeople(int userId, string RowNum, ref int TotalCount)
        {
            string key = "userSimilarPeople" + "_" + userId.ToString();
            //DataTable dt = (DataTable)primitivesCache.GetData(key);
            DataTable dt = null;

            if (dt == null)
            {
                UserDA da = new UserDA();
                dt = da.GetUserSimilarPeople(userId, RowNum, ref TotalCount);

                // primitivesCache.Add(key, dt, CacheItemPriority.Normal, null,
                //     new SlidingTime(TimeSpan.FromMinutes(System.Convert.ToInt32(ConfigUtil.GetConfigItem("SpotlightCacheDuration")))));
            }
            return dt;
        }

        #endregion

        #region  Same Department

        public DataTable GetUserDepartmentPeople(int personId, string RowNum, ref int TotalCount)
        {
            string key = "userDepartmentPeople" + "_" + personId.ToString();
            DataTable dt = (DataTable)primitivesCache.GetData(key);

            if (dt == null)
            {
                UserDA da = new UserDA();
                dt = da.GetUserDepartmentPeople(personId, RowNum, ref TotalCount);


                primitivesCache.Add(key, dt, CacheItemPriority.Normal, null,
                     new SlidingTime(TimeSpan.FromMinutes(System.Convert.ToInt32(ConfigUtil.GetConfigItem("SpotlightCacheDuration")))));
            }
            return dt;
        }

        #endregion

        #region Spotlight Items

        public DataTable GetMostViewedToday(int personId)
        {
            return GetSpotlight(personId, "MostSearchedKwToday");
        }

        public DataTable GetMostViewedThisMonth(int personId)
        {
            return GetSpotlight(personId, "MostSearchedKwThisMonth");
        }

        public DataTable GetInMyDepartment(int personId)
        {
            return GetSpotlight(personId, "InMyDepartment");
        }

        private DataTable GetSpotlight(int personId, string spotlightType)
        {
            string key = spotlightType + "_" + personId.ToString();
            DataTable vt = (DataTable)primitivesCache.GetData(key);

            if (vt == null)
            {
                UserDA da = new UserDA();
                vt = da.GetSpotlight(personId, spotlightType);

                primitivesCache.Add(key, vt, CacheItemPriority.Normal, null,
                     new SlidingTime(TimeSpan.FromMinutes(System.Convert.ToInt32(ConfigUtil.GetConfigItem("SpotlightCacheDuration")))));
            }
            return vt;
        }

        #endregion

        #region Advisors

        public DataTable GetUserCurrentAdvisors(int userId)
        {
            return GetUserAdvisors(userId, "CurrentAdvisor");
        }

        public DataTable GetUserPastAdvisors(int userId)
        {
            return GetUserAdvisors(userId, "PastAdvisor");
        }

        public DataTable GetUserCurrentAdvisees(int userId)
        {
            return GetUserAdvisors(userId, "CurrentAdvisee");
        }

        public DataTable GetUserPastAdvisees(int userId)
        {
            return GetUserAdvisors(userId, "PastAdvisee");
        }

        public DataTable GetUserCollaborators(int userId)
        {
            return GetUserAdvisors(userId, "Collaborator");
        }

        private DataTable GetUserAdvisors(int userId, string relationShipType)
        {
           // string key = relationShipType + "_" + userId.ToString();
           DataTable ua = null ; //= (DataTable)primitivesCache.GetData(key);

            if (ua == null)
            {
                UserDA da = new UserDA();
                ua = da.GetUserAdvisors(userId, relationShipType);

              //  primitivesCache.Add(key, ua, CacheItemPriority.Normal, null,
               //      new SlidingTime(TimeSpan.FromMinutes(System.Convert.ToInt32(ConfigUtil.GetConfigItem("SpotlightCacheDuration")))));
            }
            return ua;
        }

        #endregion

        #region Google Maps

        public IDataReader GetGMapUserSimilar(int personId, bool showConnections)
        {
            return new UserDA().GetGMapUserSimilar(personId, showConnections);
        }

        public IDataReader GetGMapUserCoAuthors(int userId, int which)
        {
            return new UserDA().GetGMapUserCoAuthors(userId, which);
        }

        #endregion

        #region Helper Functions

        private void FlushRelationshipCache(string UID)
        {
            //Todo: Move these tags to an enum if the number of relationships increase
            primitivesCache.Remove("CurrentAdvisor_" + UID);
            primitivesCache.Remove("PastAdvisor_" + UID);
            primitivesCache.Remove("CurrentAdvisee_" + UID);
            primitivesCache.Remove("PastAdvisee_" + UID);
            primitivesCache.Remove("Collaborator_" + UID);
            primitivesCache.Remove("userCheckList_" + UID);
            primitivesCache.Remove("userNetwork_" + UID);
        }

        #endregion

        #region Photos

        public string GetUserPhotoURL(int personId)
        {
            UserPreferences userPreference = new UserPreferences();
            userPreference = new UserBL().GetUserPreferences(personId);

            string url = ConfigUtil.GetConfigItem("DefaultPersonImageURL");

            if (userPreference.PhotoPref == 9)
            {
                url = string.Format("Thumbnail.ashx?id={0}&random={1}", personId, new Random().Next().ToString());
            }
            else
            {
                DataSet photoDS = new PhotoDA().GetUserPhotoList(personId, 2);

                if (photoDS.Tables[0].Rows.Count > 0)
                {
                    if (photoDS.Tables[0].Rows[userPreference.PhotoPref] != null)
                        url = Convert.ToString(photoDS.Tables[0].Rows[userPreference.PhotoPref]["PhotoLink"]);
                }
            }
            
            return url;
        }

        public DataSet GetUserPhotoList(int personId, int photousagetypeid)
        {
            return new PhotoDA().GetUserPhotoList(personId, photousagetypeid);
        }

        public Byte[] GetUserPhoto(int personId)
        {
            Byte[] img = null;
            PhotoDA photo = new PhotoDA();

            DataSet photoDS = photo.GetUserPhotoList(personId, photo.GetUsageCode());

            // Currently limited to one
            if (photoDS.Tables[0].Rows.Count > 0)
            {
                if (photoDS.Tables[0].Rows[0] != null)
                    img = (byte[])photoDS.Tables[0].Rows[0]["Photo"];
            }
            return img;
        }

        public void SaveUserPhoto(int personId, byte[] photoData)
        {
            new PhotoDA().SaveUserPhoto(personId, photoData);
        }

        #endregion

        #region HTML Help Text

        public String GetProfileSupportHtml(int personId, bool anonymous)
        {
            int editMode = 0;

            if (!anonymous)
                editMode = 1;

            return new UserDA().GetUserSupportHtml(personId, editMode);
        }

        #endregion

    }
}
