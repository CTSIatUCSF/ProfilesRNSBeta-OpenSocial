
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Connects.Profiles.Service.DataContracts;
using Connects.Profiles.Utility;

public partial class Connection : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["ProfileSearchRequest"] == null)
            Response.Redirect("search.aspx");

        if (!Page.IsPostBack)
        {
            InitalizePage();

            ShowSearchCriteria();
        }
    }

    protected void lblHeaderKeywords_DataBinding(object sender, EventArgs e)
    {
        ((Label)sender).Text = ((Profiles)Session["ProfileSearchRequest"]).QueryDefinition.Keywords.KeywordString.Text;
    }

    protected string GetPublicationReference(object publications)
    {
        string text = "";

        if (((Publications)publications).PublicationList != null)
        {
            if (((Publications)publications).PublicationList.Count > 0)
                text = ((Publications)publications).PublicationList[0].PublicationReference;
        }

        return text;
    }

    private void InitalizePage()
    {
        string profileId = Convert.ToString(Request.QueryString["Person"]);

        // Get a copy of the last search
        Profiles personQuery = new Profiles();
        personQuery.QueryDefinition = new QueryDefinition();
        personQuery.OutputOptions = new OutputOptions();
        personQuery.OutputOptions.StartRecord = "0";

        personQuery.QueryDefinition.Keywords = ((Profiles)Session["ProfileSearchRequest"]).QueryDefinition.Keywords;

        // Set the selection input parameter to the session variable holding the search request
        personQuery.QueryDefinition.PersonID = profileId;

        PublicationMatchDetailList pmdl = new Connects.Profiles.Service.ServiceImplementation.ProfileService().GetProfilePublicationMatchSummary(personQuery);

        PersonList thisPerson = new Connects.Profiles.Service.ServiceImplementation.ProfileService().ProfileSearch(personQuery);
        lstViewHeader.DataSource = thisPerson.Person;
        lstViewHeader.DataBind();

        rptMatchingPubs.DataSource = thisPerson.Person[0].PublicationList;
        rptMatchingPubs.DataBind();
        
        lblSubTitle.Text = String.Format("Search Results to {0} {1}", thisPerson.Person[0].Name.FirstName, thisPerson.Person[0].Name.LastName);
        lblSubTitleCaptionText.Text = String.Format("This is a \"connection\" page, showing why {0} {1} matched the keywords from your search.", thisPerson.Person[0].Name.FirstName, thisPerson.Person[0].Name.LastName);
    }

    private void ShowSearchCriteria()
    {
        //ListItem li = new ListItem(((Profiles)Session["ProfileSearchRequest"]).QueryDefinition.Name.FirstName.Text, 
        List<string> searchRequestList = (List<string>)Session["ProfileSearchRequestCriteriaList"];
        if (searchRequestList.Count > 0)
        {
            lstSearchCriteriaDisplay.DataSource = (List<string>)Session["ProfileSearchRequestCriteriaList"];
            lstSearchCriteriaDisplay.DataBind();
        }

        string keyWords = Convert.ToString(((Profiles)Session["ProfileSearchRequest"]).QueryDefinition.Keywords.KeywordString.Text);

        if (keyWords != null)
        {
            Profiles searchReq = (Profiles)Session["ProfileSearchRequest"];
            string keyword = searchReq.QueryDefinition.Keywords.KeywordString.Text;
            string queryId = searchReq.QueryDefinition.QueryID;
            KeywordMatchType matchType = searchReq.QueryDefinition.Keywords.KeywordString.MatchType;
            bool matchExact = (matchType == KeywordMatchType.exact) ? true : false;

            MatchingKeywordList keywordList = new Connects.Profiles.Service.ServiceImplementation.ProfileService().GetMatchingKeywords(keyword, queryId, matchExact);

            if (keywordList.Count > 0)
            {
                lstSearchKeywordDisplay.DataSource = keywordList;
                lstSearchKeywordDisplay.DataBind();
            }
        }

    }

    protected void lstSearchKeywordDisplay_ItemDataBound(object sender, EventArgs e)
    {
        if ((((DataListItemEventArgs)e).Item.ItemType == ListItemType.Item) || (((DataListItemEventArgs)e).Item.ItemType == ListItemType.AlternatingItem))
        {
            DataList dlKeywords = ((DataList)((DataListItemEventArgs)e).Item.FindControl("lstKeywordMatchMeshHeader"));

            if (dlKeywords != null)
            {
                dlKeywords.DataSource = ((MatchingKeyword)((DataListItemEventArgs)e).Item.DataItem).MatchingMeshHeader;
                dlKeywords.DataBind();
            }
        }

    }

    public string GetBackPageURL()
    {
        if (Session["BackPage"] != null)
            return (string)Session["BackPage"];
        else
            return "~/Search.aspx?page=0";
    }


}
