using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using Connects.Profiles.BusinessLogic;

public partial class ucProfileRightSide : BaseUserControl
{
    private int _profileId=0;
    public int ProfileId
    {
        get { return _profileId; }
        set { _profileId = value; }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            this.KeywordList1.ProfileId = _profileId;
            this.AuthorList1.ProfileId = _profileId;
            this.SimilarPeopleList1.ProfileId = _profileId;
            this.NeighborList1.ProfileId = _profileId;
            this.SameDeptList1.ProfileId = _profileId;

            ControlDisplayLines();
        }
    }

    protected void Pre_Render(object sender, EventArgs e)
    {

    }

    // Rather than put the control of the separating lines in the controls themselves
    // which is bad for encapsulation, control them here.  Look for the presence of the
    // leading user control and if it's not null, show the divider.
    private void ControlDisplayLines()
    {
        bool prevTrack = false;

        if (KeywordList1.HasData == true)
            prevTrack = true;           

        if (AuthorList1.HasData == true)
        {
            if (prevTrack == true)
            {
                line1.Visible = true;
            }
            prevTrack = true;   
        }
            
        if (SimilarPeopleList1.HasData == true)
        {
            if (prevTrack == true)
            {
                line2.Visible = true;
            }
            prevTrack = true;
        }

        if (SameDeptList1.HasData == true)
        {
            if (prevTrack == true)
            {
                line3.Visible = true;
            }
            prevTrack = true;
        }

        if (NeighborList1.HasData == true)
        {
            if (prevTrack == true)
            {
                line4.Visible = true;
            }
            prevTrack = true;
        }

    }
}
