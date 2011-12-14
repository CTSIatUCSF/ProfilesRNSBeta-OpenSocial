using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Connects.Profiles.BusinessLogic;
using Connects.Profiles.Utility;

public partial class UserControls_ucMiniSearch : BaseUserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
            PopulateDropdowns();
        
      
    }

    #region Search, ClearSearch Onclick Events
    protected void BtnMiniSearch_Click(object sender, EventArgs e)
    {
        StringBuilder sbURL = new StringBuilder();

        sbURL.Append("Search.aspx?From=SP");

        if (txtLName.Text.Length > 0)
            sbURL.AppendFormat("&Lname={0}", txtLName.Text.Trim());

        if (txtKword.Text.Length > 0)
            sbURL.AppendFormat("&Keyword={0}", txtKword.Text.Trim());

        // Ignore the first selection and no selection (-1)
        if (ddlInst.SelectedIndex > 0) 
            sbURL.AppendFormat("&Institute={0}", ddlInst.SelectedItem.Text);

        if (ddlDepartment.SelectedIndex > 0)
            sbURL.AppendFormat("&DeptName={0}", ddlDepartment.SelectedItem.Text);


        


        Response.Redirect(sbURL.ToString());
    }

    protected void BtnMiniClear_Click(object sender, EventArgs e)
    {
        txtLName.Text = "";
        txtKword.Text = "";
        ddlInst.SelectedIndex = -1;
    }

    private void PopulateDropdowns()
    {
        if (!Convert.ToBoolean(ConfigUtil.GetConfigItem("HideInstitutionSelectionForSearch")))
        {
            ddlInst.DataSource = new InstitutionBL().GetInstitutions();
            ddlInst.DataTextField = "InstitutionName";
            ddlInst.DataValueField = "InstitutionAbbreviation";
            ddlInst.DataBind();
            ddlInst.Items.Insert(0, new ListItem("--Select--"));
            ddlInst.Items[0].Selected = true;

            // PRG - this was in the original code, not sure of its purpose
            foreach (ListItem li in ddlInst.Items)
            {
                li.Attributes.Add("title", li.Text);
            }
        }
        else
            divInstitution.Visible = false;

        if (!Convert.ToBoolean(ConfigUtil.GetConfigItem("HideDepartmentSelectionForMiniSearch")))
        {
            ddlDepartment.DataSource = new DepartmentBL().GetDepartments();
            ddlDepartment.DataTextField = "Department";
            ddlDepartment.DataBind();
            ddlDepartment.Items.Insert(0, new ListItem("--Select--"));
            ddlDepartment.Items[0].Selected = true;
        }
        else
        {
            divDepartment.Visible = false;
        }


    }

    #endregion


}
