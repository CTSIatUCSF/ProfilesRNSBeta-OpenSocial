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
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Activation;
using Connects.Profiles.BusinessLogic;
using Connects.Profiles.DataAccess;
using Connects.Profiles.Service.DataContracts;
using Connects.Profiles.Utility;

using System.Diagnostics;
using System.Web.Security;

namespace Connects.Profiles.Service.ServiceImplementation
{
    [ServiceBehavior(IncludeExceptionDetailInFaults = true), AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class ProfileServiceAdapter
    {
        public PersonList ProfileSearch(Connects.Profiles.Service.DataContracts.Profiles qd, bool isSecure)
        {
            PersonList pl = null;
            try
            {
                ProfileSearchBL ps = new ProfileSearchBL();
                Connects.Profiles.Service.DataContracts.Profiles p = new Connects.Profiles.Service.DataContracts.Profiles();
                
                //qd.OutputOptions.StartRecord = (Convert.ToInt32(qd.OutputOptions.StartRecord) + 1).ToString();

                string req = XmlUtilities.SerializeToString(qd);
                                          
                
                req = req.Replace("Version=\"0\"", "Version=\"1\"");
                           

                XmlUtilities.logit("Line 1: ProfileServiceAdapter.ProfileSearch(" + req + "," + isSecure.ToString() +")");

                // If we are enforcing XSD
                if (Convert.ToBoolean(ConfigUtil.GetConfigItem("EnforceQuerySchema")) == true)
                {

                    XmlUtilities.logit("Line 2: Enforcing XSD");
                    if (ValidateSearchRequest(req) == false)
                    {
                        XmlUtilities.logit("Line 3: Failed XSD");
                        throw new Exception("Search request failed XML schema validation");
                    }
                    XmlUtilities.logit("Line 3: Passed XSD");
                }
                else {
                    XmlUtilities.logit("Line 2 and 3: No XSD Required");
                }

                using (XmlReaderScope scope = ps.ProfileSearch(req, isSecure))
                {
                    Type type = typeof(PersonList);
                    string responseXML;

                    scope.Reader.Read();

                    responseXML = scope.Reader.ReadOuterXml();
                    XmlUtilities.logit("Line 4: Response data " + responseXML);

                    // If we are enforcing XSD
                    if (Convert.ToBoolean(ConfigUtil.GetConfigItem("EnforceResponseSchema")) == true)
                    {
                        XmlUtilities.logit("Line 5: Enforcing response XSD");

                        if (ValidateSearchResponse(responseXML) == false)
                        {
                            XmlUtilities.logit("Line 6: Failed response xsd");
                            throw new Exception("Search response failed XML schema validation");
                        }
                        XmlUtilities.logit("Line 6: Passed response xsd");
                    }
                    else
                    {
                        XmlUtilities.logit("Line 5 and 6: No XSD Required");
                    }
                           
             
                    pl = XmlUtilities.DeserializeObject(responseXML, type) as PersonList;

                    XmlUtilities.logit("Line 7: Returned to requestor");
                    
                }
            }
            catch (Exception ex)
            {
                XmlUtilities.logit("ERROR==> " + ex.Message + " STACK:" + ex.StackTrace + " SOURCE:" + ex.Source);
            }
            

            return pl;

        }

        public PersonList GetPersonFromPersonId(int personId)
        {
            QueryDefinition qd = new QueryDefinition();
            Connects.Profiles.Service.DataContracts.Profiles profiles = new Connects.Profiles.Service.DataContracts.Profiles();
            profiles.Version = 2;
            profiles.QueryDefinition = qd;
            profiles.QueryDefinition.PersonID = personId.ToString();

            OutputOptions oo = new OutputOptions();
            oo.SortType = OutputOptionsSortType.QueryRelevance;
            oo.StartRecord = "0";

            OutputFilterList ofl = new OutputFilterList();
            OutputFilter of = new OutputFilter();
            of.Summary = false;
            of.Text = "CoAuthorList";

            ofl.OutputFilter = new List<OutputFilter>();
            ofl.OutputFilter.Add(of);

            oo.OutputFilterList = ofl;
            profiles.OutputOptions = oo;

            bool isSecure = System.Convert.ToBoolean(ConfigUtil.GetConfigItem("IsSecure"));
            profiles.Version = 2;

            return ProfileSearch(profiles, isSecure);
        }

        public PersonList GetDepartmentPeopleFromPersonId(int personId, int count)
        {
            //thisPerson is the current profile being viewed by a user or process.
            PersonList thisPerson;
            PersonList returnPeople;

            thisPerson = GetPersonFromPersonId(personId);

            QueryDefinition qd = new QueryDefinition();
            Connects.Profiles.Service.DataContracts.Profiles profiles = new Connects.Profiles.Service.DataContracts.Profiles();

            if (Convert.ToInt32(thisPerson.TotalCount) > 0)
            {
                if (thisPerson.Person[0].AffiliationList != null)
                {
                    if (thisPerson.Person[0].AffiliationList.Affiliation.Count > 0)
                    {
                        Affiliation affiliation = new Affiliation();
                        AffiliationList affList = new AffiliationList();
                        affiliation.DepartmentName = new AffiliationDepartmentName();
                        affiliation.InstitutionName = new AffiliationInstitutionName();

                        foreach (AffiliationPerson aff in thisPerson.Person[0].AffiliationList.Affiliation)
                        {
                            if (aff.Primary)
                            {
                                affiliation.DepartmentName.Text = aff.DepartmentName;
                                affiliation.InstitutionName.Text = aff.InstitutionName;
                                
                            }
                        }
                        affList.Affiliation = new List<Affiliation>();
                        affList.Affiliation.Add(affiliation);

                        qd.AffiliationList = affList;

                        profiles.QueryDefinition = qd;

                        OutputOptions oo = new OutputOptions();
                        oo.SortType = OutputOptionsSortType.QueryRelevance;
                        oo.StartRecord = "0";
                        oo.MaxRecords = count.ToString();

                        profiles.OutputOptions = oo;


                        bool isSecure = System.Convert.ToBoolean(ConfigUtil.GetConfigItem("IsSecure"));
                        profiles.Version = 2;
                        returnPeople = ProfileSearch(profiles, isSecure);

                        //Filter out the current profile you are viewing.
                        if (Convert.ToInt32(thisPerson.ThisCount) > 0)
                        {
                            returnPeople.Person.RemoveAll(x => x.PersonID == thisPerson.Person[0].PersonID);
                        }

                        return returnPeople;
                    }
                }
            }

            return thisPerson;
        }


        public int GetPersonIdFromInternalId(string internalTag, string internalValue)
        {
            QueryDefinition qd = new QueryDefinition();
            Connects.Profiles.Service.DataContracts.Profiles profiles = new Connects.Profiles.Service.DataContracts.Profiles();
            int personId = 0;

            InternalIDList internalIdList = new InternalIDList();
            List<InternalID> intIdList = new List<InternalID>();
            InternalID intId = new InternalID();

            intId.Name = internalTag;
            intId.Text = internalValue;

            intIdList.Add(intId);

            internalIdList.InternalID = intIdList;

            profiles.QueryDefinition = qd;
            profiles.QueryDefinition.InternalIDList = internalIdList;

            OutputOptions oo = new OutputOptions();
            oo.SortType = OutputOptionsSortType.QueryRelevance;
            oo.StartRecord = "0";

            profiles.OutputOptions = oo;
            bool isSecure = System.Convert.ToBoolean(ConfigUtil.GetConfigItem("IsSecure"));
            profiles.Version = 2;
            PersonList resp = ProfileSearch(profiles, isSecure);

            personId = Convert.ToInt32(resp.Person[0].PersonID);

            return personId;
        }

        public int GetProfileSearchTotalRowCount(string queryId, int initialRowCount)
        {
            return new ProfileSearchBL().GetProfileSearchTotalRowCount(queryId, initialRowCount);
        }

        public MatchingKeywordList GetMatchingKeywords(string keyword, string queryID, bool exactKeyword)
        {
            ProfileSearchBL ps = new ProfileSearchBL();
            Connects.Profiles.Service.DataContracts.MatchingKeywordList pl = new Connects.Profiles.Service.DataContracts.MatchingKeywordList();

            using (XmlReaderScope scope = ps.GetMatchingKeywords(keyword, queryID, exactKeyword))
            {
                Type type = typeof(MatchingKeywordList);
                string responseXML;

                scope.Reader.Read();
                responseXML = scope.Reader.ReadOuterXml();

                pl = XmlUtilities.DeserializeObject(responseXML, type) as MatchingKeywordList;

                return pl;
            }
        }

        public string[] GetAutoCompleteKeywords(string prefixText, int count)
        {
            return new ProfileSearchBL().GetAutoCompleteKeywords(prefixText, count);
        }

        public PublicationMatchDetailList GetProfilePublicationMatchSummary(Connects.Profiles.Service.DataContracts.Profiles qd, bool isSecure)
        {
            qd.Version = 2;

            PersonList pl = ProfileSearch(qd, isSecure);
            PublicationMatchDetailList pubMatch = new PublicationMatchDetailList();
            HashSet<string> searchPhraseDistinct = new HashSet<string>();
            HashSet<string> publicationPhraseDistinct = new HashSet<string>();

            if (pl != null)
            {                

                foreach (Publication pub in pl.Person[0].PublicationList)
                {

                    foreach (PublicationMatchDetail pubMatchDetail in pub.PublicationMatchDetailList)
                    {
                        PublicationMatchDetail pubMatchDetailStripped = new PublicationMatchDetail();
                        pubMatchDetailStripped.SearchPhrase = pubMatchDetail.SearchPhrase;

                        if (!searchPhraseDistinct.Contains(pubMatchDetail.SearchPhrase))
                        {
                            pubMatch.Add(pubMatchDetailStripped);

                            searchPhraseDistinct.Add(pubMatchDetail.SearchPhrase);
                        }

                        foreach (PublicationPhraseDetail pubPhraseDetail in pubMatchDetail.PublicationPhraseDetailList)
                        {

                            //PublicationPhraseDetail pubPhraseDetailStripped = new PublicationPhraseDetail();
                            //pubPhraseDetailStripped.PublicationPhrase = pubPhraseDetail.PublicationPhrase;

                            //PublicationMatchDetail pmd = pubMatch.Find(delegate(PublicationMatchDetail t) { return t.SearchPhrase == pubMatchDetail.SearchPhrase; });

                            //// Handle the structure
                            //if (!publicationPhraseDistinct.Contains(pubPhraseDetail.PublicationPhrase))
                            //{
                            //    if (pmd.PublicationPhraseDetailList == null)
                            //        pmd.PublicationPhraseDetailList = new PublicationPhraseDetailList();

                            //    pmd.PublicationPhraseDetailList.Add(pubPhraseDetailStripped);

                            //    publicationPhraseDistinct.Add(pubPhraseDetail.PublicationPhrase);
                            //}

                            //// Get the Phrase Measurements
                            //PublicationPhraseDetail ppd = pmd.PublicationPhraseDetailList.Find(delegate(PublicationPhraseDetail t) { return t.PublicationPhrase == pubPhraseDetail.PublicationPhrase; });
                            //ppd.PhraseMeasurements = pubPhraseDetail.PhraseMeasurements;

                            //if (ppd.PublicationList == null)
                            //    ppd.PublicationList = new PublicationList();
                            //ppd.PublicationList.Add(pub);
                            PublicationMatchDetail pmd = pubMatch.Find(delegate(PublicationMatchDetail t) { return t.SearchPhrase == pubMatchDetail.SearchPhrase; });

                            if (pmd.PublicationPhraseDetailList == null)
                                pmd.PublicationPhraseDetailList = new PublicationPhraseDetailList();

                            pubPhraseDetail.Publication = pub;
                            pmd.PublicationPhraseDetailList.Add(pubPhraseDetail);
                        }

                    }

                }

            }

            // IEnumerable<PublicationMatchDetail> noduplicates = pubMatch.Distinct();

            return pubMatch;

        }


        #region Validation Code

        private bool ValidateSearchRequest(string requestXML)
        {
            return ValidateXML("ProfileQueryXSD", requestXML);
        }

        private bool ValidateSearchResponse(string responseXML)
        {
            return ValidateXML("ProfileResponseXSD", responseXML);
        }

        private bool ValidateXML(string configItem, string xmlToCheck)
        {
            XmlValidate xmlValidate = new XmlValidate();
            bool validated = false;
            string xsdPath = ConfigUtil.GetConfigItem(configItem);

            validated = xmlValidate.ValidateXml(xmlToCheck, xsdPath);

            return validated;
        }
        #endregion
    }
}
