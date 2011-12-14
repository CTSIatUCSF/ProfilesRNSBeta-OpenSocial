using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.ServiceModel.Activation;
using Connects.Profiles.Service.DataContracts;
using Connects.Profiles.Service.ServiceContracts;
using Connects.Profiles.Utility;

namespace Connects.Profiles.Service.ServiceImplementation
{
    [KnownType(typeof(InternalID))]
    [KnownType(typeof(InternalIDList))]
    [KnownType(typeof(OutputFilter))]
    [KnownType(typeof(OutputFilterList))]
    [KnownType(typeof(OutputOptions))]
    [KnownType(typeof(Connects.Profiles.Service.DataContracts.Profiles))]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
    public class ProfileService : IProfileService
    {
        /// <summary>
        /// The ProfileSearch action provides an XML-based query mechanism for Profiles data.  ProfileSearch takes
        /// an XML request using the Profiles XML schema and returns XML data formatted according to the PersonList XML schema.
        /// </summary>
        /// <param name="Profiles">An XML request using the Profiles XML schema</param>
        /// <returns>Profiles data formatted according to the PersonList XML schema</returns>
        public PersonList ProfileSearch(Connects.Profiles.Service.DataContracts.Profiles pq)
        {
            bool isSecure = System.Convert.ToBoolean(ConfigUtil.GetConfigItem("IsSecure"));
            return new ProfileServiceAdapter().ProfileSearch(pq, isSecure);
        }

        public PersonList GetPersonFromPersonId(int personId)
        {
            return new ProfileServiceAdapter().GetPersonFromPersonId(personId);
        }

        public int GetPersonIdFromInternalId(string internalTag, string internalValue)
        {
            return new ProfileServiceAdapter().GetPersonIdFromInternalId(internalTag, internalValue);
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<Person> ProfileSearchPersonBinding(Connects.Profiles.Service.DataContracts.Profiles pq, out string queryID, out int totalCount, int startRowIndex, int maximumRows)
        {
            bool isSecure = System.Convert.ToBoolean(ConfigUtil.GetConfigItem("IsSecure"));

            // Modify the search for the start row and max rows
            //((Connects.Profiles.Service.DataContracts.Profiles)pq).OutputOptions.StartRecord = startRowIndex.ToString();

            PersonList personList = new ProfileServiceAdapter().ProfileSearch(pq, isSecure);
            queryID = personList.QueryID;
            
            totalCount = Convert.ToInt32(personList.TotalCount);
            //complete = personList.Complete;

            int fooCount = new ProfileServiceAdapter().GetProfileSearchTotalRowCount(queryID, totalCount);

            return personList.Person;
        }

        public int GetProfileSearchTotalRowCount(Connects.Profiles.Service.DataContracts.Profiles pq, out string queryID, out int totalCount)
        {
            string qId = pq.QueryDefinition.QueryID;
            int primeCount = 0;
            int returnedCount = new ProfileServiceAdapter().GetProfileSearchTotalRowCount(qId, primeCount);
            totalCount = returnedCount;

            queryID = qId;

            return returnedCount;
        }

        public MatchingKeywordList GetMatchingKeywords(string keyword, string queryID, bool exactKeyword)
        {
            return new ProfileServiceAdapter().GetMatchingKeywords(keyword, queryID, exactKeyword);
        }

        [System.Web.Services.WebMethod]
        [System.Web.Script.Services.ScriptMethod]
        public string[] GetAutoCompleteKeywords(string prefixText, int count)
        {
            return new ProfileServiceAdapter().GetAutoCompleteKeywords(prefixText, count);
        }

        public PublicationMatchDetailList GetProfilePublicationMatchSummary(Connects.Profiles.Service.DataContracts.Profiles qd)
        {
            return new ProfileServiceAdapter().GetProfilePublicationMatchSummary(qd, false);
        }

    }
}
