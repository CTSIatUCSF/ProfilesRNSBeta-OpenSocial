using System.Collections.Generic;
using Connects.Profiles.Service.DataContracts;

/// <summary>
/// Summary description for ProfileHelper
/// </summary>
public static class ProfileHelper
{
    /// <summary>
    /// Initialize all of the internal objects inside of the query definition
    /// </summary>
    /// <returns>A new instance of type QueryDefinition</returns>
    public static Profiles GetNewProfilesDefinition()
    {
        QueryDefinition qd = new QueryDefinition();
        Profiles profiles = new Profiles();

        Name name = new Name();
        name.FirstName = new FirstName();
        name.LastName = new LastName();
        qd.Name = name;


        OutputOptions oo = new OutputOptions();
        oo.SortType = OutputOptionsSortType.QueryRelevance;
        oo.StartRecord = "0";

        Affiliation affiliation = new Affiliation();
        AffiliationList affList = new AffiliationList();

        //affiliations.AffiliationList = affList;
        affList.Affiliation = new List<Affiliation>();                  
        affList.Affiliation.Add(affiliation);

        
        FacultyRankList ftList = new FacultyRankList();
        ftList.FacultyRank = new List<string>();        

        KeywordString kws = new KeywordString();
        Keywords kw = new Keywords();
        kw.KeywordString = new KeywordString();
        kw.KeywordString = kws;

        profiles.QueryDefinition = qd;
        profiles.QueryDefinition.AffiliationList = affList;
        profiles.QueryDefinition.Keywords = kw;
        profiles.QueryDefinition.Name = name;

        profiles.OutputOptions = oo;

        //its hard wired for 2 in this version.
        profiles.Version = 2;

        return profiles;
    }

    public static Profiles AddPassiveNetworkOption(Profiles profile, bool summary)
    {
        OutputFilterList ofl = new OutputFilterList();
        ofl.Default = OutputFilterDefaultEnum.all;

        ofl.OutputFilter = new List<OutputFilter>();
        OutputFilter of = new OutputFilter();

        // Keyword List
        of.Summary = summary;
        of.Text = "KeywordList";
        ofl.OutputFilter.Add(of);

        // SimilarPersonList
        of = new OutputFilter();
        of.Summary = summary;
        of.Text = "SimilarPersonList";
        ofl.OutputFilter.Add(of);

        // CoAuthorList
        of = new OutputFilter();
        of.Summary = summary;
        of.Text = "CoAuthorList";
        ofl.OutputFilter.Add(of);

        // NeighborList
        of = new OutputFilter();
        of.Summary = summary;
        of.Text = "NeighborList";
        ofl.OutputFilter.Add(of);

        profile.OutputOptions.OutputFilterList = ofl;

        return profile;
    }

}
