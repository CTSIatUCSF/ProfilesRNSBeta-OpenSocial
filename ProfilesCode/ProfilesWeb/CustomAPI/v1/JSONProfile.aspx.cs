using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.Common;
using Connects.Profiles.Common;
using Connects.Profiles.Service.DataContracts;
using Connects.Profiles.Utility;
using Connects.Profiles.BusinessLogic;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Web.Script.Serialization;

public partial class JSONProfile : System.Web.UI.Page
{
    private UserBL _userBL = new UserBL();

    static readonly string PERSON = "Person";
    static readonly string DISAMBIGUATION = "Disambiguation";

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            string personId = Request["Person"];
            string EmployeeID = Request["EmployeeID"];
            string FNO = Request["FNO"];
            string callback = Request["callback"];
            bool mobile = "on".Equals(Request["mobile"], StringComparison.CurrentCultureIgnoreCase) || "1".Equals(Request["mobile"]);
            bool showPublications = "full".Equals(Request["publications"], StringComparison.CurrentCultureIgnoreCase);

            // get response text
            string jsonProfiles = "{}";
            try
            {
                if (personId != null && personId.Length > 0)
                {
                    jsonProfiles = GetJSONProfiles(Int32.Parse(personId), showPublications, mobile);
                }
                else if (EmployeeID != null && EmployeeID.Length > 0)
                {
                    jsonProfiles = GetJSONProfilesFromEmployeeID(EmployeeID, showPublications, mobile);
                }
                else if (FNO != null && FNO.Length > 0)
                {
                    jsonProfiles = GetJSONProfilesFromFNO(FNO, showPublications, mobile);
                }
            }
            catch (Exception ex)
            {
                // do nothing
            }

