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

public partial class UserControls_ucSameDept : BaseUserControl
{
    private int _profileId=0;
    private static int _rowCount = 0;
    private static string _dept = "";
    private static string _inst = "";
    private static int _personCount = 10;

    public int ProfileId
    {
        get { return _profileId; }
        set { 
                _profileId = value;
                BindGrdSameDepartment();
            }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            
            //Bind Department
            BindGrdSameDepartment();
        }
    }
 
    #region Load Grid Department: grdSameDepartment
    private void BindGrdSameDepartment()
    {
        Connects.Profiles.Service.DataContracts.PersonList thisPerson = new Connects.Profiles.Service.ServiceImplementation.ProfileServiceAdapter().GetPersonFromPersonId(_profileId);
        Connects.Profiles.Service.DataContracts.PersonList pl = new Connects.Profiles.Service.ServiceImplementation.ProfileServiceAdapter().GetDepartmentPeopleFromPersonId(_profileId, _personCount);

        grdSameDepartment.DataSource = pl.Person;
        grdSameDepartment.DataBind();

        _rowCount = Convert.ToInt32(pl.TotalCount);

        if (Convert.ToInt32(thisPerson.TotalCount) > 0)
        {
            if (thisPerson.Person[0].AffiliationList != null)
            {
                if (thisPerson.Person[0].AffiliationList.Affiliation.Count > 0)
                {
                    foreach (Connects.Profiles.Service.DataContracts.AffiliationPerson aff in thisPerson.Person[0].AffiliationList.Affiliation)
                    {
                        if (aff.Primary)
                        {
                            _dept = aff.DepartmentName;
                            _inst = aff.InstitutionName;
                        }
                    }
                }
            }
        }

        if (!grdSameDepartment.Rows.Count.Equals(0))
            HasData = true;
    }
    #endregion

    #region grdDepartment OnRowCreated Event
    protected void grdSameDepartment_OnRowCreated(object sender, GridViewRowEventArgs e)
    {
        string dept = "";
        
        if (e.Row.RowType == DataControlRowType.Footer)
        {
            HyperLink hypLnkFoot = new HyperLink();

            hypLnkFoot = (HyperLink)(e.Row.Cells[1].FindControl("hypLnkSameDepartments"));
            hypLnkFoot.Text = "Search for (" + _rowCount.ToString() + ") people";
            hypLnkFoot.NavigateUrl = String.Format("~/Search.aspx?From=dept&DeptName={0}&Person={1}&InstName={2}", Server.UrlEncode(_dept), _profileId.ToString(), Server.UrlEncode(_inst));
        }

    }
    #endregion

    protected string GetDepartmentText(object affiliation)
    {
        string text = "";

        if ((Connects.Profiles.Service.DataContracts.AffiliationPerson)affiliation != null)
        {
            text = Convert.ToString(((Connects.Profiles.Service.DataContracts.AffiliationPerson)affiliation).DepartmentName);
        }

        return text;
    }


}
