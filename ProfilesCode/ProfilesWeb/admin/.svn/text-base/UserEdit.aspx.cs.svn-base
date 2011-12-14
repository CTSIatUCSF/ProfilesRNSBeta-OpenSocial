using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Web.Security;
using System.Web.UI.WebControls;
using Connects.Profiles.BusinessLogic;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;

public partial class UserEdit : System.Web.UI.Page
{
    private int? UserID
    {
        get { return (int?)ViewState["UserID"]; }
        set { ViewState["UserID"] = value; }
    }

    private bool IsNewUser
    {
        get { return ViewState["IsAddNew"] == null ? false : (bool)ViewState["IsAddNew"]; }
        set { ViewState["IsAddNew"] = value; }
    }

    public int? PageSize
    {
        get
        {
            if (ViewState["UsersPageSize"] != null)
                return int.Parse(ViewState["UsersPageSize"].ToString());
            return null;
        }
        set { ViewState["UsersPageSize"] = value; }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (!string.IsNullOrEmpty(Request.QueryString["IsAddNew"]) && Request.QueryString["IsAddNew"].Trim() == "1")
            {
                IsNewUser = true;
                lbHeader.Text = "Create new user account";
            }
            else if (!string.IsNullOrEmpty(Request.QueryString["UserID"]))
            {
                int l_UserID;
                if (!int.TryParse(Request.QueryString["UserID"], out l_UserID))
                {
                    HideContent("Invalid query string argument");
                    return;
                }

                UserID = l_UserID;
                lbHeader.Text = "Edit user profile";
            }
            else
            {
                UserID = UserInfo.Current.UserID;
                lbHeader.Text = "My profile";
            }

            if (Session[GlobalConst.PageSizeSessionKey] != null)
            {
                int lPageSize = int.Parse(Session[GlobalConst.PageSizeSessionKey].ToString());
                PageSize = lPageSize;
                Session[GlobalConst.PageSizeSessionKey] = null;

                hlCancel.NavigateUrl = string.Format("{0}?PageSize={1}", hlCancel.NavigateUrl, lPageSize);
                if (UserID.HasValue)
                    hlCancel.NavigateUrl += string.Format("&ShowUser={0}", UserID.Value);
            }
           
            LoadData();
        }
    }

    private void LoadData()
    {
        if (UserID == null && !IsNewUser)
        {
            HideContent("UserID field cannot be null for edited user");
            return;
        }

        divPassworArea.Visible = IsNewUser;
        tbFirstName.Focus();

        if (UserID != null)
        {
            ProfilesMembershipUser l_EditUser =
                        (ProfilesMembershipUser)new ProfilesDBMembershipProviderBL().GetUserByID(UserID.Value);

            if (l_EditUser == null || string.IsNullOrEmpty(l_EditUser.UserName))
            {
                HideContent("User does not exist");
                return;
            }

            tbFirstName.Text = l_EditUser.FirstName;
            tbLastName.Text = l_EditUser.LastName;
            tbLogin.Text = l_EditUser.UserName;
            tbEmail.Text = l_EditUser.Email;

            tbDepartmentFullname.Text = l_EditUser.DepartmentFullname;
            tbDivisionFullname.Text = l_EditUser.DivisionFullname;
            tbInstitutionFullname.Text = l_EditUser.InstitutionFullname;
            tbOfficePhone.Text = l_EditUser.OfficePhone;
            tbPasswordAnswer.Text = l_EditUser.PasswordAnswer;
            tbPasswordQuestion.Text = l_EditUser.PasswordQuestion;
            tbComments.Text = l_EditUser.Comment;

            hlPasword.Visible = UserInfo.Current.UserID == UserID.Value;

            BindRoles(Roles.GetAllRoles(), Roles.GetRolesForUser(l_EditUser.UserName));
        }
        else
        {
            BindRoles(Roles.GetAllRoles(), null);
        }
    }

    private void BindRoles(IEnumerable<string> allRoles, IEnumerable<string> userRoles)
    {
        cblRoles.Items.Clear();
        if (allRoles != null)
        {
            foreach (string l_Role in allRoles)
            {
                ListItem l_Item = new ListItem(l_Role, l_Role);
                if (userRoles != null)
                {
                    bool l_isSelected = false;
                    foreach (string l_UserRole in userRoles)
                    {
                        if (l_UserRole == l_Role)
                        {
                            l_isSelected = true;
                            break;
                        }
                    }
                    l_Item.Selected = l_isSelected;
                }
                cblRoles.Items.Add(l_Item);
            }
        }

        lNoRoles.Visible = cblRoles.Items.Count <= 0;
    }

    protected void lbSave_Click(object sender, EventArgs e)
    {
        bool l_isValid = true;
        string l_PasswordAnswer = tbPasswordAnswer.Text.Trim();
        string l_PasswordQuestion = tbPasswordQuestion.Text.Trim();
        string l_Password = tbPassword.Text.Trim();
        string l_Login = tbLogin.Text.Trim();
        string l_LastName = tbLastName.Text.Trim();
        string l_FirstName = tbFirstName.Text.Trim();
        string l_OfficePhone = tbOfficePhone.Text.Trim();
        string l_EmailAddr = tbEmail.Text.Trim();
        string l_InstitutionFullname = tbInstitutionFullname.Text.Trim();
        string l_DepartmentFullname = tbDepartmentFullname.Text.Trim();
        string l_DivisionFullname = tbDivisionFullname.Text.Trim();
        string l_Comments = tbComments.Text.Trim();

        if (string.IsNullOrEmpty(l_PasswordAnswer))
        {
            l_isValid = false;
            tbPasswordAnswer.Focus();
        }

        if (string.IsNullOrEmpty(l_PasswordQuestion))
        {
            l_isValid = false;
            tbPasswordQuestion.Focus();
        }

        if (string.IsNullOrEmpty(l_EmailAddr))
        {
            l_isValid = false;
            tbEmail.Focus();
        }
        else
        {
            if (!Regex.IsMatch(l_EmailAddr, @"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"))
            {
                l_isValid = false;
                lInvalidEmail.Visible = true;
                lInvalidEmail.Text = "Incorrect format";
                tbEmail.Focus();
            }
        }

        if (IsNewUser)
        {
            if (string.IsNullOrEmpty(l_Password))
            {
                l_isValid = false;
                tbPassword.Focus();
            }
            else
            {
                if (l_Password != tbConfirmPassword.Text.Trim())
                {
                    l_isValid = false;
                    lInvalidPassword.Visible = true;
                    tbPassword.Focus();
                }
            }
        }

        if (string.IsNullOrEmpty(l_Login))
        {
            l_isValid = false;
            tbLogin.Focus();
        }

        if (string.IsNullOrEmpty(l_LastName))
        {
            l_isValid = false;
            tbLastName.Focus();
        }

        if (string.IsNullOrEmpty(l_FirstName))
        {
            l_isValid = false;
            tbFirstName.Focus();
        }

        if (!l_isValid) return;


        ProfilesMembershipUser l_CheckUser = new ProfilesDBMembershipProviderBL().GetUser(l_Login, false);

        if (l_CheckUser != null)
        {
            if (l_CheckUser.UserID != UserID)
            {
                l_isValid = false;
                lInvalidLogin.Visible = true;
                tbLogin.Focus();
            }
        }
        if (!l_isValid) return;



        try
        {
            MembershipUser l_updatedUser;
            ProfilesDBMembershipProvider customMembership = (ProfilesDBMembershipProvider)Membership.Provider;
            if (IsNewUser)
            {

                l_updatedUser = customMembership.CreateUser(l_Login,
                                             l_FirstName, l_LastName, l_EmailAddr,
                                             l_OfficePhone, l_InstitutionFullname,
                                             l_DepartmentFullname, l_DivisionFullname,
                                             customMembership.EncodePassword(l_Password), GlobalConst.PasswordFormat,
                                             l_PasswordQuestion, l_PasswordAnswer,
                                             GlobalConst.ApplicationName, l_Comments, true);
            }
            else
            {
                l_updatedUser = customMembership.UpdateUser(UserID.Value, l_Login,
                                                            l_FirstName, l_LastName, l_EmailAddr,
                                                            l_OfficePhone, l_InstitutionFullname,
                                                            l_DepartmentFullname, l_DivisionFullname,
                                                            customMembership.EncodePassword(l_Password),
                                                            GlobalConst.PasswordFormat,
                                                            l_PasswordQuestion, l_PasswordAnswer,
                                                            GlobalConst.ApplicationName, l_Comments, true);

                if (l_updatedUser != null)
                {
                    string[] userRolesNames = Roles.GetRolesForUser(l_Login);
                    if (userRolesNames != null && userRolesNames.Length > 0)
                        Roles.RemoveUserFromRoles(l_Login, userRolesNames);
                }
            }

            if (l_updatedUser != null)
            {
                foreach (ListItem l_Item in cblRoles.Items)
                {
                    if (l_Item.Selected)
                    {
                        Roles.AddUserToRole(l_updatedUser.UserName, l_Item.Value);
                    }
                }
            }

            RefreshCache();


            if (l_updatedUser != null)
                UserID = ((ProfilesMembershipUser) l_updatedUser).UserID;

 
            string l_redirectUrl = string.Format("{0}", ResolveUrl("AllUsers.aspx"));
            if (PageSize.HasValue) l_redirectUrl += string.Format("?PageSize={0}", PageSize.Value);
            else l_redirectUrl += string.Format("?PageSize=empty");

            if (UserID != null)
                l_redirectUrl += string.Format("&ShowUser={0}", UserID.Value);

            Response.Redirect(l_redirectUrl);
        }
        catch (Exception ex)
        {
            //ExceptionPolicy.HandleException(ex, GlobalConst.LogOnlyPolicy);
            lGeneralError.Visible = true;
            lGeneralError.Text = ex.Message;
        }
    }

    private void RefreshCache()
    {
        if (Cache[GlobalConst.CacheKeyDependency] != null)
        {
            Cache.Remove(GlobalConst.CacheKeyDependency);
        }
    }

    private void HideContent(string p_Message)
    {
        phContent.Visible = false;
        phMainError.Visible = true;
        lbMainError.Text = p_Message;
    }
}
