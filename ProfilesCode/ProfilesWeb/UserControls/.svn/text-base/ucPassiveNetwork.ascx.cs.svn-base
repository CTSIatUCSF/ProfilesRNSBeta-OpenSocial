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
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Connects.Profiles.BusinessLogic;
using Connects.Profiles.Service.DataContracts;
using Connects.Profiles.Service.ServiceImplementation;
using Connects.Profiles.Utility;

public partial class UserControls_ucPassiveNetwork : System.Web.UI.UserControl
{
    private int _profileId = 0;
    public int ProfileId
    {
        get { return _profileId; }
        set { _profileId = value; }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
    }

    public void UpdateControl()
    {
        initControl();
    }

    private void initControl()
    {
        if (_profileId != 0)
        {
            Profiles pr = ProfileHelper.GetNewProfilesDefinition();
            pr = ProfileHelper.AddPassiveNetworkOption(pr, true);

            pr.QueryDefinition.PersonID = _profileId.ToString();

            ProfileServiceAdapter pa = new ProfileServiceAdapter();

            bool isSecure = System.Convert.ToBoolean(ConfigUtil.GetConfigItem("IsSecure"));
            pr.Version = 2;
            PersonList pl = pa.ProfileSearch(pr, isSecure);

            if (pl.Person[0].PassiveNetworks != null)
            {
                if (pl.Person[0].PassiveNetworks.KeywordList != null)
                {
                    if (pl.Person[0].PassiveNetworks.KeywordList.Keyword.Count > 0)
                    {
                        rptKeywordList.DataSource = pl.Person[0].PassiveNetworks.KeywordList.Keyword;
                        lblKeywordHeader.Visible = true;
                        rptKeywordList.DataBind();
                    }
                }

                if (pl.Person[0].PassiveNetworks.SimilarPersonList != null)
                {
                    if (pl.Person[0].PassiveNetworks.SimilarPersonList.SimilarPerson.Count > 0)
                    {
                        dlSimiliarPeople.DataSource = pl.Person[0].PassiveNetworks.SimilarPersonList.SimilarPerson;
                        lblSimilarPeopleHeader.Visible = true;
                        dlSimiliarPeople.DataBind();
                    }
                }

                if (pl.Person[0].PassiveNetworks.CoAuthorList != null)
                {
                    if (pl.Person[0].PassiveNetworks.CoAuthorList.CoAuthor.Count > 0)
                    {
                        dlCoAuthor.DataSource = pl.Person[0].PassiveNetworks.CoAuthorList.CoAuthor;
                        lblCoAuthorHeader.Visible = true;
                        dlCoAuthor.DataBind();
                    }
                }

                if (pl.Person[0].PassiveNetworks.NeighborList != null)
                {
                    if (pl.Person[0].PassiveNetworks.NeighborList.Neighbor.Count > 0)
                    {
                        dlNeighbor.DataSource = pl.Person[0].PassiveNetworks.NeighborList.Neighbor;
                        lblNeighborHeader.Visible = true;
                        dlNeighbor.DataBind();
                    }
                }
            }

        }
    }
}
