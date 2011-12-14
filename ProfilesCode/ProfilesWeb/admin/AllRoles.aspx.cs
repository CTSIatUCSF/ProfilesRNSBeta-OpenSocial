using System;
using System.Collections.Generic;
using System.Data;
using System.Web.Security;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class AllRoles : System.Web.UI.Page
{
    [Serializable]
    public class RoleEntity
    {
        private readonly string m_RoleName;
        public string RoleName
        {
            get { return m_RoleName; }
        }

        private readonly bool m_IsNewRole;
        public bool IsNewRole
        {
            get { return m_IsNewRole; }
        }

        public RoleEntity(string p_RoleName)
        {
            m_RoleName = p_RoleName;
        }

        public RoleEntity(string p_RoleName, bool IsNewRole)
            : this(p_RoleName)
        {
            m_IsNewRole = IsNewRole;
        }

        public static List<RoleEntity> GetRoles(string[] rolenames)
        {
            List<RoleEntity> l_RoleEntities = new List<RoleEntity>();
            if (rolenames != null)
            {
                foreach (string l_Rolename in rolenames)
                {
                    RoleEntity l_CustomRole = new RoleEntity(l_Rolename);
                    l_RoleEntities.Add(l_CustomRole);
                }
            }
            return l_RoleEntities;
        }
    }

    private List<RoleEntity> m_Roles;

    private const string ViewStateRoleKey = "EditRole";

    private RoleEntity EditRole
    {
        get
        {
            return (RoleEntity)ViewState[ViewStateRoleKey];
        }
        set
        {
            lbNew.Visible = false;
            ViewState[ViewStateRoleKey] = value;
            BindRoles();

            if (EditRole == null)
            {
                lbNew.Visible = true;
                SetEditorVisibility(false);
                rRoles.Visible = true;
            }
            else if (EditRole.IsNewRole)
            {
                SetEditorVisibility(true);
                tbRoleName.Text = "";

                tbRoleName.Focus();
                rRoles.Visible = false;
            }
            else
            {
                RoleEntity l_EditRole = null;
                if (m_Roles != null)
                {
                    foreach (RoleEntity l_Role in m_Roles)
                    {
                        if (l_Role.RoleName == EditRole.RoleName)
                        {
                            l_EditRole = l_Role;
                            break;
                        }
                    }
                }
                if (l_EditRole == null)
                {
                    SetEditorVisibility(false);
                    lGeneralError.Visible = true;
                    lGeneralError.Text = string.Format("Role {0} not found.", EditRole);
                }
                else
                {
                    SetEditorVisibility(true);
                    tbRoleName.Text = l_EditRole.RoleName;
                    tbRoleName.Focus();
                    rRoles.Visible = false;
                }
            }
        }
    } 

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindRoles();
        }
    }
     


    private void BindRoles()
    {
        m_Roles = RoleEntity.GetRoles(Roles.GetAllRoles());

        rRoles.DataSource = m_Roles;
        rRoles.DataBind();

        lNoItems.Visible = m_Roles.Count <= 0;
    }


    protected void rptBrand_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "Edit")
        {
            EditRole = new RoleEntity(e.CommandArgument.ToString());
        }
        else if (e.CommandName == "Cancel")
        {
            EditRole = null;
        }
        else if (e.CommandName == "Delete")
        {
            string l_roleName = e.CommandArgument.ToString();
            Roles.DeleteRole(l_roleName);
            //dbRole.DeleteRole(int.Parse(e.CommandArgument.ToString()));
            lSuccess.Visible = true;
            lSuccess.Text = "Role was removed successfully.";
            EditRole = null;
        }
    }

    protected void rptBrand_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            bool l_isSelected = false;
            RoleEntity l_Role = (RoleEntity)e.Item.DataItem;

            if (EditRole != null && l_Role.RoleName == EditRole.RoleName)
            {
                HtmlTableRow l_Row = (HtmlTableRow) e.Item.FindControl("trRepeaterRow");
                l_Row.Attributes.Add("class", "SelectedRow");
                //e.Row.CssClass = "SelectedRow";
                l_isSelected = true;
            }

            LinkButton l_lbEdit = (LinkButton)e.Item.FindControl("lbEdit");
            LinkButton l_lbCancel = (LinkButton)e.Item.FindControl("lbCancel");

            LinkButton l_lbDelete = (LinkButton)e.Item.FindControl("lbDelete");

            l_lbDelete.Visible = EditRole == null;// !EditRole.HasValue;

            l_lbEdit.Visible = !l_isSelected;
            l_lbCancel.Visible = l_isSelected;
        }
    }

    private void SetEditorVisibility(bool p_Show)
    {
        divEditor.Attributes.Add("style", p_Show ? "display:block" : "display:none");
    }

    protected void lbNew_Click(object sender, EventArgs e)
    {
        EditRole = new RoleEntity("-1", true);
    }


    private string GetTextFromRow(DataRow p_Row, string p_Field)
    {
        if (p_Row[p_Field] == DBNull.Value) return "";

        return p_Row[p_Field].ToString();
    }


    protected void lbSave_Click(object sender, EventArgs e)
    {
        bool l_isValid = true;
        string l_RoleName = tbRoleName.Text.Trim();

        if (string.IsNullOrEmpty(l_RoleName))
        {
            l_isValid = false;
            tbRoleName.Focus();
        }

        if (!l_isValid) return;


        if (EditRole.IsNewRole)
        {
            if (Roles.RoleExists(l_RoleName))
            {
                lInvalidRole.Visible = true;
                l_isValid = false;
                tbRoleName.Focus();
            }
        }

        if (!l_isValid) return;

        if (EditRole.IsNewRole)
        {
            Roles.DeleteRole(EditRole.RoleName);
            Roles.CreateRole(l_RoleName);
        }
        else
        {
            string[] usernames = Roles.GetUsersInRole(EditRole.RoleName);

            if (usernames != null && usernames.Length>0) Roles.RemoveUsersFromRole(usernames, EditRole.RoleName);
            Roles.DeleteRole(EditRole.RoleName);
            Roles.CreateRole(l_RoleName);
            if (usernames != null && usernames.Length>0) Roles.AddUsersToRole(usernames, l_RoleName);
        }

        //check login aviability
        EditRole = null;
        lSuccess.Visible = true;
    }

    protected void lbCancel_Click(object sender, EventArgs e)
    {
        EditRole = null;
    }
}