            // return with proper content type
            if (jsonProfiles != null) 
            {
                if (callback != null && callback.Length > 0)
                {
                    Response.ContentType = "application/javascript";
                    Response.Write(callback + "(" + jsonProfiles + ");");
                }
                else
                {
                    Response.ContentType = "application/json";
                    Response.Write(jsonProfiles);
                }
            }
        }
        catch (Exception ex)
        {
            Response.Write("ERROR" + Environment.NewLine + ex.Message + Environment.NewLine);
        }
    }

    private string GetJSONProfilesFromEmployeeID(string employeeID, bool showPublications, bool mobile)
    {
        // lookup personid from FNO
        Database db = DatabaseFactory.CreateDatabase();
        DbCommand dbCommand = db.GetSqlStringCommand("select PersonID from person where InternalUsername = '" + employeeID + "'");
        return GetJSONProfiles((Int32)db.ExecuteScalar(dbCommand), showPublications, mobile);
    }

    private string GetJSONProfilesFromFNO(string FNO, bool showPublications, bool mobile)
    {
        // lookup personid from FNO
        Database db = DatabaseFactory.CreateDatabase();
        DbCommand dbCommand = db.GetSqlStringCommand("select PersonID from person p join cls.dbo.vw_FNO f on p.InternalUsername = f.INDIVIDUAL_ID where f.UID_USERID = '" + FNO + "'");
        return GetJSONProfiles((Int32)db.ExecuteScalar(dbCommand), showPublications, mobile);
    }

    private string GetJSONProfiles(int personId, bool showPublications, bool mobile)
    {
        Dictionary<string, Object> personData = new Dictionary<string, Object>();
        List<Dictionary<string, Object>> personDataList = new List<Dictionary<string, object>>();
        Dictionary<string, Object> profileData = new Dictionary<string, Object>();

        // lookup personid from FNO
        try
        {
            PersonList personProfileList = new Connects.Profiles.Service.ServiceImplementation.ProfileService().GetPersonFromPersonId(personId);
            if (personProfileList.Person.Count == 1)
            {
                Person person = personProfileList.Person[0];
                UserPreferences userPreference = _userBL.GetUserPreferences(personId);

                personData.Add("Name", person.Name.FullName);
                personData.Add("ProfilesURL", ConfigUtil.GetConfigItem("URLBase") + "ProfileDetails.aspx?Person=" + personId);
                /*personData.Add("SampleHTML", "<a href=\"" + ConfigUtil.GetConfigItem("URLBase") + "ProfileDetails.aspx?Person=" + personId + 
                    "\" title=\"Go to UCSF Profiles, powered by CTSI\" rel=\"me\">View " + person.Name.FirstName + " " +
                    (person.Name.MiddleName != null && person.Name.MiddleName.Length > 0 ? person.Name.MiddleName + " " : "") + person.Name.LastName + "'s research profile</a>"); */

                if (person.EmailImageUrl.Visible)
                {
                    personData.Add("Email", person.EmailImageUrl.Text);
                }

                personData.Add("Address", person.Address);
                List<String> titles = new List<string>();
                foreach (AffiliationPerson aff in person.AffiliationList.Affiliation)
                {
                    if (aff.Primary)
                    {
                        personData.Add("Department", aff.DepartmentName);
                        personData.Add("School", aff.InstitutionName);
                    }
                    titles.Add(aff.JobTitle);
                }
                personData.Add("Titles", titles);

                if (userPreference.Narrative.Equals("Y"))
                {
                    personData.Add("Narrative", person.Narrative.Text);
                }

                if (userPreference.Photo.Equals("Y") && person.PhotoUrl.Visible)
                {
                    personData.Add("PhotoURL", ConfigUtil.GetConfigItem("URLBase") + "Thumbnail.ashx?id=" + personId);
                }

                if (userPreference.Publications.Equals("Y"))
                {
                    if (showPublications)
                    {
                        List<Object> pubList = new List<object>();
                        foreach (Publication pub in person.PublicationList)
                        {
                            Dictionary<string, Object> pubData = new Dictionary<string, Object>();
                            pubData.Add("PublicationID", pub.PublicationID);
                            pubData.Add("PublicationTitle", pub.PublicationReference);
                            //pubData.Add("PublicationAbstract", pub.PublicationDetails);

                            List<Object> pubSourceList = new List<object>();
                            foreach (PublicationSource pubSource in pub.PublicationSourceList)
                            {
                                Dictionary<string, Object> pubSourceData = new Dictionary<string, Object>();
                                pubSourceData.Add("PublicationSourceName", pubSource.Name);
                                pubSourceData.Add("PublicationSourceURL", (mobile ? pubSource.URL.Replace("/pubmed", "/m/pubmed") : pubSource.URL) );
                                pubSourceData.Add("PublicationAddedBy", GetPublicationInclusionSource(personId, pubSource.ID));
                                pubSourceList.Add(pubSourceData);
                            }
                            pubData.Add("PublicationSource", pubSourceList);
                            pubList.Add(pubData);
                        }
                        personData.Add("Publications", pubList);
                    }
                    else
                    {
                        personData.Add("PublicationCount", person.PublicationList.Count());
                    }
                }

                // Co-authors
                List<int> coAuthors = new List<int>();
                foreach (CoAuthor ca in person.PassiveNetworks.CoAuthorList.CoAuthor)
                {
                    coAuthors.Add(Int32.Parse(ca.PersonID));
                }
                if (coAuthors.Count > 0)
                {
                    personData.Add("CoAuthors", coAuthors);
                }

                // Similiar People
                int Count = 0;
                List<int> similarPeople = new List<int>();
                foreach (DataRow row in _userBL.GetUserSimilarPeople(personId, "False", ref Count).Rows)
                {
                    similarPeople.Add((int)row.ItemArray[0]);
                }
                if (similarPeople.Count > 0)
                {
                    personData.Add("SimilarPeople", similarPeople);
                }

                // Keywords
                Count = 0;
                List<string> keywords = new List<string>();
                foreach (DataRow row in _userBL.GetUserMESHkeywords(personId, "True", ref Count).Rows)
                {
                    keywords.Add((string)row.ItemArray[0]);
                }
                if (keywords.Count > 0)
                {
                    personData.Add("Keywords", keywords);
                }
                
                // add person
                personDataList.Add(personData);
                profileData.Add("Profiles", personDataList);
            }

        }
        catch (Exception ex)
        {
            // do nothing
        }
        JavaScriptSerializer serializer = new JavaScriptSerializer();
        return serializer.Serialize(profileData);
    }

    private string GetPublicationInclusionSource(int personId, string PMID)
    {
        if (PMID == null)
        {
            return PERSON;
        }
        Database db = DatabaseFactory.CreateDatabase();
        DbCommand dbCommand = db.GetSqlStringCommand("select count(*) from publications_add where personId = " + personId + " and PMID = " + PMID);
        return (Int32)db.ExecuteScalar(dbCommand) > 0 ? PERSON : DISAMBIGUATION;
    }

}
