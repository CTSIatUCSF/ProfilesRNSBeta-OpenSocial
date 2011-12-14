using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Connects.Profiles.Service.DataContracts;

public partial class UserControls_ucProfileBaseInfo : BaseUserControl
{
    private int _personId=0;
    private Random _myRandom = new Random();  

    public int PersonId
    {
        get { return _personId; }
        set
        {
            _personId = value;
            LoadProfile();
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    public void LoadProfile()
    {
        Connects.Profiles.Service.DataContracts.PersonList thisPerson = new Connects.Profiles.Service.ServiceImplementation.ProfileServiceAdapter().GetPersonFromPersonId(_personId);
        dlistProfileInfo.DataSource = thisPerson.Person;
        dlistProfileInfo.DataBind();

        rptrTitles.DataSource = _userBL.GetPersonAffiliations(_personId);
        rptrTitles.DataBind();

        // Hide the section if no "Other Positions"
        if (rptrTitles.Items.Count==0)
            rptrTitles.Visible=false;
    }

    protected void dlistProfileInfo_ItemDataBound(object sender, DataListItemEventArgs e)
    {

        if (e.Item.ItemType == ListItemType.Item ||
            e.Item.ItemType == ListItemType.AlternatingItem)
        {
            string email;

            email = ((Connects.Profiles.Service.DataContracts.Person)e.Item.DataItem).EmailImageUrl.Text;

            Image imgEmail = (Image)e.Item.FindControl("ImageEmail");
            Label lblEmail = (Label)e.Item.FindControl("lblReadEmail");

            if (email != null)
            {
                // Need this to pass over to the page that produces the image.  Old stuff - this should be refactored.
                Session["EmailImgText"] = email;

                imgEmail.Visible = true;
                imgEmail.ImageUrl = "../EmailImage.aspx?r=" + _myRandom.Next(99999).ToString();

                lblEmail.Visible = false;
            }
            else
            {
                Session["EmailImgText"] = "none";

                imgEmail.AlternateText = "Email Address";
                imgEmail.Visible = false;
                lblEmail.Visible = false;
            }
        }
    }

    #region Grid Data Binding Helpers

    protected string GetInstitutionText(object affiliationList, int index)
    {
        string text = null;

        if ((((AffiliationListPerson)affiliationList).Affiliation != null) && (((AffiliationListPerson)affiliationList).Affiliation.Count > index))
            text = ((AffiliationListPerson)affiliationList).Affiliation[index] == null ? null : ((AffiliationListPerson)affiliationList).Affiliation[index].InstitutionName;

        return text;
    }

    protected string GetDepartmentText(object affiliationList, int index)
    {
        string text = null;

        if ((((AffiliationListPerson)affiliationList).Affiliation != null) && (((AffiliationListPerson)affiliationList).Affiliation.Count > index))
            text = ((AffiliationListPerson)affiliationList).Affiliation[index] == null ? null : ((AffiliationListPerson)affiliationList).Affiliation[index].DepartmentName;

        return text;
    }

    protected string GetDivisionText(object affiliationList, int index)
    {
        string text = null;

        if ((((AffiliationListPerson)affiliationList).Affiliation != null) && (((AffiliationListPerson)affiliationList).Affiliation.Count > index))
            text = ((AffiliationListPerson)affiliationList).Affiliation[index] == null ? null : ((AffiliationListPerson)affiliationList).Affiliation[index].DivisionName;

        return text;
    }

    protected string GetFacultyRank(object affiliationList, int index)
    {
        string text = null;

        if ((((AffiliationListPerson)affiliationList).Affiliation != null) && (((AffiliationListPerson)affiliationList).Affiliation.Count > index))
            text = ((AffiliationListPerson)affiliationList).Affiliation[index] == null ? null : ((AffiliationListPerson)affiliationList).Affiliation[index].FacultyType;

        return text;
    }

    protected string GetJobTitle(object affiliationList, int index)
    {
        string text = null;

        if ((((AffiliationListPerson)affiliationList).Affiliation != null) && (((AffiliationListPerson)affiliationList).Affiliation.Count > index))
            text = ((AffiliationListPerson)affiliationList).Affiliation[index] == null ? null : ((AffiliationListPerson)affiliationList).Affiliation[index].JobTitle;

        return text;
    }


    #endregion

}
